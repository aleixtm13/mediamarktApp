import { APIOptions, PrimeReactProvider } from 'primereact/api'
import App from '../App/App.tsx'

export default function Root() {
  const value: APIOptions = {
    cssTransition: false,
    inputStyle: 'outlined'
  }
  return (
    <PrimeReactProvider value={value}>
      <App />
    </PrimeReactProvider>
  )
}