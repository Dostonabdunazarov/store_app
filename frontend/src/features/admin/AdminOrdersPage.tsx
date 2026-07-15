import { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { Card, CardBody } from '@/shared/ui/Card'
import { Skeleton } from '@/shared/ui/Skeleton'
import { Select } from '@/shared/ui/Select'
import { OrderStatusBadge } from '@/features/orders/OrderStatusBadge'
import { formatDate, formatPrice } from '@/shared/lib/format'
import { getErrorMessage } from '@/shared/api/client'
import { OrderStatus } from '@/shared/api/types'
import type { OrderDto } from '@/shared/api/types'
import { useAdminOrders, useUpdateOrderStatus } from './adminHooks'

const STATUS_OPTIONS: OrderStatus[] = [
  OrderStatus.Pending,
  OrderStatus.Confirmed,
  OrderStatus.Shipped,
  OrderStatus.Delivered,
  OrderStatus.Cancelled,
]

const STATUS_KEY: Record<OrderStatus, string> = {
  [OrderStatus.Pending]: 'orders.statusPending',
  [OrderStatus.Confirmed]: 'orders.statusConfirmed',
  [OrderStatus.Shipped]: 'orders.statusShipped',
  [OrderStatus.Delivered]: 'orders.statusDelivered',
  [OrderStatus.Cancelled]: 'orders.statusCancelled',
}

function OrderRow({ order }: { order: OrderDto }) {
  const { t } = useTranslation()
  const currency = t('common.currency')
  const [open, setOpen] = useState(false)
  const update = useUpdateOrderStatus()
  const [error, setError] = useState<string | null>(null)

  const onStatusChange = (value: string) => {
    setError(null)
    update.mutate(
      { id: order.id, status: Number(value) as OrderStatus },
      { onError: (e) => setError(getErrorMessage(e)) },
    )
  }

  return (
    <Card>
      <CardBody className="space-y-3">
        <div className="flex flex-wrap items-start justify-between gap-3">
          <div className="min-w-0">
            <p className="font-semibold">{order.contactName}</p>
            <p className="text-sm text-fg-muted">{order.contactPhone}</p>
            <p className="text-xs text-fg-subtle">
              {formatDate(order.createdAt)} · {order.shippingCity}, {order.shippingAddress}
            </p>
          </div>
          <div className="flex flex-col items-end gap-2">
            <span className="text-lg font-bold">{formatPrice(order.totalAmount, currency)}</span>
            <OrderStatusBadge status={order.status} />
          </div>
        </div>

        <div className="flex flex-wrap items-end justify-between gap-3">
          <div className="w-48">
            <Select
              label={t('admin.changeStatus')}
              value={order.status}
              disabled={update.isPending}
              onChange={(e) => onStatusChange(e.target.value)}
            >
              {STATUS_OPTIONS.map((s) => (
                <option key={s} value={s}>
                  {t(STATUS_KEY[s])}
                </option>
              ))}
            </Select>
          </div>
          <button
            type="button"
            onClick={() => setOpen((v) => !v)}
            className="text-sm font-medium text-primary hover:underline"
          >
            {open ? t('admin.hideItems') : t('admin.showItems', { count: order.items.length })}
          </button>
        </div>

        {error && <p className="text-xs text-danger">{error}</p>}

        {open && (
          <ul className="divide-y divide-border rounded-lg border border-border">
            {order.items.map((it, i) => (
              <li key={i} className="flex items-center justify-between gap-3 px-3 py-2 text-sm">
                <span className="min-w-0 truncate">
                  {it.productName} <span className="text-fg-subtle">× {it.quantity}</span>
                </span>
                <span className="font-medium">{formatPrice(it.lineTotal, currency)}</span>
              </li>
            ))}
          </ul>
        )}
      </CardBody>
    </Card>
  )
}

export function AdminOrdersPage() {
  const { t } = useTranslation()
  const { data, isLoading, isError } = useAdminOrders()

  if (isLoading) {
    return (
      <div className="space-y-4">
        <Skeleton className="h-6 w-32" />
        {Array.from({ length: 4 }).map((_, i) => (
          <Card key={i}>
            <CardBody className="space-y-3">
              <div className="flex items-start justify-between gap-3">
                <div className="space-y-2">
                  <Skeleton className="h-4 w-32" />
                  <Skeleton className="h-3 w-24" />
                </div>
                <Skeleton className="h-9 w-36" />
              </div>
            </CardBody>
          </Card>
        ))}
      </div>
    )
  }
  if (isError) return <p className="text-sm text-danger">{t('common.somethingWrong')}</p>

  const orders = data ?? []

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <h2 className="text-lg font-semibold">{t('admin.orders')}</h2>
        <span className="text-sm text-fg-muted">{t('admin.ordersCount', { count: orders.length })}</span>
      </div>
      {orders.length === 0 ? (
        <Card>
          <CardBody>
            <p className="py-8 text-center text-sm text-fg-muted">{t('admin.noOrders')}</p>
          </CardBody>
        </Card>
      ) : (
        orders.map((o) => <OrderRow key={o.id} order={o} />)
      )}
    </div>
  )
}
