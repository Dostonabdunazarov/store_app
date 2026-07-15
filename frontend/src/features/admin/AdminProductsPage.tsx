import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { Card, CardBody } from '@/shared/ui/Card'
import { Skeleton } from '@/shared/ui/Skeleton'
import { Button } from '@/shared/ui/Button'
import { Badge } from '@/shared/ui/Badge'
import { Input } from '@/shared/ui/Input'
import { ProductImage } from '@/shared/ui/ProductImage'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { getErrorMessage } from '@/shared/api/client'
import { currentLang } from '@/shared/lib/i18n'
import type { AdminProductDto } from '@/shared/api/types'
import { useAdminProducts, useDeleteProduct } from './adminHooks'

function productName(p: AdminProductDto): string {
  const lang = currentLang()
  return (
    p.translations.find((t) => t.lang === lang)?.name ??
    p.translations.find((t) => t.lang === 'ru')?.name ??
    p.translations[0]?.name ??
    p.slug
  )
}

export function AdminProductsPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const currency = t('common.currency')
  const { data, isLoading, isError } = useAdminProducts()
  const del = useDeleteProduct()
  const [query, setQuery] = useState('')
  const [error, setError] = useState<string | null>(null)

  if (isLoading) {
    return (
      <div className="space-y-4">
        <Skeleton className="h-6 w-40" />
        <Skeleton className="h-9 w-64" />
        <Card>
          <CardBody className="p-0">
            <ul className="divide-y divide-border">
              {Array.from({ length: 6 }).map((_, i) => (
                <li key={i} className="flex items-center gap-3 px-4 py-3">
                  <Skeleton className="h-12 w-12 shrink-0 rounded-lg" />
                  <div className="min-w-0 flex-1 space-y-2">
                    <Skeleton className="h-4 w-1/2" />
                    <Skeleton className="h-3 w-1/3" />
                  </div>
                  <Skeleton className="h-8 w-16" />
                </li>
              ))}
            </ul>
          </CardBody>
        </Card>
      </div>
    )
  }
  if (isError) return <p className="text-sm text-danger">{t('common.somethingWrong')}</p>

  const all = data ?? []
  const q = query.trim().toLowerCase()
  const products = q
    ? all.filter((p) => productName(p).toLowerCase().includes(q) || p.slug.includes(q))
    : all

  const onDelete = (p: AdminProductDto) => {
    if (!window.confirm(t('admin.confirmDeleteProduct', { name: productName(p) }))) return
    setError(null)
    del.mutate(p.id, { onError: (e) => setError(getErrorMessage(e)) })
  }

  return (
    <div className="space-y-4">
      <div className="flex flex-wrap items-center justify-between gap-3">
        <h2 className="text-lg font-semibold">{t('admin.products')}</h2>
        <Button size="sm" onClick={() => navigate(paths.adminProductNew)}>
          + {t('admin.newProduct')}
        </Button>
      </div>

      <div className="max-w-xs">
        <Input
          placeholder={t('catalog.searchPlaceholder')}
          value={query}
          onChange={(e) => setQuery(e.target.value)}
        />
      </div>

      {error && <p className="text-sm text-danger">{error}</p>}

      <Card>
        <CardBody className="p-0">
          {products.length === 0 ? (
            <p className="px-5 py-8 text-center text-sm text-fg-muted">{t('catalog.empty')}</p>
          ) : (
            <ul className="divide-y divide-border">
              {products.map((p) => (
                <li key={p.id} className="flex items-center gap-3 px-4 py-3">
                  <div className="h-12 w-12 shrink-0 overflow-hidden rounded-lg bg-surface-2">
                    <ProductImage
                      src={p.imageUrls[0] ?? null}
                      alt={productName(p)}
                      className="h-full w-full object-cover"
                    />
                  </div>
                  <div className="min-w-0 flex-1">
                    <p className="truncate text-sm font-medium">{productName(p)}</p>
                    <p className="truncate text-xs text-fg-subtle">
                      {p.slug} · {p.brandName}
                    </p>
                  </div>
                  <div className="hidden items-center gap-2 sm:flex">
                    {!p.isActive && <Badge tone="neutral">{t('admin.inactive')}</Badge>}
                    <Badge tone={p.stock === 0 ? 'danger' : p.stock < 5 ? 'warning' : 'success'}>
                      {t('admin.stockLabel', { count: p.stock })}
                    </Badge>
                  </div>
                  <span className="w-28 shrink-0 text-right text-sm font-semibold">
                    {formatPrice(p.price, currency)}
                  </span>
                  <div className="flex shrink-0 items-center gap-1.5">
                    <Link to={paths.adminProductEdit(p.id)}>
                      <Button variant="outline" size="sm">
                        {t('admin.edit')}
                      </Button>
                    </Link>
                    <Button
                      variant="ghost"
                      size="sm"
                      className="text-danger"
                      disabled={!p.isActive || del.isPending}
                      onClick={() => onDelete(p)}
                    >
                      {t('admin.delete')}
                    </Button>
                  </div>
                </li>
              ))}
            </ul>
          )}
        </CardBody>
      </Card>
    </div>
  )
}
