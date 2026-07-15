import { useState } from 'react'
import { motion } from 'motion/react'
import { ProductImage } from '@/shared/ui/ProductImage'
import { cn } from '@/shared/lib/cn'

export function ProductGallery({ images, alt }: { images: string[]; alt: string }) {
  const list = images.length > 0 ? images : [null]
  const [active, setActive] = useState(0)

  return (
    <div className="flex flex-col gap-3">
      <motion.div
        key={active}
        initial={{ opacity: 0.4 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.25 }}
      >
        <ProductImage
          src={list[active]}
          alt={alt}
          className="aspect-square rounded-xl border border-border"
        />
      </motion.div>

      {list.length > 1 && (
        <div className="grid grid-cols-5 gap-2">
          {list.map((img, i) => (
            <button
              key={i}
              type="button"
              onClick={() => setActive(i)}
              className={cn(
                'overflow-hidden rounded-lg border transition-colors',
                i === active ? 'border-primary ring-1 ring-primary' : 'border-border hover:border-fg-subtle',
              )}
            >
              <ProductImage src={img} alt={`${alt} ${i + 1}`} className="aspect-square" />
            </button>
          ))}
        </div>
      )}
    </div>
  )
}
