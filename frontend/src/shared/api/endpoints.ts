import { api } from './client'
import type {
  AdminProductDto,
  AuthResponse,
  BrandDto,
  BrandUpsertRequest,
  CategoryDto,
  CategoryUpsertRequest,
  CreateOrderRequest,
  CreateReviewRequest,
  FavoriteDto,
  LoginRequest,
  OrderDto,
  OrderStatus,
  PagedResult,
  ProductDetailDto,
  ProductListItemDto,
  ProductQuery,
  ProductUpsertRequest,
  RegisterRequest,
  ReviewDto,
  UserDto,
} from './types'

// ── Auth ────────────────────────────────────────────────────────
export const authApi = {
  register: (body: RegisterRequest) =>
    api.post<AuthResponse>('/auth/register', body).then((r) => r.data),
  login: (body: LoginRequest) =>
    api.post<AuthResponse>('/auth/login', body).then((r) => r.data),
  me: () => api.get<UserDto>('/auth/me').then((r) => r.data),
  // refresh is handled inside the client interceptor.
}

// ── Catalog ─────────────────────────────────────────────────────
export const catalogApi = {
  products: (query: ProductQuery) =>
    api
      .get<PagedResult<ProductListItemDto>>('/products', { params: query })
      .then((r) => r.data),
  product: (slug: string) =>
    api.get<ProductDetailDto>(`/products/${slug}`).then((r) => r.data),
  categories: () => api.get<CategoryDto[]>('/categories').then((r) => r.data),
  brands: () => api.get<BrandDto[]>('/brands').then((r) => r.data),
}

// ── Reviews ─────────────────────────────────────────────────────
export const reviewsApi = {
  list: (productId: string) =>
    api.get<ReviewDto[]>(`/products/${productId}/reviews`).then((r) => r.data),
  create: (productId: string, body: CreateReviewRequest) =>
    api.post<ReviewDto>(`/products/${productId}/reviews`, body).then((r) => r.data),
}

// ── Favorites ───────────────────────────────────────────────────
export const favoritesApi = {
  list: () => api.get<FavoriteDto[]>('/favorites').then((r) => r.data),
  add: (productId: string) => api.post(`/favorites/${productId}`).then(() => undefined),
  remove: (productId: string) => api.delete(`/favorites/${productId}`).then(() => undefined),
}

// ── Orders ──────────────────────────────────────────────────────
export const ordersApi = {
  create: (body: CreateOrderRequest) =>
    api.post<OrderDto>('/orders', body).then((r) => r.data),
  list: () => api.get<OrderDto[]>('/orders').then((r) => r.data),
  get: (id: string) => api.get<OrderDto>(`/orders/${id}`).then((r) => r.data),
}

// ── Admin (role=Admin only) ─────────────────────────────────────
export const adminApi = {
  // Orders
  orders: () => api.get<OrderDto[]>('/admin/orders').then((r) => r.data),
  order: (id: string) => api.get<OrderDto>(`/admin/orders/${id}`).then((r) => r.data),
  setOrderStatus: (id: string, status: OrderStatus) =>
    api.patch(`/admin/orders/${id}/status`, { status }).then(() => undefined),

  // Products
  products: () => api.get<AdminProductDto[]>('/admin/products').then((r) => r.data),
  product: (id: string) => api.get<AdminProductDto>(`/admin/products/${id}`).then((r) => r.data),
  createProduct: (body: ProductUpsertRequest) =>
    api.post<AdminProductDto>('/admin/products', body).then((r) => r.data),
  updateProduct: (id: string, body: ProductUpsertRequest) =>
    api.put<AdminProductDto>(`/admin/products/${id}`, body).then((r) => r.data),
  deleteProduct: (id: string) =>
    api.delete(`/admin/products/${id}`).then(() => undefined),

  // Categories
  createCategory: (body: CategoryUpsertRequest) =>
    api.post<CategoryDto>('/admin/categories', body).then((r) => r.data),
  updateCategory: (id: number, body: CategoryUpsertRequest) =>
    api.put<CategoryDto>(`/admin/categories/${id}`, body).then((r) => r.data),
  deleteCategory: (id: number) =>
    api.delete(`/admin/categories/${id}`).then(() => undefined),

  // Brands
  createBrand: (body: BrandUpsertRequest) =>
    api.post<BrandDto>('/admin/brands', body).then((r) => r.data),
  updateBrand: (id: number, body: BrandUpsertRequest) =>
    api.put<BrandDto>(`/admin/brands/${id}`, body).then((r) => r.data),
  deleteBrand: (id: number) =>
    api.delete(`/admin/brands/${id}`).then(() => undefined),
}
