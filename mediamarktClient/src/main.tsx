import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import store from './store/store.ts'
import {Provider} from 'react-redux'

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom"

import { APIOptions, PrimeReactProvider } from 'primereact/api'
import App from './components/App/App.tsx'


const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
]);

const value: APIOptions = {
  cssTransition: false,
  inputStyle: 'outlined'
}

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}>
      <PrimeReactProvider value={value}>
         <RouterProvider router={router} />
      </PrimeReactProvider>
    </Provider>
  </React.StrictMode>
)
