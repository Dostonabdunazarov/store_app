import { useState, type FormEvent } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { ShoppingCart } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Input } from '@/shared/ui/Input'
import { Card, CardBody } from '@/shared/ui/Card'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { getErrorMessage, getFieldErrors } from '@/shared/api/client'
import { useCartStore, selectCartTotal } from '@/shared/store/cart.store'
import { useAuthStore } from '@/shared/store/auth.store'
import { useCreateOrder } from '@/features/orders/orderHooks'

interface FormState {
  contactName: string
  contactPhone: string
  shippingCity: string
  shippingAddress: string
  comment: string
}

export function CheckoutPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const user = useAuthStore((s) => s.user)
  const items = useCartStore((s) => s.items)
  const total = useCartStore(selectCartTotal)
  const clearCart = useCartStore((s) => s.clear)
  const createOrder = useCreateOrder()

  const [form, setForm] = useState<FormState>({
    contactName: user?.fullName ?? '',
    contactPhone: '',
    shippingCity: '',
    shippingAddress: '',
    comment: '',
  })
  const [errors, setErrors] = useState<Record<string, string>>({})
  const [submitError, setSubmitError] = useState<string | null>(null)

  const set = (key: keyof FormState) => (e: React.ChangeEvent<HTMLInputElement>) =>
    setForm((f) => ({ ...f, [key]: e.target.value }))

  const validate = (): boolean => {
    const next: Record<string, string> = {}
    if (!form.contactName.trim()) next.contactName = t('checkout.required')
    if (!form.contactPhone.trim()) next.contactPhone = t('checkout.required')
    if (!form.shippingCity.trim()) next.shippingCity = t('checkout.required')
    if (!form.shippingAddress.trim()) next.shippingAddress = t('checkout.required')
    setErrors(next)
    return Object.keys(next).length === 0
  }

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setSubmitError(null)
    if (!validate()) return
    try {
      const order = await createOrder.mutateAsync({
        contactName: form.contactName.trim(),
        contactPhone: form.contactPhone.trim(),
        shippingCity: form.shippingCity.trim(),
        shippingAddress: form.shippingAddress.trim(),
        comment: form.comment.trim() || null,
        items: items.map((i) => ({ productId: i.productId, quantity: i.quantity })),
      })
      clearCart()
      navigate(paths.order(order.id), { replace: true, state: { justPlaced: true } })
    } catch (err) {
      setErrors(getFieldErrors(err))
      setSubmitError(getErrorMessage(err, t('common.somethingWrong')))
    }
  }

  // Empty cart — nothing to check out.
  if (items.length === 0) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-3 text-center">
          <ShoppingCart className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
          <h1 className="text-lg font-semibold">{t('cart.empty')}</h1>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  return (
    <Container className="py-8">
      <h1 className="mb-6 text-2xl font-bold tracking-tight sm:text-3xl">{t('checkout.title')}</h1>

      <div className="grid gap-8 lg:grid-cols-[1fr_20rem]">
        {/* Form */}
        <form onSubmit={handleSubmit} className="flex flex-col gap-5">
          <Card>
            <CardBody className="flex flex-col gap-4">
              <h2 className="font-semibold">{t('checkout.contact')}</h2>
              <Input
                label={t('checkout.contactName')}
                value={form.contactName}
                onChange={set('contactName')}
                error={errors.contactName}
                autoComplete="name"
              />
              <Input
                label={t('checkout.contactPhone')}
                value={form.contactPhone}
                onChange={set('contactPhone')}
                error={errors.contactPhone}
                placeholder="+998 __ ___ __ __"
                autoComplete="tel"
                inputMode="tel"
              />
            </CardBody>
          </Card>

          <Card>
            <CardBody className="flex flex-col gap-4">
              <h2 className="font-semibold">{t('checkout.shipping')}</h2>
              <Input
                label={t('checkout.city')}
                value={form.shippingCity}
                onChange={set('shippingCity')}
                error={errors.shippingCity}
                autoComplete="address-level2"
              />
              <Input
                label={t('checkout.address')}
                value={form.shippingAddress}
                onChange={set('shippingAddress')}
                error={errors.shippingAddress}
                autoComplete="street-address"
              />
              <div className="flex flex-col gap-1.5">
                <label htmlFor="checkout-comment" className="text-sm font-medium text-fg">
                  {t('checkout.comment')}
                </label>
                <textarea
                  id="checkout-comment"
                  rows={3}
                  value={form.comment}
                  onChange={(e) => setForm((f) => ({ ...f, comment: e.target.value }))}
                  placeholder={t('checkout.commentPlaceholder')}
                  className="w-full resize-y rounded-lg border border-border bg-surface px-3.5 py-2.5 text-sm text-fg placeholder:text-fg-subtle focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-1 focus:ring-offset-bg"
                />
              </div>
            </CardBody>
          </Card>

          {submitError && <p className="text-sm text-danger">{submitError}</p>}
        </form>

        {/* Summary */}
        <aside className="lg:sticky lg:top-24 lg:self-start">
          <Card>
            <CardBody className="flex flex-col gap-4">
              <h2 className="font-semibold">{t('cart.summary')}</h2>
              <div className="flex flex-col gap-2">
                {items.map((i) => (
                  <div key={i.productId} className="flex items-center justify-between gap-2 text-sm">
                    <span className="line-clamp-1 text-fg-muted">
                      {i.name} <span className="text-fg-subtle">× {i.quantity}</span>
                    </span>
                    <span className="shrink-0 font-medium">
                      {formatPrice(i.price * i.quantity, t('common.currency'))}
                    </span>
                  </div>
                ))}
              </div>
              <div className="flex items-center justify-between border-t border-border pt-4 text-lg font-bold">
                <span>{t('cart.total')}</span>
                <span>{formatPrice(total, t('common.currency'))}</span>
              </div>
              <Button
                type="submit"
                size="lg"
                className="w-full"
                loading={createOrder.isPending}
                onClick={handleSubmit}
              >
                {t('checkout.placeOrder')}
              </Button>
              <p className="text-center text-xs text-fg-subtle">{t('cart.payOnDelivery')}</p>
            </CardBody>
          </Card>
        </aside>
      </div>
    </Container>
  )
}
