import React, { useState, useEffect } from 'react';
import axios from 'axios'
import 'antd/dist/antd.css';
import {useSelector} from 'react-redux'
import {
    Form,
    Input,
    Select,
    Row,
    Col,
    Card,
    Button,
    Image,
    Alert
} from 'antd';
import Upload from '../../Upload/Upload';
const { Option } = Select;

const RegisterShipper = () => {
    const [driver,setDriver] = useState({})
    const [image,setImage] = useState()
    const [message,setMessage] = useState()
    const [isSuccess,setIsSuccess] = useState(false)
    const [form] = Form.useForm();

    const userSignin = useSelector((state) => state.userSignin)
    form.setFieldsValue({email:userSignin.userInfo.email})

    const onFinish = (values) => {
        setDriver(values);
        console.log(values)
        axios({
            method: 'post',
            url: `https://localhost:44391/Driver/register_driver`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`,"Content-Type": "application/json"},
            data: driver
        })
        .then(res => {
            setDriver(res.data)
            setMessage('Đăng ký tài xế thành công!')
            setIsSuccess(true)
        })
        .catch((error) => {
            console.error(error);
        }) 
      };

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

      useEffect(() => {
        form.setFieldsValue({ email: userSignin.userInfo.email });
      }, []);
    return (
        <div>
            
            <Row style={{marginTop:100}}>
                <Col span={12} offset={6}>
                    <Card title="Đăng ký tài xế">
                        <Form labelCol={{
                                span: 4,
                            }}
                            wrapperCol={{
                                span: 16,
                            }}
                            onFinish={onFinish} form={form}>
                            <Form.Item label="Họ và tên" name="tenNguoiGiaoHang" 
                            rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập họ và tên của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="Số điện thoại" name="soDienThoai" rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập số điện thoại của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="Địa chỉ" name="diaChi" rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập địa chỉ của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="CMND/CCCD" name="cccd" rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập CMND/CCCD của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="STK" name="sTK" rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập số tài khoản của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="Vùng hoạt động" name="vungHoatDong" rules={[
                                    { required: true, 
                                      message: "Vui lòng nhập vùng hoạt động của bạn" }
                            ]}>
                                <Input />
                            </Form.Item>
                            <Form.Item label="Email" name="email">
                                <Input defaultValue={userSignin.userInfo.email} />
                            </Form.Item>
                            <Form.Item label="Giấy xét nghiệm" name="image">
                                <input type="file"
                                    onChange={e => { uploadImage(e.target.files[0]) }} />
                                <Image width={200} src={image} alt="" />
                            </Form.Item>
                            <Form.Item wrapperCol={{
                                offset: 9,
                                span: 16,
                                }}>
                                <Button type="primary" htmlType="submit" style={{width:200}}>
                                Submit
                                </Button>
                            </Form.Item>
                        </Form>
                        {isSuccess && <Alert message={message} type="success" showIcon />}
                    </Card>
                </Col>
            </Row>
        </div>
    );
};

export default RegisterShipper;