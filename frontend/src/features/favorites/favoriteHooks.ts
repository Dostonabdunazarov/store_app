import { useCallback, useEffect, useRef } from 'react'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { favoritesApi } from '@/shared/api/endpoints'
import { qk } from '@/shared/api/queryKeys'
import { useAuthStore } from '@/shared/store/auth.store'
import { useLocalFavorites } from '@/shared/store/favorites.local'
import type { FavoriteDto, ProductDetailDto, ProductListItemDto } from '@/shared/api/types'

/** Server-backed favorites list; only fetched when authenticated. */
export function useFavorites() {
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  return useQuery({
    queryKey: qk.favorites,
    queryFn: favoritesApi.list,
    enabled: isAuthenticated,
    staleTime: 30_000,
  })
}

/**
 * Unified favorite state for a single product: reads from the server list when
 * signed in, from the guest store otherwise. Returns `[isFavorite, toggle]`.
 */
export function useFavoriteToggle(
  product: ProductListItemDto | ProductDetailDto,
): [boolean, () => void] {
  const qc = useQueryClient()
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)

  const localItems = useLocalFavorites((s) => s.items)
  const localToggle = useLocalFavorites((s) => s.toggle)

  const serverFavs = qc.getQueryData<FavoriteDto[]>(qk.favorites)
  const isFavorite = isAuthenticated
    ? !!serverFavs?.some((f) => f.productId === product.id)
    : localItems.some((f) => f.productId === product.id)

  const mutation = useMutation({
    mutationFn: (add: boolean) =>
      add ? favoritesApi.add(product.id) : favoritesApi.remove(product.id),
    onSuccess: () => qc.invalidateQueries({ queryKey: qk.favorites }),
  })

  const toggle = useCallback(() => {
    if (isAuthenticated) mutation.mutate(!isFavorite)
    else localToggle(product)
  }, [isAuthenticated, isFavorite, mutation, localToggle, product])

  return [isFavorite, toggle]
}

/**
 * One-time sync: when a guest signs in, push their local favorites to the server
 * and clear the guest store. Mount once (in a provider/layout).
 */
export function useFavoritesSync() {
  const qc = useQueryClient()
  const isAuthenticated = useAuthStore((s) => s.isAuthenticated)
  const synced = useRef(false)

  useEffect(() => {
    if (!isAuthenticated) {
      synced.current = false
      return
    }
    if (synced.current) return
    synced.current = true

    const { ids, clear } = useLocalFavorites.getState()
    const localIds = ids()
    if (localIds.length === 0) return

    Promise.allSettled(localIds.map((id) => favoritesApi.add(id))).then(() => {
      clear()
      qc.invalidateQueries({ queryKey: qk.favorites })
    })
  }, [isAuthenticated, qc])
}
