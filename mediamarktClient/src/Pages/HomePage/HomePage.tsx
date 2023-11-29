import Products from '../../components/Products/Products'
import './HomePage.css'

const HomePage: React.FC = () => {

  return (
    <>
     <header className='bg-red-600 text-white'>
      <h1 className='text-center'>Mediamarkt App</h1>
     </header>
     <Products />
    </>
  )
}

export default HomePage
