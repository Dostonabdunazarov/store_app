import { useCallback, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom'
import { ChevronLeft, ChevronRight } from 'lucide-react'
import { ProductImage } from '@/shared/ui/ProductImage'

export interface PromoCard {
  id: string
  name: string
  imageUrl: string | null
  href: string
}

/**
 * Infinite, draggable row of promo cards (square image on top, bold title
 * below), several visible at once. The list is tripled and the scroll position
 * is kept in the middle copy; crossing a copy boundary silently wraps, so
 * scrolling/dragging/arrow-stepping in either direction loops forever.
 * Mirrors the BrandStrip infinite-loop technique.
 */
// Auto-scroll speed in pixels per second (content drifts right → left).
const AUTO_SPEED = 40

export function PromoCarousel({ cards }: { cards: PromoCard[] }) {
  const scrollerRef = useRef<HTMLDivElement>(null)
  // Width of one copy of the list — used to recenter for the infinite loop.
  const copyWidth = useRef(0)
  const drag = useRef({ active: false, startX: 0, startScroll: 0, moved: false })
  // Whether auto-scroll is currently paused (hover / drag / tab hidden).
  const paused = useRef(false)

  const measure = useCallback(() => {
    const el = scrollerRef.current
    if (!el) return
    copyWidth.current = el.scrollWidth / 3
    // Center on the middle copy if we're not already there.
    if (Math.abs(el.scrollLeft - copyWidth.current) > copyWidth.current) {
      el.scrollLeft = copyWidth.current
    }
  }, [])

  // Keep the scroll position within the middle copy; wrap seamlessly at the seams.
  const normalize = useCallback(() => {
    const el = scrollerRef.current
    const w = copyWidth.current
    if (!el || w === 0) return
    if (el.scrollLeft < w * 0.5) {
      el.scrollLeft += w
    } else if (el.scrollLeft > w * 1.5) {
      el.scrollLeft -= w
    }
  }, [])

  useEffect(() => {
    const el = scrollerRef.current
    if (!el) return
    measure()
    el.scrollLeft = copyWidth.current // start centered
    el.addEventListener('scroll', normalize, { passive: true })
    window.addEventListener('resize', measure)
    return () => {
      el.removeEventListener('scroll', normalize)
      window.removeEventListener('resize', measure)
    }
  }, [measure, normalize, cards.length])

  // Continuous auto-scroll so the cards visually travel right → left (the
  // scroll offset increases). Paused on hover/drag or when the tab is hidden;
  // `normalize` (on the scroll listener) wraps seamlessly.
  useEffect(() => {
    if (cards.length <= 1) return
    // Respect users who prefer no motion.
    if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) return

    let raf = 0
    let last = 0
    const tick = (now: number) => {
      const el = scrollerRef.current
      if (el && !paused.current) {
        const dt = last ? (now - last) / 1000 : 0
        el.scrollLeft += AUTO_SPEED * dt
        if (el.scrollLeft > copyWidth.current * 2) el.scrollLeft -= copyWidth.current
      }
      last = now
      raf = requestAnimationFrame(tick)
    }
    raf = requestAnimationFrame(tick)
    return () => cancelAnimationFrame(raf)
  }, [cards.length])

  const step = (dir: 1 | -1) => {
    const el = scrollerRef.current
    if (!el) return
    el.scrollBy({ left: dir * Math.round(el.clientWidth * 0.85), behavior: 'smooth' })
  }

  // Pointer drag-to-scroll.
  const onPointerDown = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (!el) return
    paused.current = true // stop auto-scroll while the user interacts
    drag.current = { active: true, startX: e.clientX, startScroll: el.scrollLeft, moved: false }
  }
  const onPointerMove = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (!el || !drag.current.active) return
    const dx = e.clientX - drag.current.startX
    if (!drag.current.moved && Math.abs(dx) > 6) {
      drag.current.moved = true
      el.setPointerCapture(e.pointerId)
    }
    if (drag.current.moved) el.scrollLeft = drag.current.startScroll - dx
  }
  const endDrag = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (el?.hasPointerCapture(e.pointerId)) el.releasePointerCapture(e.pointerId)
    drag.current.active = false
    paused.current = false // resume auto-scroll
  }
  // Cancel the click that follows a real drag so dragging doesn't navigate.
  const onClickCapture = (e: React.MouseEvent<HTMLDivElement>) => {
    if (drag.current.moved) {
      e.preventDefault()
      e.stopPropagation()
      drag.current.moved = false
    }
  }

  if (cards.length === 0) return null

  const loop = [...cards, ...cards, ...cards]

  return (
    <div
      className="group relative"
      onMouseEnter={() => (paused.current = true)}
      onMouseLeave={() => (paused.current = false)}
    >
      <div
        ref={scrollerRef}
        onPointerDown={onPointerDown}
        onPointerMove={onPointerMove}
        onPointerUp={endDrag}
        onPointerCancel={endDrag}
        onClickCapture={onClickCapture}
        className="flex cursor-grab gap-4 overflow-x-auto pb-2 select-none active:cursor-grabbing [scrollbar-width:none] [&::-webkit-scrollbar]:hidden"
      >
        {loop.map((c, i) => (
          <Link
            key={`${c.id}-${i}`}
            to={c.href}
            draggable={false}
            className="group/card flex w-44 shrink-0 flex-col overflow-hidden rounded-2xl border border-border bg-surface-1 shadow-card transition-all hover:-translate-y-1 hover:shadow-elevated sm:w-52"
          >
            <ProductImage
              src={c.imageUrl}
              alt={c.name}
              draggable={false}
              className="aspect-square w-full transition-transform duration-500 group-hover/card:scale-105"
            />
            <div className="flex flex-1 items-start p-4">
              <span className="line-clamp-3 text-sm font-bold leading-snug tracking-tight sm:text-base">
                {c.name}
              </span>
            </div>
          </Link>
        ))}
      </div>

      <button
        type="button"
        aria-label="Previous"
        onClick={() => step(-1)}
        className="glass absolute left-0 top-1/2 z-10 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full border shadow-card transition-colors hover:text-primary"
      >
        <ChevronLeft className="h-5 w-5" />
      </button>
      <button
        type="button"
        aria-label="Next"
        onClick={() => step(1)}
        className="glass absolute right-0 top-1/2 z-10 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full border shadow-card transition-colors hover:text-primary"
      >
        <ChevronRight className="h-5 w-5" />
      </button>
    </div>
  )
}
