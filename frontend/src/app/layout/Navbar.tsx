import { useEffect, useRef, useState } from 'react'
import { Link, NavLink, useLocation, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useQueryClient } from '@tanstack/react-query'
import { AnimatePresence, motion } from 'motion/react'
import {
  GitCompareArrows,
  Heart,
  KeyRound,
  LogIn,
  LogOut,
  Menu,
  Package,
  Search,
  Shield,
  ShoppingBag,
  User,
  UserPlus,
  X,
} from 'lucide-react'
import { useAuthStore } from '@/shared/store/auth.store'
import { useCartStore, selectCartCount } from '@/shared/store/cart.store'
import { useCompareStore, selectCompareCount } from '@/shared/store/compare.store'
import { paths } from '@/app/routes/paths'
import { LangSwitcher } from '@/shared/ui/LangSwitcher'
import { HeaderSearch } from '@/shared/ui/HeaderSearch'
import { cn } from '@/shared/lib/cn'

const dealsHref = `${paths.catalog}?onSale=true&sort=discount`

const iconBase =
  'relative h-9 w-9 shrink-0 items-center justify-center rounded-full text-fg/85 transition-colors hover:bg-white/[0.08] hover:text-fg'

const iconBtn = `${iconBase} inline-flex`

const iconBtnSm = `${iconBase} hidden sm:inline-flex`

const menuItem =
  'flex w-full items-center gap-2.5 rounded-xl px-3 py-2 text-sm text-fg-muted transition-colors hover:bg-white/[0.06] hover:text-fg'

function CountDot({ n }: { n: number }) {
  if (n <= 0) return null
  return (
    <span className="absolute -right-0.5 -top-0.5 inline-flex h-4.5 min-w-4.5 items-center justify-center rounded-full bg-fg px-1 text-[10px] font-semibold text-bg">
      {n}
    </span>
  )
}

