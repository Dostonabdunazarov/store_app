import { create } from 'zustand'
import { persist } from 'zustand/middleware'

/** Snapshot mirroring the server FavoriteDto shape so both render identically. */
export interface LocalFavorite {
  productId: string
  slug: string
  name: string
  price: number
  imageUrl: string | null
}

/** Minimal product fields needed to snapshot a favorite. */
export interface FavoritableProduct {
  id: string
  slug: string
  name: string
  price: number
  imageUrl?: string | null
  imageUrls?: string[]
}

/**
 * Guest favorites — a local, persisted list used while the user is signed out.
 * On login these product IDs are pushed to the server (see useFavoritesSync) and
 * the local list is cleared, so it never competes with the server as source of truth.
 */
interface LocalFavoritesState {
  items: LocalFavorite[]
  toggle: (product: FavoritableProduct) => void
  has: (productId: string) => boolean
  ids: () => string[]
  clear: () => void
}

function snapshot(product: FavoritableProduct): LocalFavorite {
  return {
    productId: product.id,
    slug: product.slug,
    name: product.name,
    price: product.price,
    imageUrl: product.imageUrl ?? product.imageUrls?.[0] ?? null,
  }
}

export const useLocalFavorites = create<LocalFavoritesState>()(
  persist(
    (set, get) => ({
      items: [],
      toggle: (product) =>
        set((s) => ({
          items: s.items.some((f) => f.productId === product.id)
            ? s.items.filter((f) => f.productId !== product.id)
            : [...s.items, snapshot(product)],
        })),
      has: (productId) => get().items.some((f) => f.productId === productId),
      ids: () => get().items.map((f) => f.productId),
      clear: () => set({ items: [] }),
    }),
    { name: 'hypex-favorites-guest' },
  ),
)
