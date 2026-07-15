import axios from 'axios'
import type { AxiosError, InternalAxiosRequestConfig } from 'axios'
import { tokenStorage } from './tokenStorage'
import { currentLang } from '@/shared/lib/i18n'
import type { AuthResponse, ProblemDetails, ValidationProblemDetails } from './types'

/** Vite proxies /api → http://localhost:5080 in dev. */
export const api = axios.create({
  baseURL: '/api',
  headers: { 'Content-Type': 'application/json' },
})

// ── Request: attach Bearer + current language ───────────────────
api.interceptors.request.use((config) => {
  const token = tokenStorage.getAccess()
  if (token) config.headers.Authorization = `Bearer ${token}`
  config.headers['Accept-Language'] = currentLang()
  return config
})

// ── Response: transparent refresh on 401 ────────────────────────
type RetryConfig = InternalAxiosRequestConfig & { _retry?: boolean }

// Callback the auth store registers so it can react to a forced logout.
let onAuthCleared: (() => void) | null = null
export function setOnAuthCleared(cb: (() => void) | null) {
  onAuthCleared = cb
}

// Single-flight refresh: concurrent 401s share one refresh call.
let refreshPromise: Promise<string> | null = null

async function refreshAccessToken(): Promise<string> {
  const refreshToken = tokenStorage.getRefresh()
  if (!refreshToken) throw new Error('No refresh token')

  // Bare axios (not `api`) to avoid recursive interceptors.
  const { data } = await axios.post<AuthResponse>('/api/auth/refresh', { refreshToken })
  tokenStorage.setAccess(data.accessToken)
  tokenStorage.setRefresh(data.refreshToken) // rotating: store the new one
  return data.accessToken
}

api.interceptors.response.use(
  (res) => res,
  async (error: AxiosError) => {
    const original = error.config as RetryConfig | undefined
    const status = error.response?.status

    // Only attempt refresh for a 401 on a non-refresh request we haven't retried.
    const isRefreshCall = original?.url?.includes('/auth/refresh')
    if (status === 401 && original && !original._retry && !isRefreshCall && tokenStorage.getRefresh()) {
      original._retry = true
      try {
        refreshPromise ??= refreshAccessToken().finally(() => {
          refreshPromise = null
        })
        const newToken = await refreshPromise
        original.headers.Authorization = `Bearer ${newToken}`
        return api(original)
      } catch {
        tokenStorage.clear()
        onAuthCleared?.()
      }
    }

    return Promise.reject(error)
  },
)

// ── Error helpers ───────────────────────────────────────────────
export function isProblemDetails(x: unknown): x is ProblemDetails {
  return typeof x === 'object' && x !== null && 'status' in x && 'title' in x
}

export function isValidationProblem(x: unknown): x is ValidationProblemDetails {
  return isProblemDetails(x) && 'errors' in x && typeof (x as ValidationProblemDetails).errors === 'object'
}

/** Extract a human-readable message from any axios/API error. */
export function getErrorMessage(error: unknown, fallback = 'Something went wrong'): string {
  if (axios.isAxiosError(error)) {
    const data = error.response?.data
    if (isProblemDetails(data)) return data.title
    if (error.message) return error.message
  }
  return fallback
}

/** Map a ValidationProblemDetails `errors` dict (PascalCase keys) to lowercased field keys. */
export function getFieldErrors(error: unknown): Record<string, string> {
  const out: Record<string, string> = {}
  if (axios.isAxiosError(error) && isValidationProblem(error.response?.data)) {
    for (const [key, msgs] of Object.entries(error.response.data.errors)) {
      out[key.charAt(0).toLowerCase() + key.slice(1)] = msgs[0]
    }
  }
  return out
}
