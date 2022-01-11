import React, { useState } from 'react';
import { Card, Input, Button } from 'antd';
import { Link } from 'react-router-dom';
import './logIn.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
function LogIn() {
	const [ email, setEmail ] = useState('');
	const [ password, setPassword ] = useState('');
	const navigate = useNavigate();
	const getPassword = (event) => {
		setPassword(event.target.value);
	};
	const getEmail = (event) => {
		setEmail(event.target.value);
	};

	const onClickSubmit = () => {
		axios({
			method: 'POST',
			url: 'https://localhost:5001/Accounts/Login',
			data: {
				email: email,
				password: password
			}
		})
			.then((res) => {
				localStorage.setItem('token', res.data.token);
				alert('Đăng nhập thành công');
				navigate('/');
			})
			.catch((err) => {
				console.log(err);
			});
	};

	return (
		<Card title="Đăng nhập" className="login-card">
			<Input size="large" placeholder="Enter email" addonBefore="Email" type="email" onChange={getEmail} />
			<Input
				size="large"
				placeholder="Enter password"
				addonBefore="Mật khẩu"
				type="password"
				onChange={getPassword}
			/>
			<Button type="primary" size="large" onClick={onClickSubmit}>
				Đăng nhập
			</Button>
			<p>
				<Link to="/signup">Tạo tài khoản</Link> nếu bạn chưa có tài khoản
			</p>
		</Card>
	);
}

export default LogIn;
