import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import '@fontsource-variable/onest/index.css'
import '@fontsource/unbounded/300.css'
import '@fontsource/unbounded/400.css'
import '@fontsource/cormorant-garamond/500-italic.css'
import './index.css'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
