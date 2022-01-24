import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Steps } from 'antd';
import { Popconfirm, message, Button } from 'antd';

import axios from 'axios';
const { Step } = Steps;
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

  useEffect(() => {
    getOrder();
    getHistory();
  }, []);
  return (
    <>
      <h1>{console.log(history)}</h1>
      <h1>Theo dõi đơn hàng {id}</h1>
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
        <Button>Huỷ đơn hàng</Button>
      </Popconfirm>
    </>
  );
}
