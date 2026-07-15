import { motion } from 'motion/react'
import { useTranslation } from 'react-i18next'
import { Heart } from 'lucide-react'
import { cn } from '@/shared/lib/cn'
import { useFavoriteToggle } from './favoriteHooks'
import type { ProductDetailDto, ProductListItemDto } from '@/shared/api/types'

interface FavoriteButtonProps {
  product: ProductListItemDto | ProductDetailDto
  /** 'icon' = bare heart (card overlay); 'button' = bordered button (detail page). */
  variant?: 'icon' | 'button'
  className?: string
}

/** Heart toggle backed by unified guest/server favorite state. */
export function FavoriteButton({ product, variant = 'icon', className }: FavoriteButtonProps) {
  const { t } = useTranslation()
  const [isFavorite, toggle] = useFavoriteToggle(product)

  const handleClick = (e: React.MouseEvent) => {
    e.preventDefault()
    e.stopPropagation()
    toggle()
  }

  const heart = (
    <motion.span
      key={String(isFavorite)}
      initial={{ scale: 0.6 }}
      animate={{ scale: 1 }}
      transition={{ type: 'spring', stiffness: 500, damping: 15 }}
      className="inline-flex"
    >
      <Heart
        size={variant === 'button' ? 20 : 18}
        fill={isFavorite ? 'currentColor' : 'none'}
        strokeWidth={2}
      />
    </motion.span>
  )

  if (variant === 'button') {
    return (
      <button
        type="button"
        onClick={handleClick}
        aria-pressed={isFavorite}
        aria-label={t('nav.favorites')}
        className={cn(
          'inline-flex h-12 items-center justify-center gap-2 rounded-lg border border-border px-4 text-base font-medium transition-colors hover:bg-surface-2',
          isFavorite ? 'text-danger' : 'text-fg',
          className,
        )}
      >
        {heart}
        <span className="sm:hidden">{t('nav.favorites')}</span>
      </button>
    )
  }

  return (
    <button
      type="button"
      onClick={handleClick}
      aria-pressed={isFavorite}
      aria-label={t('nav.favorites')}
      className={cn(
        'flex h-9 w-9 items-center justify-center rounded-full bg-bg/80 backdrop-blur transition-colors',
        isFavorite ? 'text-danger' : 'text-fg-muted hover:text-fg',
        className,
      )}
    >
      {heart}
    </button>
  )
}
