import { Product } from '../../Model/Product'
import { DataTable } from 'primereact/datatable'
import { Column } from 'primereact/column'
import { useEffect, useState } from 'react'
import { getProducts } from '../../services/productService'
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'
import { useNavigate } from 'react-router'
import { Dialog } from 'primereact/dialog'
import { set } from 'immer/dist/internal.js'
import ProductDetail from '../ProductDetail/ProductDetail'

const Products: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([])
    const [selectedProduct, setSelectedProduct] = useState<Product | null>(null)
    const [searchText, setSearchText] = useState<string>('')
    const [displayDetailsModal, setDisplayDetailsModal] = useState<boolean>(false)
    const navigate = useNavigate()

    const onGetProducts = async () => {
        try {
            const products = await getProducts(searchText)
            setProducts(products)
        } catch (error) {
            console.error('Error fetching products')
        }
    }

    const onCreateProdruct = async () => {
        navigate('/product')
    }

    const showModal = (product: Product) => {
        setSelectedProduct(product)
        setDisplayDetailsModal(true)
    }
    const hideModal = () => {
        setDisplayDetailsModal(false)
    }
    const modalFooter = (
        <div>
          <Button label="Close" icon="pi pi-times" onClick={hideModal} className="p-button-text" />
        </div>
      );

    useEffect(() => {
        onGetProducts()
    }, [])
    return (
        <div>
            <div className='container mx-auto'>
                <div className='flex'>
                    <InputText className='flex-1' value={searchText} onChange={(e) => setSearchText(e.target.value)} placeholder='Filter products by name'/>
                    <Button className='flex-1' icon="pi pi-search" rounded outlined aria-label='search' onClick={onGetProducts}/>
                    <Button className='flex-1' icon="pi pi-plus" rounded outlined aria-label='add' onClick={onCreateProdruct} tooltip='Add new product'/>
                </div>
                <DataTable value={products}  tableStyle={{ minWidth: '50rem' }}>
                    <Column field="name" header="Name"></Column>
                    <Column field="productFamily" header="Product family"></Column>
                    <Column
                        body={
                            (rowData: Product) => {
                                return (
                                    <Button
                                        label="Details"
                                        icon="pi pi-info-circle"
                                        onClick={() => showModal(rowData)}
                                    />
                                )
                            }
                        }
                    />
                </DataTable>

                <Dialog
                    visible ={displayDetailsModal}
                    onHide={hideModal}
                    header="Product details"
                    modal
                    footer={modalFooter}
                >
                    <ProductDetail product={selectedProduct}/>
                </Dialog>
            </div>
           
        </div>
    )
}

export default Products