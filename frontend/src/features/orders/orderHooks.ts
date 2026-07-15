import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { ordersApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { useAuthStore } from '@/shared/store/auth.store'
import type { CreateOrderRequest } from '@/shared/api/types'

export function useOrders() {
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  return useQuery({
    queryKey: qk.orders,
    queryFn: ordersApi.list,
    enabled: isAuthenticated,
  })
}

export function useOrder(id: string | undefined) {
  return useQuery({
    queryKey: qk.order(id ?? ''),
    queryFn: () => ordersApi.get(id as string),
    enabled: !!id,
  })
}

export function useCreateOrder() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (body: CreateOrderRequest) => ordersApi.create(body),
    onSuccess: () => qc.invalidateQueries({ queryKey: qk.orders }),
  })
}
