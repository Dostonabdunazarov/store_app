import { useEffect, useRef, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { keepPreviousData, useQuery } from '@tanstack/react-query'
import { Search, X } from 'lucide-react'
import { catalogApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { paths } from '@/app/routes/paths'
import { formatPrice } from '@/shared/lib/format'
import { ProductImage } from '@/shared/ui/ProductImage'
import { cn } from '@/shared/lib/cn'

const DEBOUNCE_MS = 250
const MAX_RESULTS = 6

/**
 * Header search box with a live results dropdown. Debounces the input and
 * queries the products API (searches across ALL products). Arrow keys move the
 * highlight; Enter opens the highlighted product or, if none, the full catalog
 * results page for the term. Escape / outside-click closes the dropdown.
 */
export function HeaderSearch({ className }: { className?: string }) {
  const { t } = useTranslation()
  const navigate = useNavigate()

  const [term, setTerm] = useState('')
  const [debounced, setDebounced] = useState('')
  const [open, setOpen] = useState(false)
  const [active, setActive] = useState(-1) // highlighted result index (-1 = none)

  const rootRef = useRef<HTMLDivElement>(null)
  const inputRef = useRef<HTMLInputElement>(null)

  // Debounce the term that actually drives the query.
  useEffect(() => {
    const id = setTimeout(() => setDebounced(term.trim()), DEBOUNCE_MS)
    return () => clearTimeout(id)
  }, [term])

  const enabled = debounced.length >= 2
  const { data, isFetching } = useQuery({
    queryKey: qk.products({ search: debounced, page: 1, pageSize: MAX_RESULTS }),
    queryFn: () => catalogApi.products({ search: debounced, page: 1, pageSize: MAX_RESULTS }),
    enabled,
    placeholderData: keepPreviousData,
  })

  const results = enabled ? (data?.items ?? []) : []

  // Close on outside click.
  useEffect(() => {
    const onDown = (e: MouseEvent) => {
      if (rootRef.current && !rootRef.current.contains(e.target as Node)) setOpen(false)
    }
    document.addEventListener('mousedown', onDown)
    return () => document.removeEventListener('mousedown', onDown)
  }, [])

  // Reset highlight whenever the result set changes.
  useEffect(() => setActive(-1), [debounced])

  const goToCatalog = (q: string) => {
    const query = q.trim()
    if (!query) return
    setOpen(false)
    inputRef.current?.blur()
    navigate(`${paths.catalog}?search=${encodeURIComponent(query)}`)
  }

  const goToProduct = (slug: string) => {
    setOpen(false)
    setTerm('')
    inputRef.current?.blur()
    navigate(paths.product(slug))
  }

  const onKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Escape') {
      setOpen(false)
      inputRef.current?.blur()
      return
    }
    if (e.key === 'ArrowDown') {
      e.preventDefault()
      setOpen(true)
      setActive((i) => Math.min(i + 1, results.length - 1))
      return
    }
    if (e.key === 'ArrowUp') {
      e.preventDefault()
      setActive((i) => Math.max(i - 1, -1))
      return
    }
    if (e.key === 'Enter') {
      e.preventDefault()
      if (active >= 0 && results[active]) goToProduct(results[active].slug)
      else goToCatalog(term)
    }
  }

  const clear = () => {
    setTerm('')
    setDebounced('')
    setActive(-1)
    inputRef.current?.focus()
  }

  const showDropdown = open && enabled

  return (
    <div ref={rootRef} className={cn('relative', className)}>
      <form
        role="search"
        onSubmit={(e) => {
          e.preventDefault()
          goToCatalog(term)
        }}
      >
        <div className="relative">
          <Search
            className="pointer-events-none absolute left-3.5 top-1/2 h-5 w-5 -translate-y-1/2 text-fg-subtle"
            strokeWidth={2}
          />
          <input
            ref={inputRef}
            type="search"
            value={term}
            onChange={(e) => {
              setTerm(e.target.value)
              setOpen(true)
            }}
            onFocus={() => setOpen(true)}
            onKeyDown={onKeyDown}
            placeholder={t('nav.searchPlaceholder')}
            aria-label={t('common.search')}
            autoComplete="off"
            className="h-12 w-full rounded-xl border border-border bg-surface pl-11 pr-10 text-base text-fg transition-colors placeholder:text-fg-subtle focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-1 focus:ring-offset-bg [&::-webkit-search-cancel-button]:appearance-none"
          />
          {term && (
            <button
              type="button"
              onClick={clear}
              aria-label="Clear search"
              className="absolute right-3 top-1/2 flex h-6 w-6 -translate-y-1/2 items-center justify-center rounded-full text-fg-subtle transition-colors hover:text-fg"
            >
              <X className="h-4 w-4" strokeWidth={2} />
            </button>
          )}
        </div>
      </form>

      {showDropdown && (
        <div className="glass-strong absolute left-0 right-0 top-full z-50 mt-2 overflow-hidden rounded-xl border shadow-elevated">
          {results.length > 0 ? (
            <ul className="max-h-[70vh] overflow-y-auto py-1">
              {results.map((p, i) => (
                <li key={p.id}>
                  <button
                    type="button"
                    onMouseEnter={() => setActive(i)}
                    onClick={() => goToProduct(p.slug)}
                    className={cn(
                      'flex w-full items-center gap-3 px-3 py-2 text-left transition-colors',
                      i === active ? 'bg-surface-2' : 'hover:bg-surface-2',
                    )}
                  >
                    <ProductImage
                      src={p.imageUrl}
                      alt={p.name}
                      className="h-11 w-11 shrink-0 rounded-md"
                    />
                    <span className="min-w-0 flex-1">
                      <span className="block truncate text-sm font-medium text-fg">{p.name}</span>
                      <span className="block text-xs text-fg-muted">{p.brandName}</span>
                    </span>
                    <span className="shrink-0 text-sm font-semibold text-fg">
                      {formatPrice(p.price, t('common.currency'))}
                    </span>
                  </button>
                </li>
              ))}
              <li className="border-t border-border">
                <button
                  type="button"
                  onClick={() => goToCatalog(term)}
                  className="flex w-full items-center gap-2 px-3 py-2.5 text-sm font-medium text-primary transition-colors hover:bg-surface-2"
                >
                  <Search className="h-4 w-4" strokeWidth={2} />
                  {t('nav.searchViewAll')}
                </button>
              </li>
            </ul>
          ) : (
            <div className="px-3 py-6 text-center text-sm text-fg-muted">
              {isFetching ? t('common.loading') : t('nav.searchNoResults')}
            </div>
          )}
        </div>
      )}
    </div>
  )
}
