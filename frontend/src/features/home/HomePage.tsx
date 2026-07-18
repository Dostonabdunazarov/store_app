import type { ComponentType } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import {
  Headphones,
  Keyboard,
  Laptop,
  type LucideProps,
  Monitor,
  Package,
  Smartphone,
  Tablet,
  Tv,
  Watch,
} from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { paths } from '@/app/routes/paths'
import { useBrands, useCategories, useProducts } from '@/features/catalog/hooks'
import { ProductCard } from '@/features/catalog/ProductCard'
import { ProductCardSkeleton } from '@/features/catalog/ProductCardSkeleton'
import type { ProductListItemDto } from '@/shared/api/types'
import { BrandStrip } from './BrandStrip'
import { CATEGORY_IMAGES } from './categoryImages'
import { PromoCarousel, type PromoCard } from './PromoCarousel'
import { HeroSlider, type HeroSlide } from './HeroSlider'

const fadeUp = {
  initial: { opacity: 0, y: 20 },
  whileInView: { opacity: 1, y: 0 },
  viewport: { once: true, margin: '-80px' },
  transition: { duration: 0.5, ease: 'easeOut' as const },
}

type Icon = ComponentType<LucideProps>

const CATEGORY_ICONS: Record<string, Icon> = {
  laptops: Laptop,
  tablets: Tablet,
  phones: Smartphone,
  gadgets: Watch,
  headsets: Headphones,
  smartwatches: Watch,
  tvs: Tv,
  monitors: Monitor,
  peripherals: Keyboard,
  accessories: Package,
}

