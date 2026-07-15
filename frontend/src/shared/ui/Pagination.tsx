import { ChevronLeft, ChevronRight } from 'lucide-react'
import { cn } from '@/shared/lib/cn'

interface PaginationProps {
  page: number
  totalPages: number
  onChange: (page: number) => void
  className?: string
}

/** Build a compact page list with ellipses: 1 … 4 5 [6] 7 8 … 20 */
function pageList(page: number, total: number): (number | 'gap')[] {
  if (total <= 7) return Array.from({ length: total }, (_, i) => i + 1)
  const out: (number | 'gap')[] = [1]
  const start = Math.max(2, page - 1)
  const end = Math.min(total - 1, page + 1)
  if (start > 2) out.push('gap')
  for (let p = start; p <= end; p++) out.push(p)
  if (end < total - 1) out.push('gap')
  out.push(total)
  return out
}

export function Pagination({ page, totalPages, onChange, className }: PaginationProps) {
  if (totalPages <= 1) return null
  const pages = pageList(page, totalPages)

  const arrow = (dir: 'prev' | 'next', disabled: boolean) => (
    <button
      type="button"
      disabled={disabled}
      onClick={() => onChange(dir === 'prev' ? page - 1 : page + 1)}
      aria-label={dir}
      className="flex h-9 w-9 items-center justify-center rounded-lg border border-border text-fg transition-colors hover:bg-surface-2 disabled:cursor-not-allowed disabled:opacity-40"
    >
      {dir === 'prev' ? (
        <ChevronLeft className="h-4 w-4" strokeWidth={2} />
      ) : (
        <ChevronRight className="h-4 w-4" strokeWidth={2} />
      )}
    </button>
  )

  return (
    <nav className={cn('flex items-center justify-center gap-1.5', className)} aria-label="pagination">
      {arrow('prev', page <= 1)}
      {pages.map((p, i) =>
        p === 'gap' ? (
          <span key={`gap-${i}`} className="px-1 text-fg-subtle">
            …
          </span>
        ) : (
          <button
            key={p}
            type="button"
            onClick={() => onChange(p)}
            aria-current={p === page}
            className={cn(
              'h-9 min-w-9 rounded-lg border px-3 text-sm font-medium transition-colors',
              p === page
                ? 'border-primary bg-primary text-primary-fg'
                : 'border-border text-fg hover:bg-surface-2',
            )}
          >
            {p}
          </button>
        ),
      )}
      {arrow('next', page >= totalPages)}
    </nav>
  )
}
