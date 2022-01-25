import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { Table } from 'antd';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { Bar } from 'react-chartjs-2';

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

// const labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

// export const data = {
//   labels,
//   datasets: [
//     {
//       label: 'Dataset 1',
//       data: labels.map(() => faker.datatype.number({ min: 0, max: 1000 })),
//       backgroundColor: 'rgba(255, 99, 132, 0.5)',
//     },
//     {
//       label: 'Dataset 2',
//       data: labels.map(() => faker.datatype.number({ min: 0, max: 1000 })),
//       backgroundColor: 'rgba(53, 162, 235, 0.5)',
//     },
//   ],
// };

export default function CommissionAdmin() {
  let token = localStorage.getItem('token');

  const [commission, setCommission] = useState([]);
  // const [labels, setLabels] = useState([]);
  // const [data, setData] = useState([]);

  let config = {
    headers: {
      Authorization: 'Bearer ' + token,
    },
  };

  const addLabel = (commission) => {
    const labels = [];
    for (const item of commission) {
      if (labels.indexOf(`${item.thang}-${item.nam}`) < 0) {
        labels.push(`${item.thang}-${item.nam}`);
      }
    }
    return labels;
  };

  const addDataset = (labels, commission) => {
    const dataset = [];

    for (let i = 0; i < labels.length; i++) {
      dataset[i] = 0;
      for (let item of commission) {
        if (`${item.thang}-${item.nam}` === labels[i]) {
          dataset[i] += item.tienHoaHong;
        }
      }
    }
    return dataset;
  };

  useEffect(() => {
    const getCommission = async () => {
      const commissionRes = await axios.get(
        `http://localhost:8080/store/commission`,
        config
      );
      const data = commissionRes.data ? [...commissionRes.data.data] : [];

      for (let item of data) {
        item['tienHoaHong'] = item.hoaHong * item.doanhThu;
      }

      setCommission(data);
    };

    getCommission();
  }, []);
  const labels = addLabel(commission);
  const data = addDataset(labels, commission);
  const dataChart = {
    labels,
    datasets: [
      {
        label: 'Hoa Hồng',
        data: data,
        backgroundColor: 'rgba(255, 99, 132, 0.5)',
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: 'top',
      },
      title: {
        display: true,
        text: 'Tổng hoa hồng theo tháng',
      },
    },
  };

  const columns = [
    {
      title: 'Cửa Hàng',
      dataIndex: 'tenCuaHang',
    },
    {
      title: 'Số đơn',
      dataIndex: 'soLuong',
      sorter: (a, b) => a.soLuong - b.soLuong,
    },
    {
      title: 'Doanh Thu',
      dataIndex: 'doanhThu',
      sorter: (a, b) => a.doanhThu - b.doanhThu,
    },
    {
      title: 'Hoa Hồng',
      dataIndex: 'hoaHong',
    },
    {
      title: 'Tiền hoa hồng',
      dataIndex: 'tienHoaHong',
    },
    {
      title: 'Tháng',
      dataIndex: 'thang',
      sorter: (a, b) => a.thang - b.thang,
      width: '10%',
    },
    {
      title: 'Năm',
      dataIndex: 'nam',
      sorter: (a, b) => a.nam - b.nam,
      width: '10%',
    },
  ];

  function onChange(pagination, filters, sorter, extra) {
    console.log('params', pagination, filters, sorter, extra);
  }

  return (
    <div>
      {console.log(commission)}
      <Bar options={options} data={dataChart} />;
      <Table columns={columns} dataSource={commission} onChange={onChange} />
    </div>
  );
}
