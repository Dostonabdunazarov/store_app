import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { paths } from '@/app/routes/paths'

export function Footer() {
  const { t } = useTranslation()
  const year = new Date().getFullYear()

  return (
    <footer className="glass-strong mt-auto border-t">
      <div className="mx-auto flex w-full max-w-7xl flex-col gap-6 px-4 py-10 sm:px-6 lg:px-8">
        <div className="flex flex-col gap-4 sm:flex-row sm:items-center sm:justify-between">
          <div>
            <span className="bg-linear-to-r from-teal-500 to-emerald-700 bg-clip-text text-lg font-bold text-transparent">
              {t('common.appName')}
            </span>
            <p className="mt-1 text-sm text-fg-muted">{t('footer.tagline')}</p>
          </div>
          <nav className="flex flex-wrap gap-x-6 gap-y-2 text-sm text-fg-muted">
            <Link to={paths.catalog} className="hover:text-fg">{t('nav.catalog')}</Link>
            <Link to={paths.favorites} className="hover:text-fg">{t('nav.favorites')}</Link>
            <Link to={paths.compare} className="hover:text-fg">{t('nav.compare')}</Link>
            <Link to={paths.cart} className="hover:text-fg">{t('nav.cart')}</Link>
          </nav>
        </div>
        <div className="border-t border-border pt-6 text-xs text-fg-subtle">
          © {year} {t('common.appName')}. {t('footer.rights')}
        </div>
      </div>
    </footer>
  )
}
