import { Minus, Plus } from 'lucide-react'
import { cn } from '@/shared/lib/cn'

interface QuantityStepperProps {
  value: number
  onChange: (value: number) => void
  min?: number
  max?: number
  className?: string
}

/** Compact −/N/+ stepper with clamping. */
export function QuantityStepper({
  value,
  onChange,
  min = 1,
  max = Infinity,
  className,
}: QuantityStepperProps) {
  const dec = () => onChange(Math.max(min, value - 1))
  const inc = () => onChange(Math.min(max, value + 1))

  return (
    <div className={cn('inline-flex items-center rounded-lg border border-border', className)}>
      <button
        type="button"
        onClick={dec}
        disabled={value <= min}
        aria-label="−"
        className="flex h-9 w-9 items-center justify-center text-fg-muted transition-colors hover:text-fg disabled:cursor-not-allowed disabled:opacity-40"
      >
        <Minus className="h-3.5 w-3.5" strokeWidth={2.5} />
      </button>
      <span className="min-w-8 text-center text-sm font-semibold tabular-nums">{value}</span>
      <button
        type="button"
        onClick={inc}
        disabled={value >= max}
        aria-label="+"
        className="flex h-9 w-9 items-center justify-center text-fg-muted transition-colors hover:text-fg disabled:cursor-not-allowed disabled:opacity-40"
      >
        <Plus className="h-3.5 w-3.5" strokeWidth={2.5} />
      </button>
    </div>
  )
}
