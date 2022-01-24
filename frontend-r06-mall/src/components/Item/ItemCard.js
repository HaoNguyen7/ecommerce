import React from 'react';
import { Card } from 'antd';
import { Link } from 'react-router-dom';
const { Meta } = Card;

export default function ItemCard({ item }) {
  return (
    <>
      <Link to={`/product/${item.sanPhamId}`}>
        <Card
          hoverable
          style={{ width: 250 }}
          cover={
            <img
              alt="example"
              src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
            />
          }
        >
          <Meta
            title={item.tenSanPham}
            description={new Intl.NumberFormat('vi-VN', {
              style: 'currency',
              currency: 'VND',
            }).format(item.donGia)}
          />
        </Card>
      </Link>
    </>
  );
}
