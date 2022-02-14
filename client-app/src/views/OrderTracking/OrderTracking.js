import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Steps } from 'antd';
import { Popconfirm, message, Button, Layout, Tag } from 'antd';
import './OrderTracking.css';
import axios from 'axios';
const { Step } = Steps;
const { Content } = Layout;
export default function OrderTracking() {
  const [history, setHistory] = useState([]);
  const [order, setOrder] = useState({});
  let token = localStorage.getItem('token');
  const id = useParams().id;

  let config = {
    headers: {
      Authorization: 'Bearer ' + token,
    },
  };

  async function confirm(e) {
    console.log(e);
    try {
      const res = await cancelOrder();
      console.log(res);
      message.success('Huỷ đơn thành công');
    } catch (e) {
      console.log(e);
      message.error('Huỷ đơn thất bại');
    }
  }

  function cancel(e) {
    console.log(e);
    // message.error('Click on No');
  }

  const getHistory = async () => {
    const historyRes = await axios.get(
      `http://localhost:8080/tracking/${id}`,
      config
    );

    setHistory(historyRes.data);
  };

  const getOrder = async () => {
    const orderRes = await axios.get(
      `https://localhost:5001/api/order/view/${id}`,
      config
    );

    setOrder(orderRes.data);
  };

  const cancelOrder = async () => {
    return await axios.delete(
      `https://localhost:5001/api/order/tracking/${id}`,
      config
    );
  };

  let isCompleted = false;
  const testItem = history[0];
  if (testItem) {
    isCompleted =
      testItem.tenTinhTrang === 'Giao hàng thành công' ||
      testItem.tenTinhTrang === 'Shop huỷ đơn' ||
      testItem.tenTinhTrang === 'Khách huỷ đơn' ||
      testItem.tenTinhTrang === 'Đang vận chuyển';
  }
  useEffect(() => {
    getOrder();
    getHistory();
  }, []);
  return (
    <>
      <Layout style={{ margin: 50 }}>
        <Content>
          <h1>
            Theo dõi đơn hàng <Tag color="magenta"> {id}</Tag>
          </h1>
          {order.nguoiGiaoHang ? (
            <p>Đơn hàng được giao bởi {order.nguoiGiaoHang.tenNguoiGiaoHang}</p>
          ) : (
            ''
          )}

          <Steps direction="vertical" current={0}>
            {history.map((item) => {
              return (
                <Step
                  key={item.ttdhId}
                  title={item.tenTinhTrang}
                  description={`${item.ghiChu}\n${item.ngayThucHien}`}
                />
              );
            })}
          </Steps>

          <Popconfirm
            title="Bạn có muốn huỷ đơn hàng?"
            onConfirm={confirm}
            onCancel={cancel}
            okText="Ok"
            cancelText="Không"
          >
            {!isCompleted ? <Button>Huỷ đơn hàng</Button> : ''}
          </Popconfirm>
        </Content>
      </Layout>
    </>
  );
}
