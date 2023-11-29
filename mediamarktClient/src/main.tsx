import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom"

import { APIOptions, PrimeReactProvider } from 'primereact/api'

import ProductPage from './Pages/Product/ProductPage.tsx'
import HomePage from './Pages/HomePage/HomePage.tsx'

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

const value: APIOptions = {
  cssTransition: false,
  inputStyle: 'outlined'
}

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
      <PrimeReactProvider value={value}>
         <RouterProvider router={router} />
      </PrimeReactProvider>
  </React.StrictMode>
)
