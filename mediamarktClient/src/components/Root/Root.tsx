import { APIOptions, PrimeReactProvider } from "primereact/api";
import Header from "../Header/Header";
import { RouterProvider } from "react-router";
import ProductPage from "../../Pages/Product/ProductPage";
import HomePage from "../../Pages/HomePage/HomePage";
import { createBrowserRouter } from "react-router-dom";

const Root: React.FC = () => {
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
    
    return (
    <PrimeReactProvider value={value}>
        <Header />
        <RouterProvider router={router} />
    </PrimeReactProvider>
    )
}

export default Root