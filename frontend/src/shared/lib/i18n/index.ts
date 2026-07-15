import i18n from 'i18next'
import { initReactI18next } from 'react-i18next'
import LanguageDetector from 'i18next-browser-languagedetector'
import { ru } from './locales/ru'
import { uz } from './locales/uz'
import { en } from './locales/en'

export const SUPPORTED_LANGS = ['ru', 'uz', 'en'] as const
export type Lang = (typeof SUPPORTED_LANGS)[number]

export const LANG_LABELS: Record<Lang, string> = {
  ru: 'РУ',
  uz: 'UZ',
  en: 'EN',
}

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    resources: {
      ru: { translation: ru },
      uz: { translation: uz },
      en: { translation: en },
    },
    fallbackLng: 'ru',
    supportedLngs: SUPPORTED_LANGS as unknown as string[],
    interpolation: { escapeValue: false },
    detection: {
      order: ['localStorage', 'navigator'],
      lookupLocalStorage: 'hypex-lang',
      caches: ['localStorage'],
    },
  })

/** Current UI language, always narrowed to a supported code (backend expects ru/uz/en). */
export function currentLang(): Lang {
  const base = i18n.language?.split('-')[0]
  return (SUPPORTED_LANGS as readonly string[]).includes(base) ? (base as Lang) : 'ru'
}

export default i18n
