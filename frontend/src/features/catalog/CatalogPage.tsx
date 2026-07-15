import { useMemo, useState } from 'react'
import { useSearchParams } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { AnimatePresence, motion } from 'motion/react'
import { SearchX, SlidersHorizontal, Search } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Input } from '@/shared/ui/Input'
import { Select } from '@/shared/ui/Select'
import { Button } from '@/shared/ui/Button'
import { Pagination } from '@/shared/ui/Pagination'
import { useProducts } from './hooks'
import { ProductCard } from './ProductCard'
import { ProductCardSkeleton } from './ProductCardSkeleton'
import { FilterSidebar, type FilterValues } from './FilterSidebar'
import type { ProductQuery, ProductSort } from '@/shared/api/types'

const PAGE_SIZE = 12
const SORTS: ProductSort[] = ['newest', 'price_asc', 'price_desc', 'rating', 'name']

/** Parse the URL search params into a typed ProductQuery. */
function parseParams(sp: URLSearchParams): Required<Pick<ProductQuery, 'page' | 'pageSize'>> &
  ProductQuery {
  const num = (k: string) => {
    const v = sp.get(k)
    return v != null && v !== '' ? Number(v) : undefined
  }
  return {
    search: sp.get('search') || undefined,
    category: sp.get('category') || undefined,
    brand: sp.get('brand') || undefined,
    minPrice: num('minPrice'),
    maxPrice: num('maxPrice'),
    inStock: sp.get('inStock') === 'true' || undefined,
    sort: (sp.get('sort') as ProductSort) || 'newest',
    page: num('page') ?? 1,
    pageSize: PAGE_SIZE,
  }
}

export function CatalogPage() {
  const { t } = useTranslation()
  const [searchParams, setSearchParams] = useSearchParams()
  const [drawerOpen, setDrawerOpen] = useState(false)

  const query = useMemo(() => parseParams(searchParams), [searchParams])
  const [searchDraft, setSearchDraft] = useState(query.search ?? '')

  const { data, isLoading, isError, refetch, isPlaceholderData } = useProducts(query)

  /** Merge params, dropping empties; reset to page 1 unless the change *is* a page change. */
  const patchParams = (patch: Record<string, string | number | boolean | undefined>) => {
    setSearchParams(
      (prev) => {
        const next = new URLSearchParams(prev)
        for (const [key, value] of Object.entries(patch)) {
          if (value === undefined || value === '' || value === false) next.delete(key)
          else next.set(key, String(value))
        }
        if (!('page' in patch)) next.delete('page')
        return next
      },
      { replace: true },
    )
  }

  const filterValues: FilterValues = {
    category: query.category,
    brand: query.brand,
    minPrice: query.minPrice,
    maxPrice: query.maxPrice,
    inStock: query.inStock,
  }

  const clearFilters = () => {
    setSearchDraft('')
    setSearchParams({}, { replace: true })
  }

  const submitSearch = (e: React.FormEvent) => {
    e.preventDefault()
    patchParams({ search: searchDraft.trim() || undefined })
  }

  return (
    <Container className="py-8">
      <div className="mb-6 flex flex-col gap-4">
        <h1 className="text-2xl font-bold tracking-tight sm:text-3xl">{t('catalog.title')}</h1>

        <div className="flex flex-col gap-3 sm:flex-row sm:items-center">
          <form onSubmit={submitSearch} className="flex-1">
            <Input
              value={searchDraft}
              onChange={(e) => setSearchDraft(e.target.value)}
              placeholder={t('catalog.searchPlaceholder')}
              leftIcon={<Search className="h-4 w-4" strokeWidth={2} />}
            />
          </form>

          <div className="flex items-center gap-3">
            <Select
              value={query.sort}
              onChange={(e) => patchParams({ sort: e.target.value })}
              className="w-full sm:w-52"
            >
              {SORTS.map((s) => (
                <option key={s} value={s}>
                  {t(
                    `catalog.sort${s
                      .split('_')
                      .map((w) => w.charAt(0).toUpperCase() + w.slice(1))
                      .join('')}`,
                  )}
                </option>
              ))}
            </Select>

            {/* Mobile filter trigger */}
            <Button
              variant="outline"
              className="shrink-0 lg:hidden"
              onClick={() => setDrawerOpen(true)}
            >
              <SlidersHorizontal className="h-4 w-4" strokeWidth={2} />
              {t('catalog.filters')}
            </Button>
          </div>
        </div>

        {data && (
          <p className="text-sm text-fg-muted">
            {t('catalog.resultsCount', { count: data.totalCount })}
          </p>
        )}
      </div>

      <div className="flex gap-8">
        {/* Desktop sidebar */}
        <aside className="hidden w-64 shrink-0 lg:block">
          <div className="sticky top-24">
            <FilterSidebar
              values={filterValues}
              onChange={(patch) => patchParams(patch)}
              onClear={clearFilters}
            />
          </div>
        </aside>

        {/* Grid */}
        <div className="min-w-0 flex-1">
          {isError ? (
            <div className="flex flex-col items-center gap-4 py-24 text-center">
              <p className="text-fg-muted">{t('common.somethingWrong')}</p>
              <Button variant="outline" onClick={() => refetch()}>
                {t('common.retry')}
              </Button>
            </div>
          ) : isLoading ? (
            <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4">
              {Array.from({ length: 8 }).map((_, i) => (
                <ProductCardSkeleton key={i} />
              ))}
            </div>
          ) : data && data.items.length === 0 ? (
            <div className="flex flex-col items-center gap-3 py-24 text-center">
              <SearchX className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
              <h2 className="text-lg font-semibold">{t('catalog.empty')}</h2>
              <p className="max-w-sm text-sm text-fg-muted">{t('catalog.emptyHint')}</p>
              <Button variant="outline" onClick={clearFilters}>
                {t('catalog.clearFilters')}
              </Button>
            </div>
          ) : (
            <>
              <div
                className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-4"
                style={{ opacity: isPlaceholderData ? 0.6 : 1, transition: 'opacity 0.2s' }}
              >
                {data?.items.map((p) => (
                  <ProductCard key={p.id} product={p} />
                ))}
              </div>

              {data && (
                <Pagination
                  page={data.page}
                  totalPages={data.totalPages}
                  onChange={(page) => {
                    patchParams({ page })
                    window.scrollTo({ top: 0, behavior: 'smooth' })
                  }}
                  className="mt-10"
                />
              )}
            </>
          )}
        </div>
      </div>

      {/* Mobile filter drawer */}
      <AnimatePresence>
        {drawerOpen && (
          <motion.div
            className="fixed inset-0 z-50 lg:hidden"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            exit={{ opacity: 0 }}
          >
            <div
              className="absolute inset-0 bg-black/40"
              onClick={() => setDrawerOpen(false)}
            />
            <motion.div
              className="absolute inset-y-0 left-0 flex w-80 max-w-[85%] flex-col bg-bg p-5 shadow-elevated"
              initial={{ x: '-100%' }}
              animate={{ x: 0 }}
              exit={{ x: '-100%' }}
              transition={{ type: 'tween', duration: 0.25 }}
            >
              <div className="flex-1 overflow-y-auto">
                <FilterSidebar
                  values={filterValues}
                  onChange={(patch) => patchParams(patch)}
                  onClear={clearFilters}
                />
              </div>
              <Button className="mt-4 w-full" onClick={() => setDrawerOpen(false)}>
                {t('catalog.applyFilters')}
              </Button>
            </motion.div>
          </motion.div>
        )}
      </AnimatePresence>
    </Container>
  )
}
