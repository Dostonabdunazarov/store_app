import { useCallback, useEffect, useRef } from 'react'
import { Link } from 'react-router-dom'
import { ChevronLeft, ChevronRight } from 'lucide-react'
import type { BrandDto } from '@/shared/api/types'
import { paths } from '@/app/routes/paths'
import { BRAND_LOGOS } from './brandLogos'

type BrandStripProps = {
  brands: BrandDto[]
}

// Wide wordmark logos that should scale up (taller cap, less side padding).
const WIDE_LOGOS = new Set(['samsung', 'sony', 'asus'])

/**
 * Infinite, draggable strip of brand chips. The list is tripled and the scroll
 * position is kept in the middle copy; crossing a copy boundary silently wraps,
 * so scrolling/dragging in either direction loops forever. Arrows are always shown.
 */
export function BrandStrip({ brands }: BrandStripProps) {
  const scrollerRef = useRef<HTMLDivElement>(null)
  // Width of one copy of the list — used to recenter for the infinite loop.
  const copyWidth = useRef(0)
  // Drag state (pointer). moved tracks whether it became a drag (to cancel the click).
  const drag = useRef({ active: false, startX: 0, startScroll: 0, moved: false })

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
  }, [measure, normalize, brands.length])

  const step = (dir: 1 | -1) => {
    const el = scrollerRef.current
    if (!el) return
    el.scrollBy({ left: dir * Math.round(el.clientWidth * 0.7), behavior: 'smooth' })
  }

  // Pointer drag-to-scroll.
  const onPointerDown = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (!el) return
    drag.current = { active: true, startX: e.clientX, startScroll: el.scrollLeft, moved: false }
    el.setPointerCapture(e.pointerId)
  }
  const onPointerMove = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (!el || !drag.current.active) return
    const dx = e.clientX - drag.current.startX
    if (Math.abs(dx) > 4) drag.current.moved = true
    el.scrollLeft = drag.current.startScroll - dx
  }
  const endDrag = (e: React.PointerEvent<HTMLDivElement>) => {
    const el = scrollerRef.current
    if (el?.hasPointerCapture(e.pointerId)) el.releasePointerCapture(e.pointerId)
    drag.current.active = false
  }
  // Cancel the click that follows a drag, so dragging doesn't navigate.
  const onClickCapture = (e: React.MouseEvent<HTMLDivElement>) => {
    if (drag.current.moved) {
      e.preventDefault()
      e.stopPropagation()
      drag.current.moved = false
    }
  }

  if (brands.length === 0) return null

  const loop = [...brands, ...brands, ...brands]

  return (
    <div className="relative">
      <button
        type="button"
        aria-label="Scroll brands left"
        onClick={() => step(-1)}
        className="glass absolute left-0 top-1/2 z-10 flex h-10 w-10 -translate-y-1/2 items-center justify-center rounded-full border shadow-card transition-colors hover:text-primary"
      >
        <ChevronLeft className="h-5 w-5" />
      </button>

      <div
        ref={scrollerRef}
        onPointerDown={onPointerDown}
        onPointerMove={onPointerMove}
        onPointerUp={endDrag}
        onPointerCancel={endDrag}
        onClickCapture={onClickCapture}
        className="flex cursor-grab gap-3 overflow-x-auto px-1 py-1 select-none active:cursor-grabbing [scrollbar-width:none] [&::-webkit-scrollbar]:hidden"
      >
        {loop.map((b, i) => {
          const logo = BRAND_LOGOS[b.slug] ?? b.logoUrl
          // Wide wordmark logos read small when height-limited — let them use the full
          // tile width and a taller cap so they scale up to match the icon logos.
          const wide = WIDE_LOGOS.has(b.slug)
          return (
            <Link
              key={`${b.id}-${i}`}
              to={`${paths.catalog}?brand=${b.slug}`}
              title={b.name}
              draggable={false}
              className={`flex h-20 w-40 shrink-0 items-center justify-center rounded-2xl border border-border bg-white shadow-card transition-all hover:-translate-y-0.5 hover:shadow-elevated ${
                wide ? 'px-3' : 'px-6'
              }`}
            >
              {logo ? (
                <img
                  src={logo}
                  alt={b.name}
                  loading="lazy"
                  draggable={false}
                  className={`max-w-full object-contain ${wide ? 'max-h-14' : 'max-h-11'}`}
                />
              ) : (
                <span className="truncate text-lg font-bold tracking-tight text-neutral-900">
                  {b.name}
                </span>
              )}
            </Link>
          )
        })}
      </div>

      <button
        type="button"
        aria-label="Scroll brands right"
        onClick={() => step(1)}
        className="glass absolute right-0 top-1/2 z-10 flex h-10 w-10 -translate-y-1/2 items-center justify-center rounded-full border shadow-card transition-colors hover:text-primary"
      >
        <ChevronRight className="h-5 w-5" />
      </button>
    </div>
  )
}
