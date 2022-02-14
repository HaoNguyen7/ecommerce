import React, { useState } from 'react';
import {
  Form,
  Input,
  Button,
  Image
} from 'antd';
import "./sellRegister.css"
import axios from "axios"
import Upload from '../Upload/Upload';
import { useNavigate } from "react-router-dom"
const { TextArea } = Input;
function SellRegister() {
  const [form] = Form.useForm();
  const [name, setName] = useState("");
  const [phone, setPhone] = useState("");
  const [card, setCard] = useState("")
  const [email, setEmail] = useState("");
  const [tax, setTax] = useState("");
  const [address, setAddress] = useState("");
  const [description, setDescription] = useState("");
  const [image, setImage] = useState("");
  const navigate = useNavigate();
  let token = localStorage.getItem('token');

  let config = {
    headers: {
      'Authorization': 'Bearer ' + token
    }
  }
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
    console.log(image)
    if (name !== "" && phone !== "" && card !== "" && email !== "" && tax !== "" && address !== "" && description !== "" && image !== "") {

      axios.post("https://localhost:5001/Store/register",
        {
          name: name,
          storeName: name,
          email: email,
          phoneNumber: phone,
          address: address,
          cardId: card,
          taxId: tax,
          description: description,
          giayPhepKinhDoanh: image
        }, config
      ).then(() => {
        alert("Yêu cầu của bạn đã được ghi nhận!")
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
      <h1>Đăng ký mở cửa hàng</h1>
      <Form.Item label="Tên cửa hàng" rules={[{ required: true }]}>
        <Input onChange={(event) => setName(event.target.value)} />
      </Form.Item>
      <Form.Item label="Giấy phép kinh doanh" name="image">
        <input type="file"
          onChange={e => { uploadImage(e.target.files[0]) }} />
        <Image width={200} src={image} alt="" />
      </Form.Item>
      <Form.Item label="Số điện thoại" rules={[{ required: true }]}>
        <Input onChange={(event) => setPhone(event.target.value)} />
      </Form.Item>
      <Form.Item label="Email" rules={[{ required: true }]}>
        <Input onChange={(event) => setEmail(event.target.value)} />
      </Form.Item>
      <Form.Item label="Số tài khoản" rules={[{ required: true }]}>
        <Input onChange={(event) => setCard(event.target.value)} />
      </Form.Item>
      <Form.Item label="Mã số thuế" rules={[{ required: true }]}>
        <Input onChange={(event) => setTax(event.target.value)} />
      </Form.Item>
      <Form.Item label="Địa chỉ" rules={[{ required: true }]}>
        <Input onChange={(event) => setAddress(event.target.value)} />
      </Form.Item>
      <Form.Item label="Mô tả" rules={[{ required: true }]}>
        <TextArea rows={4} onChange={(event) => setDescription(event.target.value)} />
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" onClick={onSubmit} >
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
}

export default SellRegister;
