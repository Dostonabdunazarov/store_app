import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
// Self-hosted fonts (offline-safe). Inter = body, Space Grotesk = display/headings.
import '@fontsource-variable/inter/index.css'
import '@fontsource/space-grotesk/400.css'
import '@fontsource/space-grotesk/500.css'
import '@fontsource/space-grotesk/600.css'
import '@fontsource/space-grotesk/700.css'
import './index.css'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
