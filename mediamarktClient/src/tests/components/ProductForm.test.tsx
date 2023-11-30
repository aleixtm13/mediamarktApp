import { describe, test, expect, vi } from 'vitest'
import { fireEvent, render, screen } from '@testing-library/react'
import ProductForm from '../../components/ProductForm/ProductForm'
import { BrowserRouter } from 'react-router-dom'
import userEvent from '@testing-library/user-event'

describe('<ProductForm />', () => {
    test('ProductForm mounts correctly', () => {
        // Arrange
        // Act
        const wrapper = render(<ProductForm />, {wrapper: BrowserRouter})
        // Assert
        expect(wrapper).toBeTruthy()
    })
    test('ProductForm inputs and its props', () => {
        // Arrange
        render(<ProductForm />, {wrapper: BrowserRouter})

        const nameInput = document.querySelector('#name') as HTMLInputElement | null
        const descriptionInput = document.querySelector('#description') as HTMLInputElement | null
        const priceInput = document.querySelector('#price') as HTMLInputElement | null
        const productFamilyInput = document.querySelector('#productFamily') as HTMLInputElement | null
        // Act
        // Assert
        
        expect(nameInput).toBeTruthy()
        expect(nameInput).toBeRequired()
        expect(nameInput?.value).toBe('')
        expect(nameInput?.type).toBe('text')
        expect(nameInput?.placeholder).toBe('Introduce the product name')

        expect(descriptionInput).toBeTruthy()
        expect(descriptionInput?.value).toBe('')
        expect(descriptionInput?.type).toBe('textarea')
        expect(descriptionInput?.placeholder).toBe('Introduce the product description')

        expect(priceInput).toBeTruthy()

        expect(productFamilyInput).toBeTruthy()
    })

    test('ProductForm inputs updates its value when the user change it', () => {
        // Arrange
        render(<ProductForm />, {wrapper: BrowserRouter})

        const nameInput = document.querySelector('#name') as HTMLInputElement | null
        const productName: string = 'Product name'

        const descriptionInput = document.querySelector('#description') as HTMLInputElement | null
        const priceInput = document.querySelector('#price') as HTMLInputElement | null
        const productFamilyInput = document.querySelector('#productFamily') as HTMLInputElement | null
        
        // Act
        if(nameInput) {
            fireEvent.change(nameInput, {
                target: {
                    value: productName
                }
            })
        }
        
        // Assert
        expect(nameInput?.value).toBe(productName)
        //TODO: Test the rest of inputs
    })
})