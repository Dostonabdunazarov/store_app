import { useEffect, useState } from 'react'
import { AnimatePresence, motion } from 'motion/react'
import { ArrowUp } from 'lucide-react'

/**
 * Floating "back to top" button, fixed to the bottom-right. Appears once the
 * page is scrolled past ~one viewport and smooth-scrolls to the top on click.
 */
export function ScrollToTopButton() {
  const [visible, setVisible] = useState(false)

  useEffect(() => {
    const onScroll = () => setVisible(window.scrollY > window.innerHeight * 0.6)
    onScroll()
    window.addEventListener('scroll', onScroll, { passive: true })
    return () => window.removeEventListener('scroll', onScroll)
  }, [])

  const toTop = () => window.scrollTo({ top: 0, behavior: 'smooth' })

  return (
    <AnimatePresence>
      {visible && (
        <motion.button
          type="button"
          onClick={toTop}
          aria-label="Scroll to top"
          initial={{ opacity: 0, scale: 0.8, y: 8 }}
          animate={{ opacity: 1, scale: 1, y: 0 }}
          exit={{ opacity: 0, scale: 0.8, y: 8 }}
          transition={{ duration: 0.2, ease: 'easeOut' }}
          className="glass-strong fixed bottom-6 right-6 z-50 flex h-12 w-12 items-center justify-center rounded-full border shadow-elevated transition-colors hover:text-primary"
        >
          <ArrowUp className="h-5 w-5" strokeWidth={2.25} />
        </motion.button>
      )}
    </AnimatePresence>
  )
}
