import React from 'react';
import { Form, Input, Button, Checkbox, Card, Typography } from 'antd';
import 'antd/dist/antd.css';
import './index.css'

const {Title} = Typography
const Login = () => {
    const onFinish = (values) => {
        console.log('Success:', values);
    };

    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <Card className='center' style={{ width: 600 }}>
            <Title level={2} className='align'>Đăng nhập</Title>
            <Form
                name="basic"
                labelCol={{
                    span: 8,
                }}
                wrapperCol={{
                    span: 12,
                }}
                initialValues={{
                    remember: true,
                }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    label="Tên đăng nhập"
                    name="username"
                    rules={[
                        {
                            required: true,
                            message: 'Vui lòng nhập tên đăng nhập!',
                        },
                    ]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Mật khẩu"
                    name="password"
                    rules={[
                        {
                            required: true,
                            message: 'Vui lòng nhập mật khẩu!',
                        },
                    ]}
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    name="remember"
                    valuePropName="checked"
                    wrapperCol={{
                        offset: 8,
                        span: 16,
                    }}
                >
                    <Checkbox>Nhớ mật khẩu</Checkbox>
                </Form.Item>

                <Form.Item
                    wrapperCol={{
                        offset: 8,
                        span: 16,
                    }}
                >
                    <Button type="primary" htmlType="submit" style={{width:275}}>
                        Đăng nhập
                    </Button>
                </Form.Item>
            </Form>
        </Card>

    );
};

export default Login;