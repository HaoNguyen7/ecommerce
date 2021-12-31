import React, { useState } from 'react';
import axios from 'axios'
import 'antd/dist/antd.css';
import {
    Form,
    Input,
    Select,
    Row,
    Col,
    Card,
    Button
} from 'antd';
const { Option } = Select;

const RegisterShipper = () => {
    const [driver,setDriver] = useState({})
    const [form] = Form.useForm();
    const onFinish = (values) => {
        setDriver(values);
        axios({
            method: 'post',
            url: `https://localhost:44391/Driver/register_driver`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`,"Content-Type": "application/json"},
            data: driver
        })
        .then(res => {
            setDriver(res.data)
            console.log('Thành công')
        })
        .catch((error) => {
            console.error(error);
        }) 
      };
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
                            onFinish={onFinish}>
                            <Form.Item label="Name" name="tenNguoiGiaoHang">
                                <Input />
                            </Form.Item>
                            <Form.Item label="Số điện thoại" name="soDienThoai">
                                <Input />
                            </Form.Item>
                            <Form.Item label="Địa chỉ" name="diaChi">
                                <Input />
                            </Form.Item>
                            <Form.Item label="CMND/CCCD" name="cccd">
                                <Input />
                            </Form.Item>
                            <Form.Item label="STK" name="sTK">
                                <Input />
                            </Form.Item>
                            <Form.Item label="Vùng hoạt động" name="vungHoatDong">
                                <Input />
                            </Form.Item>
                            <Form.Item label="Email" name="email">
                                <Input />
                            </Form.Item>
                            <Form.Item wrapperCol={{
                                offset: 10,
                                span: 16,
                                }}>
                                <Button type="primary" htmlType="submit" style={{width:200}}>
                                Submit
                                </Button>
                            </Form.Item>
                        </Form>
                    </Card>
                </Col>
            </Row>
        </div>
    );
};

export default RegisterShipper;