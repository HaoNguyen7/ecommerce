import React, {useState} from 'react'
import { Form, Input, Button } from 'antd';
import './index.css'
import axios from 'axios'
import { toast } from 'react-toastify';

const layout = {
  labelCol: {
    span: 6,
  },
  wrapperCol: {
    span: 16,
  },
};
const tailLayout = {
  wrapperCol: {
    offset: 6,
    span: 16,
  },
};
const CreateCategory = () => {
  const [data,setData] = useState();
  const [form] = Form.useForm();
  const onReset = () => {
    form.resetFields();
  };
  const onFinish = (values) => {
    console.log(values);
    axios({
      method: 'post',
      url: 'https://localhost:44391/api/TypeProduct/create',
      data: values
    }).then(res => 
      {
        setData(res.data)
        toast.success("Tạo mới danh mục thành công");
      }
    ).catch(err => {
      toast.error(err.response.data);
    });
  };

  return (
    <Form {...layout} form={form} name="control-hooks" onFinish={onFinish}>
      <Form.Item
        name="categoryName"
        label="Tên danh mục"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input />
      </Form.Item>
      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Thêm danh mục
        </Button>
        <Button htmlType="button" onClick={onReset}>
          Xóa
        </Button>
      </Form.Item>
    </Form>
  )
}

export default CreateCategory