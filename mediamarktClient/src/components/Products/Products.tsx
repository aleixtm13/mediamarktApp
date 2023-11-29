import { Product } from '../../Model/Product'
import { DataTable } from 'primereact/datatable'
import { Column } from 'primereact/column'
import { useEffect, useState } from 'react'
import { getProducts } from '../../services/productService'

const products: Product[] = [
    {
        id: "1",
        name: "iPhone 12",
        description: "Apple iPhone 12 64GB Zwart",
        price: 909,
        productFamily: "Smartphone"
    },
    {
        id: "2",
        name: "Delonghi Dedica",
        description: "Delonghi Dedica EC685.BK",
        price: 199.9,
        productFamily: "coffee machine"
    },
]

const Products: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([])

    useEffect(() => {
        const onGetProducts = async () => {
            try {
                const products = await getProducts('')
                setProducts(products)
            } catch (error) {
                console.error('Error fetching products')
            }
        }
        onGetProducts()
    })
    return (
        <div>
            <div className='container'>
                <DataTable value={products}  tableStyle={{ minWidth: '50rem' }}>
                    <Column field="name" header="Name"></Column>
                    <Column field="productFamily" header="Product family"></Column>
                </DataTable>
            </div>
           
        </div>
    )
}

export default Products