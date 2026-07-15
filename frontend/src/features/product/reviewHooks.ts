import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { reviewsApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import type { CreateReviewRequest } from '@/shared/api/types'

export function useReviews(productId: string | undefined) {
  return useQuery({
    queryKey: qk.reviews(productId ?? ''),
    queryFn: () => reviewsApi.list(productId as string),
    enabled: !!productId,
  })
}

export function useCreateReview(productId: string, slug: string) {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (body: CreateReviewRequest) => reviewsApi.create(productId, body),
    onSuccess: () => {
      // Refresh reviews list + the product detail (rating average/count changed).
      qc.invalidateQueries({ queryKey: qk.reviews(productId) })
      qc.invalidateQueries({ queryKey: qk.product(slug) })
    },
  })
}
