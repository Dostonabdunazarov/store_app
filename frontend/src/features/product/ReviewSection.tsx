import { useState, type FormEvent } from 'react'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { useAuthStore } from '@/shared/store/auth.store'
import { getErrorMessage } from '@/shared/api/client'
import { paths } from '@/app/routes/paths'
import { Card, CardBody } from '@/shared/ui/Card'
import { Button } from '@/shared/ui/Button'
import { StarRating } from '@/shared/ui/StarRating'
import { Spinner } from '@/shared/ui/Spinner'
import { formatDate } from '@/shared/lib/format'
import { useReviews, useCreateReview } from './reviewHooks'

function initials(name: string): string {
  return name
    .split(' ')
    .map((w) => w[0])
    .filter(Boolean)
    .slice(0, 2)
    .join('')
    .toUpperCase()
}

export function ReviewSection({ productId, slug }: { productId: string; slug: string }) {
  const { t } = useTranslation()
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const { data: reviews, isLoading } = useReviews(productId)
  const createReview = useCreateReview(productId, slug)

  const [rating, setRating] = useState(0)
  const [comment, setComment] = useState('')
  const [error, setError] = useState<string | null>(null)
  const [done, setDone] = useState(false)

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault()
    setError(null)
    if (rating < 1) return
    try {
      await createReview.mutateAsync({ rating, comment: comment.trim() || null })
      setDone(true)
      setRating(0)
      setComment('')
    } catch (err) {
      setError(getErrorMessage(err, t('common.somethingWrong')))
    }
  }

  return (
    <section className="flex flex-col gap-6">
      <h2 className="text-xl font-bold">
        {t('product.reviews')}
        {reviews && reviews.length > 0 && (
          <span className="ml-2 text-base font-normal text-fg-subtle">({reviews.length})</span>
        )}
      </h2>

      {/* Review form */}
      {isAuthenticated ? (
        done ? (
          <div className="rounded-lg bg-success/10 px-4 py-3 text-sm text-success">
            {t('product.reviewSubmitted')}
          </div>
        ) : (
          <Card>
            <CardBody className="flex flex-col gap-4">
              <h3 className="font-semibold">{t('product.writeReview')}</h3>
              <form onSubmit={handleSubmit} className="flex flex-col gap-4">
                <div className="flex flex-col gap-1.5">
                  <span className="text-sm font-medium text-fg">{t('product.yourRating')}</span>
                  <StarRating value={rating} size={28} onChange={setRating} />
                </div>
                <div className="flex flex-col gap-1.5">
                  <label htmlFor="review-comment" className="text-sm font-medium text-fg">
                    {t('product.yourComment')}
                  </label>
                  <textarea
                    id="review-comment"
                    rows={3}
                    value={comment}
                    onChange={(e) => setComment(e.target.value)}
                    placeholder={t('product.commentPlaceholder')}
                    className="w-full resize-y rounded-lg border border-border bg-surface px-3.5 py-2.5 text-sm text-fg placeholder:text-fg-subtle focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-1 focus:ring-offset-bg"
                  />
                </div>
                {error && <p className="text-sm text-danger">{error}</p>}
                <Button type="submit" loading={createReview.isPending} disabled={rating < 1} className="self-start">
                  {t('product.submitReview')}
                </Button>
              </form>
            </CardBody>
          </Card>
        )
      ) : (
        <Card>
          <CardBody className="flex items-center justify-between gap-4">
            <span className="text-sm text-fg-muted">{t('product.loginToReview')}</span>
            <Link to={paths.login}>
              <Button variant="outline" size="sm">
                {t('nav.login')}
              </Button>
            </Link>
          </CardBody>
        </Card>
      )}

      {/* Review list */}
      {isLoading ? (
        <div className="flex justify-center py-8">
          <Spinner className="h-6 w-6" />
        </div>
      ) : reviews && reviews.length > 0 ? (
        <div className="flex flex-col gap-4">
          {reviews.map((r) => (
            <motion.div
              key={r.id}
              initial={{ opacity: 0, y: 8 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.3 }}
            >
              <Card>
                <CardBody className="flex flex-col gap-2">
                  <div className="flex items-center gap-3">
                    <div className="flex h-9 w-9 items-center justify-center rounded-full bg-primary/15 text-sm font-semibold text-primary">
                      {initials(r.userName)}
                    </div>
                    <div className="flex flex-1 flex-col">
                      <span className="text-sm font-semibold">{r.userName}</span>
                      <span className="text-xs text-fg-subtle">{formatDate(r.createdAt)}</span>
                    </div>
                    <StarRating value={r.rating} size={14} />
                  </div>
                  {r.comment && <p className="text-sm text-fg-muted">{r.comment}</p>}
                </CardBody>
              </Card>
            </motion.div>
          ))}
        </div>
      ) : (
        <p className="py-4 text-sm text-fg-subtle">{t('product.noReviews')}</p>
      )}
    </section>
  )
}
