import { InputText } from "primereact/inputtext"
import { Product } from "../../Model/Product"
import { useState } from "react"
import { InputNumber } from "primereact/inputnumber"
import { Dropdown } from "primereact/dropdown"
import { Button } from "primereact/button"
import { createProduct } from "../../services/productService"
import { InputTextarea } from "primereact/inputtextarea"

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
    const [errors, setErrors] = useState({
        name: '',
        productFamily: '',
        price: ''
    });
    const handleInputChange = (e: { target: { value: any } }, fieldName: any) => {
        const value = e.target.value;
        setProduct({ ...product, [fieldName]: value });
    };

    const validateForm = () => {
        let isValid = true;
        const { name, productFamily, price } = product;
        const newErrors = { name: '', productFamily: '', price: '' };
    
        if (!name.trim()) {
          newErrors.name = 'Name is required';
          isValid = false;
        }
    
        if (!productFamily) {
          newErrors.productFamily = 'Product Family is required';
          isValid = false;
        }
    
        if (price < 0 || isNaN(price)) {
          newErrors.price = 'Price must be a non-negative number';
          isValid = false;
        }
    
        setErrors(newErrors);
        return isValid;
      };

    const handleSubmit = async(e: any) => {
        e.preventDefault();
        if(validateForm()) {
            const createdProduct = await createProduct(product)
            console.log(createdProduct)
            setProduct(createdProduct)
        } else {
            console.log('Form is not valid')
        }
       
    }
    return (
        <form onSubmit={handleSubmit}>
            <div className="p-fluid pl-28 pr-28 pt-5">
                <div className="p-field mb-4">
                    <label className="block text-sm text-gray-600 mb-1" htmlFor="name">Product Name</label>
                    <InputText 
                        id="name"
                        placeholder="Introduce the product name"
                        value={product.name}
                        onChange={(e) => handleInputChange(e, 'name')}
                        className="p-inputtext-sm w-full"
                    />
                    <small className="p-error">{errors.name}</small>
                </div>

                <div className="p-field mb-4">
                    <label className="block text-sm text-gray-600 mb-1" htmlFor="description">Description</label>
                    <InputTextarea 
                        id="name"
                        placeholder="Introduce the product description"
                        value={product.description}
                        onChange={(e) => handleInputChange(e, 'description')}
                        className="p-inputtext-sm w-full"
                    />
                </div>
                <div className="p-field mb-4">
                    <label className="block text-sm text-gray-600 mb-1" htmlFor="price">Price</label>
                    <InputNumber 
                        inputId="currency" 
                        value={product.price} 
                        onValueChange={(e) => handleInputChange(e, 'price')} 
                        mode="currency" 
                        currency="EUR"
                        className="p-inputtext-sm w-full"
                        />
                    <small className="p-error">{errors.price}</small>
                </div>

                <div className="p-field mb-4">
                    <label className="block text-sm text-gray-600 mb-1" htmlFor="productFamily">Product Family</label>
                    <Dropdown 
                        id="productFamily"
                        value={product.productFamily}
                        options={familyProducts}
                        optionLabel="name"
                        optionValue="id"
                        onChange={(e) => handleInputChange(e, 'productFamily')}
                        placeholder="Select a product family"
                        className="w-full"
                    />
                    <small className="p-error">{errors.productFamily}</small>
                </div>
                
                <div className="flex justify-center">
                    <Button label="Create product" type="submit" className="p-button" style={{ width: 'fit-content' }}/>
                </div>

            </div>
        </form>
    )
}

export default ProductForm