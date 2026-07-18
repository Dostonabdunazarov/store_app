import { useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Badge } from '@/shared/ui/Badge'
import { Skeleton } from '@/shared/ui/Skeleton'
import { StarRating } from '@/shared/ui/StarRating'
import { QuantityStepper } from '@/shared/ui/QuantityStepper'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { useCartStore } from '@/shared/store/cart.store'
import { FavoriteButton } from '@/features/favorites/FavoriteButton'
import { CompareButton } from '@/features/compare/CompareButton'
import { useProduct } from '@/features/catalog/hooks'
import { ProductGallery } from './ProductGallery'
import { ReviewSection } from './ReviewSection'

function DetailSkeleton() {
  return (
    <Container className="py-8">
      <div className="grid gap-8 lg:grid-cols-2">
        <Skeleton className="aspect-square rounded-xl" />
        <div className="flex flex-col gap-4">
          <Skeleton className="h-4 w-24" />
          <Skeleton className="h-8 w-3/4" />
          <Skeleton className="h-5 w-32" />
          <Skeleton className="h-10 w-40" />
          <Skeleton className="h-12 w-full" />
        </div>
      </div>
    </Container>
  )
}

export function ProductDetailPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const { slug = '' } = useParams()
  const { data: product, isLoading, isError } = useProduct(slug)
  const addToCart = useCartStore((s) => s.add)
  const [quantity, setQuantity] = useState(1)

  if (isLoading) return <DetailSkeleton />

  if (isError || !product) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-4 text-center">
          <h1 className="text-2xl font-bold">{t('product.notFound')}</h1>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  const stockTone = product.inStock
    ? product.stock <= 5
      ? 'warning'
      : 'success'
    : 'danger'
  const stockLabel = !product.inStock
    ? t('product.outOfStock')
    : product.stock <= 5
      ? t('product.stockLeft', { count: product.stock })
      : t('product.inStock')

  return (
    <Container className="py-8">
      {/* Breadcrumb */}
      <nav className="mb-6 flex flex-wrap items-center gap-1.5 text-sm text-fg-subtle">
        <Link to={paths.home} className="hover:text-fg">
          {t('common.appName')}
        </Link>
        <span>/</span>
        <Link to={`${paths.catalog}?category=${product.categorySlug}`} className="hover:text-fg">
          {product.categoryName}
        </Link>
        <span>/</span>
        <span className="text-fg-muted">{product.name}</span>
      </nav>

      <motion.div
        className="grid gap-8 lg:grid-cols-2"
        initial={{ opacity: 0, y: 12 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.4, ease: 'easeOut' }}
      >
        <ProductGallery images={product.imageUrls} alt={product.name} />

        <div className="flex flex-col gap-5">
          <div className="flex flex-col gap-2">
            <span className="text-sm font-medium uppercase tracking-wide text-fg-subtle">
              {product.brandName}
            </span>
            <h1 className="text-2xl font-bold tracking-tight sm:text-3xl">{product.name}</h1>
            {product.ratingCount > 0 && (
              <div className="flex items-center gap-2">
                <StarRating value={product.ratingAverage} size={18} />
                <span className="text-sm text-fg-muted">
                  {product.ratingAverage.toFixed(1)} · {t('product.reviewsCount', { count: product.ratingCount })}
                </span>
              </div>
            )}
          </div>

          <div className="flex flex-wrap items-center gap-3">
            <span
              className={
                product.discountPercent > 0 ? 'text-3xl font-bold text-danger' : 'text-3xl font-bold'
              }
            >
              {formatPrice(product.price, t('common.currency'))}
            </span>
            {product.oldPrice != null && (
              <span className="text-lg font-medium text-fg-subtle line-through">
                {formatPrice(product.oldPrice, t('common.currency'))}
              </span>
            )}
            {product.discountPercent > 0 && (
              <Badge tone="success">−{product.discountPercent}%</Badge>
            )}
            <Badge tone={stockTone}>{stockLabel}</Badge>
          </div>

          {product.inStock && (
            <div className="flex items-center gap-3">
              <span className="text-sm font-medium text-fg">{t('cart.quantity')}</span>
              <QuantityStepper
                value={quantity}
                onChange={setQuantity}
                max={product.stock}
              />
            </div>
          )}

          <div className="flex flex-col gap-3 sm:flex-row">
            <Button
              size="lg"
              disabled={!product.inStock}
              className="flex-1"
              onClick={() => addToCart(product, quantity)}
            >
              {t('product.addToCart')}
            </Button>
            <Button
              size="lg"
              variant="secondary"
              disabled={!product.inStock}
              className="flex-1"
              onClick={() => {
                addToCart(product, quantity)
                navigate(paths.cart)
              }}
            >
              {t('product.buyNow')}
            </Button>
          </div>

          <div className="flex gap-3">
            <FavoriteButton product={product} variant="button" className="flex-1" />
            <CompareButton slug={product.slug} variant="button" className="flex-1" />
          </div>

          {product.description && (
            <div className="flex flex-col gap-2 border-t border-border pt-5">
              <h2 className="font-semibold">{t('product.description')}</h2>
              <p className="whitespace-pre-line text-sm leading-relaxed text-fg-muted">
                {product.description}
              </p>
            </div>
          )}

          {product.attributes.length > 0 && (
            <div className="flex flex-col gap-3 border-t border-border pt-5">
              <h2 className="font-semibold">{t('product.specs')}</h2>
              <dl className="grid grid-cols-1 gap-x-8 gap-y-2 sm:grid-cols-2">
                {product.attributes.map((a) => (
                  <div
                    key={a.key}
                    className="flex items-center justify-between gap-4 border-b border-border/60 py-1.5 text-sm"
                  >
                    <dt className="text-fg-subtle">{a.label}</dt>
                    <dd className="text-right font-medium text-fg">{a.value}</dd>
                  </div>
                ))}
              </dl>
            </div>
          )}
        </div>
      </motion.div>

      <div className="mt-14 max-w-3xl">
        <ReviewSection productId={product.id} slug={product.slug} />
      </div>
    </Container>
  )
}
