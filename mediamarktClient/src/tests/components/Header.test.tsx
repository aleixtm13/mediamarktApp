import { describe, expect, test, vi } from 'vitest'
import {render, screen} from '@testing-library/react'
import Header from '../../components/Header/Header'
import { BrowserRouter } from 'react-router-dom'
import userEvent from '@testing-library/user-event'

describe('<Header />', () => {
    test('Header mounts correctly', () => {
          // Arrange
          // Act
          const wrapper = render(<Header />, {wrapper: BrowserRouter})
          // Assert
          expect(wrapper).toBeTruthy()
          expect(screen.getByText('MediaMarkt')).toBeInTheDocument()
    })

    test('Header navigates to home page when logo is clicked', async () => {
        // Arrange
        render(<Header />, {wrapper: BrowserRouter})
        const user = userEvent.setup()
        const logo = vi.spyOn(user, 'click')
        const logoButton = screen.getByTestId('logo-button')
        
        // Act
        await user.click(logoButton)
        
        // Assert
        expect(logo).toHaveBeenCalled()
    })
})