import { create } from 'zustand'
import { persist } from 'zustand/middleware'

/** Max products that fit side-by-side in the compare table. */
export const COMPARE_LIMIT = 4

interface CompareState {
  /** Product slugs (the compare table fetches details by slug). */
  slugs: string[]
  toggle: (slug: string) => boolean // returns the new membership state
  remove: (slug: string) => void
  clear: () => void
  has: (slug: string) => boolean
  isFull: () => boolean
}

export const useCompareStore = create<CompareState>()(
  persist(
    (set, get) => ({
      slugs: [],

      toggle: (slug) => {
        const { slugs } = get()
        if (slugs.includes(slug)) {
          set({ slugs: slugs.filter((s) => s !== slug) })
          return false
        }
        if (slugs.length >= COMPARE_LIMIT) return false // silently ignore over-limit
        set({ slugs: [...slugs, slug] })
        return true
      },

      remove: (slug) => set((s) => ({ slugs: s.slugs.filter((x) => x !== slug) })),
      clear: () => set({ slugs: [] }),
      has: (slug) => get().slugs.includes(slug),
      isFull: () => get().slugs.length >= COMPARE_LIMIT,
    }),
    { name: 'hypex-compare' },
  ),
)

export const selectCompareCount = (s: CompareState) => s.slugs.length
