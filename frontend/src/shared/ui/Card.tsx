import type { HTMLAttributes } from 'react'
import { cn } from '@/shared/lib/cn'

export interface CardProps extends HTMLAttributes<HTMLDivElement> {
  interactive?: boolean
}

/** Surface container with border + card shadow. `interactive` adds hover lift. */
export function Card({ interactive, className, ...props }: CardProps) {
  return (
    <div
      className={cn(
        'glass rounded-2xl border shadow-card',
        interactive &&
          'transition-[transform,box-shadow,border-color] duration-300 hover:-translate-y-0.5 hover:border-white/20 hover:shadow-elevated',
        className,
      )}
      {...props}
    />
  )
}

export function CardBody({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return <div className={cn('p-5', className)} {...props} />
}

export function CardHeader({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return (
    <div
      className={cn('border-b border-border px-5 py-4 font-semibold', className)}
      {...props}
    />
  )
}
