import { createBrowserRouter } from 'react-router-dom'
import { RootLayout } from '@/app/layout/RootLayout'
import { ProtectedRoute } from './ProtectedRoute'
import { paths } from './paths'
import { HomePage } from '@/features/home/HomePage'
import { LoginPage } from '@/features/auth/LoginPage'
import { RegisterPage } from '@/features/auth/RegisterPage'
import { CatalogPage } from '@/features/catalog/CatalogPage'
import { ProductDetailPage } from '@/features/product/ProductDetailPage'
import { CartPage } from '@/features/cart/CartPage'
import { FavoritesPage } from '@/features/favorites/FavoritesPage'
import { ComparePage } from '@/features/compare/ComparePage'
import { CheckoutPage } from '@/features/checkout/CheckoutPage'
import { OrdersPage } from '@/features/orders/OrdersPage'
import { OrderDetailPage } from '@/features/orders/OrderDetailPage'
import { NotFoundPage } from '@/features/misc/NotFoundPage'
import { AboutPage } from '@/features/misc/AboutPage'
import { AdminLayout } from '@/features/admin/AdminLayout'
import { DashboardPage } from '@/features/admin/DashboardPage'
import { AdminOrdersPage } from '@/features/admin/AdminOrdersPage'
import { AdminProductsPage } from '@/features/admin/AdminProductsPage'
import { ProductFormPage } from '@/features/admin/ProductFormPage'
import { AdminCatalogPage } from '@/features/admin/AdminCatalogPage'

export const router = createBrowserRouter([
  {
    element: <RootLayout />,
    children: [
      { path: paths.home, element: <HomePage /> },
      { path: paths.about, element: <AboutPage /> },
      { path: paths.login, element: <LoginPage /> },
      { path: paths.register, element: <RegisterPage /> },

      // Public catalog + product (Phase 4).
      { path: paths.catalog, element: <CatalogPage /> },
      { path: paths.product(), element: <ProductDetailPage /> },

      // Commerce — Phase 5 (public: cart, favorites, compare).
      { path: paths.compare, element: <ComparePage /> },
      { path: paths.cart, element: <CartPage /> },
      { path: paths.favorites, element: <FavoritesPage /> },

      // Authenticated — Phase 5.
      {
        element: <ProtectedRoute />,
        children: [
          { path: paths.checkout, element: <CheckoutPage /> },
          { path: paths.orders, element: <OrdersPage /> },
          { path: paths.order(), element: <OrderDetailPage /> },
        ],
      },

      // Admin — Phase 6.
      {
        element: <ProtectedRoute adminOnly />,
        children: [
          {
            element: <AdminLayout />,
            children: [
              { path: paths.admin, element: <DashboardPage /> },
              { path: paths.adminOrders, element: <AdminOrdersPage /> },
              { path: paths.adminProducts, element: <AdminProductsPage /> },
              { path: paths.adminProductNew, element: <ProductFormPage /> },
              { path: paths.adminProductEdit(), element: <ProductFormPage /> },
              { path: paths.adminCatalog, element: <AdminCatalogPage /> },
            ],
          },
        ],
      },

      { path: '*', element: <NotFoundPage /> },
    ],
  },
])
