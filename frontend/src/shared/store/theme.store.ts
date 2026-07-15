import { create } from 'zustand'
import { persist } from 'zustand/middleware'

export type Theme = 'light' | 'dark'

interface ThemeState {
  theme: Theme
  setTheme: (theme: Theme) => void
  toggle: () => void
}

/** Applies the theme to <html data-theme=...>, which drives the CSS token swap. */
function apply(theme: Theme) {
  document.documentElement.setAttribute('data-theme', theme)
}

export const useThemeStore = create<ThemeState>()(
  persist(
    (set, get) => ({
      theme: 'light',
      setTheme: (theme) => {
        apply(theme)
        set({ theme })
      },
      toggle: () => get().setTheme(get().theme === 'light' ? 'dark' : 'light'),
    }),
    {
      name: 'hypex-theme',
      onRehydrateStorage: () => (state) => {
        // Re-apply persisted theme to the DOM after hydration.
        apply(state?.theme ?? 'light')
      },
    },
  ),
)
