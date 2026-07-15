/**
 * Tiny className combiner — filters out falsy values and joins with spaces.
 * Deliberately dependency-free (no clsx/tailwind-merge) to keep the bundle lean.
 * Order-sensitive: later classes win only if Tailwind's cascade allows it, so
 * pass conditional overrides last.
 */
export function cn(...parts: Array<string | false | null | undefined>): string {
  return parts.filter(Boolean).join(' ')
}
