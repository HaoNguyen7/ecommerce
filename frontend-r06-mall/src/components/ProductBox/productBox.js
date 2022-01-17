import React from 'react';
import { Card, Button } from 'antd';
import './productBox.css';
import { Link } from 'react-router-dom';
function ProductBox({ productInfor }) {

  return (
    <div>
      <Card title={productInfor.tenSanPham} className='card-store' extra={<Link to={{
        pathname: `/product-update/${productInfor.sanPhamId}`,
        query: { product: productInfor.sanPhamId }
      }}>Cập nhật</Link>}>
        <p><strong>Giá:</strong> {productInfor.donGia}/{productInfor.donVi}</p>
        <p><strong>Mô tả:</strong> {productInfor.moTa}</p>
      </Card>
    </div>
  );
}

export default ProductBox;