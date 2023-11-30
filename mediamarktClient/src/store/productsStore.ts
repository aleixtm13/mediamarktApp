import { Product } from "../model/Product";
import { create } from "zustand";

interface ProductsStore {
    products: Product[]
    setProducts: (products: Product[]) => void
    isLoadingProducts: boolean,
    setProductsLoading: (isLoadingProducts: boolean) => void
}

export const useProductsStore = create<ProductsStore>((set) => ({
    products: [],
    setProducts: (products) => set({ products }),
    isLoadingProducts: false,
    setProductsLoading: (isLoadingProducts) => set({ isLoadingProducts })
}));