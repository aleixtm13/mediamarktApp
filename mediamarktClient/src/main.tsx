import { createRoot } from 'react-dom/client'
import './index.css'
import router from './router/router'
import { RouterProvider } from 'react-router'

createRoot(document.getElementById('root')!).render(
  <RouterProvider router={router} />
)
