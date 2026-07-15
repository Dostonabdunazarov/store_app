import type { Lang } from '@/shared/lib/i18n'

/** Inline SVG country flags for the language switcher. Self-contained (no assets,
 *  no CDN) and OS-independent — unlike emoji flags, which Windows renders as a
 *  2-letter code. Rounded via a clip so they read as small pills. */
export function FlagIcon({ lang, className }: { lang: Lang; className?: string }) {
  const common = {
    viewBox: '0 0 24 16',
    className,
    role: 'img' as const,
    'aria-hidden': true,
  }

  switch (lang) {
    case 'ru':
      return (
        <svg {...common}>
          <rect width="24" height="16" rx="2" fill="#fff" />
          <rect y="5.33" width="24" height="5.34" fill="#0039A6" />
          <rect y="10.67" width="24" height="5.33" fill="#D52B1E" />
        </svg>
      )
    case 'uz':
      return (
        <svg {...common}>
          <rect width="24" height="16" rx="2" fill="#fff" />
          <rect width="24" height="5" fill="#1EB53A" />
          <rect y="11" width="24" height="5" fill="#0099B5" />
          <rect y="5" width="24" height="6" fill="#fff" />
          <rect y="5" width="24" height="0.5" fill="#CE1126" />
          <rect y="10.5" width="24" height="0.5" fill="#CE1126" />
          <circle cx="4.5" cy="2.6" r="1.6" fill="#fff" />
          <circle cx="5.1" cy="2.6" r="1.6" fill="#0099B5" />
        </svg>
      )
    case 'en':
      // Union Jack (simplified).
      return (
        <svg {...common}>
          <rect width="24" height="16" rx="2" fill="#012169" />
          <path d="M0 0l24 16M24 0L0 16" stroke="#fff" strokeWidth="3" />
          <path d="M0 0l24 16M24 0L0 16" stroke="#C8102E" strokeWidth="1.6" />
          <path d="M12 0v16M0 8h24" stroke="#fff" strokeWidth="5" />
          <path d="M12 0v16M0 8h24" stroke="#C8102E" strokeWidth="3" />
        </svg>
      )
  }
}
