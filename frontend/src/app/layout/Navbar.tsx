import { useState } from 'react'
import { Link, NavLink, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useQueryClient } from '@tanstack/react-query'
import {
  ChevronDown,
  GitCompareArrows,
  Heart,
  Info,
  LayoutGrid,
  LogOut,
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
    'inline-flex shrink-0 items-center gap-2 whitespace-nowrap text-sm font-medium transition-colors hover:text-fg',
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
      <NavLink to={paths.cart} className={linkClass} onClick={() => setMobileOpen(false)}>
        <ShoppingCart className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.cart')}
        {countBadge(cartCount)}
      </NavLink>
      <NavLink to={paths.about} className={linkClass} onClick={() => setMobileOpen(false)}>
        <Info className="h-4.5 w-4.5" strokeWidth={2} />
        {t('nav.about')}
      </NavLink>
    </>
  )

  return (
    <header className="sticky top-0 z-40 px-3 pt-3 sm:px-4 sm:pt-4">
      <div className="glass-strong relative mx-auto flex h-16 w-full max-w-7xl items-center gap-4 rounded-2xl border px-4 shadow-elevated sm:px-6 lg:px-8">
        <Link to={paths.home} className="flex shrink-0 items-center gap-2 font-bold tracking-tight">
          <img src="/favicon.svg" alt="" aria-hidden className="h-7 w-auto shrink-0" />
          <span className="bg-linear-to-r from-teal-500 to-emerald-700 bg-clip-text text-xl text-transparent">
            {t('common.appName')}
          </span>
        </Link>

        {/* Desktop nav — flows between logo and actions, centered, so it can
            never overlap them no matter how many links are shown. */}
        <nav className="hidden min-w-0 flex-1 items-center justify-center gap-4 md:flex lg:gap-5">
          {navLinks}
        </nav>

        <div className="flex shrink-0 items-center gap-2">
          <LangSwitcher onChange={() => queryClient.invalidateQueries()} />

          {isAuthenticated ? (
            <div className="hidden items-center gap-1 sm:flex">
              {/* User name — hovering reveals the account dropdown (admin link).
                  The whole thing is still just a label when there's nothing to show. */}
              <div className="group relative">
                <span className="inline-flex cursor-default items-center gap-1 rounded-lg px-2 py-1.5 text-sm text-fg-muted transition-colors group-hover:text-fg">
                  <span className="max-w-[12ch] truncate">{user?.fullName}</span>
                  {isAdmin && (
                    <ChevronDown
                      className="h-4 w-4 transition-transform group-hover:rotate-180"
                      strokeWidth={2}
                    />
                  )}
                </span>
                {isAdmin && (
                  // Dropdown: hidden until the group is hovered/focused. The pt-2
                  // keeps a hover bridge so the menu doesn't flicker on the gap.
                  <div className="invisible absolute right-0 top-full pt-2 opacity-0 transition-opacity group-focus-within:visible group-focus-within:opacity-100 group-hover:visible group-hover:opacity-100">
                    <div className="glass-strong min-w-44 overflow-hidden rounded-xl border py-1 shadow-elevated">
                      <Link
                        to={paths.admin}
                        className="flex items-center gap-2 px-3 py-2 text-sm text-fg-muted transition-colors hover:bg-surface-2 hover:text-fg"
                      >
                        <Shield className="h-4 w-4" strokeWidth={2} />
                        {t('nav.admin')}
                      </Link>
                    </div>
                  </div>
                )}
              </div>

              {/* Compact logout icon button */}
              <Button
                variant="ghost"
                size="icon"
                onClick={handleLogout}
                aria-label={t('nav.logout')}
                title={t('nav.logout')}
              >
                <LogOut className="h-5 w-5" strokeWidth={2} />
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
        <div className="glass-strong mx-auto mt-2 w-full max-w-7xl rounded-2xl border shadow-elevated md:hidden">
          <nav className="flex w-full flex-col gap-4 px-4 py-4">
            {navLinks}
            {isAdmin && (
              <NavLink to={paths.admin} className={linkClass} onClick={() => setMobileOpen(false)}>
                <Shield className="h-4.5 w-4.5" strokeWidth={2} />
                {t('nav.admin')}
              </NavLink>
            )}
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
