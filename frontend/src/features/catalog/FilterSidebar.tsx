import { useTranslation } from 'react-i18next'
import { Button } from '@/shared/ui/Button'
import { Input } from '@/shared/ui/Input'
import { useCategories, useBrands } from './hooks'
import { cn } from '@/shared/lib/cn'

export interface FilterValues {
  category?: string
  brand?: string
  minPrice?: number
  maxPrice?: number
  inStock?: boolean
}

interface FilterSidebarProps {
  values: FilterValues
  onChange: (patch: Partial<FilterValues>) => void
  onClear: () => void
  className?: string
}

function Section({ title, children }: { title: string; children: React.ReactNode }) {
  return (
    <div className="flex flex-col gap-2.5 border-b border-border pb-5 last:border-0 last:pb-0">
      <h3 className="text-sm font-semibold text-fg">{title}</h3>
      {children}
    </div>
  )
}

export function FilterSidebar({ values, onChange, onClear, className }: FilterSidebarProps) {
  const { t } = useTranslation()
  const { data: categories } = useCategories()
  const { data: brands } = useBrands()

  const radioRow = (
    key: string,
    label: string,
    checked: boolean,
    onSelect: () => void,
    count?: number,
  ) => (
    <button
      key={key}
      type="button"
      onClick={onSelect}
      className={cn(
        'flex items-center justify-between rounded-md px-2 py-1.5 text-left text-sm transition-colors',
        checked ? 'bg-primary/10 font-medium text-primary' : 'text-fg-muted hover:bg-surface-2',
      )}
    >
      <span>{label}</span>
      {count !== undefined && <span className="text-xs text-fg-subtle">{count}</span>}
    </button>
  )

  return (
    <div className={cn('flex flex-col gap-5', className)}>
      <div className="flex items-center justify-between">
        <h2 className="text-base font-bold">{t('catalog.filters')}</h2>
        <button
          type="button"
          onClick={onClear}
          className="text-xs font-medium text-primary hover:underline"
        >
          {t('catalog.clearFilters')}
        </button>
      </div>

      <Section title={t('catalog.category')}>
        <div className="flex flex-col gap-0.5">
          {radioRow('all', t('common.all'), !values.category, () => onChange({ category: undefined }))}
          {categories?.map((c) =>
            radioRow(
              c.slug,
              c.name,
              values.category === c.slug,
              () => onChange({ category: c.slug }),
              c.productCount,
            ),
          )}
        </div>
      </Section>

      <Section title={t('catalog.brand')}>
        <div className="flex max-h-56 flex-col gap-0.5 overflow-y-auto">
          {radioRow('all', t('common.all'), !values.brand, () => onChange({ brand: undefined }))}
          {brands?.map((b) =>
            radioRow(b.slug, b.name, values.brand === b.slug, () => onChange({ brand: b.slug })),
          )}
        </div>
      </Section>

      <Section title={t('catalog.price')}>
        <div className="flex items-center gap-2">
          <Input
            type="number"
            min={0}
            placeholder={t('catalog.priceFrom')}
            value={values.minPrice ?? ''}
            onChange={(e) =>
              onChange({ minPrice: e.target.value ? Number(e.target.value) : undefined })
            }
          />
          <span className="text-fg-subtle">—</span>
          <Input
            type="number"
            min={0}
            placeholder={t('catalog.priceTo')}
            value={values.maxPrice ?? ''}
            onChange={(e) =>
              onChange({ maxPrice: e.target.value ? Number(e.target.value) : undefined })
            }
          />
        </div>
      </Section>

      <Section title={t('product.inStock')}>
        <label className="flex cursor-pointer items-center gap-2.5 text-sm text-fg-muted">
          <input
            type="checkbox"
            checked={!!values.inStock}
            onChange={(e) => onChange({ inStock: e.target.checked || undefined })}
            className="h-4 w-4 rounded border-border accent-primary"
          />
          {t('catalog.inStockOnly')}
        </label>
      </Section>
    </div>
  )
}

/** Re-export as a component so the mobile drawer can reuse the same body with an Apply button. */
export function MobileFilterActions({ onApply }: { onApply: () => void }) {
  const { t } = useTranslation()
  return (
    <Button className="w-full" onClick={onApply}>
      {t('catalog.applyFilters')}
    </Button>
  )
}
