import { useTranslation } from 'react-i18next'
import { Badge } from '@/shared/ui/Badge'
import { OrderStatus } from '@/shared/api/types'

const TONE: Record<OrderStatus, 'neutral' | 'brand' | 'success' | 'danger' | 'warning'> = {
  [OrderStatus.Pending]: 'warning',
  [OrderStatus.Confirmed]: 'brand',
  [OrderStatus.Shipped]: 'brand',
  [OrderStatus.Delivered]: 'success',
  [OrderStatus.Cancelled]: 'danger',
}

const KEY: Record<OrderStatus, string> = {
  [OrderStatus.Pending]: 'orders.statusPending',
  [OrderStatus.Confirmed]: 'orders.statusConfirmed',
  [OrderStatus.Shipped]: 'orders.statusShipped',
  [OrderStatus.Delivered]: 'orders.statusDelivered',
  [OrderStatus.Cancelled]: 'orders.statusCancelled',
}

export function OrderStatusBadge({ status }: { status: OrderStatus }) {
  const { t } = useTranslation()
  return <Badge tone={TONE[status]}>{t(KEY[status])}</Badge>
}
