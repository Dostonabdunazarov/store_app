import { useMemo } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { Card, CardBody } from '@/shared/ui/Card'
import { Skeleton } from '@/shared/ui/Skeleton'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { OrderStatus } from '@/shared/api/types'
import { OrderStatusBadge } from '@/features/orders/OrderStatusBadge'
import { formatDate } from '@/shared/lib/format'
import { useAdminOrders, useAdminProducts } from './adminHooks'

const REVENUE_STATUSES: OrderStatus[] = [
  OrderStatus.Confirmed,
  OrderStatus.Shipped,
  OrderStatus.Delivered,
]

export function DashboardPage() {
  const { t } = useTranslation()
  const currency = t('common.currency')
  const orders = useAdminOrders()
  const products = useAdminProducts()

  const stats = useMemo(() => {
    const os = orders.data ?? []
    const ps = products.data ?? []
    const revenue = os
      .filter((o) => REVENUE_STATUSES.includes(o.status))
      .reduce((sum, o) => sum + o.totalAmount, 0)
    const pending = os.filter((o) => o.status === OrderStatus.Pending).length
    const active = ps.filter((p) => p.isActive).length
    const outOfStock = ps.filter((p) => p.isActive && p.stock === 0).length
    return { totalOrders: os.length, revenue, pending, active, outOfStock, recent: os.slice(0, 6) }
  }, [orders.data, products.data])

  if (orders.isLoading || products.isLoading) {
    return (
      <div className="space-y-6">
        <div className="grid grid-cols-2 gap-4 lg:grid-cols-4">
          {Array.from({ length: 4 }).map((_, i) => (
            <Card key={i}>
              <CardBody className="space-y-2">
                <Skeleton className="h-3 w-20" />
                <Skeleton className="h-7 w-24" />
              </CardBody>
            </Card>
          ))}
        </div>
        <Skeleton className="h-64 w-full rounded-lg" />
      </div>
    )
  }

  const tiles = [
    { label: t('admin.statOrders'), value: String(stats.totalOrders), accent: 'text-fg' },
    { label: t('admin.statRevenue'), value: formatPrice(stats.revenue, currency), accent: 'text-success' },
    { label: t('admin.statPending'), value: String(stats.pending), accent: 'text-warning' },
    { label: t('admin.statProducts'), value: String(stats.active), accent: 'text-fg' },
  ]

  return (
    <div className="space-y-6">
      <div className="grid grid-cols-2 gap-4 lg:grid-cols-4">
        {tiles.map((tile, i) => (
          <motion.div
            key={tile.label}
            initial={{ opacity: 0, y: 12 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ delay: i * 0.05 }}
          >
            <Card>
              <CardBody>
                <p className="text-sm text-fg-muted">{tile.label}</p>
                <p className={`mt-1.5 text-2xl font-bold tracking-tight ${tile.accent}`}>
                  {tile.value}
                </p>
              </CardBody>
            </Card>
          </motion.div>
        ))}
      </div>

      {stats.outOfStock > 0 && (
        <Card>
          <CardBody className="flex items-center gap-3 text-sm">
            <span className="inline-flex h-8 w-8 items-center justify-center rounded-full bg-danger/15 text-danger">
              !
            </span>
            <span className="text-fg-muted">
              {t('admin.outOfStockWarning', { count: stats.outOfStock })}{' '}
              <Link to={paths.adminProducts} className="font-medium text-primary hover:underline">
                {t('admin.products')}
              </Link>
            </span>
          </CardBody>
        </Card>
      )}

      <Card>
        <div className="flex items-center justify-between border-b border-border px-5 py-4">
          <h2 className="font-semibold">{t('admin.recentOrders')}</h2>
          <Link to={paths.adminOrders} className="text-sm font-medium text-primary hover:underline">
            {t('admin.viewAll')}
          </Link>
        </div>
        <CardBody className="p-0">
          {stats.recent.length === 0 ? (
            <p className="px-5 py-8 text-center text-sm text-fg-muted">{t('admin.noOrders')}</p>
          ) : (
            <ul className="divide-y divide-border">
              {stats.recent.map((o) => (
                <li key={o.id} className="flex items-center justify-between gap-3 px-5 py-3">
                  <div className="min-w-0">
                    <p className="truncate text-sm font-medium">{o.contactName}</p>
                    <p className="text-xs text-fg-subtle">{formatDate(o.createdAt)}</p>
                  </div>
                  <div className="flex items-center gap-3">
                    <span className="text-sm font-semibold">{formatPrice(o.totalAmount, currency)}</span>
                    <OrderStatusBadge status={o.status} />
                  </div>
                </li>
              ))}
            </ul>
          )}
        </CardBody>
      </Card>
    </div>
  )
}
