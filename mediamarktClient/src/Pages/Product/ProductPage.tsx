
import ProductForm from "../../components/ProductForm/ProductForm"

const ProductPage: React.FC = () => {
    return(
        <>
            <header className='bg-red-600 text-white'>
                <h1 className='text-center'>New Product</h1>
            </header>

            <ProductForm />
        </>
    )
}

export default ProductPage