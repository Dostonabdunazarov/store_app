import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { ShoppingCart } from 'lucide-react'
import { paths } from '@/app/routes/paths'
import { Card } from '@/shared/ui/Card'
import { Badge } from '@/shared/ui/Badge'
import { StarRating } from '@/shared/ui/StarRating'
import { ProductImage } from '@/shared/ui/ProductImage'
import { cn } from '@/shared/lib/cn'
import { formatPrice } from '@/shared/lib/format'
import { useCartStore } from '@/shared/store/cart.store'
import { FavoriteButton } from '@/features/favorites/FavoriteButton'
import { CompareButton } from '@/features/compare/CompareButton'
import type { ProductListItemDto } from '@/shared/api/types'

export function ProductCard({ product }: { product: ProductListItemDto }) {
  const { t } = useTranslation()
  const addToCart = useCartStore((s) => s.add)

  const handleAddToCart = (e: React.MouseEvent) => {
    e.preventDefault()
    e.stopPropagation()
    addToCart(product)
  }

  return (
    <motion.div
      initial={{ opacity: 0, y: 12 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.35, ease: 'easeOut' }}
    >
      <Link to={paths.product(product.slug)} className="group block h-full">
        <Card interactive className="flex h-full flex-col overflow-hidden">
          <div className="relative">
            <ProductImage
              src={product.imageUrl}
              alt={product.name}
              className="aspect-square"
            />
            <div className="absolute left-3 top-3 flex flex-col items-start gap-2">
              {!product.inStock && (
                <Badge tone="danger">{t('product.outOfStock')}</Badge>
              )}
              {product.discountPercent > 0 && (
                <Badge tone="success">−{product.discountPercent}%</Badge>
              )}
            </div>
            <div className="absolute right-3 top-3 flex flex-col gap-2">
              <FavoriteButton product={product} />
              <CompareButton slug={product.slug} />
            </div>
          </div>

          <div className="flex flex-1 flex-col gap-2 p-4">
            <span className="text-xs font-medium uppercase tracking-wide text-fg-subtle">
              {product.brandName}
            </span>
            <h3 className="line-clamp-2 text-sm font-semibold text-fg transition-colors group-hover:text-primary">
              {product.name}
            </h3>

            {product.ratingCount > 0 && (
              <div className="flex items-center gap-1.5">
                <StarRating value={product.ratingAverage} size={14} />
                <span className="text-xs text-fg-subtle">({product.ratingCount})</span>
              </div>
            )}

            <div className="mt-auto flex items-center justify-between gap-2 pt-2">
              <div className="flex flex-col">
                <span
                  className={cn(
                    'text-lg font-bold',
                    product.discountPercent > 0 ? 'text-danger' : 'text-fg',
                  )}
                >
                  {formatPrice(product.price, t('common.currency'))}
                </span>
                {product.oldPrice != null && (
                  <span className="text-xs font-medium text-fg-subtle line-through">
                    {formatPrice(product.oldPrice, t('common.currency'))}
                  </span>
                )}
              </div>
              {product.inStock && (
                <button
                  type="button"
                  onClick={handleAddToCart}
                  aria-label={t('product.addToCart')}
                  className="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-primary text-primary-fg shadow-card transition-transform hover:scale-105 active:scale-95"
                >
                  <ShoppingCart className="h-4 w-4" strokeWidth={2} />
                </button>
              )}
            </div>
          </div>
        </Card>
      </Link>
    </motion.div>
  )
}
