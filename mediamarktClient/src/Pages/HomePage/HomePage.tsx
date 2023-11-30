import Layout from '../../components/Layout/Layout'
import Products from '../../components/Products/Products'
import './HomePage.css'
const HomePage: React.FC = () => {

  return (
    <Layout>
      <div className='p-1 container justify-center text-center mx-auto'>
        <h1 className="text-4xl font-bold">Products</h1>
      </div>
      
      <Products />
    </Layout>
  )
}

export default HomePage
