import { useEffect, useMemo, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useTranslation } from 'react-i18next'
import { X } from 'lucide-react'
import { Card, CardBody, CardHeader } from '@/shared/ui/Card'
import { Button } from '@/shared/ui/Button'
import { Input } from '@/shared/ui/Input'
import { Select } from '@/shared/ui/Select'
import { Spinner } from '@/shared/ui/Spinner'
import { paths } from '@/app/routes/paths'
import { getErrorMessage, getFieldErrors } from '@/shared/api/client'
import { SUPPORTED_LANGS } from '@/shared/lib/i18n'
import type {
  ProductAttributeInput,
  ProductTranslationDto,
  ProductUpsertRequest,
} from '@/shared/api/types'
import {
  useAdminBrands,
  useAdminCategories,
  useAdminProduct,
  useCreateProduct,
  useUpdateProduct,
} from './adminHooks'

const LANGS = SUPPORTED_LANGS

interface FormState {
  slug: string
  price: string
  oldPrice: string
  stock: string
  categoryId: string
  brandId: string
  imageUrls: string
  isActive: boolean
  translations: Record<string, { name: string; description: string }>
  attributes: (ProductAttributeInput & { _id: number })[]
}

function emptyTranslations(): FormState['translations'] {
  return Object.fromEntries(LANGS.map((l) => [l, { name: '', description: '' }]))
}

let attrIdSeq = 1

