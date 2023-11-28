import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import store from './store/store.ts'
import {Provider} from 'react-redux'

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom"
import Root from './components/Root/root.tsx'

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>,
)
