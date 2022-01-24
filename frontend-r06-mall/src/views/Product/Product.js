import React, { useEffect, useState } from 'react';
import { Image, InputNumber, Button, Descriptions, Layout } from 'antd';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import './Product.css';
import 'antd/dist/antd.css';

export default function Product() {
  const id = useParams().id;
  const [product, setProduct] = useState({});

  useEffect(() => {
    const getProduct = async () => {
      const productRes = await axios.get(
        `https://localhost:5001/api/Product/${id}`
      );
      setProduct(productRes.data);
    };
    getProduct();
    console.log(product.loaiSanPham);
    // eslint-disable-next-line
  }, []);
  const { loaiSanPham } = product;
  const { cuaHang } = product;

  function onChange(value) {
    console.log('changed', value);
  }

  return (
    <div>
      {console.log(loaiSanPham)}
      {console.log(cuaHang)}
      <div className="row">
        <div className="column">
          <Image
            width={400}
            src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
          />
        </div>
        <div className="column">
          <h1>{product.tenSanPham}</h1>
          <h2>{product.donGia} đ</h2>
          <p>Còn {product.tonKho} sản phẩm</p>
          <h3>Số lượng</h3>
          <InputNumber min={1} defaultValue={1} onChange={onChange} />

          <div>
            <Button type="primary" danger>
              Chọn Mua
            </Button>
          </div>
        </div>
      </div>

      <div>
        <Descriptions title="Thông tin sản phẩm" column={1} bordered>
          <Descriptions.Item label="Đơn vị">{product.donVi}</Descriptions.Item>
          <Descriptions.Item label="Ngày đăng">
            {product.ngayDang}
          </Descriptions.Item>
          <Descriptions.Item label="Mô tả sản phẩm">
            {product.moTa}
          </Descriptions.Item>
          <Descriptions.Item label="Loại sản phẩm">
            {loaiSanPham ? loaiSanPham.ten : ''}
          </Descriptions.Item>
        </Descriptions>
      </div>
    </div>
  );
}
