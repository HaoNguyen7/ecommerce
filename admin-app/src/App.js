import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import HomePage from './views/Home/HomePage';
import Product from './views/Product/Product';
import Dashboard from './components/Layout/layout';
import Login from './views/Login/Login';
import Category from './views/Category/Category'
import Customer from './views/Customer/Customer'
import Order from './views/Order/Order'
import CreateCategory from './views/Category/CreateCategory';
function App() {
  return (<>
      <Routes>
        <Route path="/" element={<Dashboard />}>
          <Route index element={<HomePage />} />
          <Route path="product" element={<Product />} />
          <Route path="user">
            <Route path=":id" element={<Product />} />
          </Route>
          <Route path="category">
            <Route path="" element={<Category />} />
            <Route path=":id" element={<Product />} />
            <Route path="create" element={<CreateCategory />} />

          </Route>
          <Route path="customer" element={<Customer />} />
          <Route path="order" element={<Order />} />

        </Route>
        <Route path='/login' element={<Login />} />
      </Routes>
  </>
  );
}

export default App;
