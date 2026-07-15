/**
 * Framework-free token storage. The axios interceptor and the auth store both
 * read/write here so there is a single source of truth outside React.
 * Access token lives only in memory (short-lived, 15 min); refresh token is
 * persisted so a page reload can re-establish the session.
 */
const REFRESH_KEY = 'hypex-refresh'

let accessToken: string | null = null

export const tokenStorage = {
  getAccess: () => accessToken,
  setAccess: (token: string | null) => {
    accessToken = token
  },

  getRefresh: () => localStorage.getItem(REFRESH_KEY),
  setRefresh: (token: string | null) => {
    if (token) localStorage.setItem(REFRESH_KEY, token)
    else localStorage.removeItem(REFRESH_KEY)
  },

  clear: () => {
    accessToken = null
    localStorage.removeItem(REFRESH_KEY)
  },
}
