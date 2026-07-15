import { useTranslation } from 'react-i18next'
import { Scale } from 'lucide-react'
import { cn } from '@/shared/lib/cn'
import { useCompareStore } from '@/shared/store/compare.store'

interface CompareButtonProps {
  slug: string
  variant?: 'icon' | 'button'
  className?: string
}

/** Toggle a product's membership in the compare set (capped by COMPARE_LIMIT). */
export function CompareButton({ slug, variant = 'icon', className }: CompareButtonProps) {
  const { t } = useTranslation()
  const slugs = useCompareStore((s) => s.slugs)
  const toggle = useCompareStore((s) => s.toggle)
  const isFull = useCompareStore((s) => s.isFull)

  const active = slugs.includes(slug)
  const disabled = !active && isFull()

  const handleClick = (e: React.MouseEvent) => {
    e.preventDefault()
    e.stopPropagation()
    toggle(slug)
  }

  const icon = <Scale size={variant === 'button' ? 20 : 18} strokeWidth={2} />


  if (variant === 'button') {
    return (
      <button
        type="button"
        onClick={handleClick}
        disabled={disabled}
        aria-pressed={active}
        aria-label={t('nav.compare')}
        title={disabled ? t('compare.full') : t('nav.compare')}
        className={cn(
          'inline-flex h-12 items-center justify-center gap-2 rounded-lg border border-border px-4 text-base font-medium transition-colors hover:bg-surface-2 disabled:cursor-not-allowed disabled:opacity-40',
          active ? 'text-primary' : 'text-fg',
          className,
        )}
      >
        {icon}
        <span className="sm:hidden">{t('nav.compare')}</span>
      </button>
    )
  }

  return (
    <button
      type="button"
      onClick={handleClick}
      disabled={disabled}
      aria-pressed={active}
      aria-label={t('nav.compare')}
      title={disabled ? t('compare.full') : t('nav.compare')}
      className={cn(
        'flex h-9 w-9 items-center justify-center rounded-full bg-bg/80 backdrop-blur transition-colors disabled:cursor-not-allowed disabled:opacity-40',
        active ? 'text-primary' : 'text-fg-muted hover:text-fg',
        className,
      )}
    >
      {icon}
    </button>
  )
}
