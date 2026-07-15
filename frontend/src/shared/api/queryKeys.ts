import type { ProductQuery } from './types'

/** Centralized TanStack Query keys so invalidation stays consistent. */
export const qk = {
  me: ['me'] as const,
  products: (query: ProductQuery) => ['products', query] as const,
  product: (slug: string) => ['product', slug] as const,
  categories: ['categories'] as const,
  brands: ['brands'] as const,
  reviews: (productId: string) => ['reviews', productId] as const,
  favorites: ['favorites'] as const,
  orders: ['orders'] as const,
  order: (id: string) => ['order', id] as const,

  // Admin
  adminOrders: ['admin', 'orders'] as const,
  adminOrder: (id: string) => ['admin', 'order', id] as const,
  adminProducts: ['admin', 'products'] as const,
  adminProduct: (id: string) => ['admin', 'product', id] as const,
}
