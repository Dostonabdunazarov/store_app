import { useTranslation } from 'react-i18next'
import { Moon, Sun } from 'lucide-react'
import { useThemeStore } from '@/shared/store/theme.store'
import { Button } from './Button'

/** Sun/moon toggle bound to the theme store. */
export function ThemeToggle() {
  const { t } = useTranslation()
  const theme = useThemeStore((s) => s.theme)
  const toggle = useThemeStore((s) => s.toggle)

  return (
    <Button
      variant="ghost"
      size="icon"
      onClick={toggle}
      aria-label={t('theme.toggle')}
      title={t('theme.toggle')}
    >
      {theme === 'dark' ? (
        <Sun className="h-4.5 w-4.5" strokeWidth={2} />
      ) : (
        <Moon className="h-4.5 w-4.5" strokeWidth={2} />
      )}
    </Button>
  )
}
