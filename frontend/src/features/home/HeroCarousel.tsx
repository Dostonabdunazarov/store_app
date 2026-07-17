import { useCallback, useEffect, useRef, useState } from 'react'
import { Link } from 'react-router-dom'
import { motion } from 'motion/react'
import { ChevronLeft, ChevronRight } from 'lucide-react'
import { ProductImage } from '@/shared/ui/ProductImage'
import { cn } from '@/shared/lib/cn'

export interface HeroSlide {
  id: string
  name: string
  imageUrl: string | null
  href: string
}

const AUTOPLAY_MS = 4500

/** Plain full-width slider: one slide at a time on a horizontal track that
 *  slides left/right. Auto-advances, pauses on hover, supports arrows + dot
 *  indicators and swipe. No 3D transforms — nothing can overflow the viewport. */
export function HeroCarousel({ slides }: { slides: HeroSlide[] }) {
  const [index, setIndex] = useState(0)
  const [paused, setPaused] = useState(false)
  const count = slides.length

  const go = useCallback(
    (next: number) => setIndex(((next % count) + count) % count),
    [count],
  )

  useEffect(() => {
    if (paused || count <= 1) return
    const id = setInterval(() => setIndex((i) => (i + 1) % count), AUTOPLAY_MS)
    return () => clearInterval(id)
  }, [paused, count])

  // Pointer swipe: a horizontal drag past the threshold advances a slide.
  const SWIPE_THRESHOLD = 50
  const drag = useRef({ active: false, startX: 0, dx: 0, moved: false })

  const onPointerDown = (e: React.PointerEvent<HTMLDivElement>) => {
    if (count <= 1) return
    drag.current = { active: true, startX: e.clientX, dx: 0, moved: false }
  }
  const onPointerMove = (e: React.PointerEvent<HTMLDivElement>) => {
    if (!drag.current.active) return
    drag.current.dx = e.clientX - drag.current.startX
    if (!drag.current.moved && Math.abs(drag.current.dx) > 8) {
      drag.current.moved = true
      e.currentTarget.setPointerCapture(e.pointerId)
      setPaused(true)
    }
  }
  const onPointerUp = (e: React.PointerEvent<HTMLDivElement>) => {
    if (!drag.current.active) return
    if (e.currentTarget.hasPointerCapture(e.pointerId)) {
      e.currentTarget.releasePointerCapture(e.pointerId)
    }
    const { dx, moved } = drag.current
    drag.current.active = false
    if (!moved) return // it was a click, not a drag — let it through
    if (dx <= -SWIPE_THRESHOLD) setIndex((i) => (i + 1) % count)
    else if (dx >= SWIPE_THRESHOLD) setIndex((i) => (i - 1 + count) % count)
  }

  // Cancel a click that follows a real drag so it doesn't navigate the slide link.
  const onClickCapture = (e: React.MouseEvent<HTMLDivElement>) => {
    if (drag.current.moved) {
      e.preventDefault()
      e.stopPropagation()
      drag.current.moved = false
    }
  }

  if (count === 0) return null

  return (
    <div
      className={cn(
        'group relative h-[56vh] max-h-160 min-h-96 w-full touch-pan-y overflow-hidden rounded-2xl',
        count > 1 && 'cursor-grab select-none active:cursor-grabbing',
      )}
      onMouseEnter={() => setPaused(true)}
      onMouseLeave={() => setPaused(false)}
      onPointerDown={onPointerDown}
      onPointerMove={onPointerMove}
      onPointerUp={onPointerUp}
      onPointerCancel={onPointerUp}
      onClickCapture={onClickCapture}
    >
      {/* Track: one slide per viewport width, translated by -index * 100%. */}
      <motion.div
        className="flex h-full"
        style={{ width: `${count * 100}%` }}
        initial={false}
        animate={{ x: `${-index * (100 / count)}%` }}
        transition={{ duration: 0.7, ease: [0.16, 1, 0.3, 1] }}
      >
        {slides.map((s) => (
          <Link
            key={s.id}
            to={s.href}
            aria-label={s.name}
            draggable={false}
            className="relative block h-full shrink-0"
            style={{ width: `${100 / count}%` }}
          >
            <ProductImage
              src={s.imageUrl}
              alt={s.name}
              draggable={false}
              eager
              className="h-full w-full"
            />
            {/* Caption gradient */}
            <div className="pointer-events-none absolute inset-x-0 bottom-0 bg-linear-to-t from-black/70 via-black/25 to-transparent px-4 pb-8 pt-16 sm:px-8 lg:px-12">
              <span className="block text-lg font-semibold text-white drop-shadow sm:text-2xl">
                {s.name}
              </span>
            </div>
          </Link>
        ))}
      </motion.div>

      {count > 1 && (
        <>
          {/* Arrows */}
          <button
            type="button"
            onClick={() => go(index - 1)}
            aria-label="Previous"
            className="absolute left-4 top-1/2 z-40 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full bg-black/40 text-white opacity-0 backdrop-blur transition-opacity hover:bg-black/60 group-hover:opacity-100 sm:left-6"
          >
            <ChevronLeft className="h-6 w-6" strokeWidth={2.5} />
          </button>
          <button
            type="button"
            onClick={() => go(index + 1)}
            aria-label="Next"
            className="absolute right-4 top-1/2 z-40 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full bg-black/40 text-white opacity-0 backdrop-blur transition-opacity hover:bg-black/60 group-hover:opacity-100 sm:right-6"
          >
            <ChevronRight className="h-6 w-6" strokeWidth={2.5} />
          </button>

          {/* Dots */}
          <div className="absolute inset-x-0 bottom-3 z-40 flex items-center justify-center gap-1.5">
            {slides.map((s, i) => (
              <button
                key={s.id}
                type="button"
                onClick={() => go(i)}
                aria-label={`Go to slide ${i + 1}`}
                aria-current={i === index}
                className={cn(
                  'h-1.5 rounded-full bg-white/60 transition-all',
                  i === index ? 'w-6 bg-white' : 'w-1.5 hover:bg-white/80',
                )}
              />
            ))}
          </div>
        </>
      )}
    </div>
  )
}
