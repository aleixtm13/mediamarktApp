import { Button } from "primereact/button"
import { useNavigate } from "react-router";
const Header: React.FC = () => {
    const navigate = useNavigate()
    const onAppLogoClick = () => {
        navigate('/')
    }
    return (
    <div className="text-white" style={{backgroundColor: 'var(--primary-color)'}}>
        <div className="container mx-auto py-4 flex justify-center">
            <Button
            id="logo-button"
            data-testid="logo-button"
            onClick={onAppLogoClick}
            >
                <h1 className="text-2xl font-semibold">MediaMarkt</h1>
            </Button>
            
        </div>
    </div>
    )
}

export default Header;