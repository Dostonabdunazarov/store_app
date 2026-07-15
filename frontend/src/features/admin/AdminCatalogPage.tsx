import { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { Card, CardBody, CardHeader } from '@/shared/ui/Card'
import { Button } from '@/shared/ui/Button'
import { Input } from '@/shared/ui/Input'
import { Spinner } from '@/shared/ui/Spinner'
import { Badge } from '@/shared/ui/Badge'
import { getErrorMessage } from '@/shared/api/client'
import { SUPPORTED_LANGS } from '@/shared/lib/i18n'
import type { BrandDto, CategoryDto } from '@/shared/api/types'
import {
  useAdminBrands,
  useAdminCategories,
  useCreateBrand,
  useCreateCategory,
  useDeleteBrand,
  useDeleteCategory,
  useUpdateBrand,
  useUpdateCategory,
} from './adminHooks'

const LANGS = SUPPORTED_LANGS

// ── Categories ──────────────────────────────────────────────────
function CategoryEditor({ editing, onDone }: { editing: CategoryDto | null; onDone: () => void }) {
  const { t } = useTranslation()
  const create = useCreateCategory()
  const update = useUpdateCategory()
  const [slug, setSlug] = useState(editing?.slug ?? '')
  // We only have the localized name for the current UI language from the list DTO,
  // so prefill it into every language field as a sensible starting point on edit.
  const [names, setNames] = useState<Record<string, string>>(() =>
    Object.fromEntries(LANGS.map((l) => [l, editing?.name ?? ''])),
  )
  const [error, setError] = useState<string | null>(null)

  const submit = (ev: React.FormEvent) => {
    ev.preventDefault()
    setError(null)
    const body = { slug: slug.trim(), names }
    const opts = { onSuccess: onDone, onError: (e: unknown) => setError(getErrorMessage(e)) }
    if (editing) update.mutate({ id: editing.id, body }, opts)
    else create.mutate(body, opts)
  }

  return (
    <form onSubmit={submit} className="space-y-3 rounded-lg border border-border bg-surface-2 p-4">
      <Input label={t('admin.slug')} value={slug} onChange={(e) => setSlug(e.target.value)} placeholder="laptops" />
      <div className="grid gap-3 sm:grid-cols-3">
        {LANGS.map((l) => (
          <Input
            key={l}
            label={`${t('admin.name')} (${l.toUpperCase()})`}
            value={names[l]}
            onChange={(e) => setNames((n) => ({ ...n, [l]: e.target.value }))}
          />
        ))}
      </div>
      {error && <p className="text-xs text-danger">{error}</p>}
      <div className="flex justify-end gap-2">
        <Button type="button" variant="ghost" size="sm" onClick={onDone}>
          {t('common.cancel')}
        </Button>
        <Button type="submit" size="sm" loading={create.isPending || update.isPending}>
          {t('common.save')}
        </Button>
      </div>
    </form>
  )
}

function CategoriesSection() {
  const { t } = useTranslation()
  const { data, isLoading } = useAdminCategories()
  const del = useDeleteCategory()
  const [editor, setEditor] = useState<{ open: boolean; editing: CategoryDto | null }>({
    open: false,
    editing: null,
  })
  const [error, setError] = useState<string | null>(null)

  const onDelete = (c: CategoryDto) => {
    if (!window.confirm(t('admin.confirmDelete', { name: c.name }))) return
    setError(null)
    del.mutate(c.id, { onError: (e) => setError(getErrorMessage(e)) })
  }

  return (
    <Card>
      <CardHeader className="flex items-center justify-between">
        <span>{t('admin.categories')}</span>
        {!editor.open && (
          <Button size="sm" onClick={() => setEditor({ open: true, editing: null })}>
            + {t('admin.newCategory')}
          </Button>
        )}
      </CardHeader>
      <CardBody className="space-y-3">
        {editor.open && (
          <CategoryEditor
            editing={editor.editing}
            onDone={() => setEditor({ open: false, editing: null })}
          />
        )}
        {error && <p className="text-xs text-danger">{error}</p>}
        {isLoading ? (
          <div className="flex justify-center py-6">
            <Spinner className="h-6 w-6" />
          </div>
        ) : (
          <ul className="divide-y divide-border">
            {(data ?? []).map((c) => (
              <li key={c.id} className="flex items-center gap-3 py-2.5">
                <div className="min-w-0 flex-1">
                  <p className="truncate text-sm font-medium">{c.name}</p>
                  <p className="text-xs text-fg-subtle">{c.slug}</p>
                </div>
                <Badge tone="neutral">{c.productCount}</Badge>
                <Button
                  variant="outline"
                  size="sm"
                  onClick={() => setEditor({ open: true, editing: c })}
                >
                  {t('admin.edit')}
                </Button>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-danger"
                  disabled={c.productCount > 0 || del.isPending}
                  onClick={() => onDelete(c)}
                >
                  {t('admin.delete')}
                </Button>
              </li>
            ))}
          </ul>
        )}
      </CardBody>
    </Card>
  )
}

// ── Brands ──────────────────────────────────────────────────────
function BrandEditor({ editing, onDone }: { editing: BrandDto | null; onDone: () => void }) {
  const { t } = useTranslation()
  const create = useCreateBrand()
  const update = useUpdateBrand()
  const [slug, setSlug] = useState(editing?.slug ?? '')
  const [name, setName] = useState(editing?.name ?? '')
  const [logoUrl, setLogoUrl] = useState(editing?.logoUrl ?? '')
  const [error, setError] = useState<string | null>(null)

  const submit = (ev: React.FormEvent) => {
    ev.preventDefault()
    setError(null)
    const body = { slug: slug.trim(), name: name.trim(), logoUrl: logoUrl.trim() || null }
    const opts = { onSuccess: onDone, onError: (e: unknown) => setError(getErrorMessage(e)) }
    if (editing) update.mutate({ id: editing.id, body }, opts)
    else create.mutate(body, opts)
  }

  return (
    <form onSubmit={submit} className="space-y-3 rounded-lg border border-border bg-surface-2 p-4">
      <div className="grid gap-3 sm:grid-cols-2">
        <Input label={t('admin.slug')} value={slug} onChange={(e) => setSlug(e.target.value)} placeholder="apple" />
        <Input label={t('admin.name')} value={name} onChange={(e) => setName(e.target.value)} placeholder="Apple" />
      </div>
      <Input label={t('admin.logoUrl')} value={logoUrl} onChange={(e) => setLogoUrl(e.target.value)} />
      {error && <p className="text-xs text-danger">{error}</p>}
      <div className="flex justify-end gap-2">
        <Button type="button" variant="ghost" size="sm" onClick={onDone}>
          {t('common.cancel')}
        </Button>
        <Button type="submit" size="sm" loading={create.isPending || update.isPending}>
          {t('common.save')}
        </Button>
      </div>
    </form>
  )
}

function BrandsSection() {
  const { t } = useTranslation()
  const { data, isLoading } = useAdminBrands()
  const del = useDeleteBrand()
  const [editor, setEditor] = useState<{ open: boolean; editing: BrandDto | null }>({
    open: false,
    editing: null,
  })
  const [error, setError] = useState<string | null>(null)

  const onDelete = (b: BrandDto) => {
    if (!window.confirm(t('admin.confirmDelete', { name: b.name }))) return
    setError(null)
    del.mutate(b.id, { onError: (e) => setError(getErrorMessage(e)) })
  }

  return (
    <Card>
      <CardHeader className="flex items-center justify-between">
        <span>{t('admin.brands')}</span>
        {!editor.open && (
          <Button size="sm" onClick={() => setEditor({ open: true, editing: null })}>
            + {t('admin.newBrand')}
          </Button>
        )}
      </CardHeader>
      <CardBody className="space-y-3">
        {editor.open && (
          <BrandEditor editing={editor.editing} onDone={() => setEditor({ open: false, editing: null })} />
        )}
        {error && <p className="text-xs text-danger">{error}</p>}
        {isLoading ? (
          <div className="flex justify-center py-6">
            <Spinner className="h-6 w-6" />
          </div>
        ) : (
          <ul className="divide-y divide-border">
            {(data ?? []).map((b) => (
              <li key={b.id} className="flex items-center gap-3 py-2.5">
                <div className="min-w-0 flex-1">
                  <p className="truncate text-sm font-medium">{b.name}</p>
                  <p className="text-xs text-fg-subtle">{b.slug}</p>
                </div>
                <Button variant="outline" size="sm" onClick={() => setEditor({ open: true, editing: b })}>
                  {t('admin.edit')}
                </Button>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-danger"
                  disabled={del.isPending}
                  onClick={() => onDelete(b)}
                >
                  {t('admin.delete')}
                </Button>
              </li>
            ))}
          </ul>
        )}
      </CardBody>
    </Card>
  )
}

export function AdminCatalogPage() {
  return (
    <div className="grid gap-6 lg:grid-cols-2">
      <CategoriesSection />
      <BrandsSection />
    </div>
  )
}
