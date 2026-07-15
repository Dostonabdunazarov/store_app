import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { adminApi, catalogApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { useAuthStore } from '@/shared/store/auth.store'
import type {
  BrandUpsertRequest,
  CategoryUpsertRequest,
  OrderStatus,
  ProductUpsertRequest,
} from '@/shared/api/types'

// ── Orders ──────────────────────────────────────────────────────
export function useAdminOrders() {
  const isAdmin = useAuthStore((s) => s.isAdmin)
  return useQuery({ queryKey: qk.adminOrders, queryFn: adminApi.orders, enabled: isAdmin })
}

export function useUpdateOrderStatus() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: ({ id, status }: { id: string; status: OrderStatus }) =>
      adminApi.setOrderStatus(id, status),
    onSuccess: () => qc.invalidateQueries({ queryKey: qk.adminOrders }),
  })
}

// ── Products ────────────────────────────────────────────────────
export function useAdminProducts() {
  const isAdmin = useAuthStore((s) => s.isAdmin)
  return useQuery({ queryKey: qk.adminProducts, queryFn: adminApi.products, enabled: isAdmin })
}

export function useAdminProduct(id: string | undefined) {
  return useQuery({
    queryKey: qk.adminProduct(id ?? ''),
    queryFn: () => adminApi.product(id as string),
    enabled: !!id,
  })
}

function invalidateProducts(qc: ReturnType<typeof useQueryClient>) {
  qc.invalidateQueries({ queryKey: qk.adminProducts })
  qc.invalidateQueries({ queryKey: ['products'] })
  qc.invalidateQueries({ queryKey: qk.categories })
}

export function useCreateProduct() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (body: ProductUpsertRequest) => adminApi.createProduct(body),
    onSuccess: () => invalidateProducts(qc),
  })
}

export function useUpdateProduct() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: ({ id, body }: { id: string; body: ProductUpsertRequest }) =>
      adminApi.updateProduct(id, body),
    onSuccess: (_res, { id }) => {
      invalidateProducts(qc)
      qc.invalidateQueries({ queryKey: qk.adminProduct(id) })
    },
  })
}

export function useDeleteProduct() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (id: string) => adminApi.deleteProduct(id),
    onSuccess: () => invalidateProducts(qc),
  })
}

// ── Categories & Brands ─────────────────────────────────────────
export function useAdminCategories() {
  return useQuery({ queryKey: qk.categories, queryFn: catalogApi.categories })
}

export function useAdminBrands() {
  return useQuery({ queryKey: qk.brands, queryFn: catalogApi.brands })
}

function invalidateCategories(qc: ReturnType<typeof useQueryClient>) {
  qc.invalidateQueries({ queryKey: qk.categories })
}
function invalidateBrands(qc: ReturnType<typeof useQueryClient>) {
  qc.invalidateQueries({ queryKey: qk.brands })
}

export function useCreateCategory() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (body: CategoryUpsertRequest) => adminApi.createCategory(body),
    onSuccess: () => invalidateCategories(qc),
  })
}
export function useUpdateCategory() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: ({ id, body }: { id: number; body: CategoryUpsertRequest }) =>
      adminApi.updateCategory(id, body),
    onSuccess: () => invalidateCategories(qc),
  })
}
export function useDeleteCategory() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (id: number) => adminApi.deleteCategory(id),
    onSuccess: () => invalidateCategories(qc),
  })
}

export function useCreateBrand() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (body: BrandUpsertRequest) => adminApi.createBrand(body),
    onSuccess: () => invalidateBrands(qc),
  })
}
export function useUpdateBrand() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: ({ id, body }: { id: number; body: BrandUpsertRequest }) =>
      adminApi.updateBrand(id, body),
    onSuccess: () => invalidateBrands(qc),
  })
}
export function useDeleteBrand() {
  const qc = useQueryClient()
  return useMutation({
    mutationFn: (id: number) => adminApi.deleteBrand(id),
    onSuccess: () => invalidateBrands(qc),
  })
}
