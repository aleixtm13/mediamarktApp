import { Product } from "../Model/Product"

export const getProducts = async (searchText: string) => {
    try  {
        let productsPATH: string = `${import.meta.env.VITE_PRODUCT_API_BASE_URL}/products`
        if(searchText) {
            productsPATH = `${productsPATH}?searchText=${searchText}`
        }
        const response = await fetch(productsPATH)
        if(!response.ok) { 
            throw new Error('Failed to fetch products')
        }
        const products = await response.json()
        return products
    } catch (error) {
        throw new Error('Failed to fetch products')
    }
}

export const createProduct = async(product: Product) => {
    try {
        const response = await fetch(`${import.meta.env.VITE_PRODUCT_API_BASE_URL}/products`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(product)
        })
        if(!response.ok) {
            throw new Error('Failed to create product')
        }
        const createdProduct = await response.json()
        return createdProduct
    } catch (error) {
        throw new Error('Failed to create product')
    }
}