import React, { useState } from 'react';
import { Card, Input, Button } from "antd"
import "./signUp.css"
import axios from 'axios';
function SignUp() {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("")

  const getUserName = (event) => {
    setUserName(event.target.value)
  }
  const getEmail = (event) => {
    setEmail(event.target.value)
  }
  const getPassword = (event) => {
    setPassword(event.target.value)
  }

  const onClickSubmit = () => {
    axios({
      method:"POST",
      url: "https://localhost:5001/Accounts/Register",
      data: {
        tenKhachHang: userName,
        email: email,
        password: password 
      }
    }).then(res=> {
      console.log(res.data)
    }).catch(err=> {
      console.log(err)
    })
  }
  return (
    <Card title="Tạo tài khoản" className='signup-card'>
      <Input size="large" placeholder="large size" addonBefore="Tên đăng nhập" type="text" onChange={getUserName}/>
      <Input size="large" placeholder="large size" addonBefore="Email" type="email" onChange={getEmail}/>
      <Input size="large" placeholder="large size" addonBefore="Mật khẩu" type="password" onChange={getPassword}/>
      <Button className = "login-button" type="primary" size="large" onClick={onClickSubmit}>
          Tạo tài khoản
        </Button>
    </Card>
  );
}

export default SignUp;