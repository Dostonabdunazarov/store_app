import { Navigate, Outlet, useLocation } from 'react-router-dom'
import { useAuthStore } from '@/shared/store/auth.store'
import { paths } from './paths'
import { PageSpinner } from '@/shared/ui/PageSpinner'

/** Gate for authenticated routes. `adminOnly` additionally requires the Admin role. */
export function ProtectedRoute({ adminOnly = false }: { adminOnly?: boolean }) {
  const location = useLocation()
  const initializing = useAuthStore((s) => s.initializing)
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const isAdmin = useAuthStore((s) => s.isAdmin)

  // Wait for session bootstrap before deciding — avoids a flash-redirect on reload.
  if (initializing) return <PageSpinner />

  if (!isAuthenticated) {
    return <Navigate to={paths.login} replace state={{ from: location }} />
  }

  if (adminOnly && !isAdmin) {
    return <Navigate to={paths.home} replace />
  }

  return <Outlet />
}
