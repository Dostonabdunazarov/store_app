import type { HTMLAttributes } from 'react'
import { cn } from '@/shared/lib/cn'

/** Pulsing placeholder block. Set width/height via className. */
export function Skeleton({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return (
    <div
      className={cn('animate-pulse rounded-md bg-surface-2', className)}
      {...props}
    />
  )
}
