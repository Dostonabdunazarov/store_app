import type { ComponentType } from 'react'
import { useTranslation } from 'react-i18next'
import { motion } from 'motion/react'
import { Clock, Mail, MapPin, Phone, type LucideProps } from 'lucide-react'
import { Container } from '@/shared/ui/Container'

type Icon = ComponentType<LucideProps>

/** Public "About us" page: company intro + contact details and a map. */
export function AboutPage() {
  const { t } = useTranslation()

  const contacts: { icon: Icon; label: string; value: string; href?: string }[] = [
    { icon: MapPin, label: t('about.addressLabel'), value: t('about.address') },
    {
      icon: Phone,
      label: t('about.phoneLabel'),
      value: t('about.phone'),
      href: `tel:${t('about.phone').replace(/[^+\d]/g, '')}`,
    },
    {
      icon: Mail,
      label: t('about.emailLabel'),
      value: t('about.email'),
      href: `mailto:${t('about.email')}`,
    },
    { icon: Clock, label: t('about.hoursLabel'), value: t('about.hours') },
  ]

  const mapSrc = `https://www.google.com/maps?q=${encodeURIComponent(t('about.address'))}&output=embed`

  return (
    <Container className="py-10 lg:py-14">
      <motion.div
        initial={{ opacity: 0, y: 16 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5, ease: 'easeOut' }}
        className="flex flex-col gap-10"
      >
        {/* Intro */}
        <header className="flex max-w-3xl flex-col gap-4">
          <h1 className="text-3xl font-bold tracking-tight sm:text-4xl">{t('about.title')}</h1>
          <p className="text-lg text-fg-muted">{t('about.lead')}</p>
          <p className="text-fg-muted">{t('about.body')}</p>
        </header>

        {/* Contacts + map */}
        <section className="grid gap-8 lg:grid-cols-2">
          <div className="flex flex-col gap-5">
            <h2 className="text-xl font-bold tracking-tight">{t('about.contactsTitle')}</h2>
            <ul className="flex flex-col gap-4">
              {contacts.map(({ icon: Icon, label, value, href }) => (
                <li key={label} className="flex items-start gap-3">
                  <span className="flex h-10 w-10 shrink-0 items-center justify-center rounded-xl bg-primary/10 text-primary">
                    <Icon className="h-5 w-5" strokeWidth={2} />
                  </span>
                  <div className="flex flex-col">
                    <span className="text-xs font-medium uppercase tracking-wide text-fg-subtle">
                      {label}
                    </span>
                    {href ? (
                      <a href={href} className="text-fg transition-colors hover:text-primary">
                        {value}
                      </a>
                    ) : (
                      <span className="text-fg">{value}</span>
                    )}
                  </div>
                </li>
              ))}
            </ul>
          </div>

          <div className="overflow-hidden rounded-2xl border border-border shadow-card">
            <iframe
              title={t('about.title')}
              src={mapSrc}
              loading="lazy"
              referrerPolicy="no-referrer-when-downgrade"
              className="h-72 w-full lg:h-full lg:min-h-80"
            />
          </div>
        </section>
      </motion.div>
    </Container>
  )
}
