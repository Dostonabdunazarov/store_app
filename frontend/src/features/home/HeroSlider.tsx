import { useCallback, useEffect, useRef, useState } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { AnimatePresence, motion } from 'motion/react'
import { ChevronLeft, ChevronRight } from 'lucide-react'
import { Button } from '@/shared/ui/Button'
import { ProductImage } from '@/shared/ui/ProductImage'
import { formatPrice } from '@/shared/lib/format'

export interface HeroSlide {
  id: string
  name: string
  imageUrl: string | null
  href: string
  price: number
  oldPrice: number | null
  discountPercent: number
  brandName: string
}

const AUTO_MS = 5000

/**
 * Full-width hero slider: one product per slide with a large image, brand,
 * name, price (with optional discount) and a CTA. Auto-advances, pauses on
 * hover, supports arrows, dots and swipe. A soft gradient + blurred image
 * backdrop keeps text readable over any product photo.
 */
export function HeroSlider({ slides }: { slides: HeroSlide[] }) {
  const { t } = useTranslation()
  const [index, setIndex] = useState(0)
  const [dir, setDir] = useState(1)
  const paused = useRef(false)
  const touchX = useRef<number | null>(null)

  const count = slides.length

  const go = useCallback(
    (next: number, direction: 1 | -1) => {
      setDir(direction)
      setIndex(((next % count) + count) % count)
    },
    [count],
  )
  const next = useCallback(() => go(index + 1, 1), [go, index])
  const prev = useCallback(() => go(index - 1, -1), [go, index])

  // Auto-advance; paused on hover / when the tab is hidden.
  useEffect(() => {
    if (count <= 1) return
    if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) return
    const id = window.setInterval(() => {
      if (!paused.current && !document.hidden) setIndex((i) => (i + 1) % count)
    }, AUTO_MS)
    return () => window.clearInterval(id)
  }, [count])

  if (count === 0) return null

  const slide = slides[index]

  return (
    <div
      className="relative aspect-16/10 w-full overflow-hidden shadow-elevated sm:aspect-21/9 sm:max-h-140"
      onMouseEnter={() => (paused.current = true)}
      onMouseLeave={() => (paused.current = false)}
      onTouchStart={(e) => (touchX.current = e.touches[0].clientX)}
      onTouchEnd={(e) => {
        if (touchX.current == null) return
        const dx = e.changedTouches[0].clientX - touchX.current
        if (dx > 50) prev()
        else if (dx < -50) next()
        touchX.current = null
      }}
    >
      <AnimatePresence initial={false} custom={dir} mode="popLayout">
        <motion.div
          key={slide.id}
          custom={dir}
          initial={{ opacity: 0, x: dir * 60 }}
          animate={{ opacity: 1, x: 0 }}
          exit={{ opacity: 0, x: dir * -60 }}
          transition={{ duration: 0.5, ease: 'easeOut' }}
          className="absolute inset-0"
        >
          <Link to={slide.href} className="block h-full w-full">
            {/* Blurred backdrop fills the frame edge-to-edge */}
            {slide.imageUrl && (
              <img
                src={slide.imageUrl}
                alt=""
                aria-hidden
                className="absolute inset-0 h-full w-full scale-110 object-cover blur-2xl"
              />
            )}
            <div className="absolute inset-0 bg-linear-to-r from-black/85 via-black/55 to-black/20" />

            <div className="relative z-10 mx-auto grid h-full w-full max-w-7xl grid-cols-1 items-center gap-4 px-4 py-6 sm:grid-cols-2 sm:px-6 sm:py-10 lg:px-8">
              {/* Copy */}
              <div className="flex flex-col items-start gap-3 text-white sm:gap-4">
                {slide.discountPercent > 0 ? (
                  <span className="rounded-full bg-danger px-3 py-1 text-xs font-bold uppercase tracking-wide text-white">
                    −{slide.discountPercent}% {t('home.slideSale')}
                  </span>
                ) : (
                  <span className="rounded-full bg-white/15 px-3 py-1 text-xs font-semibold uppercase tracking-wide backdrop-blur-md">
                    {slide.brandName}
                  </span>
                )}
                <h2 className="line-clamp-3 text-2xl font-extrabold leading-tight tracking-tight drop-shadow-sm sm:text-4xl lg:text-5xl">
                  {slide.name}
                </h2>
                <div className="flex items-baseline gap-3">
                  <span className="text-2xl font-bold sm:text-3xl">
                    {formatPrice(slide.price, t('common.currency'))}
                  </span>
                  {slide.oldPrice != null && (
                    <span className="text-base font-medium text-white/60 line-through sm:text-lg">
                      {formatPrice(slide.oldPrice, t('common.currency'))}
                    </span>
                  )}
                </div>
                <Button className="mt-1">{t('home.shopNow')} →</Button>
              </div>

              {/* Foreground product image */}
              <div className="hidden items-center justify-center sm:flex">
                <ProductImage
                  src={slide.imageUrl}
                  alt={slide.name}
                  className="aspect-square w-full max-w-sm rounded-2xl shadow-elevated"
                />
              </div>
            </div>
          </Link>
        </motion.div>
      </AnimatePresence>

      {count > 1 && (
        <>
          <button
            type="button"
            aria-label={t('home.slidePrev')}
            onClick={prev}
            className="glass absolute left-3 top-1/2 z-20 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full border text-white shadow-card transition-colors hover:text-primary"
          >
            <ChevronLeft className="h-5 w-5" />
          </button>
          <button
            type="button"
            aria-label={t('home.slideNext')}
            onClick={next}
            className="glass absolute right-3 top-1/2 z-20 flex h-11 w-11 -translate-y-1/2 items-center justify-center rounded-full border text-white shadow-card transition-colors hover:text-primary"
          >
            <ChevronRight className="h-5 w-5" />
          </button>

          {/* Dots */}
          <div className="absolute bottom-4 left-1/2 z-20 flex -translate-x-1/2 items-center gap-2">
            {slides.map((s, i) => (
              <button
                key={s.id}
                type="button"
                aria-label={`${t('home.slideGoto')} ${i + 1}`}
                aria-current={i === index}
                onClick={() => go(i, i > index ? 1 : -1)}
                className={`h-2 rounded-full transition-all ${
                  i === index ? 'w-6 bg-white' : 'w-2 bg-white/50 hover:bg-white/80'
                }`}
              />
            ))}
          </div>
        </>
      )}
    </div>
  )
}