export function HomePage() {
  const { t } = useTranslation()
  const { data: categories } = useCategories()
  const { data: brands } = useBrands()
  // Popular = top-rated products, shown as the moving carousel after Categories.
  const { data: popular } = useProducts({
    sort: 'rating',
    pageSize: 12,
    page: 1,
  })
  // Deals = products currently on sale, sorted by discount depth.
  const { data: deals, isLoading: dealsLoading } = useProducts({
    onSale: true,
    sort: 'discount',
    pageSize: 8,
    page: 1,
  })
  const { data: newest, isLoading: newestLoading } = useProducts({
    sort: 'newest',
    pageSize: 8,
    page: 1,
  })

  // Build promo cards from newest + top-rated products with images (deduped).
  const promoCards: PromoCard[] = Array.from(
    new Map(
      [...(newest?.items ?? []), ...(popular?.items ?? [])]
        .filter((p) => p.imageUrl)
        .map((p) => [
          p.id,
          { id: p.id, name: p.name, imageUrl: p.imageUrl, href: paths.product(p.slug) },
        ]),
    ).values(),
  ).slice(0, 12)

  // Hero slides: best deals first, then newest arrivals — deduped, images only.
  const heroSlides: HeroSlide[] = Array.from(
    new Map(
      [...(deals?.items ?? []), ...(newest?.items ?? [])]
        .filter((p) => p.imageUrl)
        .map((p: ProductListItemDto) => [
          p.id,
          {
            id: p.id,
            name: p.name,
            imageUrl: p.imageUrl,
            href: paths.product(p.slug),
            price: p.price,
            oldPrice: p.oldPrice,
            discountPercent: p.discountPercent,
            brandName: p.brandName,
          },
        ]),
    ).values(),
  ).slice(0, 6)

  return (
    <div className="flex flex-col gap-16 pb-20">
      {/* Hero slider — full-bleed, edge-to-edge across the viewport */}
      {heroSlides.length > 0 && (
        <motion.section
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          transition={{ duration: 0.6, ease: 'easeOut' }}
        >
          <HeroSlider slides={heroSlides} />
        </motion.section>
      )}

      {/* Brand strip — heading in the gutter, lane bleeds to the right edge */}
      {brands && brands.length > 0 && (
        <motion.section
          initial={{ opacity: 0, y: 16 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5, ease: 'easeOut', delay: 0.1 }}
          className="flex flex-col gap-6"
        >
          <Container>
            <h2 className="text-center text-2xl font-bold tracking-tight sm:text-3xl">
              {t('home.brands')}
            </h2>
          </Container>
          {/* Full-bleed lane: left padding aligns to the gutter, runs off-screen right */}
          <div className="pl-4 sm:pl-6 lg:pl-8">
            <BrandStrip brands={brands} />
          </div>
        </motion.section>
      )}

      <Container className="flex flex-col gap-16">
        {/* Categories */}
        <motion.section id="categories" className="flex flex-col gap-6 scroll-mt-24" {...fadeUp}>
          <div className="text-center">
            <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">
              {t('home.browseCategories')}
            </h2>
          </div>
          <div className="grid grid-cols-2 gap-4 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5">
            {categories?.map((c) => {
              const Icon = CATEGORY_ICONS[c.slug] ?? Package
              const image = CATEGORY_IMAGES[c.slug]
              return (
                <Link
                  key={c.id}
                  to={`${paths.catalog}?category=${c.slug}`}
                  className="group relative flex aspect-4/5 flex-col justify-end overflow-hidden rounded-2xl border border-border shadow-card transition-all hover:-translate-y-1 hover:shadow-elevated"
                >
                  {/* Background: photo or gradient fallback */}
                  {image ? (
                    <img
                      src={image}
                      alt={c.name}
                      loading="lazy"
                      className="absolute inset-0 h-full w-full object-cover transition-transform duration-500 group-hover:scale-105"
                    />
                  ) : (
                    <div className="absolute inset-0 bg-linear-to-br from-primary/25 to-primary/5" />
                  )}
                  {/* Readability gradient */}
                  <div className="absolute inset-0 bg-linear-to-t from-black/80 via-black/25 to-transparent" />

                  {/* Icon badge */}
                  <span className="absolute right-3 top-3 flex h-10 w-10 items-center justify-center rounded-xl bg-white/15 text-white backdrop-blur-md transition-transform group-hover:scale-110">
                    <Icon className="h-5 w-5" strokeWidth={1.75} />
                  </span>

                  {/* Label */}
                  <div className="relative z-10 flex flex-col gap-0.5 p-4">
                    <span className="text-base font-semibold text-white drop-shadow-sm sm:text-lg">
                      {c.name}
                    </span>
                    <span className="text-xs font-medium text-white/70">
                      {t('home.categoryProducts', { count: c.productCount })}
                    </span>
                  </div>
                </Link>
              )
            })}
          </div>
        </motion.section>

        {/* Popular products — auto-moving carousel; lane bleeds to the right edge */}
        {promoCards.length > 0 && (
          <motion.section className="flex flex-col gap-6" {...fadeUp}>
            <div className="flex items-end justify-between gap-4">
              <div>
                <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">
                  {t('home.popular')}
                </h2>
                <p className="mt-1 text-sm text-fg-subtle">{t('home.popularSubtitle')}</p>
              </div>
              <Link to={`${paths.catalog}?sort=rating`} className="shrink-0">
                <Button variant="ghost">{t('home.viewAll')} →</Button>
              </Link>
            </div>
            {/* Cancel the container's right padding so the lane runs off-screen */}
            <div className="-mr-4 sm:-mr-6 lg:-mr-8">
              <PromoCarousel cards={promoCards} />
            </div>
          </motion.section>
        )}

        {/* Deals / sale — replaces the former "Popular products" grid */}
        {(dealsLoading || (deals && deals.items.length > 0)) && (
          <motion.section className="flex flex-col gap-6" {...fadeUp}>
            <div className="flex items-end justify-between gap-4">
              <div>
                <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">
                  {t('home.deals')}
                </h2>
                <p className="mt-1 text-sm text-fg-subtle">{t('home.dealsSubtitle')}</p>
              </div>
              <Link to={`${paths.catalog}?onSale=true&sort=discount`} className="shrink-0">
                <Button variant="ghost">{t('home.viewAll')} →</Button>
              </Link>
            </div>
            <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
              {dealsLoading
                ? Array.from({ length: 8 }).map((_, i) => <ProductCardSkeleton key={i} />)
                : deals?.items.map((p) => <ProductCard key={p.id} product={p} />)}
            </div>
          </motion.section>
        )}

        {/* New products */}
        <motion.section className="flex flex-col gap-6" {...fadeUp}>
          <div className="flex items-end justify-between gap-4">
            <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">
              {t('home.newProducts')}
            </h2>
            <Link to={`${paths.catalog}?sort=newest`} className="shrink-0">
              <Button variant="ghost">{t('home.viewAll')} →</Button>
            </Link>
          </div>
          <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
            {newestLoading
              ? Array.from({ length: 8 }).map((_, i) => <ProductCardSkeleton key={i} />)
              : newest?.items.map((p) => <ProductCard key={p.id} product={p} />)}
          </div>
        </motion.section>
      </Container>
    </div>
  )
}
