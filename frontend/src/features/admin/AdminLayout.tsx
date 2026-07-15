import { NavLink, Outlet } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { LayoutDashboard, Layers, type LucideIcon, Package, Tags } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { paths } from '@/app/routes/paths'
import { cn } from '@/shared/lib/cn'

const items: { to: string; key: string; Icon: LucideIcon; end: boolean }[] = [
  { to: paths.admin, key: 'admin.dashboard', Icon: LayoutDashboard, end: true },
  { to: paths.adminOrders, key: 'admin.orders', Icon: Package, end: false },
  { to: paths.adminProducts, key: 'admin.products', Icon: Tags, end: false },
  { to: paths.adminCatalog, key: 'admin.catalog', Icon: Layers, end: false },
]

export function AdminLayout() {
  const { t } = useTranslation()

  return (
    <Container className="py-8">
      <h1 className="mb-6 text-2xl font-bold tracking-tight">{t('admin.title')}</h1>
      <div className="flex flex-col gap-6 lg:flex-row">
        <aside className="lg:w-56 lg:shrink-0">
          <nav className="flex gap-1 overflow-x-auto lg:flex-col lg:overflow-visible">
            {items.map((it) => (
              <NavLink
                key={it.to}
                to={it.to}
                end={it.end}
                className={({ isActive }) =>
                  cn(
                    'flex items-center gap-2.5 whitespace-nowrap rounded-lg px-3.5 py-2.5 text-sm font-medium transition-colors',
                    isActive
                      ? 'bg-primary text-primary-fg shadow-card'
                      : 'text-fg-muted hover:bg-surface-2 hover:text-fg',
                  )
                }
              >
                <it.Icon className="h-4 w-4" strokeWidth={2} />
                {t(it.key)}
              </NavLink>
            ))}
          </nav>
        </aside>

        <main className="min-w-0 flex-1">
          <Outlet />
        </main>
      </div>
    </Container>
  )
}
