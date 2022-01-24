import React, { useEffect, useState } from 'react';
import { Image, InputNumber, Button, Descriptions, Layout } from 'antd';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const { Content } = Layout;

export default function Product() {
  const id = useParams().id;
  const [product, setProduct] = useState({});
  let loaiSanPham;

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
  loaiSanPham = product.loaiSanPham;

  function onChange(value) {
    console.log('changed', value);
  }

  return (
    <div>
      {console.log(loaiSanPham)}
      <Content>
        <Image
          width={400}
          src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
        />
        <div>
          <h1>{product.tenSanPham}</h1>
          <h2>{product.donGia} đ</h2>
          <p>Còn {product.tonKho} sản phẩm</p>
          <span>
            <h3>Số lượng</h3>
          </span>

          <InputNumber min={1} defaultValue={1} onChange={onChange} />
          <div>
            <Button type="primary" danger>
              Chọn Mua
            </Button>
          </div>
        </div>

        <div>
          <Descriptions title="Thông tin sản phẩm" bordered column={1}>
            <Descriptions.Item label="Đơn vị">
              {product.donVi}
            </Descriptions.Item>
            <Descriptions.Item label="Ngày đăng">
              {product.ngayDang}
            </Descriptions.Item>
            <Descriptions.Item label="Mô tả sản phẩm">
              {product.moTa}
            </Descriptions.Item>
            <Descriptions.Item label="Loại sản phẩm">
              {loaiSanPham.ten}
            </Descriptions.Item>
          </Descriptions>
        </div>
      </Content>
    </div>
  );
}
