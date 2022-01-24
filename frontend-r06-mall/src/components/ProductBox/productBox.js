import React from 'react';
import { Card, Button } from 'antd';
import './productBox.css';
import { Link } from 'react-router-dom';
import axios from "axios";
const { Meta } = Card;
function ProductBox({ productInfor, removeItem }) {

  let onClick = () => {
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
      <Card
        style={{ width: 300 }}
        className='card-store'
        cover={
          <img
            alt="Hình minh họa"
            src={productInfor.hinhMinhHoa}
          />
        }
        actions={[
          <Link to={{
            pathname: `/product-update/${productInfor.sanPhamId}`,
            query: { product: productInfor.sanPhamId }
          }}>Cập nhật</Link>,
          <Button onClick={onClick}>Xóa</Button>,
        ]}
      >
        <Meta
          title={productInfor.tenSanPham}
          description={<div><p><strong>Giá:</strong> {productInfor.donGia}/{productInfor.donVi}</p>
            <p><strong>Mô tả:</strong> {productInfor.moTa}</p>
            <p><strong>Nguồn gốc:</strong> {productInfor.nguonGoc}</p>
            </div>}
            
        />
      </Card>

    </div>
  );
}

export default ProductBox;