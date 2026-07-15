/**
 * TypeScript mirror of the backend API contract.
 * JSON is camelCase; enums are serialized as NUMBERS (no string converter).
 */

// ── Enums (wire format = number) ────────────────────────────────
export const UserRole = { Customer: 0, Admin: 1 } as const
export type UserRole = (typeof UserRole)[keyof typeof UserRole]

export const OrderStatus = {
  Pending: 0,
  Confirmed: 1,
  Shipped: 2,
  Delivered: 3,
  Cancelled: 4,
} as const
export type OrderStatus = (typeof OrderStatus)[keyof typeof OrderStatus]

// ── Auth ────────────────────────────────────────────────────────
export interface UserDto {
  id: string
  email: string
  fullName: string
  role: UserRole
}

export interface AuthResponse {
  accessToken: string
  refreshToken: string
  accessTokenExpiresAt: string // ISO-8601 UTC
  user: UserDto
}

export interface RegisterRequest {
  email: string
  password: string
  fullName: string
}

export interface LoginRequest {
  email: string
  password: string
}

export interface RefreshRequest {
  refreshToken: string
}

// ── Catalog ─────────────────────────────────────────────────────
export interface PagedResult<T> {
  items: T[]
  page: number
  pageSize: number
  totalCount: number
  totalPages: number
}

export interface ProductListItemDto {
  id: string
  slug: string
  name: string
  price: number
  stock: number
  inStock: boolean
  ratingAverage: number
  ratingCount: number
  categorySlug: string
  brandName: string
  imageUrl: string | null
}

export interface ProductAttributeDto {
  key: string
  label: string
  value: string
}

export interface ProductDetailDto {
  id: string
  slug: string
  name: string
  description: string
  price: number
  stock: number
  inStock: boolean
  ratingAverage: number
  ratingCount: number
  categorySlug: string
  categoryName: string
  brandSlug: string
  brandName: string
  imageUrls: string[]
  attributes: ProductAttributeDto[]
}

export interface CategoryDto {
  id: number
  slug: string
  name: string
  productCount: number
}

export interface BrandDto {
  id: number
  slug: string
  name: string
  logoUrl: string | null
}

export type ProductSort = 'newest' | 'price_asc' | 'price_desc' | 'rating' | 'name'

export interface ProductQuery {
  search?: string
  category?: string
  brand?: string
  minPrice?: number
  maxPrice?: number
  inStock?: boolean
  sort?: ProductSort
  page?: number
  pageSize?: number
}

// ── Reviews ─────────────────────────────────────────────────────
export interface ReviewDto {
  id: string
  productId: string
  userId: string
  userName: string
  rating: number
  comment: string | null
  createdAt: string
}

export interface CreateReviewRequest {
  rating: number
  comment?: string | null
}

// ── Favorites ───────────────────────────────────────────────────
export interface FavoriteDto {
  productId: string
  slug: string
  name: string
  price: number
  imageUrl: string | null
  createdAt: string
}

// ── Orders ──────────────────────────────────────────────────────
export interface OrderItemRequest {
  productId: string
  quantity: number
}

export interface CreateOrderRequest {
  contactName: string
  contactPhone: string
  shippingCity: string
  shippingAddress: string
  comment?: string | null
  items: OrderItemRequest[]
}

export interface OrderItemDto {
  productId: string | null
  productName: string
  productImageUrl: string | null
  unitPrice: number
  quantity: number
  lineTotal: number
}

export interface OrderDto {
  id: string
  status: OrderStatus
  contactName: string
  contactPhone: string
  shippingCity: string
  shippingAddress: string
  comment: string | null
  totalAmount: number
  createdAt: string
  updatedAt: string
  items: OrderItemDto[]
}

// ── Admin ───────────────────────────────────────────────────────
export interface ProductTranslationDto {
  lang: string
  name: string
  description: string
}

export interface ProductAttributeInput {
  lang: string
  key: string
  label: string
  value: string
  sortOrder: number
}

export interface AdminProductDto {
  id: string
  slug: string
  price: number
  stock: number
  categoryId: number
  brandId: number
  categorySlug: string
  brandName: string
  imageUrls: string[]
  ratingAverage: number
  ratingCount: number
  isActive: boolean
  createdAt: string
  translations: ProductTranslationDto[]
  attributes: ProductAttributeInput[]
}

export interface ProductUpsertRequest {
  slug: string
  price: number
  stock: number
  categoryId: number
  brandId: number
  imageUrls: string[]
  translations: ProductTranslationDto[]
  attributes: ProductAttributeInput[]
  isActive: boolean
}

export interface CategoryUpsertRequest {
  slug: string
  /** lang → localized name (e.g. { ru: '…', uz: '…', en: '…' }). */
  names: Record<string, string>
}

export interface BrandUpsertRequest {
  slug: string
  name: string
  logoUrl?: string | null
}

export interface UpdateOrderStatusRequest {
  status: OrderStatus
}

// ── Error shapes ────────────────────────────────────────────────
/** RFC7807 ProblemDetails (business errors + 500). */
export interface ProblemDetails {
  status: number
  title: string
  type?: string
}

/** FluentValidation failure — `errors` keyed by PascalCase property name. */
export interface ValidationProblemDetails extends ProblemDetails {
  errors: Record<string, string[]>
}
