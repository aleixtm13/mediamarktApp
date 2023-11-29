import { Product } from "../../Model/Product";

interface ProductDetailProps {
    product: Product | null;
}
const ProductDetail: React.FC<ProductDetailProps> = ({ product }) => {
    return (
        <div>
            <p>Name: {product?.name}</p>
            <p>Product Family: {product?.productFamily}</p>
            <p>Price: {product?.price}</p>
        </div>
    )
}

export default ProductDetail