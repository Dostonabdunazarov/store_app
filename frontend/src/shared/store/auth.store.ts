import { create } from 'zustand'
import { tokenStorage } from '@/shared/api/tokenStorage'
import { setOnAuthCleared } from '@/shared/api/client'
import { authApi } from '@/shared/api/endpoints'
import { UserRole } from '@/shared/api/types'
import type { AuthResponse, LoginRequest, RegisterRequest, UserDto } from '@/shared/api/types'

interface AuthState {
  user: UserDto | null
  /** True until the initial session bootstrap (refresh + /me) resolves. */
  initializing: boolean
  isAuthenticated: boolean
  isAdmin: boolean

  login: (body: LoginRequest) => Promise<void>
  register: (body: RegisterRequest) => Promise<void>
  logout: () => void
  /** Called once on app start: restores a session from a persisted refresh token. */
  bootstrap: () => Promise<void>
}

function applyAuth(set: (partial: Partial<AuthState>) => void, res: AuthResponse) {
  tokenStorage.setAccess(res.accessToken)
  tokenStorage.setRefresh(res.refreshToken)
  set({
    user: res.user,
    isAuthenticated: true,
    isAdmin: res.user.role === UserRole.Admin,
  })
}

export const useAuthStore = create<AuthState>((set) => {
  // If the interceptor gives up on refreshing, drop the user.
  setOnAuthCleared(() => {
    set({ user: null, isAuthenticated: false, isAdmin: false })
  })

  return {
    user: null,
    initializing: true,
    isAuthenticated: false,
    isAdmin: false,

    login: async (body) => {
      const res = await authApi.login(body)
      applyAuth(set, res)
    },

    register: async (body) => {
      const res = await authApi.register(body)
      applyAuth(set, res)
    },

    logout: () => {
      tokenStorage.clear()
      set({ user: null, isAuthenticated: false, isAdmin: false })
    },

    bootstrap: async () => {
      if (!tokenStorage.getRefresh()) {
        set({ initializing: false })
        return
      }
      try {
        // No access token yet after reload → /me 401 triggers the refresh
        // interceptor, which mints a fresh access token and retries.
        const user = await authApi.me()
        set({
          user,
          isAuthenticated: true,
          isAdmin: user.role === UserRole.Admin,
        })
      } catch {
        tokenStorage.clear()
      } finally {
        set({ initializing: false })
      }
    },
  }
})

// re-export for convenience at call sites
export { UserRole }
export type { UserDto }
