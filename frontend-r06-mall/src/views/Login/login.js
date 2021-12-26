import React, { useState } from 'react';
import { Card, Input, Button } from "antd"
import "./logIn.css"
function LogIn() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("")
  const getPassword = (event) => {
    setPassword(event.target.value)
  }
  const getEmail = (event) => {
    setEmail(event.target.value)
  }
  
  const onClickSubmit = () => {
    console.log(email)
    console.log(password)
  }
  
  return (
    <Card title="Đăng nhập" className='login-card'>
      <Input size="large" placeholder="large size" addonBefore="Email" type="email" onChange={getEmail} />
      <Input size="large" placeholder="large size" addonBefore="Mật khẩu" type="password" onChange={getPassword} />
      <Button className="login-button" type="primary" size="large" onClick={onClickSubmit}>
          Đăng nhập
      </Button>
    </Card>
  );
}

export default LogIn;