export function Navbar() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const location = useLocation()
  const queryClient = useQueryClient()
  const [mobileOpen, setMobileOpen] = useState(false)
  const [searchOpen, setSearchOpen] = useState(false)
  const [userOpen, setUserOpen] = useState(false)
  const userRef = useRef<HTMLDivElement>(null)

  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const isAdmin = useAuthStore((s) => s.isAdmin)
  const user = useAuthStore((s) => s.user)
  const logout = useAuthStore((s) => s.logout)
  const cartCount = useCartStore(selectCartCount)
  const compareCount = useCompareStore(selectCompareCount)

  useEffect(() => {
    setMobileOpen(false)
    setSearchOpen(false)
    setUserOpen(false)
  }, [location.pathname, location.search])

  useEffect(() => {
    if (!userOpen) return
    const onDown = (e: MouseEvent) => {
      if (userRef.current && !userRef.current.contains(e.target as Node)) setUserOpen(false)
    }
    const onKey = (e: KeyboardEvent) => e.key === 'Escape' && setUserOpen(false)
    document.addEventListener('mousedown', onDown)
    document.addEventListener('keydown', onKey)
    return () => {
      document.removeEventListener('mousedown', onDown)
      document.removeEventListener('keydown', onKey)
    }
  }, [userOpen])

  const handleLogout = () => {
    logout()
    setUserOpen(false)
    navigate(paths.home)
  }

  const isDeals = location.pathname === paths.catalog && location.search.includes('onSale=true')

  const isNew = location.pathname === paths.catalog && location.search.includes('sort=newest')

  const links = [
    { to: paths.catalog, label: t('nav.catalog'), active: location.pathname === paths.catalog && !isDeals && !isNew },
    { to: dealsHref, label: t('nav.deals'), active: isDeals },
    { to: `${paths.catalog}?sort=newest`, label: t('nav.new'), active: isNew },
    { to: paths.about, label: t('nav.about'), active: location.pathname === paths.about },
  ]

  return (
    <header
      className={cn(
        'sticky top-0 z-40 bg-black',
      )}
    >
      <div className="relative mx-auto flex h-14 w-full max-w-[max(80rem,70%)] items-center gap-4 px-4 sm:px-6 lg:h-16 lg:px-8">
        <Link
          to={paths.home}
          className="flex shrink-0 items-center font-display text-base font-medium uppercase tracking-[0.2em] whitespace-nowrap text-fg sm:text-lg"
        >
          {t('common.appName')}
        </Link>

        <nav className="absolute left-1/2 hidden -translate-x-1/2 items-center gap-1 rounded-full p-1 md:flex">
          {links.map((l) => (
            <Link
              key={l.label}
              to={l.to}
              className={cn(
                'relative rounded-full px-4 py-1.5 text-sm transition-colors hover:text-fg',
                l.active ? 'text-fg' : 'text-fg/70',
              )}
            >
              {l.active && (
                <motion.span
                  layoutId="nav-pill"
                  transition={{ type: 'spring', stiffness: 380, damping: 32 }}
                  className="absolute inset-0 rounded-full bg-white/[0.1]"
                />
              )}
              <span className="relative">{l.label}</span>
            </Link>
          ))}
        </nav>

        <div className="ml-auto flex shrink-0 items-center gap-0.5 sm:gap-1">
          <button
            type="button"
            className={iconBtn}
            aria-label={t('common.search')}
            aria-expanded={searchOpen}
            onClick={() => setSearchOpen((v) => !v)}
          >
            {searchOpen ? <X className="h-4.5 w-4.5" strokeWidth={1.75} /> : <Search className="h-4.5 w-4.5" strokeWidth={1.75} />}
          </button>

          <NavLink to={paths.favorites} className={iconBtnSm} aria-label={t('nav.favorites')} title={t('nav.favorites')}>
            <Heart className="h-4.5 w-4.5" strokeWidth={1.75} />
          </NavLink>

          <NavLink to={paths.compare} className={iconBtnSm} aria-label={t('nav.compare')} title={t('nav.compare')}>
            <GitCompareArrows className="h-4.5 w-4.5" strokeWidth={1.75} />
            <CountDot n={compareCount} />
          </NavLink>

          <NavLink to={paths.cart} className={iconBtn} aria-label={t('nav.cart')} title={t('nav.cart')}>
            <ShoppingBag className="h-4.5 w-4.5" strokeWidth={1.75} />
            <CountDot n={cartCount} />
          </NavLink>

          <div className="hidden sm:block">
            <LangSwitcher onChange={() => queryClient.invalidateQueries()} />
          </div>

          <div ref={userRef} className="relative hidden sm:block">
            <button
              type="button"
              onClick={() => setUserOpen((v) => !v)}
              aria-haspopup="menu"
              aria-expanded={userOpen}
              aria-label={t('nav.account')}
              title={isAuthenticated ? user?.fullName : t('nav.account')}
              className="ml-1 inline-flex h-8 w-8 items-center justify-center rounded-full bg-white/[0.08] text-fg ring-1 ring-white/15 transition-colors hover:bg-white/15"
            >
              {isAuthenticated && user?.fullName ? (
                <span className="text-[11px] font-semibold uppercase">{user.fullName.trim().charAt(0)}</span>
              ) : (
                <User className="h-3.5 w-3.5" strokeWidth={2} />
              )}
            </button>

            <AnimatePresence>
              {userOpen && (
                <motion.div
                  role="menu"
                  initial={{ opacity: 0, y: -6 }}
                  animate={{ opacity: 1, y: 0 }}
                  exit={{ opacity: 0, y: -6 }}
                  transition={{ duration: 0.18 }}
                  className="glass-strong absolute right-0 top-full mt-3 w-56 rounded-2xl border p-1.5 shadow-elevated"
                >
                  {isAuthenticated ? (
                    <>
                      <div className="px-3 pb-2 pt-1.5">
                        <div className="truncate text-sm font-medium text-fg">{user?.fullName}</div>
                        <div className="truncate text-xs text-fg-subtle">{user?.email}</div>
                      </div>
                      <div className="my-1 h-px bg-white/[0.08]" />
                      <Link to={paths.orders} className={menuItem}>
                        <Package className="h-4 w-4" strokeWidth={1.75} />
                        {t('nav.orders')}
                      </Link>
                      <Link to={paths.changePassword} className={menuItem}>
                        <KeyRound className="h-4 w-4" strokeWidth={1.75} />
                        {t('nav.changePassword')}
                      </Link>
                      {isAdmin && (
                        <Link to={paths.admin} className={menuItem}>
                          <Shield className="h-4 w-4" strokeWidth={1.75} />
                          {t('nav.admin')}
                        </Link>
                      )}
                      <div className="my-1 h-px bg-white/[0.08]" />
                      <button type="button" onClick={handleLogout} className={menuItem}>
                        <LogOut className="h-4 w-4" strokeWidth={1.75} />
                        {t('nav.logout')}
                      </button>
                    </>
                  ) : (
                    <>
                      <Link to={paths.login} className={menuItem}>
                        <LogIn className="h-4 w-4" strokeWidth={1.75} />
                        {t('nav.login')}
                      </Link>
                      <Link to={paths.register} className={menuItem}>
                        <UserPlus className="h-4 w-4" strokeWidth={1.75} />
                        {t('nav.register')}
                      </Link>
                    </>
                  )}
                </motion.div>
              )}
            </AnimatePresence>
          </div>

          <button
            type="button"
            className={`${iconBase} inline-flex md:hidden`}
            aria-label="menu"
            aria-expanded={mobileOpen}
            onClick={() => setMobileOpen((v) => !v)}
          >
            {mobileOpen ? <X className="h-4.5 w-4.5" strokeWidth={1.75} /> : <Menu className="h-4.5 w-4.5" strokeWidth={1.75} />}
          </button>
        </div>
      </div>

      <AnimatePresence>
        {searchOpen && (
          <motion.div
            initial={{ opacity: 0, height: 0 }}
            animate={{ opacity: 1, height: 'auto' }}
            exit={{ opacity: 0, height: 0 }}
            transition={{ duration: 0.25 }}
            className="overflow-visible"
          >
            <div className="mx-auto w-full max-w-3xl px-4 pb-5 sm:px-6">
              <HeaderSearch />
            </div>
          </motion.div>
        )}
      </AnimatePresence>

      {mobileOpen && (
        <div className="mx-auto w-full max-w-[max(80rem,70%)] md:hidden">
          <nav className="flex w-full flex-col gap-1 px-4 py-4">
            {links.map((l) => (
              <Link key={l.label} to={l.to} className={cn(menuItem, 'text-base', l.active && 'text-fg')}>
                {l.label}
              </Link>
            ))}
            <Link to={paths.favorites} className={cn(menuItem, 'text-base')}>
              <Heart className="h-4.5 w-4.5" strokeWidth={1.75} />
              {t('nav.favorites')}
            </Link>
            <Link to={paths.compare} className={cn(menuItem, 'text-base')}>
              <GitCompareArrows className="h-4.5 w-4.5" strokeWidth={1.75} />
              {t('nav.compare')}
            </Link>
            {isAuthenticated && (
              <>
                <Link to={paths.orders} className={cn(menuItem, 'text-base')}>
                  <Package className="h-4.5 w-4.5" strokeWidth={1.75} />
                  {t('nav.orders')}
                </Link>
                <Link to={paths.changePassword} className={cn(menuItem, 'text-base')}>
                  <KeyRound className="h-4.5 w-4.5" strokeWidth={1.75} />
                  {t('nav.changePassword')}
                </Link>
              </>
            )}
            {isAdmin && (
              <Link to={paths.admin} className={cn(menuItem, 'text-base')}>
                <Shield className="h-4.5 w-4.5" strokeWidth={1.75} />
                {t('nav.admin')}
              </Link>
            )}
            <div className="mt-3 flex items-center gap-2 pt-4">
              <LangSwitcher onChange={() => queryClient.invalidateQueries()} />
              {isAuthenticated ? (
                <button
                  type="button"
                  onClick={handleLogout}
                  className="ml-auto inline-flex h-10 items-center gap-2 rounded-full border border-white/20 px-5 text-sm"
                >
                  <LogOut className="h-4 w-4" strokeWidth={1.75} />
                  {t('nav.logout')}
                </button>
              ) : (
                <div className="ml-auto flex gap-2">
                  <Link to={paths.login} className="inline-flex h-10 items-center rounded-full bg-fg px-5 text-sm font-medium text-bg">
                    {t('nav.login')}
                  </Link>
                  <Link to={paths.register} className="inline-flex h-10 items-center rounded-full border border-white/20 px-5 text-sm">
                    {t('nav.register')}
                  </Link>
                </div>
              )}
            </div>
          </nav>
        </div>
      )}
    </header>
  )
}
