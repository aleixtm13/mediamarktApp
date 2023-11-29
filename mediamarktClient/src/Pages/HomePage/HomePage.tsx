import Products from '../../components/Products/Products'
import './HomePage.css'
const HomePage: React.FC = () => {

  return (
    <>
      <div className='p-1 container justify-center text-center mx-auto'>
        <h1 className="text-4xl font-bold">Products</h1>
      </div>
      
      <Products />
    </>
  )
}

export default HomePage
