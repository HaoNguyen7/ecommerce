import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import HomePage from './views/Home/HomePage';
import Product from './views/Product/Product';
import Dashboard from './components/Layout/layout';
import Login from './views/Login/Login';

function App() {
  return (
      <Routes>
        <Route path="/" element={<Dashboard />}>
          <Route index element={<HomePage />} />
          <Route path="product" element={<Product />} />
          <Route path="user">
            <Route path=":id" element={<Product />} />
          </Route>
        </Route>
        <Route path='/login' element={<Login />} />
      </Routes>
  );
}

export default App;
