import { create } from 'zustand'
import { persist } from 'zustand/middleware'

/** Minimal product snapshot the cart persists — decoupled from live catalog data. */
export interface CartItem {
  productId: string
  slug: string
  name: string
  price: number
  imageUrl: string | null
  /** Stock at the time of adding — used to cap the quantity stepper. */
  stock: number
  quantity: number
}

/** The subset of product fields the cart needs — accepts list items, detail, or snapshots. */
export interface CartableProduct {
  id: string
  slug: string
  name: string
  price: number
  stock: number
  imageUrl?: string | null
  imageUrls?: string[]
}

interface CartState {
  items: CartItem[]
  add: (product: CartableProduct, quantity?: number) => void
  setQuantity: (productId: string, quantity: number) => void
  remove: (productId: string) => void
  clear: () => void
}

function snapshot(product: CartableProduct, quantity: number): CartItem {
  const imageUrl = product.imageUrl ?? product.imageUrls?.[0] ?? null
  return {
    productId: product.id,
    slug: product.slug,
    name: product.name,
    price: product.price,
    imageUrl,
    stock: product.stock,
    quantity,
  }
}

export const useCartStore = create<CartState>()(
  persist(
    (set) => ({
      items: [],

      add: (product, quantity = 1) =>
        set((state) => {
          const existing = state.items.find((i) => i.productId === product.id)
          if (existing) {
            const next = Math.min(existing.quantity + quantity, product.stock || Infinity)
            return {
              items: state.items.map((i) =>
                i.productId === product.id ? { ...i, quantity: next, stock: product.stock } : i,
              ),
            }
          }
          const capped = Math.min(quantity, product.stock || Infinity)
          return { items: [...state.items, snapshot(product, capped)] }
        }),

      setQuantity: (productId, quantity) =>
        set((state) => ({
          items: state.items.map((i) =>
            i.productId === productId
              ? { ...i, quantity: Math.max(1, Math.min(quantity, i.stock || Infinity)) }
              : i,
          ),
        })),

      remove: (productId) =>
        set((state) => ({ items: state.items.filter((i) => i.productId !== productId) })),

      clear: () => set({ items: [] }),
    }),
    { name: 'hypex-cart' },
  ),
)

// ── Selectors (stable, no re-render churn) ──────────────────────
export const selectCartCount = (s: CartState) =>
  s.items.reduce((sum, i) => sum + i.quantity, 0)

export const selectCartTotal = (s: CartState) =>
  s.items.reduce((sum, i) => sum + i.price * i.quantity, 0)
