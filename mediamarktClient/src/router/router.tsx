import { createBrowserRouter } from "react-router-dom";
import HomePage from "../Pages/HomePage/HomePage";
import ProductPage from "../Pages/Product/ProductPage";

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

  export default router