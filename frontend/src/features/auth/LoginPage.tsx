import { useState, type FormEvent } from 'react'
import { Link, useLocation, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useAuthStore } from '@/shared/store/auth.store'
import { getErrorMessage, getFieldErrors } from '@/shared/api/client'
import { paths } from '@/app/routes/paths'
import { Container } from '@/shared/ui/Container'
import { Card, CardBody } from '@/shared/ui/Card'
import { Input } from '@/shared/ui/Input'
import { Button } from '@/shared/ui/Button'

interface LocationState {
  from?: { pathname: string }
}

export function LoginPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const location = useLocation()
  const login = useAuthStore((s) => s.login)

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)
  const [formError, setFormError] = useState<string | null>(null)
  const [fieldErrors, setFieldErrors] = useState<Record<string, string>>({})

  const redirectTo = (location.state as LocationState | null)?.from?.pathname ?? paths.home

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setLoading(true)
    setFormError(null)
    setFieldErrors({})
    try {
      await login({ email, password })
      navigate(redirectTo, { replace: true })
    } catch (err) {
      setFieldErrors(getFieldErrors(err))
      setFormError(getErrorMessage(err, t('auth.invalidCredentials')))
    } finally {
      setLoading(false)
    }
  }

  return (
    <Container className="flex min-h-[70vh] items-center justify-center py-12">
      <Card className="w-full max-w-md">
        <CardBody className="flex flex-col gap-5 p-6 sm:p-8">
          <h1 className="text-2xl font-bold">{t('auth.loginTitle')}</h1>

          <form onSubmit={handleSubmit} className="flex flex-col gap-4" noValidate>
            <Input
              type="email"
              label={t('auth.email')}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              error={fieldErrors.email}
              autoComplete="email"
              required
            />
            <Input
              type="password"
              label={t('auth.password')}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              error={fieldErrors.password}
              autoComplete="current-password"
              required
            />

            {formError && (
              <p className="rounded-lg bg-danger/10 px-3 py-2 text-sm text-danger">{formError}</p>
            )}

            <Button type="submit" loading={loading} className="w-full">
              {t('auth.loginCta')}
            </Button>
          </form>

          <p className="text-center text-sm text-fg-muted">
            {t('auth.noAccount')}{' '}
            <Link to={paths.register} className="font-medium text-primary hover:underline">
              {t('auth.registerLink')}
            </Link>
          </p>
        </CardBody>
      </Card>
    </Container>
  )
}
