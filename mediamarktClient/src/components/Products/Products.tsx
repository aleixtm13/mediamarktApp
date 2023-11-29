import { Product } from '../../Model/Product'
import { DataTable } from 'primereact/datatable'
import { Column } from 'primereact/column'
import { useEffect, useState } from 'react'
import { getProducts } from '../../services/productService'
import { Button } from 'primereact/button'
import { InputText } from 'primereact/inputtext'
import { useNavigate } from 'react-router'
import { Dialog } from 'primereact/dialog'
import ProductDetail from '../ProductDetail/ProductDetail'
import { useProductsStore } from '../../store/productsStore'
import { Skeleton } from 'primereact/skeleton'

const Products: React.FC = () => {
  
    const products = useProductsStore(state => state.products)
    const setProducts = useProductsStore(state => state.setProducts)

    const isLoadingProducts = useProductsStore(state => state.isLoadingProducts)
    const setLoadingProducts = useProductsStore(state => state.setProductsLoading)

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
        setLoadingProducts(true)
        setTimeout(() => {
            onGetProducts()
            setLoadingProducts(false)
        }, 2000)
    }, []) //TODO: simulate long query to show skeleton

    const skeleton = (
        <div>
            <div className='flex-1 mb-2'>
                <Skeleton width='100%'/>
            </div>
            <div className='flex-1'>
                <Skeleton width='100%'/>
            </div>
        </div>
        
    );
    return (
        <div className='p-3'>
            <div className='container mx-auto'>
                <div className="p-2 flex items-center justify-between">
                    <div className="flex justify-left">
                        <InputText
                            value={searchText}
                            onChange={(e) => setSearchText(e.target.value)}
                            placeholder="Search by name..."
                            className="p-inputtext-sm focus:outline-none"
                        />
                        <Button
                            icon="pi pi-search"
                            className="p-button-sm p-button-text p-ml-2"
                            onClick={onGetProducts}
                        />
                    </div>
                    <Button
                        icon="pi pi-plus"
                        className="p-button-icon"
                        tooltip='Create new product'
                        tooltipOptions={{ position: 'bottom', mouseTrack: true }}
                        onClick={onCreateProdruct}
                    />
                </div>

                {isLoadingProducts ? skeleton : 
                    <>
                        <DataTable value={products} tableStyle={{ minWidth: '50rem' }}>
                            <Column field="name"></Column>
                            <Column
                                body={(rowData: Product) => {
                                    return (
                                        <Button
                                            label="Details"
                                            icon="pi pi-info-circle"
                                            onClick={() => showModal(rowData)} />
                                    )
                                } } />
                        </DataTable>
                        <Dialog
                            visible={displayDetailsModal}
                            onHide={hideModal}
                            header={selectedProduct?.name}
                            modal
                            footer={modalFooter}
                        >
                            <ProductDetail product={selectedProduct} />
                        </Dialog>
                    </>
                }
            
            </div>
           
        </div>
    )
}

export default Products