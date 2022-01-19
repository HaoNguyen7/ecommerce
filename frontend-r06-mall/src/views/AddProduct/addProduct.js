import React, { useState, useEffect } from 'react';
import {
  Form,
  Input,
  Button,
  Select,
  Image
} from 'antd';
import "./addProduct.css"
import axios from "axios"
import { useNavigate } from "react-router-dom"
import jwt_decode from "jwt-decode"
import Upload from '../Upload/Upload';
const { Option } = Select;
const { TextArea } = Input;
function AddProduct() {
  const [form] = Form.useForm();
  const [name, setName] = useState("");
  const [inventory, setInventory] = useState(0);
  const [unit, setUnit] = useState("")
  const [cost, setCost] = useState(0);
  const [category, setCategory] = useState("");
  const [store, setStore] = useState("");
  const [description, setDescription] = useState("");
  const [image, setImage] = useState("")
  var [listCategory, setListCategory] = useState([]);
  var [listStore, setListStore] = useState([]);

  const navigate = useNavigate();
  let token = localStorage.getItem('token');

  let config = {
    headers: {
      'Authorization': 'Bearer ' + token
    }
  }

  useEffect(() => {
    axios({
      method: "GET",
      url: "https://localhost:5001/api/TypeProduct",
    }).then((res) => {
      listCategory = res.data;
      setListCategory([...res.data]);
      console.log(listCategory)
    })
      .catch((err) => console.log(err))

    axios({
      method: "GET",
      url: "https://localhost:5001/Store/get-store-by-user",
      params: {
        id: jwt_decode(localStorage.getItem('token')).Id
      },
      headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
    }).then((res) => {
      listStore = res.data.data;
      setListStore([...res.data.data]);
      console.log(res)
    })
      .catch((err) => console.log(err))
  }, [])

  const uploadImage = (value) => {
    const formData = new FormData();
    formData.append("file", value);
    formData.append("upload_preset", "nrxqvf2q");

    axios.post(`https://api.cloudinary.com/v1_1/ddeipl7ed/image/upload`, formData
    ).then(res => {
      console.log("upload thanh cong")
      setImage(res.data.url)
      form.setFieldsValue({ image: res.data.url });
    }).catch(err => {
      console.log(err)
    })
  }

  const onSubmit = () => {
    if (name !== "" && !isNaN(inventory) && unit != "" && !isNaN(cost) && category !== "" && store !== "" && description !== "") {

      axios.post("https://localhost:5001/api/Product/register",
        {
          tenSanPham: name,
          moTa: description,
          tonKho: inventory,
          donVi: unit,
          donGia: cost,
          loaiSanPham: category,
          cuaHang: store,
          hinhMinhHoa: image
        }, config
      ).then(() => {
        alert("Sản phẩm đã được thêm")
        navigate("/")

      }).catch(err => {
        console.log(err)
        alert("Kiểm tra tính hợp lệ của các thông tin cung cấp!")
      })
    }
    else {
      alert("Cần phải hoàn thành tất cả thông tin")

    }
  }
  return (
    <Form
      labelCol={{ span: 4 }}
      wrapperCol={{ span: 14 }}
      layout="horizontal"

    >
      <h1>Đăng bán sản phẩm mới</h1>

      <Form.Item label="Tên sản phẩm" rules={[{ required: true }]}>
        <Input onChange={(event) => setName(event.target.value)} />
      </Form.Item>
      <Form.Item label="Hình minh họa" name="image">
        <input type="file"
          onChange={e => { uploadImage(e.target.files[0]) }} />
        <Image width={200} src={image} alt="" />
      </Form.Item>
      <Form.Item label="Tồn kho" rules={[{ required: true }]}>
        <Input onChange={(event) => setInventory(event.target.value)} />
      </Form.Item>
      <Form.Item label="Đơn vị" rules={[{ required: true }]}>
        <Input onChange={(event) => setUnit(event.target.value)} />
      </Form.Item>
      <Form.Item label="Đơn giá" rules={[{ required: true }]}>
        <Input onChange={(event) => setCost(event.target.value)} />
      </Form.Item>
      <Form.Item label="Loại sản phẩm" rules={[{ required: true }]}>
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Search to Select"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          filterSort={(optionA, optionB) =>
            optionA.children.toLowerCase().localeCompare(optionB.children.toLowerCase())
          }
          onChange={(value) => setCategory(value)}
        >
          {listCategory.map((category, i) => <Option value={category.loaiId}>{category.ten}</Option>)}
        </Select>
      </Form.Item>
      <Form.Item label="Tên cửa hàng" rules={[{ required: true }]}>
        <Select
          showSearch
          style={{ width: 200 }}
          placeholder="Search to Select"
          optionFilterProp="children"
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          filterSort={(optionA, optionB) =>
            optionA.children.toLowerCase().localeCompare(optionB.children.toLowerCase())
          }
          onChange={(value) => setStore(value)}
        >
          {listStore.map((store, i) => <Option value={store.cuaHangId}>{store.tenCuaHang}</Option>)}

        </Select>
      </Form.Item>
      <Form.Item label="Mô tả" rules={[{ required: true }]}>
        <TextArea rows={4} onChange={(event) => setDescription(event.target.value)} />
      </Form.Item>
      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" onClick={onSubmit} >
          Đăng sản phẩm
        </Button>
      </Form.Item>
    </Form>
  );
}

export default AddProduct;
