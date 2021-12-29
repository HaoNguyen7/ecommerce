import React, { useState } from 'react';

import { Menu, Button } from 'antd';
import { HomeOutlined } from '@ant-design/icons';
import {useNavigate } from "react-router-dom"
import "./header.css"
const { SubMenu } = Menu;
function AppHeader() {
  const [current, setCurrent] = useState("main");
  const navigate = useNavigate();
  const handleClick = e => {
    setCurrent(e.key);
  };

  function onClickLogin() {
    navigate('/login');
  };

  function onClickSignUp() {
    navigate('/signup');
  };
  return (
    <Menu onClick={handleClick} selectedKeys={[current]} mode="horizontal">
      <Menu.Item key="homepage" icon={<HomeOutlined />}>
      <a href='/'>Homepage</a>
      </Menu.Item>
      <SubMenu key="SubMenu" title="Loại hàng hóa">
        <Menu.Item key="type:1"><a href='/op1'>Option 1</a></Menu.Item>
        <Menu.Item key="type:2"><a href='/op2'>Option 2</a></Menu.Item>
        <Menu.Item key="type:3"><a href='/op3'>Option 3</a></Menu.Item>
        <Menu.Item key="type:4"><a href='/op4'>Option 4</a></Menu.Item>
      </SubMenu>
      <Menu.Item className="login-space">
        <Button className = "login-button" type="primary" size="middle" onClick={onClickLogin}>
          Đăng nhập
        </Button>
        <Button className = "signup-button" type="primary" size="middle" onClick={onClickSignUp}>
          Tạo tài khoản
        </Button>
      </Menu.Item>
    </Menu>
  );
}

export default AppHeader;