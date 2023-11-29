import { InputText } from "primereact/inputtext"
import { Product } from "../../Model/Product"
import { useState } from "react"
import { InputNumber } from "primereact/inputnumber"
import { Dropdown } from "primereact/dropdown"
import { Button } from "primereact/button"
import { createProduct } from "../../services/productService"

const familyProducts = [
    {
        id:'1FA85F64-5717-4562-B3FC-2C963F66AFA6',
        name: 'Coffe machines'
    },
    {
        id:'2FA85F64-5717-4562-B3FC-2C963F66AFA6',
        name: 'Smartphones'
    },
    {
        id:'3FA85F64-5717-4562-B3FC-2C963F66AFA6',
        name: 'TV'
    }] //TODO: Get from API

const ProductForm: React.FC = () => {
    const [product, setProduct] = useState<Product>({
        name: '',
        description: '',
        price: 0,
        productFamily: ''
    })
    const handleInputChange = (e: { target: { value: any } }, fieldName: any) => {
        const value = e.target.value;
        setProduct({ ...product, [fieldName]: value });
    };

    const handleSubmit = async(e: any) => {
        e.preventDefault();
        const createdProduct = await createProduct(product)
        console.log(createdProduct)
        setProduct(createdProduct)
    }
    return (
        <form onSubmit={handleSubmit}>
             <div className="p-fluid">
                <div className="p-field">
                    <label htmlFor="name">Product Name</label>
                    <InputText 
                        id="name"
                        placeholder="Introduce the product name"
                        value={product.name}
                        onChange={(e) => handleInputChange(e, 'name')}
                    />
                </div>

                <div className="p-field">
                    <label htmlFor="description">Description</label>
                    <InputText 
                        id="name"
                        placeholder="Introduce the product description"
                        value={product.description}
                        onChange={(e) => handleInputChange(e, 'description')}
                    />
                </div>
                <div className="p-field">
                    <label htmlFor="price">Price</label>
                    <InputNumber 
                        inputId="currency" 
                        value={product.price} 
                        onValueChange={(e) => handleInputChange(e, 'price')} 
                        mode="currency" 
                        currency="EUR"
                        />
                </div>

                <div className="p-field">
                    <label htmlFor="productFamily">Product Family</label>
                    <Dropdown 
                        id="productFamily"
                        value={product.productFamily}
                        options={familyProducts}
                        optionLabel="name"
                        optionValue="id"
                        onChange={(e) => handleInputChange(e, 'productFamily')}
                        placeholder="Select a product family"
                    />
                </div>
                <div className="p-field">
                    <Button label="Submit" type="submit" />
                </div>
             </div>
        </form>
    )
}

export default ProductForm