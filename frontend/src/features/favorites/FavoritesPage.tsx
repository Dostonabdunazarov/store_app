import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { Heart, HeartOff, ShoppingCart } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Card } from '@/shared/ui/Card'
import { ProductImage } from '@/shared/ui/ProductImage'
import { ProductCardSkeleton } from '@/features/catalog/ProductCardSkeleton'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { useAuthStore } from '@/shared/store/auth.store'
import { useLocalFavorites } from '@/shared/store/favorites.local'
import { useCartStore } from '@/shared/store/cart.store'
import { favoritesApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { useQueryClient } from '@tanstack/react-query'
import { useFavorites } from './favoriteHooks'

/** Shape shared by server FavoriteDto and local snapshots. */
interface FavoriteView {
  productId: string
  slug: string
  name: string
  price: number
  imageUrl: string | null
}

export function FavoritesPage() {
  const { t } = useTranslation()
  const qc = useQueryClient()
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const addToCart = useCartStore((s) => s.add)

  const { data: serverFavs, isLoading } = useFavorites()
  const localItems = useLocalFavorites((s) => s.items)
  const localToggle = useLocalFavorites((s) => s.toggle)

  const items: FavoriteView[] = isAuthenticated ? (serverFavs ?? []) : localItems

  const removeFavorite = async (fav: FavoriteView) => {
    if (isAuthenticated) {
      await favoritesApi.remove(fav.productId)
      qc.invalidateQueries({ queryKey: qk.favorites })
    } else {
      // Toggling an already-favorited item removes it.
      localToggle({ id: fav.productId, slug: fav.slug, name: fav.name, price: fav.price, imageUrl: fav.imageUrl })
    }
  }

  if (isAuthenticated && isLoading) {
    return (
      <Container className="py-8">
        <h1 className="mb-6 text-2xl font-bold tracking-tight sm:text-3xl">{t('nav.favorites')}</h1>
        <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
          {Array.from({ length: 4 }).map((_, i) => (
            <ProductCardSkeleton key={i} />
          ))}
        </div>
      </Container>
    )
  }

  if (items.length === 0) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-3 text-center">
          <Heart className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
          <h1 className="text-lg font-semibold">{t('favorites.empty')}</h1>
          <p className="max-w-sm text-sm text-fg-muted">{t('favorites.emptyHint')}</p>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  return (
    <Container className="py-8">
      <h1 className="mb-6 text-2xl font-bold tracking-tight sm:text-3xl">{t('nav.favorites')}</h1>

      <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
        {items.map((fav) => (
          <motion.div
            key={fav.productId}
            layout
            initial={{ opacity: 0, y: 12 }}
            animate={{ opacity: 1, y: 0 }}
          >
            <Card className="flex h-full flex-col overflow-hidden">
              <div className="relative">
                <Link to={paths.product(fav.slug)}>
                  <ProductImage src={fav.imageUrl} alt={fav.name} className="aspect-square" />
                </Link>
                <button
                  type="button"
                  onClick={() => removeFavorite(fav)}
                  aria-label={t('favorites.remove')}
                  className="group/fav absolute right-3 top-3 flex h-9 w-9 items-center justify-center rounded-full bg-bg/80 text-danger backdrop-blur transition-transform hover:scale-105"
                >
                  <Heart className="h-4.5 w-4.5 group-hover/fav:hidden" fill="currentColor" strokeWidth={2} />
                  <HeartOff className="hidden h-4.5 w-4.5 group-hover/fav:block" strokeWidth={2} />
                </button>
              </div>

              <div className="flex flex-1 flex-col gap-2 p-4">
                <Link
                  to={paths.product(fav.slug)}
                  className="line-clamp-2 text-sm font-semibold text-fg transition-colors hover:text-primary"
                >
                  {fav.name}
                </Link>
                <div className="mt-auto flex items-center justify-between gap-2 pt-2">
                  <span className="text-lg font-bold text-fg">
                    {formatPrice(fav.price, t('common.currency'))}
                  </span>
                  <button
                    type="button"
                    onClick={() =>
                      addToCart({
                        id: fav.productId,
                        slug: fav.slug,
                        name: fav.name,
                        price: fav.price,
                        imageUrl: fav.imageUrl,
                        stock: 99, // favorites carry no live stock; cap generously
                      })
                    }
                    aria-label={t('product.addToCart')}
                    className="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-primary text-primary-fg shadow-card transition-transform hover:scale-105 active:scale-95"
                  >
                    <ShoppingCart className="h-4 w-4" strokeWidth={2} />
                  </button>
                </div>
              </div>
            </Card>
          </motion.div>
        ))}
      </div>
    </Container>
  )
}
