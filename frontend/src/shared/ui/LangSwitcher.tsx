import { useEffect, useRef, useState } from 'react'
import { useTranslation } from 'react-i18next'
import { Check, ChevronDown } from 'lucide-react'
import { SUPPORTED_LANGS, LANG_LABELS, type Lang } from '@/shared/lib/i18n'
import { FlagIcon } from './FlagIcon'
import { cn } from '@/shared/lib/cn'

const LANG_NAMES: Record<Lang, string> = {
  ru: 'Русский',
  uz: 'O‘zbekcha',
  en: 'English',
}

/** Language dropdown (flag trigger → menu of RU / UZ / EN). Selecting a language
 *  also invalidates queries so server-localized data refetches in the new lang. */
export function LangSwitcher({ onChange }: { onChange?: (lang: Lang) => void }) {
  const { i18n } = useTranslation()
  const active = (i18n.language?.split('-')[0] ?? 'ru') as Lang
  const [open, setOpen] = useState(false)
  const ref = useRef<HTMLDivElement>(null)

  // Close on outside click / Escape.
  useEffect(() => {
    if (!open) return
    const onClick = (e: MouseEvent) => {
      if (ref.current && !ref.current.contains(e.target as Node)) setOpen(false)
    }
    const onKey = (e: KeyboardEvent) => {
      if (e.key === 'Escape') setOpen(false)
    }
    document.addEventListener('mousedown', onClick)
    document.addEventListener('keydown', onKey)
    return () => {
      document.removeEventListener('mousedown', onClick)
      document.removeEventListener('keydown', onKey)
    }
  }, [open])

  const select = (lang: Lang) => {
    i18n.changeLanguage(lang)
    onChange?.(lang)
    setOpen(false)
  }

  return (
    <div ref={ref} className="relative">
      <button
        type="button"
        onClick={() => setOpen((v) => !v)}
        className="inline-flex items-center gap-1.5 rounded-lg border border-border bg-surface px-2.5 py-1.5 text-xs font-semibold text-fg-muted transition-colors hover:text-fg"
        aria-haspopup="listbox"
        aria-expanded={open}
        aria-label="Language"
      >
        <FlagIcon lang={active} className="h-3.5 w-5 rounded-[2px]" />
        <span>{LANG_LABELS[active]}</span>
        <ChevronDown
          className={cn('h-3.5 w-3.5 transition-transform', open && 'rotate-180')}
          strokeWidth={2.5}
        />
      </button>

      {open && (
        <ul
          role="listbox"
          className="absolute right-0 z-50 mt-2 min-w-36 overflow-hidden rounded-xl border border-border bg-surface p-1 shadow-elevated"
        >
          {SUPPORTED_LANGS.map((lang) => (
            <li key={lang}>
              <button
                type="button"
                role="option"
                aria-selected={active === lang}
                onClick={() => select(lang)}
                className={cn(
                  'flex w-full items-center justify-between gap-3 rounded-lg px-3 py-2 text-sm transition-colors',
                  active === lang
                    ? 'bg-surface-2 font-semibold text-fg'
                    : 'text-fg-muted hover:bg-surface-2 hover:text-fg',
                )}
              >
                <span className="flex items-center gap-2">
                  <FlagIcon lang={lang} className="h-4 w-6 rounded-[2px]" />
                  {LANG_NAMES[lang]}
                </span>
                {active === lang && <Check className="h-4 w-4 text-primary" strokeWidth={2.5} />}
              </button>
            </li>
          ))}
        </ul>
      )}
    </div>
  )
}
