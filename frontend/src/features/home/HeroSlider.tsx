import { useCallback, useEffect, useRef, useState } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { AnimatePresence, motion } from 'motion/react'
import { ArrowLeft, ArrowRight, Headphones, ShieldCheck, Truck } from 'lucide-react'
import { paths } from '@/app/routes/paths'
import { cn } from '@/shared/lib/cn'
import canon1280 from '@/assets/hero/canon-1280.webp'
import canon1672 from '@/assets/hero/canon-1672.webp'
import ecosystem1280 from '@/assets/hero/ecosystem-1280.webp'
import ecosystem1672 from '@/assets/hero/ecosystem-1672.webp'
import laptop1280 from '@/assets/hero/laptop-1280.webp'
import laptop1920 from '@/assets/hero/laptop-1920.webp'
import laptop2560 from '@/assets/hero/laptop-2560.webp'
import laptop3840 from '@/assets/hero/laptop-3840.webp'
import gadgets1280 from '@/assets/hero/gadgets-1280.webp'
import gadgets1920 from '@/assets/hero/gadgets-1920.webp'
import gadgets2560 from '@/assets/hero/gadgets-2560.webp'
import gadgets3840 from '@/assets/hero/gadgets-3840.webp'

const AUTO_MS = 7000

type Slide = { key: string; href: string; image: string; srcSet: string }

const SLIDES: Slide[] = [
  { key: 's1', href: paths.catalog, image: canon1672, srcSet: `${canon1280} 1280w, ${canon1672} 1672w` },
  { key: 's2', href: `${paths.catalog}?brand=apple`, image: ecosystem1672, srcSet: `${ecosystem1280} 1280w, ${ecosystem1672} 1672w` },
  { key: 's3', href: `${paths.catalog}?category=laptops`, image: laptop3840, srcSet: `${laptop1280} 1280w, ${laptop1920} 1920w, ${laptop2560} 2560w, ${laptop3840} 3840w` },
  { key: 's4', href: `${paths.catalog}?category=gadgets`, image: gadgets3840, srcSet: `${gadgets1280} 1280w, ${gadgets1920} 1920w, ${gadgets2560} 2560w, ${gadgets3840} 3840w` },
]

const ease = [0.22, 1, 0.36, 1] as const

function SlideBackground({ slide }: { slide: Slide }) {
  return (
    <div className="absolute inset-0 bg-black">
      <img
        src={slide.image}
        srcSet={slide.srcSet}
        sizes="100vw"
        alt=""
        aria-hidden
        draggable={false}
        className="h-full w-full select-none object-cover"
      />
    </div>
  )
}

