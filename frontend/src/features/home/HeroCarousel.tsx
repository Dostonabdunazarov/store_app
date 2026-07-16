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

const AUTOPLAY_MS = 3500

/** Position of a slide relative to the active one: center (big, straight),
 *  left / right (smaller, tilted "curved" side layers), or hidden. */
type Slot = 'center' | 'left' | 'right' | 'hidden'

/** Transform + styling per slot — the two side layers are scaled down,
 *  pushed outward, rotated on the Y axis and dimmed to read as "curved". */
const SLOT_STYLES: Record<Exclude<Slot, 'hidden'>, { x: string; rotateY: number; scale: number; z: number; opacity: number; blur: number }> = {
  left: { x: '-56%', rotateY: 38, scale: 0.82, z: 10, opacity: 0.75, blur: 1 },
  center: { x: '0%', rotateY: 0, scale: 1, z: 30, opacity: 1, blur: 0 },
  right: { x: '56%', rotateY: -38, scale: 0.82, z: 10, opacity: 0.75, blur: 1 },
}

/** 3-layer coverflow hero carousel: a large centered slide flanked by two
 *  smaller, tilted "curved" side layers. Auto-advances, pauses on hover,
 *  supports arrows + dot indicators, and degrades to a single slide. */
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

  // Pointer swipe/drag: a horizontal drag past the threshold advances a slide.
  // Pointer capture guarantees we keep receiving moves even as the pointer
  // crosses child slides; we accumulate the delta from move events (the
  // pointerup coordinate is unreliable under the stage's 3D transform).
  const SWIPE_THRESHOLD = 50
  const drag = useRef({ active: false, startX: 0, dx: 0, moved: false })

  const onPointerDown = (e: React.PointerEvent<HTMLDivElement>) => {
    if (count <= 1) return
    // Don't capture yet — a plain click must still reach the arrows / side slides.
    // Capture only starts once the pointer actually moves (in onPointerMove).
    drag.current = { active: true, startX: e.clientX, dx: 0, moved: false }
  }
  const onPointerMove = (e: React.PointerEvent<HTMLDivElement>) => {
    if (!drag.current.active) return
    drag.current.dx = e.clientX - drag.current.startX
    if (!drag.current.moved && Math.abs(drag.current.dx) > 8) {
      // Promote to a real drag: now capture the pointer so we keep getting moves
      // even as it crosses child slides, and pause autoplay.
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

  // Cancel a click that follows a real drag so it doesn't navigate the center link.
  const onClickCapture = (e: React.MouseEvent<HTMLDivElement>) => {
    if (drag.current.moved) {
      e.preventDefault()
      e.stopPropagation()
      drag.current.moved = false
    }
  }

  if (count === 0) return null

  // Compute the slot for each slide relative to the active index.
  const slotFor = (i: number): Slot => {
    if (i === index) return 'center'
    if (count > 1 && i === (index - 1 + count) % count) return 'left'
    if (count > 1 && i === (index + 1) % count) return 'right'
    return 'hidden'
  }

  return (
    <div
      className={cn(
        'group relative h-[72vh] max-h-205 min-h-110 w-full touch-pan-y overflow-hidden',
        count > 1 && 'cursor-grab select-none active:cursor-grabbing',
      )}
      onMouseEnter={() => setPaused(true)}
      onMouseLeave={() => setPaused(false)}
      onPointerDown={onPointerDown}
      onPointerMove={onPointerMove}
      onPointerUp={onPointerUp}
      onPointerCancel={onPointerUp}
      onClickCapture={onClickCapture}
      style={{ perspective: '1600px' }}
    >
      {/* Stage: slides positioned in 3D around the center */}
      <div className="absolute inset-0 flex items-center justify-center transform-3d">
        {slides.map((s, i) => {
          const slot = slotFor(i)
          if (slot === 'hidden') return null
          const st = SLOT_STYLES[slot]
          const isCenter = slot === 'center'
          return (
            <motion.div
              key={s.id}
              className="absolute h-full w-[68%] sm:w-[62%] lg:w-[56%]"
              initial={false}
              animate={{
                x: st.x,
                rotateY: st.rotateY,
                scale: st.scale,
                opacity: st.opacity,
                filter: `blur(${st.blur}px)`,
              }}
              transition={{ duration: 0.6, ease: [0.22, 1, 0.36, 1] }}
              style={{ zIndex: st.z, transformStyle: 'preserve-3d' }}
            >
              {isCenter ? (
                <Link
                  to={s.href}
                  aria-label={s.name}
                  draggable={false}
                  className="block h-full w-full overflow-hidden rounded-2xl shadow-elevated ring-1 ring-white/10"
                >
                  <ProductImage
                    src={s.imageUrl}
                    alt={s.name}
                    draggable={false}
                    className="h-full w-full"
                  />
                  {/* Caption gradient */}
                  <div className="pointer-events-none absolute inset-x-0 bottom-0 bg-linear-to-t from-black/70 via-black/25 to-transparent px-4 pb-8 pt-16 sm:px-8 lg:px-12">
                    <span className="block text-lg font-semibold text-white drop-shadow sm:text-2xl">
                      {s.name}
                    </span>
                  </div>
                </Link>
              ) : (
                // Side layers are decorative — click advances toward them.
                <button
                  type="button"
                  onClick={() => go(slot === 'left' ? index - 1 : index + 1)}
                  aria-label={s.name}
                  className="block h-full w-full overflow-hidden rounded-2xl shadow-card ring-1 ring-white/10"
                >
                  <ProductImage
                    src={s.imageUrl}
                    alt={s.name}
                    draggable={false}
                    className="h-full w-full"
                  />
                  <div className="pointer-events-none absolute inset-0 bg-black/10" />
                </button>
              )}
            </motion.div>
          )
        })}
      </div>

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
