import React, { useState, useEffect } from 'react';
import {
  Form,
  Input,
  Button,
  Select,
  Image
} from 'antd';
import "./updateProduct.css"
import axios from "axios"
import { useNavigate, useParams, useLocation } from "react-router-dom"
import jwt_decode from "jwt-decode"
import Upload from "../Upload/Upload"
const { Option } = Select;
const { TextArea } = Input;
function UpdateProduct() {
  const id = useParams().id;
  const [name, setName] = useState("");
  const [inventory, setInventory] = useState(-1);
  const [unit, setUnit] = useState("")
  const [cost, setCost] = useState(-1);
  const [category, setCategory] = useState(id);
  const [description, setDescription] = useState("");
  const [image, setImage] = useState("");
  const [form] = Form.useForm();
  var [listCategory, setListCategory] = useState([]);

  const navigate = useNavigate();

  const uploadImage = (value) => {
    const formData = new FormData();
    formData.append("file", value);
    formData.append("upload_preset", "nrxqvf2q")

    axios.post(`https://api.cloudinary.com/v1_1/ddeipl7ed/image/upload`, formData
    ).then(res => {
      console.log("upload thanh cong")
      setImage(res.data.url)
      form.setFieldsValue({ image: res.data.url });
    }).catch(err => {
      console.log(err)
    })
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
  }, [])
  const onSubmit = () => {
    axios({
      method: "PUT",
      url: "https://localhost:5001/api/Product/update-product",
      data: {
        id: id,
        tenSanPham: name,
        moTa: description,
        tonKho: inventory,
        donVi: unit,
        donGia: cost,
        loaiSanPham: category,
        hinhMinhHoa: image
      }
    }).then(() => {
      alert("Sản phẩm đã được cập nhật")
      navigate("/")

    }).catch(err => {
      console.log(err)
      alert("Kiểm tra tính hợp lệ của các thông tin cung cấp!")
    })
  }
  return (
    <Form
      labelCol={{ span: 4 }}
      wrapperCol={{ span: 14 }}
      layout="horizontal"

    >
      <h1>Cập nhật thông tin sản phẩm (id:{id})</h1>

      <Form.Item label="Tên sản phẩm" rules={[{ required: true }]}>
        <Input onChange={(event) => setName(event.target.value)} />
      </Form.Item>
      <Form.Item label="Hình minh họa" name="image">
        <input type="file"
          onChange={e => { uploadImage(e.target.files[0]) }} />
        <Image width={200} src={image} alt="" />
      </Form.Item>
      <Form.Item label="Tồn kho" rules={[{ required: true }]}>
        <Input onChange={(event) => setInventory(Number(event.target.value))} />
      </Form.Item>
      <Form.Item label="Đơn vị" rules={[{ required: true }]}>
        <Input onChange={(event) => setUnit(Number(event.target.value))} />
      </Form.Item>
      <Form.Item label="Đơn giá" rules={[{ required: true }]}>
        <Input onChange={(event) => setCost(Number(event.target.value))} />
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
      <Form.Item label="Mô tả" rules={[{ required: true }]}>
        <TextArea rows={4} onChange={(event) => setDescription(event.target.value)} />
      </Form.Item>
      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" onClick={onSubmit} >
          Cập nhật
        </Button>
      </Form.Item>
    </Form>
  );
}

export default UpdateProduct;
