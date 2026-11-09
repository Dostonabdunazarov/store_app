import { useState, type FormEvent } from 'react'
import { useTranslation } from 'react-i18next'
import { useAuthStore } from '@/shared/store/auth.store'
import { getErrorMessage, getFieldErrors } from '@/shared/api/client'
import { Container } from '@/shared/ui/Container'
import { Card, CardBody } from '@/shared/ui/Card'
import { Input } from '@/shared/ui/Input'
import { Button } from '@/shared/ui/Button'

const MIN_PASSWORD_LENGTH = 10

export function ChangePasswordPage() {
  const { t } = useTranslation()
  const changePassword = useAuthStore((s) => s.changePassword)

  const [currentPassword, setCurrentPassword] = useState('')
  const [newPassword, setNewPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [loading, setLoading] = useState(false)
  const [formError, setFormError] = useState<string | null>(null)
  const [success, setSuccess] = useState(false)
  const [fieldErrors, setFieldErrors] = useState<Record<string, string>>({})

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setFormError(null)
    setFieldErrors({})
    setSuccess(false)

    if (newPassword.length < MIN_PASSWORD_LENGTH) {
      setFieldErrors({ newPassword: t('auth.passwordTooShort') })
      return
    }
    if (newPassword !== confirmPassword) {
      setFieldErrors({ confirmPassword: t('auth.passwordsMismatch') })
      return
    }

    setLoading(true)
    try {
      await changePassword({ currentPassword, newPassword })
      setCurrentPassword('')
      setNewPassword('')
      setConfirmPassword('')
      setSuccess(true)
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
          <h1 className="text-2xl font-bold">{t('auth.changePasswordTitle')}</h1>

          <form onSubmit={handleSubmit} className="flex flex-col gap-4" noValidate>
            <Input
              type="password"
              label={t('auth.currentPassword')}
              value={currentPassword}
              onChange={(e) => setCurrentPassword(e.target.value)}
              error={fieldErrors.currentPassword}
              autoComplete="current-password"
              required
            />
            <Input
              type="password"
              label={t('auth.newPassword')}
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              error={fieldErrors.newPassword}
              autoComplete="new-password"
              required
            />
            <Input
              type="password"
              label={t('auth.confirmPassword')}
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              error={fieldErrors.confirmPassword}
              autoComplete="new-password"
              required
            />

            {formError && (
              <p className="rounded-lg bg-danger/10 px-3 py-2 text-sm text-danger">{formError}</p>
            )}
            {success && (
              <p className="rounded-lg bg-primary/10 px-3 py-2 text-sm text-primary">
                {t('auth.passwordChanged')}
              </p>
            )}

            <Button type="submit" loading={loading} className="w-full">
              {t('auth.changePasswordTitle')}
            </Button>
          </form>
        </CardBody>
      </Card>
    </Container>
  )
}
