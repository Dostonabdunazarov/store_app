import type { ComponentType } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import {
  Headphones,
  Laptop,
  type LucideProps,
  Package,
  Smartphone,
  Tablet,
  Watch,
} from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { paths } from '@/app/routes/paths'
import { useCategories, useProducts } from '@/features/catalog/hooks'
import { ProductCard } from '@/features/catalog/ProductCard'
import { ProductCardSkeleton } from '@/features/catalog/ProductCardSkeleton'
import { HeroCarousel, type HeroSlide } from './HeroCarousel'
import heroImage from '@/assets/hero.png'

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
}

export function HomePage() {
  const { t } = useTranslation()
  const { data: categories } = useCategories()
  const { data: featured, isLoading: featuredLoading } = useProducts({
    sort: 'rating',
    pageSize: 8,
    page: 1,
  })

  // Build carousel slides from top-rated products with images; fall back to the static hero art.
  const slides: HeroSlide[] =
    featured?.items
      .filter((p) => p.imageUrl)
      .slice(0, 5)
      .map((p) => ({ id: p.id, name: p.name, imageUrl: p.imageUrl, href: paths.product(p.slug) })) ??
    []
  const heroSlides: HeroSlide[] =
    slides.length > 0
      ? slides
      : [{ id: 'hero', name: t('common.appName'), imageUrl: heroImage, href: paths.catalog }]

  return (
    <div className="flex flex-col gap-16 pb-20">
      {/* Hero — "New arrivals" heading + 3-layer carousel */}
      <motion.section
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.6, ease: 'easeOut' }}
        className="flex flex-col gap-6 pt-8"
      >
        <div className="flex flex-col items-center gap-2 text-center">
          <span className="rounded-full bg-primary/10 px-4 py-1 text-xs font-semibold uppercase tracking-widest text-primary">
            {t('home.heroBadge')}
          </span>
          <h1 className="text-3xl font-bold tracking-tight sm:text-4xl lg:text-5xl">
            {t('home.newArrivals')}
          </h1>
        </div>
        <HeroCarousel slides={heroSlides} />
      </motion.section>

      <Container className="flex flex-col gap-16">
        {/* Categories */}
        <motion.section id="categories" className="flex flex-col gap-6 scroll-mt-24" {...fadeUp}>
          <div className="flex flex-col gap-1 text-center">
            <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">
              {t('home.browseCategories')}
            </h2>
            <p className="text-fg-muted">{t('home.browseCategoriesSubtitle')}</p>
          </div>
          <div className="grid grid-cols-2 gap-4 sm:grid-cols-3 lg:grid-cols-5">
            {categories?.map((c) => {
              const Icon = CATEGORY_ICONS[c.slug] ?? Package
              return (
                <Link
                  key={c.id}
                  to={`${paths.catalog}?category=${c.slug}`}
                  className="group glass flex flex-col items-center gap-3 rounded-xl border p-6 text-center shadow-card transition-all hover:-translate-y-1 hover:shadow-elevated"
                >
                  <span className="flex h-14 w-14 items-center justify-center rounded-xl bg-primary/10 text-primary transition-transform group-hover:scale-110">
                    <Icon className="h-7 w-7" strokeWidth={1.75} />
                  </span>
                  <span className="text-sm font-semibold group-hover:text-primary">{c.name}</span>
                  <span className="text-xs text-fg-subtle">{c.productCount}</span>
                </Link>
              )
            })}
          </div>
        </motion.section>

        {/* Featured products */}
        <motion.section className="flex flex-col gap-6" {...fadeUp}>
          <div className="flex items-end justify-between gap-4">
            <div className="flex flex-col gap-1">
              <h2 className="text-2xl font-bold tracking-tight sm:text-3xl">{t('home.featured')}</h2>
              <p className="text-fg-muted">{t('home.featuredSubtitle')}</p>
            </div>
            <Link to={paths.catalog} className="shrink-0">
              <Button variant="ghost">{t('home.viewAll')} →</Button>
            </Link>
          </div>
          <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
            {featuredLoading
              ? Array.from({ length: 8 }).map((_, i) => <ProductCardSkeleton key={i} />)
              : featured?.items.map((p) => <ProductCard key={p.id} product={p} />)}
          </div>
        </motion.section>
      </Container>
    </div>
  )
}
