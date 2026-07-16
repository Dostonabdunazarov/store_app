import { useState } from 'react'
import { ImageOff } from 'lucide-react'
import { cn } from '@/shared/lib/cn'

interface ProductImageProps {
  src: string | null | undefined
  alt: string
  className?: string
  draggable?: boolean
  /** Load immediately instead of lazily — use for above-the-fold images
   *  (e.g. carousel slides) so they don't pop in / flicker on transition. */
  eager?: boolean
}

/** Product image with a graceful placeholder for missing/broken URLs. */
export function ProductImage({ src, alt, className, draggable, eager }: ProductImageProps) {
  const [failed, setFailed] = useState(false)
  const show = src && !failed

  return (
    <div className={cn('relative overflow-hidden bg-surface-2', className)}>
      {show ? (
        <img
          src={src}
          alt={alt}
          loading={eager ? 'eager' : 'lazy'}
          draggable={draggable}
          onError={() => setFailed(true)}
          className="h-full w-full object-cover"
        />
      ) : (
        <div className="flex h-full w-full items-center justify-center text-fg-subtle">
          <ImageOff className="h-10 w-10" strokeWidth={1.5} />
        </div>
      )}
    </div>
  )
}
