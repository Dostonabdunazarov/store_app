import { keepPreviousData, useQuery } from '@tanstack/react-query'
import { catalogApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import type { ProductQuery } from '@/shared/api/types'

export function useProducts(query: ProductQuery) {
  return useQuery({
    queryKey: qk.products(query),
    queryFn: () => catalogApi.products(query),
    placeholderData: keepPreviousData, // keep the grid visible while paging/filtering
  })
}

export function useProduct(slug: string) {
  return useQuery({
    queryKey: qk.product(slug),
    queryFn: () => catalogApi.product(slug),
    enabled: !!slug,
  })
}

export function useCategories() {
  return useQuery({
    queryKey: qk.categories,
    queryFn: catalogApi.categories,
    staleTime: 5 * 60_000, // taxonomy rarely changes
  })
}

export function useBrands() {
  return useQuery({
    queryKey: qk.brands,
    queryFn: catalogApi.brands,
    staleTime: 5 * 60_000,
  })
}
