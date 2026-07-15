import { Link, useLocation, useParams } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { CheckCircle2 } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Card, CardBody } from '@/shared/ui/Card'
import { Skeleton } from '@/shared/ui/Skeleton'
import { ProductImage } from '@/shared/ui/ProductImage'
import { paths } from '@/app/routes/paths'
import { formatDate, formatPrice } from '@/shared/lib/format'
import { useOrder } from './orderHooks'
import { OrderStatusBadge } from './OrderStatusBadge'

export function OrderDetailPage() {
  const { t } = useTranslation()
  const { id } = useParams()
  const location = useLocation()
  const justPlaced = (location.state as { justPlaced?: boolean } | null)?.justPlaced
  const { data: order, isLoading, isError } = useOrder(id)

  if (isLoading) {
    return (
      <Container className="py-8">
        <Skeleton className="mb-6 h-4 w-40" />
        <Skeleton className="mb-6 h-8 w-56" />
        <div className="grid gap-8 lg:grid-cols-[1fr_20rem]">
          <div className="flex flex-col gap-4">
            {Array.from({ length: 2 }).map((_, i) => (
              <Card key={i}>
                <CardBody className="flex gap-4">
                  <Skeleton className="h-20 w-20 shrink-0 rounded-lg" />
                  <div className="flex flex-1 flex-col justify-center gap-2">
                    <Skeleton className="h-4 w-3/4" />
                    <Skeleton className="h-3 w-24" />
                  </div>
                </CardBody>
              </Card>
            ))}
          </div>
          <aside className="flex flex-col gap-4">
            <Skeleton className="h-40 w-full rounded-lg" />
            <Skeleton className="h-16 w-full rounded-lg" />
          </aside>
        </div>
      </Container>
    )
  }

  if (isError || !order) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-4 text-center">
          <h1 className="text-2xl font-bold">{t('orders.notFound')}</h1>
          <Link to={paths.orders}>
            <Button variant="outline">{t('orders.backToOrders')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  return (
    <Container className="py-8">
      <nav className="mb-6 flex flex-wrap items-center gap-1.5 text-sm text-fg-subtle">
        <Link to={paths.orders} className="hover:text-fg">
          {t('nav.orders')}
        </Link>
        <span>/</span>
        <span className="text-fg-muted">
          {t('orders.orderNumber', { id: order.id.slice(0, 8).toUpperCase() })}
        </span>
      </nav>

      {justPlaced && (
        <motion.div
          initial={{ opacity: 0, y: -8 }}
          animate={{ opacity: 1, y: 0 }}
          className="mb-6 flex items-center gap-3 rounded-lg bg-success/10 px-4 py-3 text-sm text-success"
        >
          <CheckCircle2 className="h-5 w-5" strokeWidth={2} />
          {t('orders.placedSuccess')}
        </motion.div>
      )}

      <div className="mb-6 flex flex-wrap items-center justify-between gap-4">
        <div className="flex flex-col gap-1">
          <div className="flex items-center gap-3">
            <h1 className="text-2xl font-bold tracking-tight">
              {t('orders.orderNumber', { id: order.id.slice(0, 8).toUpperCase() })}
            </h1>
            <OrderStatusBadge status={order.status} />
          </div>
          <span className="text-sm text-fg-subtle">{formatDate(order.createdAt)}</span>
        </div>
      </div>

      <div className="grid gap-8 lg:grid-cols-[1fr_20rem]">
        {/* Items */}
        <div className="flex flex-col gap-4">
          {order.items.map((item, idx) => (
            <Card key={`${item.productId ?? 'removed'}-${idx}`}>
              <CardBody className="flex gap-4">
                <ProductImage
                  src={item.productImageUrl}
                  alt={item.productName}
                  className="h-20 w-20 shrink-0 rounded-lg"
                />
                <div className="flex min-w-0 flex-1 flex-col justify-center gap-1">
                  <span className="line-clamp-2 text-sm font-semibold">{item.productName}</span>
                  <span className="text-sm text-fg-subtle">
                    {formatPrice(item.unitPrice, t('common.currency'))} × {item.quantity}
                  </span>
                </div>
                <span className="self-center font-bold">
                  {formatPrice(item.lineTotal, t('common.currency'))}
                </span>
              </CardBody>
            </Card>
          ))}
        </div>

        {/* Summary + delivery */}
        <aside className="flex flex-col gap-4">
          <Card>
            <CardBody className="flex flex-col gap-3">
              <h2 className="font-semibold">{t('checkout.shipping')}</h2>
              <div className="flex flex-col gap-1 text-sm text-fg-muted">
                <span className="font-medium text-fg">{order.contactName}</span>
                <span>{order.contactPhone}</span>
                <span>
                  {order.shippingCity}, {order.shippingAddress}
                </span>
                {order.comment && (
                  <span className="mt-1 border-t border-border pt-2 italic">{order.comment}</span>
                )}
              </div>
            </CardBody>
          </Card>

          <Card>
            <CardBody className="flex items-center justify-between text-lg font-bold">
              <span>{t('cart.total')}</span>
              <span>{formatPrice(order.totalAmount, t('common.currency'))}</span>
            </CardBody>
          </Card>

          <p className="text-center text-xs text-fg-subtle">{t('cart.payOnDelivery')}</p>
        </aside>
      </div>
    </Container>
  )
}
