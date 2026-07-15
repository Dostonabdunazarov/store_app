import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { ShoppingCart, Trash2 } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Card, CardBody } from '@/shared/ui/Card'
import { ProductImage } from '@/shared/ui/ProductImage'
import { QuantityStepper } from '@/shared/ui/QuantityStepper'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { useCartStore, selectCartTotal } from '@/shared/store/cart.store'

export function CartPage() {
  const { t } = useTranslation()
  const items = useCartStore((s) => s.items)
  const setQuantity = useCartStore((s) => s.setQuantity)
  const remove = useCartStore((s) => s.remove)
  const clear = useCartStore((s) => s.clear)
  const total = useCartStore(selectCartTotal)

  if (items.length === 0) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-3 text-center">
          <ShoppingCart className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
          <h1 className="text-lg font-semibold">{t('cart.empty')}</h1>
          <p className="max-w-sm text-sm text-fg-muted">{t('cart.emptyHint')}</p>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  return (
    <Container className="py-8">
      <div className="mb-6 flex items-center justify-between">
        <h1 className="text-2xl font-bold tracking-tight sm:text-3xl">{t('nav.cart')}</h1>
        <button
          type="button"
          onClick={clear}
          className="text-sm text-fg-subtle transition-colors hover:text-danger"
        >
          {t('cart.clear')}
        </button>
      </div>

      <div className="grid gap-8 lg:grid-cols-[1fr_20rem]">
        {/* Line items */}
        <div className="flex flex-col gap-4">
          {items.map((item) => (
            <motion.div
              key={item.productId}
              layout
              initial={{ opacity: 0, y: 8 }}
              animate={{ opacity: 1, y: 0 }}
              exit={{ opacity: 0 }}
            >
              <Card>
                <CardBody className="flex gap-4">
                  <Link to={paths.product(item.slug)} className="shrink-0">
                    <ProductImage
                      src={item.imageUrl}
                      alt={item.name}
                      className="h-24 w-24 rounded-lg"
                    />
                  </Link>

                  <div className="flex min-w-0 flex-1 flex-col gap-2">
                    <Link
                      to={paths.product(item.slug)}
                      className="line-clamp-2 text-sm font-semibold text-fg transition-colors hover:text-primary"
                    >
                      {item.name}
                    </Link>
                    <span className="text-sm text-fg-muted">
                      {formatPrice(item.price, t('common.currency'))}
                    </span>

                    <div className="mt-auto flex items-center justify-between gap-2">
                      <QuantityStepper
                        value={item.quantity}
                        onChange={(q) => setQuantity(item.productId, q)}
                        max={item.stock}
                      />
                      <button
                        type="button"
                        onClick={() => remove(item.productId)}
                        aria-label={t('cart.remove')}
                        className="flex h-9 w-9 items-center justify-center rounded-lg text-fg-subtle transition-colors hover:text-danger"
                      >
                        <Trash2 className="h-4.5 w-4.5" strokeWidth={2} />
                      </button>
                    </div>
                  </div>

                  <div className="hidden shrink-0 self-center text-right font-bold sm:block">
                    {formatPrice(item.price * item.quantity, t('common.currency'))}
                  </div>
                </CardBody>
              </Card>
            </motion.div>
          ))}
        </div>

        {/* Summary */}
        <aside className="lg:sticky lg:top-24 lg:self-start">
          <Card>
            <CardBody className="flex flex-col gap-4">
              <h2 className="font-semibold">{t('cart.summary')}</h2>
              <div className="flex items-center justify-between text-sm text-fg-muted">
                <span>{t('cart.subtotal')}</span>
                <span>{formatPrice(total, t('common.currency'))}</span>
              </div>
              <div className="flex items-center justify-between text-sm text-fg-muted">
                <span>{t('cart.delivery')}</span>
                <span>{t('cart.deliveryFree')}</span>
              </div>
              <div className="flex items-center justify-between border-t border-border pt-4 text-lg font-bold">
                <span>{t('cart.total')}</span>
                <span>{formatPrice(total, t('common.currency'))}</span>
              </div>
              <Link to={paths.checkout} className="block">
                <Button size="lg" className="w-full">
                  {t('cart.checkout')}
                </Button>
              </Link>
              <p className="text-center text-xs text-fg-subtle">{t('cart.payOnDelivery')}</p>
            </CardBody>
          </Card>
        </aside>
      </div>
    </Container>
  )
}
