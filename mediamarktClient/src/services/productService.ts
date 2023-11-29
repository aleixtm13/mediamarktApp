
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