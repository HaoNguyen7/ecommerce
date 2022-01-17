import React from 'react';
import { Card, Button } from 'antd';
import './productBox.css';
import { Link } from 'react-router-dom';
import axios from "axios";
function ProductBox({ productInfor, removeItem }) {

  let onClick = ()=> {
    axios({
      method: "DELETE",
      url: "https://localhost:5001/api/Product/delete-product",
      data: {
        id: productInfor.sanPhamId,
      }
    }).then(() => {
      alert("Sản phẩm đã được xóa")
      removeItem(productInfor.sanPhamId)
    }).catch(err => {
      console.log(err)
      alert("Kiểm tra tính hợp lệ của các thông tin cung cấp!")
    })
  }
  return (
    <div>
      <Card title={productInfor.tenSanPham} className='card-store' extra={<div><Link to={{
        pathname: `/product-update/${productInfor.sanPhamId}`,
        query: { product: productInfor.sanPhamId }
      }}>Cập nhật</Link><Button  onClick={onClick}>Xóa</Button></div>}>
        <p><strong>Giá:</strong> {productInfor.donGia}/{productInfor.donVi}</p>
        <p><strong>Mô tả:</strong> {productInfor.moTa}</p>
      </Card>
    </div>
  );
}

export default ProductBox;