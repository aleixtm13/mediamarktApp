import { Product } from "../../Model/Product";

interface ProductDetailProps {
    product: Product | null;
}
const ProductDetail: React.FC<ProductDetailProps> = ({ product }) => {
    return (
        <div className="p-4">
            <div className="mb-4">
                <p className="text-gray-600">Description:</p>
                <p>{product?.description}</p>
            </div>
            <div className="mb-4">
                <p className="text-gray-600">Product Family</p>
                <p>{product?.productFamily}</p>
            </div>
            <div>
                <p className="text-gray-600">Price:</p>
                <p>{product?.price} €</p>
            </div>
      </div>
    )
}

export default ProductDetail