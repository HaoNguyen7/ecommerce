import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./manageProduct.css"
import jwt_decode from "jwt-decode"
import {
  Form,
  Input,
  Button,
  Select,
  Row,
  Col
} from 'antd';
import { Constants } from '../../Constaints';
import ProductBox from '../../components/ProductBox/productBox';
const { Option } = Select;
function ManageProduct() {
  var [listProduct, setListProduct] = useState([])
  var [listCategory, setListCategory] = useState([]);
  var [listStore, setListStore] = useState([]);
  const [category, setCategory] = useState("");
  const [store, setStore] = useState("");
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

  let removeItem = (id) => {
    listProduct = listProduct.filter(value => value.sanPhamId !== id)
    setListProduct(listProduct)
  }
  useEffect(() => {
    let params = {pageSize: 50};
    if(userRole.includes(Constants.ROLE_CUAHANG)) {
      params.id =  jwt_decode(localStorage.getItem('token')).Id;
    }
    axios({
      method: "GET",
      url: "https://localhost:5001/api/TypeProduct",
    }).then((res) => {
      listCategory.push({ loaiId: "All", ten: "All" })
      listCategory = res.data;
      setListCategory([{ loaiId: "All", ten: "All" }, ...res.data]);
    })
      .catch((err) => console.log(err))

    axios({
      method: "GET",
      url: "https://localhost:5001/Store/get-store-by-user",
      headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
      params: params,
    }).then((res) => {
      listStore.push({ cuaHangId: "All", tenCuaHang: "All" });
      listStore = res.data.data;
      setListStore([{ cuaHangId: "All", tenCuaHang: "All" }, ...res.data.data]);
    })
      .catch((err) => console.log(err))
  }, [])

  let findProduct = () => {

    let params = { pageSize: 20 };
    if (store !== "All") {
      params.shopIds = store
    }
    if (category !== "All") {
      params.cateoryIds = category
    }
    axios({
      method: "GET",
      url: "https://localhost:5001/api/Product",
      params: params
    }).then((res) => {
      listProduct.push()
      listProduct = res.data;
      setListProduct([...res.data]);

    })
      .catch((err) => console.log(err))
  }
  return (
    <div className='manage-product-screen'>
      <div className="filter-bar">
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Loại sản phẩm"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          onChange={(value) => setCategory(value)}
        >
          {listCategory.map((category, i) => <Option value={category.loaiId}>{category.ten}</Option>)}
        </Select>
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
        <Button type="primary" class="button-find" onClick={findProduct}>
          Tìm kiếm
        </Button>
      </div>
      <Row>
        {listProduct.map((product, i) =>
          <Col xs={24} lg = {8}>
            <ProductBox productInfor={product} key={product.sanPhamId} removeItem={removeItem} />
          </Col>
        )}
      </Row>
    </div>
  );
}

export default ManageProduct;