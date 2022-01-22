import React, { useState } from 'react';
import { Carousel, Space, Avatar } from 'antd';
import { Menu, Button, Card, List, Row } from 'antd';
import { MessageOutlined, LikeOutlined, StarOutlined } from '@ant-design/icons';
const { Meta } = Card;
const { SubMenu } = Menu;

function HomePage() {
  const [current, setCurrent] = useState('main');

  const handleClick = (e) => {
    console.log('click ', e);
    setCurrent(e.key);
  };

  const contentStyle = {
    height: '360px',
    color: '#fff',
    lineHeight: '360px',
    textAlign: 'center',
    'background-image':
      'url("https://salt.tikicdn.com/cache/w1080/ts/banner/e7/9f/00/ca66add76f71afc0a73f06b82ff1980b.jpg.webp")',
  };

  function onChange(a, b, c) {
    console.log(a, b, c);
  }

  const IconText = ({ icon, text }) => (
    <Space>
      {React.createElement(icon)}
      {text}
    </Space>
  );

  const listData = [];
  for (let i = 0; i < 23; i++) {
    listData.push({
      sanPhamId: 'd1e184d9-5a69-4766-9fa8-7f2b2c7f2126',
      tenSanPham: 'Kệ Sách Gỗ Để Sàn Cao Cấp SPEVI',
      moTa: 'Tủ Ngăn Kéo INDEX KARLMAR (60 x 39.7 x 106.7 cm) được làm từ chất liệu bền chắc, hạn chế cong vênh và nứt gãy, cũng như mối mọt theo thời gian',
      tonKho: 54,
      donGia: 1273000,
      donVi: '1',
      ngayDang: '2021-12-25T00:00:00',
      loaiSanPham: null,
      cuaHang: {
        cuaHangId: '25c80cd4-9eca-4455-9de9-aba8eb0364f1',
        tenCuaHang: 'Hoàng An Furniture',
        moTa: 'Bán nội thất',
        danhGia: null,
        soDienThoai: '0348724198',
        stk: '18120273',
        tinhTrang: false,
        maSoThue: null,
        diaChi: null,
        kinhDo: 106.341118,
        viDo: 9.93628,
        userId: '00000000-0000-0000-0000-000000000000',
      },
    });
  }

  return (
    <div>
      <Carousel afterChange={onChange}>
        <div>
          <h3 style={contentStyle}>1</h3>
        </div>
        <div>
          <h3 style={contentStyle}>2</h3>
        </div>
        <div>
          <h3 style={contentStyle}>3</h3>
        </div>
        <div>
          <h3 style={contentStyle}>4</h3>
        </div>
      </Carousel>
      <List
        grid={{ gutter: 16, column: 4 }}
        pagination={{
          onChange: (page) => {
            console.log(page);
          },
          pageSize: 8,
        }}
        dataSource={listData}
        footer={
          <div>
            <b>ant design</b> footer part
          </div>
        }
        renderItem={(item) => (
          <List.Item>
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
              <Meta title={item.tenSanPham} description={item.donGia} />
            </Card>
          </List.Item>
        )}
      />
    </div>
  );
}

export default HomePage;
