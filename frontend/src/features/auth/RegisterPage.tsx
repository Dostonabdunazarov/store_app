import { useState, type FormEvent } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { useAuthStore } from '@/shared/store/auth.store'
import { getErrorMessage, getFieldErrors } from '@/shared/api/client'
import { paths } from '@/app/routes/paths'
import { Container } from '@/shared/ui/Container'
import { Card, CardBody } from '@/shared/ui/Card'
import { Input } from '@/shared/ui/Input'
import { Button } from '@/shared/ui/Button'

export function RegisterPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const register = useAuthStore((s) => s.register)

  const [fullName, setFullName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirm, setConfirm] = useState('')
  const [loading, setLoading] = useState(false)
  const [formError, setFormError] = useState<string | null>(null)
  const [fieldErrors, setFieldErrors] = useState<Record<string, string>>({})

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setFormError(null)
    setFieldErrors({})

    if (password !== confirm) {
      setFieldErrors({ confirmPassword: t('auth.passwordsMismatch') })
      return
    }

    setLoading(true)
    try {
      await register({ email, password, fullName })
      navigate(paths.home, { replace: true })
    } catch (err) {
      setFieldErrors(getFieldErrors(err))
      setFormError(getErrorMessage(err, t('common.somethingWrong')))
    } finally {
      setLoading(false)
    }
  }

  return (
    <Container className="flex min-h-[70vh] items-center justify-center py-12">
      <Card className="w-full max-w-md">
        <CardBody className="flex flex-col gap-5 p-6 sm:p-8">
          <h1 className="text-2xl font-bold">{t('auth.registerTitle')}</h1>

          <form onSubmit={handleSubmit} className="flex flex-col gap-4" noValidate>
            <Input
              label={t('auth.name')}
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
              error={fieldErrors.fullName}
              autoComplete="name"
              required
            />
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
              autoComplete="new-password"
              required
            />
            <Input
              type="password"
              label={t('auth.confirmPassword')}
              value={confirm}
              onChange={(e) => setConfirm(e.target.value)}
              error={fieldErrors.confirmPassword}
              autoComplete="new-password"
              required
            />

            {formError && (
              <p className="rounded-lg bg-danger/10 px-3 py-2 text-sm text-danger">{formError}</p>
            )}

            <Button type="submit" loading={loading} className="w-full">
              {t('auth.registerCta')}
            </Button>
          </form>

          <p className="text-center text-sm text-fg-muted">
            {t('auth.haveAccount')}{' '}
            <Link to={paths.login} className="font-medium text-primary hover:underline">
              {t('auth.loginLink')}
            </Link>
          </p>
        </CardBody>
      </Card>
    </Container>
  )
}
