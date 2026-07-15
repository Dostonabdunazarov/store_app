import { Spinner } from './Spinner'

/** Full-viewport centered spinner for route-level suspense/loading. */
export function PageSpinner() {
  return (
    <div className="flex min-h-[60vh] items-center justify-center text-primary">
      <Spinner className="h-8 w-8" />
    </div>
  )
}
