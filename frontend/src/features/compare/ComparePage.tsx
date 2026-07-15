import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useQueries } from '@tanstack/react-query'
import { Check, Scale, X } from 'lucide-react'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { Skeleton } from '@/shared/ui/Skeleton'
import { StarRating } from '@/shared/ui/StarRating'
import { ProductImage } from '@/shared/ui/ProductImage'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { catalogApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { useCompareStore } from '@/shared/store/compare.store'
import { useCartStore } from '@/shared/store/cart.store'
import type { ProductDetailDto } from '@/shared/api/types'

export function ComparePage() {
  const { t } = useTranslation()
  const slugs = useCompareStore((s) => s.slugs)
  const remove = useCompareStore((s) => s.remove)
  const clear = useCompareStore((s) => s.clear)
  const addToCart = useCartStore((s) => s.add)

  const results = useQueries({
    queries: slugs.map((slug) => ({
      queryKey: qk.product(slug),
      queryFn: () => catalogApi.product(slug),
    })),
  })

  const isLoading = results.some((r) => r.isLoading)
  const products = results
    .map((r) => r.data)
    .filter((p): p is ProductDetailDto => !!p)

  if (slugs.length === 0) {
    return (
      <Container className="py-24">
        <div className="flex flex-col items-center gap-3 text-center">
          <Scale className="h-14 w-14 text-fg-subtle" strokeWidth={1.5} />
          <h1 className="text-lg font-semibold">{t('compare.empty')}</h1>
          <p className="max-w-sm text-sm text-fg-muted">{t('compare.emptyHint')}</p>
          <Link to={paths.catalog}>
            <Button variant="outline">{t('product.backToCatalog')}</Button>
          </Link>
        </div>
      </Container>
    )
  }

  if (isLoading) {
    return (
      <Container className="py-8">
        <Skeleton className="mb-6 h-8 w-48" />
        <div className="flex gap-3 overflow-x-auto">
          {Array.from({ length: Math.min(slugs.length, 4) }).map((_, i) => (
            <div key={i} className="flex min-w-52 flex-col gap-3">
              <Skeleton className="aspect-square rounded-lg" />
              <Skeleton className="h-4 w-3/4" />
              <Skeleton className="h-5 w-24" />
              <Skeleton className="h-4 w-full" />
              <Skeleton className="h-4 w-full" />
              <Skeleton className="mt-2 h-9 w-full" />
            </div>
          ))}
        </div>
      </Container>
    )
  }

  // Union of attribute keys across all products, preserving first-seen order + label.
  const attrKeys: { key: string; label: string }[] = []
  const seen = new Set<string>()
  for (const p of products) {
    for (const a of p.attributes) {
      if (!seen.has(a.key)) {
        seen.add(a.key)
        attrKeys.push({ key: a.key, label: a.label })
      }
    }
  }

  const valueOf = (p: ProductDetailDto, key: string) =>
    p.attributes.find((a) => a.key === key)?.value ?? '—'

  return (
    <Container className="py-8">
      <div className="mb-6 flex items-center justify-between">
        <h1 className="text-2xl font-bold tracking-tight sm:text-3xl">{t('nav.compare')}</h1>
        <button
          type="button"
          onClick={clear}
          className="text-sm text-fg-subtle transition-colors hover:text-danger"
        >
          {t('cart.clear')}
        </button>
      </div>

      <div className="overflow-x-auto">
        <table className="w-full border-collapse text-sm">
          <thead>
            <tr>
              <th className="w-40 min-w-40" />
              {products.map((p) => (
                <th key={p.id} className="min-w-52 p-3 align-top">
                  <div className="flex flex-col gap-3">
                    <div className="relative">
                      <Link to={paths.product(p.slug)}>
                        <ProductImage
                          src={p.imageUrls[0] ?? null}
                          alt={p.name}
                          className="aspect-square rounded-lg"
                        />
                      </Link>
                      <button
                        type="button"
                        onClick={() => remove(p.slug)}
                        aria-label={t('compare.remove')}
                        className="absolute right-2 top-2 flex h-8 w-8 items-center justify-center rounded-full bg-bg/80 text-fg-muted backdrop-blur transition-colors hover:text-danger"
                      >
                        <X className="h-4 w-4" strokeWidth={2.5} />
                      </button>
                    </div>
                    <Link
                      to={paths.product(p.slug)}
                      className="line-clamp-2 text-left text-sm font-semibold text-fg transition-colors hover:text-primary"
                    >
                      {p.name}
                    </Link>
                  </div>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            <CompareRow label={t('catalog.price')}>
              {products.map((p) => (
                <td key={p.id} className="p-3 text-center font-bold">
                  {formatPrice(p.price, t('common.currency'))}
                </td>
              ))}
            </CompareRow>

            <CompareRow label={t('product.reviews')}>
              {products.map((p) => (
                <td key={p.id} className="p-3">
                  <div className="flex flex-col items-center gap-1">
                    <StarRating value={p.ratingAverage} size={14} />
                    <span className="text-xs text-fg-subtle">
                      {p.ratingCount > 0 ? p.ratingAverage.toFixed(1) : '—'}
                    </span>
                  </div>
                </td>
              ))}
            </CompareRow>

            <CompareRow label={t('catalog.brand')}>
              {products.map((p) => (
                <td key={p.id} className="p-3 text-center text-fg-muted">
                  {p.brandName}
                </td>
              ))}
            </CompareRow>

            <CompareRow label={t('product.inStock')}>
              {products.map((p) => (
                <td key={p.id} className="p-3 text-center">
                  {p.inStock ? (
                    <Check className="mx-auto h-4 w-4 text-success" strokeWidth={2.5} />
                  ) : (
                    <X className="mx-auto h-4 w-4 text-danger" strokeWidth={2.5} />
                  )}
                </td>
              ))}
            </CompareRow>

            {attrKeys.map((attr) => (
              <CompareRow key={attr.key} label={attr.label}>
                {products.map((p) => (
                  <td key={p.id} className="p-3 text-center text-fg-muted">
                    {valueOf(p, attr.key)}
                  </td>
                ))}
              </CompareRow>
            ))}

            <tr>
              <td className="p-3" />
              {products.map((p) => (
                <td key={p.id} className="p-3">
                  <Button
                    size="sm"
                    className="w-full"
                    disabled={!p.inStock}
                    onClick={() => addToCart(p)}
                  >
                    {t('product.addToCart')}
                  </Button>
                </td>
              ))}
            </tr>
          </tbody>
        </table>
      </div>
    </Container>
  )
}

function CompareRow({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <tr className="border-t border-border">
      <th className="p-3 text-left align-middle text-sm font-medium text-fg-subtle">{label}</th>
      {children}
    </tr>
  )
}
