import { currentLang } from './i18n'

const LOCALE: Record<string, string> = { ru: 'ru-RU', uz: 'uz-UZ', en: 'en-US' }

/** Format a price as a grouped integer + localized currency suffix (e.g. "12 990 000 сум"). */
export function formatPrice(value: number, currency: string): string {
  const locale = LOCALE[currentLang()] ?? 'ru-RU'
  const amount = new Intl.NumberFormat(locale, { maximumFractionDigits: 0 }).format(value)
  return `${amount} ${currency}`
}

/** Localized short date (e.g. "14 июл. 2026"). */
export function formatDate(iso: string): string {
  const locale = LOCALE[currentLang()] ?? 'ru-RU'
  return new Intl.DateTimeFormat(locale, {
    day: 'numeric',
    month: 'short',
    year: 'numeric',
  }).format(new Date(iso))
}
