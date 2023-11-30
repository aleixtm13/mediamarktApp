import { createRoot } from 'react-dom/client'
import './index.css'

import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import HomePage from './Pages/HomePage/HomePage.tsx';
import ProductPage from './Pages/Product/ProductPage.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/product",
    element: <ProductPage />,
  }
]);

createRoot(document.getElementById('root')!).render(
  <RouterProvider router={router} />
)
