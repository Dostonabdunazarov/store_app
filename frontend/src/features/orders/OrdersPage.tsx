import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { PackageOpen } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Card, CardBody } from '@/shared/ui/Card'
import { Skeleton } from '@/shared/ui/Skeleton'
import { paths } from '@/app/routes/paths'
import { formatDate, formatPrice } from '@/shared/lib/format'
import { useOrders } from './orderHooks'
import { OrderStatusBadge } from './OrderStatusBadge'

export function OrdersPage() {
  const { t } = useTranslation()
  const { data: orders, isLoading, isError, refetch } = useOrders()

  if (isLoading) {
    return (
      <Container className="py-8">
        <Skeleton className="mb-6 h-8 w-48" />
        <div className="flex flex-col gap-4">
          {Array.from({ length: 4 }).map((_, i) => (
            <Card key={i}>
              <CardBody className="flex flex-wrap items-center justify-between gap-4">
                <div className="flex flex-col gap-2">
                  <Skeleton className="h-4 w-40" />
                  <Skeleton className="h-3 w-24" />
                </div>
                <Skeleton className="h-5 w-24" />
              </CardBody>
            </Card>
          ))}
        </div>
      </Container>
    )
  }

  if (isError) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-4 text-center">
          <p className="text-fg-muted">{t('common.somethingWrong')}</p>
          <Button variant="outline" onClick={() => refetch()}>
            {t('common.retry')}
          </Button>
        </div>
      </Container>
    )
  }

  if (!orders || orders.length === 0) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-3 text-center">
          <PackageOpen className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
          <h1 className="text-lg font-semibold">{t('orders.empty')}</h1>
          <p className="max-w-sm text-sm text-fg-muted">{t('orders.emptyHint')}</p>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  return (
    <Container className="py-8">
      <h1 className="mb-6 text-2xl font-bold tracking-tight sm:text-3xl">{t('nav.orders')}</h1>

      <div className="flex flex-col gap-4">
        {orders.map((order) => (
          <motion.div
            key={order.id}
            initial={{ opacity: 0, y: 8 }}
            animate={{ opacity: 1, y: 0 }}
          >
            <Link to={paths.order(order.id)}>
              <Card interactive>
                <CardBody className="flex flex-wrap items-center justify-between gap-4">
                  <div className="flex flex-col gap-1">
                    <div className="flex items-center gap-3">
                      <span className="font-semibold">
                        {t('orders.orderNumber', { id: order.id.slice(0, 8).toUpperCase() })}
                      </span>
                      <OrderStatusBadge status={order.status} />
                    </div>
                    <span className="text-sm text-fg-subtle">{formatDate(order.createdAt)}</span>
                  </div>
                  <div className="flex items-center gap-6">
                    <span className="text-sm text-fg-muted">
                      {t('orders.itemsCount', {
                        count: order.items.reduce((s, i) => s + i.quantity, 0),
                      })}
                    </span>
                    <span className="text-lg font-bold">
                      {formatPrice(order.totalAmount, t('common.currency'))}
                    </span>
                  </div>
                </CardBody>
              </Card>
            </Link>
          </motion.div>
        ))}
      </div>
    </Container>
  )
}
