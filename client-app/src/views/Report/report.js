import React, { useState, useEffect } from 'react';
import axios from 'axios';
import jwt_decode from "jwt-decode"
import {
  Form,
  Input,
  Button,
  Select,
  Row,
  Col,
  Table, Tag, Space
} from 'antd';


import { Constants } from '../../Constaints';
const { Option } = Select;
const { Column, ColumnGroup } = Table;
function Report() {
  var [listStore, setListStore] = useState([]);
  const [range, setRange] = useState([]);
  const [year, setYear] = useState(0);
  const [quarter, setQuarter] = useState(0);
  const [store, setStore] = useState("");
  let [data, setData] = useState([]);
  let [dataReport, setDataReport] = useState([])
  let userRole = [];
  if (localStorage.getItem('token')) {
    let roles = jwt_decode(localStorage.getItem('token')).role
    if (Array.isArray(roles)) {
      userRole = [...roles]
    }
    else {
      userRole.push(roles)
    }
  }
  let onFind = () => {
    axios({
      method: "GET",
      url: "http://localhost:8080/store/report",
      params: {
        year: year,
        quarter: quarter,
        idCuaHang: store
      }
    }).then((res) => {
      calcTongDoanhThu(res.data.data);

    })
      .catch((err) => console.log(err))
  }

  let calcTongDoanhThu = (array) => {
    let sum = array.map(product => {
      return { id: product.sanPhamId, name: product.tenSanPham, doanhThu: product.soLuong * product.donGia, doanhSo: product.soLuong, donGia: product.donGia }
    });
    data = sum;
    setData([...sum])
    calcDataForTable(data);
  }
  let calcDataForTable = (array) => {
    let tabledata = [
      {
        key: "Tổng doanh thu",
        product: null,
        value: array.map(i => i.doanhThu).reduce((a, b) => a + b) + " VNĐ"
      },
      {
        key: "Tổng doanh số",
        product: null,
        value: array.map(i => i.doanhSo).reduce((a, b) => a + b) + " Sản phẩm"
      },
      {
        key: "Sản phẩm có doanh số cao nhất",
        product: array.reduce((max, obj) => (max.doanhSo > obj.doanhSo) ? max : obj).name,
        value: Math.max.apply(Math, array.map(function (o) { return o.doanhSo; })) + " Sản phẩm"
      },
      {
        key: "Sản phẩm có doanh thu cao nhất",
        product: array.reduce((max, obj) => (max.doanhThu > obj.doanhThu) ? max : obj).name,
        value: Math.max.apply(Math, array.map(function (o) { return o.doanhThu; })) + " VNĐ"
      }
    ];
    dataReport = [...tabledata];
    setDataReport([...tabledata]);
    console.log(dataReport);
  }
  useEffect(() => {
    axios({
      method: "GET",
      url: "http://localhost:8080/time-range",
    }).then((res) => {
      let min = res.data.timerange.min;
      let max = res.data.timerange.max;
      let r = []
      for (let i = min; i <= max; i++) {
        r.push(i);
      }
      setRange([...r])
    })
      .catch((err) => console.log(err))
    let params = { pageSize: 50 };
    if (userRole.includes(Constants.ROLE_CUAHANG)) {
      params.id = jwt_decode(localStorage.getItem('token')).Id;
    }
    axios({
      method: "GET",
      url: "https://localhost:5001/Store/get-store-by-user",
      headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
      params: params,
    }).then((res) => {
      listStore = res.data.data;
      setListStore([...res.data.data]);
    })
      .catch((err) => console.log(err))
  }, [])


  return (
    <div >
      <div className="filter-bar">
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Tên cửa hàng"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          onChange={(value) => setStore(value)}
        >
          {listStore.map((store, i) => <Option value={store.cuaHangId}>{store.tenCuaHang}</Option>)}
        </Select>
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Quý"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          onChange={(value) => setQuarter(value)}
        >
          <Option value={0}>Cả năm</Option>
          <Option value={1}>Quý 1</Option>
          <Option value={2}>Quý 2</Option>
          <Option value={3}>Quý 3</Option>
          <Option value={4}>Quý 4</Option>
        </Select>
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Chọn năm"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          onChange={(value) => setYear(value)}
        >
          {range.map((year, i) => <Option value={year}>{year}</Option>)}
        </Select>
        <Button type="primary" class="button-find" onClick={onFind}>
          Tìm kiếm
        </Button>
      </div>
      <h1>Thống kê tổng quát</h1>
      <Table dataSource={dataReport}>
        <Column title="Thông số" dataIndex="key" key="key" />
        <Column title="Sản phẩm" dataIndex="product" key="product" />
        <Column title="Giá trị" dataIndex="value" key="value" />
      </Table>
      <h1>Chi tiết hoạt động kinh doanh</h1>
      <Table dataSource={data}>
        <Column title="Sản phẩm" dataIndex="name" key="name" />
        <Column title="Doanh thu" dataIndex="doanhThu" key="doanhThu" />
        <Column title="Doanh số" dataIndex="doanhSo" key="doanhSo" />
        <Column title="Đơn giá" dataIndex="donGia" key="donGia" />
      </Table>
    </div>
  );
}

export default Report;