import type { HTMLAttributes } from 'react'
import { cn } from '@/shared/lib/cn'

/** Max-width page gutter used by all pages for consistent horizontal rhythm.
 *  The hero carousel opts out of this (rendered outside Container) to stay
 *  full-bleed; everything else is centered within this width. */
export function Container({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return (
    <div
      className={cn('mx-auto w-full max-w-7xl px-4 sm:px-6 lg:px-8', className)}
      {...props}
    />
  )
}
