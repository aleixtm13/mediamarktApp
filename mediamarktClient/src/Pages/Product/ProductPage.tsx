
import ProductForm from "../../components/ProductForm/ProductForm"

const ProductPage: React.FC = () => {
    return (
        <> 
         <div className='p-1 container justify-center text-center mx-auto'>
            <h1 className="text-4xl font-bold">Create a new product</h1>
        </div>
        <ProductForm />
        </>
      
    )
}

export default ProductPage