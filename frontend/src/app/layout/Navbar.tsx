import { useState } from 'react'
import { Link, NavLink, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useQueryClient } from '@tanstack/react-query'
import {
  GitCompareArrows,
  Heart,
  LayoutGrid,
  Menu,
  Package,
  Shield,
  ShoppingCart,
  X,
} from 'lucide-react'
import { useAuthStore } from '@/shared/store/auth.store'
import { useCartStore, selectCartCount } from '@/shared/store/cart.store'
import { useCompareStore, selectCompareCount } from '@/shared/store/compare.store'
import { paths } from '@/app/routes/paths'
import { Button } from '@/shared/ui/Button'
import { LangSwitcher } from '@/shared/ui/LangSwitcher'
import { cn } from '@/shared/lib/cn'

const linkClass = ({ isActive }: { isActive: boolean }) =>
  cn(
    'inline-flex items-center gap-2 text-sm font-medium transition-colors hover:text-fg',
    isActive ? 'text-fg' : 'text-fg-muted',
  )

const countBadge = (n: number) =>
  n > 0 && (
    <span className="inline-flex h-5 min-w-5 items-center justify-center rounded-full bg-primary px-1 text-xs font-semibold text-primary-fg">
      {n}
    </span>
  )

export function Navbar() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const queryClient = useQueryClient()
  const [mobileOpen, setMobileOpen] = useState(false)

  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const isAdmin = useAuthStore((s) => s.isAdmin)
  const user = useAuthStore((s) => s.user)
  const logout = useAuthStore((s) => s.logout)
  const cartCount = useCartStore(selectCartCount)
  const compareCount = useCompareStore(selectCompareCount)

  const handleLogout = () => {
    logout()
    navigate(paths.home)
  }

  const navLinks = (
    <>
      <NavLink to={paths.catalog} className={linkClass} onClick={() => setMobileOpen(false)}>
        <LayoutGrid className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.catalog')}
      </NavLink>
      <NavLink to={paths.cart} className={linkClass} onClick={() => setMobileOpen(false)}>
        <ShoppingCart className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.cart')}
        {countBadge(cartCount)}
      </NavLink>
      <NavLink to={paths.favorites} className={linkClass} onClick={() => setMobileOpen(false)}>
        <Heart className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.favorites')}
      </NavLink>
      <NavLink to={paths.compare} className={linkClass} onClick={() => setMobileOpen(false)}>
        <GitCompareArrows className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.compare')}
        {countBadge(compareCount)}
      </NavLink>
      {isAuthenticated && (
        <NavLink to={paths.orders} className={linkClass} onClick={() => setMobileOpen(false)}>
          <Package className="h-4.5 w-4.5" strokeWidth={2} />
          {t('nav.orders')}
        </NavLink>
      )}
      {isAdmin && (
        <NavLink to={paths.admin} className={linkClass} onClick={() => setMobileOpen(false)}>
          <Shield className="h-4.5 w-4.5" strokeWidth={2} />
          {t('nav.admin')}
        </NavLink>
      )}
    </>
  )

  return (
    <header className="glass-strong sticky top-0 z-40 border-b">
      <div className="relative mx-auto flex h-16 w-full max-w-7xl items-center gap-6 px-4 sm:px-6 lg:px-8">
        <Link to={paths.home} className="flex items-center gap-2 font-bold tracking-tight">
          <span className="bg-linear-to-r from-teal-500 to-emerald-700 bg-clip-text text-xl text-transparent">
            {t('common.appName')}
          </span>
        </Link>

        {/* Desktop nav — icon + label items */}
        <nav className="hidden items-center gap-5 md:flex lg:gap-6">
          {navLinks}
        </nav>

        <div className="ml-auto flex items-center gap-2">
          <LangSwitcher onChange={() => queryClient.invalidateQueries()} />

          {isAuthenticated ? (
            <div className="hidden items-center gap-2 sm:flex">
              <span className="max-w-[10ch] truncate text-sm text-fg-muted">{user?.fullName}</span>
              <Button variant="outline" size="sm" onClick={handleLogout}>
                {t('nav.logout')}
              </Button>
            </div>
          ) : (
            <Link to={paths.login} className="hidden sm:block">
              <Button size="sm">{t('nav.login')}</Button>
            </Link>
          )}

          {/* Mobile hamburger */}
          <Button
            variant="ghost"
            size="icon"
            className="md:hidden"
            aria-label="menu"
            aria-expanded={mobileOpen}
            onClick={() => setMobileOpen((v) => !v)}
          >
            {mobileOpen ? (
              <X className="h-5 w-5" strokeWidth={2} />
            ) : (
              <Menu className="h-5 w-5" strokeWidth={2} />
            )}
          </Button>
        </div>
      </div>

      {/* Mobile drawer */}
      {mobileOpen && (
        <div className="glass-strong border-t md:hidden">
          <nav className="mx-auto flex w-full max-w-7xl flex-col gap-4 px-4 py-4">
            {navLinks}
            <div className="flex items-center gap-2 pt-2">
              {isAuthenticated ? (
                <Button variant="outline" size="sm" onClick={handleLogout} className="w-full">
                  {t('nav.logout')}
                </Button>
              ) : (
                <>
                  <Link to={paths.login} className="flex-1" onClick={() => setMobileOpen(false)}>
                    <Button size="sm" className="w-full">{t('nav.login')}</Button>
                  </Link>
                  <Link to={paths.register} className="flex-1" onClick={() => setMobileOpen(false)}>
                    <Button variant="outline" size="sm" className="w-full">{t('nav.register')}</Button>
                  </Link>
                </>
              )}
            </div>
          </nav>
        </div>
      )}
    </header>
  )
}
