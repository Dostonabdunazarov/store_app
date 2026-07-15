import { Container } from '@/shared/ui/Container'
import { Badge } from '@/shared/ui/Badge'

/**
 * Temporary stand-in for pages delivered in later phases (catalog, product,
 * cart, favorites, compare, checkout, orders, admin). Replaced phase by phase.
 */
export function PlaceholderPage({ title, phase }: { title: string; phase: string }) {
  return (
    <Container className="py-20">
      <div className="flex flex-col items-center gap-4 text-center">
        <Badge tone="brand">{phase}</Badge>
        <h1 className="text-3xl font-bold tracking-tight">{title}</h1>
        <p className="max-w-md text-fg-muted">
          Эта страница будет реализована в следующей фазе проекта.
        </p>
      </div>
    </Container>
  )
}
