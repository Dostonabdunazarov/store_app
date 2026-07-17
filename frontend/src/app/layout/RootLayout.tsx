import { Outlet } from 'react-router-dom'
import { Navbar } from './Navbar'
import { Footer } from './Footer'
import { useFavoritesSync } from '@/features/favorites/favoriteHooks'

/** App shell: sticky navbar, routed page content, footer. */
export function RootLayout() {
  useFavoritesSync() // push guest favorites to the server once, on sign-in

  return (
    <div className="flex min-h-screen flex-col overflow-x-hidden text-fg">
      <Navbar />
      <main className="flex-1">
        <Outlet />
      </main>
      <Footer />
    </div>
  )
}
