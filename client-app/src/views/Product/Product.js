import React, { useEffect, useState } from 'react';
import { Image, InputNumber, Button, Descriptions, PageHeader } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';
import './Product.css';
import 'antd/dist/antd.css';

export default function Product() {
  const id = useParams().id;
  const [product, setProduct] = useState({});
  const [qty, setQty] = useState(1);
  useEffect(() => {
    const getProduct = async () => {
      const productRes = await axios.get(
        `https://localhost:5001/api/Product/${id}`
      );
      setProduct(productRes.data);
    };
    getProduct();
    console.log(product.loaiSanPham);
    console.log(product);
    // eslint-disable-next-line
  }, []);
  const { loaiSanPham } = product;
  const { cuaHang } = product;

  function onChange(value) {
    setQty(value);
  }
  const navigate = useNavigate();
  const addToCartHandler = () => {
    navigate(`/cart/${id}?qty=${qty}`);
  };
  const routes = [
    {
      href: '/',
      breadcrumbName: 'Trang chủ',
    },
    {
      href: `/search?category=${loaiSanPham ? loaiSanPham.loaiId : ''}`,
      breadcrumbName: `${loaiSanPham ? loaiSanPham.ten : ''}`,
    },
    {
      href: '#',
      breadcrumbName: product.tenSanPham,
    },
  ];

  return (
    <div>
      {console.log(loaiSanPham)}
      {console.log(cuaHang)}

      <PageHeader className="site-page-header" breadcrumb={{ routes }} />

      <div className="row">
        <div className="column">
          <Image width={400} src={product.hinhMinhHoa} />
        </div>
        <div className="column">
          <h1>{product.tenSanPham}</h1>
          <h2>
            {new Intl.NumberFormat('vi-VN', {
              style: 'currency',
              currency: 'VND',
            }).format(product.donGia)}
          </h2>
          <p>Còn {product.tonKho} sản phẩm</p>

          <div className="product-num">
            <InputNumber
              min={1}
              defaultValue={1}
              addonBefore={<p>Số lượng: </p>}
              keyboard={false}
              onChange={onChange}
            />
          </div>
          <div style={{ 'margin-top': 10 }}>
            <Button type="primary" danger onClick={addToCartHandler}>
              {' '}
              Chọn Mua{' '}
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
