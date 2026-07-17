import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { Clock, Mail, MapPin, Phone } from 'lucide-react'
import { paths } from '@/app/routes/paths'

export function Footer() {
  const { t } = useTranslation()
  const year = new Date().getFullYear()

  return (
    <footer className="glass-strong mt-auto border-t">
      <div className="mx-auto flex w-full max-w-7xl flex-col gap-8 px-4 py-10 sm:px-6 lg:px-8">
        <div className="grid gap-8 sm:grid-cols-2 lg:grid-cols-4">
          {/* Brand */}
          <div className="lg:col-span-2">
            <span className="bg-linear-to-r from-teal-500 to-emerald-700 bg-clip-text text-lg font-bold text-transparent">
              {t('common.appName')}
            </span>
            <p className="mt-2 max-w-xs text-sm text-fg-muted">{t('footer.tagline')}</p>
          </div>

          {/* Company links */}
          <nav className="flex flex-col gap-2 text-sm text-fg-muted">
            <span className="mb-1 font-semibold text-fg">{t('footer.aboutTitle')}</span>
            <Link to={paths.about} className="hover:text-fg">{t('nav.about')}</Link>
            <Link to={paths.catalog} className="hover:text-fg">{t('nav.catalog')}</Link>
            <Link to={paths.favorites} className="hover:text-fg">{t('nav.favorites')}</Link>
            <Link to={paths.compare} className="hover:text-fg">{t('nav.compare')}</Link>
          </nav>

          {/* Contacts */}
          <div className="flex flex-col gap-3 text-sm text-fg-muted">
            <span className="font-semibold text-fg">{t('footer.contactsTitle')}</span>
            <span className="flex items-start gap-2">
              <MapPin className="mt-0.5 h-4 w-4 shrink-0 text-fg-subtle" strokeWidth={2} />
              {t('about.address')}
            </span>
            <a
              href={`tel:${t('about.phone').replace(/[^+\d]/g, '')}`}
              className="flex items-center gap-2 hover:text-fg"
            >
              <Phone className="h-4 w-4 shrink-0 text-fg-subtle" strokeWidth={2} />
              {t('about.phone')}
            </a>
            <a
              href={`mailto:${t('about.email')}`}
              className="flex items-center gap-2 hover:text-fg"
            >
              <Mail className="h-4 w-4 shrink-0 text-fg-subtle" strokeWidth={2} />
              {t('about.email')}
            </a>
            <span className="flex items-center gap-2">
              <Clock className="h-4 w-4 shrink-0 text-fg-subtle" strokeWidth={2} />
              {t('about.hours')}
            </span>
          </div>
        </div>

        <div className="border-t border-border pt-6 text-xs text-fg-subtle">
          © {year} {t('common.appName')}. {t('footer.rights')}
        </div>
      </div>
    </footer>
  )
}
