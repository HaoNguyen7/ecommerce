import React, { useState } from 'react';
import { Card, Input, Button } from "antd"
import "./signUp.css"
import axios from 'axios';
import {useNavigate } from "react-router-dom"
function SignUp() {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("")
  const navigate = useNavigate();
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
      alert("Đăng ký thành công")
      navigate("/login")
    }).catch(err=> {
      console.log(err)
    })
  }
  return (
    <Card title="Tạo tài khoản" className='signup-card'>
      <Input size="large" placeholder="Enter username" addonBefore="Tên đăng nhập" type="text" onChange={getUserName}/>
      <Input size="large" placeholder="Enter email" addonBefore="Email" type="email" onChange={getEmail}/>
      <Input size="large" placeholder="Enter password" addonBefore="Mật khẩu" type="password" onChange={getPassword}/>
      <Button className = "login-button" type="primary" size="large" onClick={onClickSubmit}>
          Tạo tài khoản
        </Button>
    </Card>
  );
}

export default SignUp;