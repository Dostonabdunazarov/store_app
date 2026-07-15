import { useEffect, type ReactNode } from 'react'
import { QueryClientProvider } from '@tanstack/react-query'
import { queryClient } from '@/shared/api/queryClient'
import { useAuthStore } from '@/shared/store/auth.store'
import '@/shared/lib/i18n' // side-effect: initialize i18next

/** Wraps the app with data + session providers and runs the auth bootstrap once. */
export function AppProviders({ children }: { children: ReactNode }) {
  const bootstrap = useAuthStore((s) => s.bootstrap)

  useEffect(() => {
    void bootstrap()
  }, [bootstrap])

  return <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>
}
