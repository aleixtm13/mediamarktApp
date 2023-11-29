import { Product } from '../../Model/Product'
import { DataTable } from 'primereact/datatable'
import { Column } from 'primereact/column'
import { useEffect, useState } from 'react'
import { getProducts } from '../../services/productService'
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'

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
    const [searchText, setSearchText] = useState<string>('')

    const onGetProducts = async () => {
        try {
            const products = await getProducts(searchText)
            setProducts(products)
        } catch (error) {
            console.error('Error fetching products')
        }
    }

    useEffect(() => {
        onGetProducts()
    }, [])
    return (
        <div>
            <div className='container mx-auto'>
                <div className='flex'>
                    <InputText className='flex-1' value={searchText} onChange={(e) => setSearchText(e.target.value)} placeholder='Filter products by name'/>
                    <Button className='flex-1'  icon="pi pi-search" rounded outlined aria-label='search' onClick={onGetProducts}/>
                </div>
                <DataTable value={products}  tableStyle={{ minWidth: '50rem' }}>
                    <Column field="name" header="Name"></Column>
                    <Column field="productFamily" header="Product family"></Column>
                </DataTable>
            </div>
           
        </div>
    )
}

export default Products