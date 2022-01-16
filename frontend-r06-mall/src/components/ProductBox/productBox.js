import React from 'react';
import { Card } from 'antd';
import './productBox.css';
function ProductBox({productInfor}) {  

  return (
    <div>
      <Card title={productInfor.tenSanPham} className='card-store'>
      <p><strong>Giá:</strong> {productInfor.donGia}/{productInfor.donVi}</p>
      <p><strong>Mô tả:</strong> {productInfor.moTa}</p>
    </Card>
    </div>
  );
}

export default ProductBox;