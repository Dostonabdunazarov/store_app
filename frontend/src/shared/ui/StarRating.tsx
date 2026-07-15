import { cn } from '@/shared/lib/cn'

interface StarRatingProps {
  /** 0–5, may be fractional; renders partial fill on the last star. */
  value: number
  /** Pixel size of each star. */
  size?: number
  className?: string
  /** When provided, stars become interactive buttons. */
  onChange?: (value: number) => void
}

function Star({ fill, size }: { fill: number; size: number }) {
  // fill: 0..1 fraction of this star that is colored.
  const clipId = `star-clip-${Math.round(fill * 100)}-${size}`
  return (
    <svg width={size} height={size} viewBox="0 0 24 24" className="shrink-0">
      <defs>
        <clipPath id={clipId}>
          <rect x="0" y="0" width={24 * fill} height="24" />
        </clipPath>
      </defs>
      <path
        d="M12 2l2.9 6.26L22 9.27l-5 4.87 1.18 6.88L12 17.77l-6.18 3.25L7 14.14 2 9.27l7.1-1.01L12 2z"
        className="fill-border"
      />
      <path
        d="M12 2l2.9 6.26L22 9.27l-5 4.87 1.18 6.88L12 17.77l-6.18 3.25L7 14.14 2 9.27l7.1-1.01L12 2z"
        className="fill-warning"
        clipPath={`url(#${clipId})`}
      />
    </svg>
  )
}

/** Read-only or interactive 5-star rating display. */
export function StarRating({ value, size = 16, className, onChange }: StarRatingProps) {
  const stars = [0, 1, 2, 3, 4]

  if (onChange) {
    return (
      <div className={cn('flex items-center gap-0.5', className)}>
        {stars.map((i) => (
          <button
            key={i}
            type="button"
            onClick={() => onChange(i + 1)}
            aria-label={`${i + 1}`}
            className="rounded transition-transform hover:scale-110 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-primary"
          >
            <Star fill={value >= i + 1 ? 1 : 0} size={size} />
          </button>
        ))}
      </div>
    )
  }

  return (
    <div className={cn('flex items-center gap-0.5', className)} aria-hidden>
      {stars.map((i) => {
        const fill = Math.min(1, Math.max(0, value - i))
        return <Star key={i} fill={fill} size={size} />
      })}
    </div>
  )
}