export function ProductFormPage() {
  const { t } = useTranslation()
  const navigate = useNavigate()
  const { id } = useParams<{ id: string }>()
  const isEdit = !!id

  const existing = useAdminProduct(id)
  const categories = useAdminCategories()
  const brands = useAdminBrands()
  const create = useCreateProduct()
  const update = useUpdateProduct()

  const [form, setForm] = useState<FormState>({
    slug: '',
    price: '',
    oldPrice: '',
    stock: '0',
    categoryId: '',
    brandId: '',
    imageUrls: '',
    isActive: true,
    translations: emptyTranslations(),
    attributes: [],
  })
  const [activeLang, setActiveLang] = useState<string>(LANGS[0])
  const [errors, setErrors] = useState<Record<string, string>>({})
  const [formError, setFormError] = useState<string | null>(null)

  // Hydrate from existing product on edit.
  useEffect(() => {
    if (!existing.data) return
    const p = existing.data
    const translations = emptyTranslations()
    for (const tr of p.translations) {
      translations[tr.lang] = { name: tr.name, description: tr.description }
    }
    setForm({
      slug: p.slug,
      price: String(p.price),
      oldPrice: p.oldPrice != null ? String(p.oldPrice) : '',
      stock: String(p.stock),
      categoryId: String(p.categoryId),
      brandId: String(p.brandId),
      imageUrls: p.imageUrls.join('\n'),
      isActive: p.isActive,
      translations,
      attributes: p.attributes.map((a) => ({ ...a, _id: attrIdSeq++ })),
    })
  }, [existing.data])

  const patch = (part: Partial<FormState>) => setForm((f) => ({ ...f, ...part }))

  const setTranslation = (lang: string, field: 'name' | 'description', value: string) =>
    setForm((f) => ({
      ...f,
      translations: { ...f.translations, [lang]: { ...f.translations[lang], [field]: value } },
    }))

  const addAttribute = () =>
    setForm((f) => ({
      ...f,
      attributes: [
        ...f.attributes,
        { _id: attrIdSeq++, lang: activeLang, key: '', label: '', value: '', sortOrder: f.attributes.length },
      ],
    }))

  const setAttribute = (rowId: number, part: Partial<ProductAttributeInput>) =>
    setForm((f) => ({
      ...f,
      attributes: f.attributes.map((a) => (a._id === rowId ? { ...a, ...part } : a)),
    }))

  const removeAttribute = (rowId: number) =>
    setForm((f) => ({ ...f, attributes: f.attributes.filter((a) => a._id !== rowId) }))

  const attrsForLang = useMemo(
    () => form.attributes.filter((a) => a.lang === activeLang),
    [form.attributes, activeLang],
  )

  const buildRequest = (): ProductUpsertRequest => {
    const translations: ProductTranslationDto[] = LANGS.map((l) => ({
      lang: l,
      name: form.translations[l].name.trim(),
      description: form.translations[l].description.trim(),
    })).filter((tr) => tr.name.length > 0)

    const attributes: ProductAttributeInput[] = form.attributes
      .filter((a) => a.key.trim() && a.label.trim() && a.value.trim())
      .map((a, i) => ({
        lang: a.lang,
        key: a.key.trim(),
        label: a.label.trim(),
        value: a.value.trim(),
        sortOrder: a.sortOrder || i,
      }))

    return {
      slug: form.slug.trim(),
      price: Number(form.price) || 0,
      oldPrice: form.oldPrice.trim() ? Number(form.oldPrice) || null : null,
      stock: Number(form.stock) || 0,
      categoryId: Number(form.categoryId) || 0,
      brandId: Number(form.brandId) || 0,
      imageUrls: form.imageUrls
        .split('\n')
        .map((u) => u.trim())
        .filter(Boolean),
      translations,
      attributes,
      isActive: form.isActive,
    }
  }

  const validate = (req: ProductUpsertRequest): boolean => {
    const e: Record<string, string> = {}
    if (!req.slug) e.slug = t('checkout.required')
    if (!req.categoryId) e.categoryId = t('checkout.required')
    if (!req.brandId) e.brandId = t('checkout.required')
    if (req.translations.length === 0) e.translations = t('admin.needTranslation')
    setErrors(e)
    return Object.keys(e).length === 0
  }

  const onSubmit = (ev: React.FormEvent) => {
    ev.preventDefault()
    setFormError(null)
    const req = buildRequest()
    if (!validate(req)) return

    const onError = (err: unknown) => {
      setErrors(getFieldErrors(err))
      setFormError(getErrorMessage(err))
    }
    const onSuccess = () => navigate(paths.adminProducts)

    if (isEdit && id) update.mutate({ id, body: req }, { onError, onSuccess })
    else create.mutate(req, { onError, onSuccess })
  }

  if (isEdit && existing.isLoading) {
    return (
      <div className="flex justify-center py-20">
        <Spinner className="h-8 w-8" />
      </div>
    )
  }

  const saving = create.isPending || update.isPending

  return (
    <form onSubmit={onSubmit} className="space-y-5">
      <div className="flex items-center justify-between">
        <h2 className="text-lg font-semibold">
          {isEdit ? t('admin.editProduct') : t('admin.newProduct')}
        </h2>
        <Button type="button" variant="ghost" size="sm" onClick={() => navigate(paths.adminProducts)}>
          {t('common.cancel')}
        </Button>
      </div>

      {formError && (
        <p className="rounded-lg bg-danger/10 px-3 py-2 text-sm text-danger">{formError}</p>
      )}

      {/* Basics */}
      <Card>
        <CardHeader>{t('admin.basics')}</CardHeader>
        <CardBody className="grid gap-4 sm:grid-cols-2">
          <Input
            label={t('admin.slug')}
            value={form.slug}
            error={errors.slug}
            placeholder="iphone-15-pro"
            onChange={(e) => patch({ slug: e.target.value })}
          />
          <Input
            label={`${t('admin.price')} (${t('common.currency')})`}
            type="number"
            min={0}
            step="0.01"
            value={form.price}
            error={errors.price}
            onChange={(e) => patch({ price: e.target.value })}
          />
          <Input
            label={`${t('admin.oldPrice')} (${t('common.currency')})`}
            type="number"
            min={0}
            step="0.01"
            value={form.oldPrice}
            error={errors.oldPrice}
            hint={t('admin.oldPriceHint')}
            onChange={(e) => patch({ oldPrice: e.target.value })}
          />
          <Input
            label={t('admin.stock')}
            type="number"
            min={0}
            value={form.stock}
            error={errors.stock}
            onChange={(e) => patch({ stock: e.target.value })}
          />
          <Select
            label={t('admin.category')}
            value={form.categoryId}
            error={errors.categoryId}
            onChange={(e) => patch({ categoryId: e.target.value })}
          >
            <option value="">—</option>
            {(categories.data ?? []).map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </Select>
          <Select
            label={t('admin.brand')}
            value={form.brandId}
            error={errors.brandId}
            onChange={(e) => patch({ brandId: e.target.value })}
          >
            <option value="">—</option>
            {(brands.data ?? []).map((b) => (
              <option key={b.id} value={b.id}>
                {b.name}
              </option>
            ))}
          </Select>
          <label className="flex items-center gap-2 self-end pb-2.5 text-sm font-medium">
            <input
              type="checkbox"
              checked={form.isActive}
              onChange={(e) => patch({ isActive: e.target.checked })}
              className="h-4 w-4 rounded border-border accent-[var(--color-primary)]"
            />
            {t('admin.active')}
          </label>
          <div className="sm:col-span-2">
            <label className="mb-1.5 block text-sm font-medium text-fg">{t('admin.imageUrls')}</label>
            <textarea
              value={form.imageUrls}
              onChange={(e) => patch({ imageUrls: e.target.value })}
              rows={3}
              placeholder="https://…/1.jpg&#10;https://…/2.jpg"
              className="w-full rounded-lg border border-border bg-surface px-3.5 py-2.5 text-sm text-fg focus:outline-none focus:ring-2 focus:ring-primary"
            />
            <p className="mt-1 text-xs text-fg-subtle">{t('admin.imageUrlsHint')}</p>
          </div>
        </CardBody>
      </Card>

      {/* Language tabs (translations + attributes) */}
      <Card>
        <CardHeader className="flex items-center justify-between">
          <span>{t('admin.content')}</span>
          <div className="flex gap-1">
            {LANGS.map((l) => (
              <button
                key={l}
                type="button"
                onClick={() => setActiveLang(l)}
                className={`rounded-md px-2.5 py-1 text-xs font-semibold uppercase transition-colors ${
                  activeLang === l
                    ? 'bg-primary text-primary-fg'
                    : 'bg-surface-2 text-fg-muted hover:text-fg'
                }`}
              >
                {l}
              </button>
            ))}
          </div>
        </CardHeader>
        <CardBody className="space-y-4">
          {errors.translations && <p className="text-xs text-danger">{errors.translations}</p>}
          <Input
            label={t('admin.name')}
            value={form.translations[activeLang].name}
            onChange={(e) => setTranslation(activeLang, 'name', e.target.value)}
          />
          <div>
            <label className="mb-1.5 block text-sm font-medium text-fg">{t('admin.description')}</label>
            <textarea
              value={form.translations[activeLang].description}
              onChange={(e) => setTranslation(activeLang, 'description', e.target.value)}
              rows={4}
              className="w-full rounded-lg border border-border bg-surface px-3.5 py-2.5 text-sm text-fg focus:outline-none focus:ring-2 focus:ring-primary"
            />
          </div>

          {/* Attributes for the active language */}
          <div className="space-y-2">
            <div className="flex items-center justify-between">
              <span className="text-sm font-medium">{t('admin.attributes')}</span>
              <Button type="button" variant="outline" size="sm" onClick={addAttribute}>
                + {t('admin.addAttribute')}
              </Button>
            </div>
            {attrsForLang.length === 0 ? (
              <p className="text-xs text-fg-subtle">{t('admin.noAttributes')}</p>
            ) : (
              <div className="space-y-2">
                {attrsForLang.map((a) => (
                  <div key={a._id} className="grid grid-cols-[1fr_1fr_1fr_auto] gap-2">
                    <input
                      value={a.key}
                      placeholder={t('admin.attrKey')}
                      onChange={(e) => setAttribute(a._id, { key: e.target.value })}
                      className="h-9 rounded-md border border-border bg-surface px-2.5 text-sm focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <input
                      value={a.label}
                      placeholder={t('admin.attrLabel')}
                      onChange={(e) => setAttribute(a._id, { label: e.target.value })}
                      className="h-9 rounded-md border border-border bg-surface px-2.5 text-sm focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <input
                      value={a.value}
                      placeholder={t('admin.attrValue')}
                      onChange={(e) => setAttribute(a._id, { value: e.target.value })}
                      className="h-9 rounded-md border border-border bg-surface px-2.5 text-sm focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <button
                      type="button"
                      onClick={() => removeAttribute(a._id)}
                      aria-label={t('admin.delete')}
                      className="flex h-9 w-9 items-center justify-center rounded-md text-fg-subtle hover:bg-surface-2 hover:text-danger"
                    >
                      <X className="h-4 w-4" strokeWidth={2.5} />
                    </button>
                  </div>
                ))}
              </div>
            )}
          </div>
        </CardBody>
      </Card>

      <div className="flex justify-end gap-2">
        <Button type="button" variant="outline" onClick={() => navigate(paths.adminProducts)}>
          {t('common.cancel')}
        </Button>
        <Button type="submit" loading={saving}>
          {t('common.save')}
        </Button>
      </div>
    </form>
  )
}