export function HeroSlider() {
  const { t } = useTranslation()
  const [index, setIndex] = useState(0)
  const paused = useRef(false)
  const touchX = useRef<number | null>(null)
  const count = SLIDES.length

  const go = useCallback((next: number) => setIndex(((next % count) + count) % count), [count])
  const next = useCallback(() => go(index + 1), [go, index])
  const prev = useCallback(() => go(index - 1), [go, index])

  useEffect(() => {
    SLIDES.forEach((s) => {
      const img = new Image()
      img.sizes = '100vw'
      img.srcset = s.srcSet
      img.src = s.image
    })
  }, [])

  useEffect(() => {
    if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) return
    const id = window.setInterval(() => {
      if (!paused.current && !document.hidden) setIndex((i) => (i + 1) % count)
    }, AUTO_MS)
    return () => window.clearInterval(id)
  }, [count, index])

  const slide = SLIDES[index]
  const base = `home.hero.${slide.key}`
  const badge = t(`${base}.badge`, { defaultValue: '' })

  const features = [
    { icon: Truck, label: t('home.freeShipping'), sub: t('home.freeShippingDesc') },
    { icon: ShieldCheck, label: t('home.warrantyDesc') },
    { icon: Headphones, label: t('home.hero.support') },
  ]

  const textVariants = (delay: number) => ({
    enter: { opacity: 0, y: 28, filter: 'blur(8px)' },
    center: { opacity: 1, y: 0, filter: 'blur(0px)', transition: { duration: 0.9, delay, ease } },
    exit: { opacity: 0, y: -16, filter: 'blur(6px)', transition: { duration: 0.35 } },
  })

  return (
    <section
      className="relative isolate flex w-full flex-col overflow-clip bg-black xl:h-[calc(100svh-4rem)] xl:min-h-[640px]"
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
      <div className="relative -z-10 aspect-video w-full xl:absolute xl:inset-0 xl:aspect-auto">
        <AnimatePresence initial={false}>
          <motion.div
            key={slide.key}
            className="absolute inset-0"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            exit={{ opacity: 0 }}
            transition={{ duration: 1.1, ease: 'easeInOut' }}
          >
            <SlideBackground slide={slide} />
          </motion.div>
        </AnimatePresence>
        <div className="absolute inset-0 hidden bg-linear-to-r from-black/55 via-black/15 to-transparent xl:block" />
        <div className="absolute inset-x-0 bottom-0 hidden h-1/3 bg-linear-to-t from-black/60 to-transparent xl:block" />
      </div>

      <div className="mx-auto flex w-full max-w-[max(80rem,70%)] flex-1 flex-col px-4 pt-8 sm:px-6 lg:px-8 xl:pt-24">
        <div className="relative min-h-[300px] max-w-2xl flex-1 sm:min-h-[280px]">
          <AnimatePresence mode="wait">
            <motion.div key={slide.key} initial="enter" animate="center" exit="exit" className="hero-text-shadow flex flex-col items-start">
              {badge && (
                <motion.span
                  variants={textVariants(0)}
                  className="mb-5 rounded-full border border-white/15 bg-white/10 px-3 py-1 text-xs font-medium text-fg backdrop-blur-md"
                >
                  {badge}
                </motion.span>
              )}
              <h1 className="hero-title text-[clamp(2.25rem,5.6vw,5rem)] leading-[1.02] text-fg">
                <motion.span className="block" variants={textVariants(0.04)}>
                  {t(`${base}.a`)}
                </motion.span>
                <motion.span className="hero-accent block pb-2" variants={textVariants(0.12)}>
                  {t(`${base}.b`)}
                </motion.span>
              </h1>
              <motion.p
                variants={textVariants(0.2)}
                className="mt-5 max-w-md text-base leading-relaxed text-fg/80 sm:text-lg md:whitespace-pre-line"
              >
                {t(`${base}.text`)}
              </motion.p>
              <motion.div variants={textVariants(0.28)} className="mt-9 flex flex-wrap items-center gap-6">
                <Link
                  to={slide.href}
                  className="group inline-flex h-12 items-center gap-3 rounded-full bg-white px-7 text-sm font-medium text-black transition-colors [text-shadow:none] hover:bg-white/85"
                >
                  {t(`${base}.cta`)}
                  <ArrowRight className="h-4 w-4 transition-transform group-hover:translate-x-1" strokeWidth={1.75} />
                </Link>
                <Link
                  to={paths.catalog}
                  className="inline-flex items-center gap-2 text-sm text-fg/80 transition-colors hover:text-fg"
                >
                  {t('home.hero.all')}
                  <ArrowRight className="h-3.5 w-3.5" strokeWidth={1.75} />
                </Link>
              </motion.div>
            </motion.div>
          </AnimatePresence>
        </div>

        <div className="flex flex-col gap-6 pb-8 pt-10 lg:flex-row lg:items-end lg:justify-between lg:pb-12">
          <div className="flex items-center gap-6">
            <div className="hero-text-shadow flex items-baseline gap-2 tabular-nums">
              <span className="text-2xl font-light text-fg">{String(index + 1).padStart(2, '0')}</span>
              <span className="text-sm text-fg-subtle">/ {String(count).padStart(2, '0')}</span>
            </div>
            <div className="flex gap-1">
              <button
                type="button"
                onClick={prev}
                aria-label={t('home.slidePrev')}
                className="inline-flex h-10 w-10 items-center justify-center rounded-full border border-white/15 bg-black/35 text-fg/80 backdrop-blur-md transition-colors hover:border-white/40 hover:text-fg"
              >
                <ArrowLeft className="h-4 w-4" strokeWidth={1.5} />
              </button>
              <button
                type="button"
                onClick={next}
                aria-label={t('home.slideNext')}
                className="inline-flex h-10 w-10 items-center justify-center rounded-full border border-white/15 bg-black/35 text-fg/80 backdrop-blur-md transition-colors hover:border-white/40 hover:text-fg"
              >
                <ArrowRight className="h-4 w-4" strokeWidth={1.5} />
              </button>
            </div>
            <div className="hidden items-center gap-1.5 sm:flex">
              {SLIDES.map((s, i) => (
                <button
                  key={s.key}
                  type="button"
                  onClick={() => go(i)}
                  aria-label={`${t('home.slideGoto')} ${i + 1}`}
                  aria-current={i === index}
                  className="relative h-0.5 w-10 overflow-hidden rounded-full bg-white/20"
                >
                  {i === index && (
                    <motion.span
                      key={index}
                      className="absolute inset-y-0 left-0 bg-white"
                      initial={{ width: '0%' }}
                      animate={{ width: '100%' }}
                      transition={{ duration: AUTO_MS / 1000, ease: 'linear' }}
                    />
                  )}
                  {i < index && <span className="absolute inset-0 bg-white/60" />}
                </button>
              ))}
            </div>
          </div>

          <div className="grid grid-cols-3 gap-2 sm:gap-3">
            {features.map(({ icon: Icon, label, sub }) => (
              <div
                key={label}
                className={cn(
                  'flex flex-col items-center gap-2 rounded-2xl border border-white/10 bg-black/45 px-2 py-3 text-center backdrop-blur-xl',
                  'sm:flex-row sm:gap-3 sm:px-5 sm:py-3.5 sm:text-left',
                )}
              >
                <Icon className="h-5 w-5 shrink-0 text-fg/85" strokeWidth={1.5} />
                <div className="flex flex-col text-[11px] leading-snug text-fg/85 sm:text-xs">
                  <span>{label}</span>
                  {sub && <span className="hidden text-fg-subtle sm:inline">{sub}</span>}
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </section>
  )
}
