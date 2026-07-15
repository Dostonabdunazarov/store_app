import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { Container } from '@/shared/ui/Container'
import { Button } from '@/shared/ui/Button'
import { paths } from '@/app/routes/paths'

export function NotFoundPage() {
  const { t } = useTranslation()
  return (
    <Container className="py-24">
      <div className="flex flex-col items-center gap-4 text-center">
        <span className="text-6xl font-black text-brand-500">404</span>
        <h1 className="text-2xl font-bold">{t('common.notFound')}</h1>
        <Link to={paths.home}>
          <Button>{t('common.goHome')}</Button>
        </Link>
      </div>
    </Container>
  )
}
