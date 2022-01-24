import React, { useEffect, useState } from 'react';
import CheckoutSteps from '../../components/CheckoutSteps';
import './ShippingAddressScreen.css';
import { useDispatch, useSelector } from 'react-redux';
import { saveShippingAddress } from '../../actions/cartActions';
import { useNavigate } from 'react-router-dom';
import { Form, Input, Button } from 'antd';
export default function ShippingAddressScreen(props) {
	const userSignin = useSelector((state) => state.userSignin);
	const { userInfo } = userSignin;
	console.log(userInfo);
	const cart = useSelector((state) => state.cart);
	const { shippingAddress } = cart;
	const navigate = useNavigate();

	useEffect(() => {
		if (!userInfo) {
			navigate('/login');
			console.log('working');
		}
	}, []);
	const [ fullName, setFullName ] = useState(shippingAddress.fullName);
	const [ address, setAddress ] = useState(shippingAddress.address);
	const [ city, setCity ] = useState(shippingAddress.city);
	const [ postalCode, setPostalCode ] = useState(shippingAddress.postalCode);
	const [ country, setCountry ] = useState(shippingAddress.country);
	const dispatch = useDispatch();

	//submit se luu data vao trong store redux
	const submitHandler = (e) => {
		e.preventDefault();
		dispatch(saveShippingAddress({ fullName, address, city, postalCode, country })); //wrap trong 1 object vi data truyen vao action la object
		navigate('/payment'); //redirect user to payment screen
	};
	return (
		// <div>
		// 	<CheckoutSteps step1 step2 />
		// 	<form className="form" onSubmit={submitHandler}>
		// 		<div>
		// 			<h1>Shipping Address</h1>
		// 		</div>
		// 		<div>
		// 			<label htmlFor="fullName">Full Name</label>
		// 			<input
		// 				type="text"
		// 				id="fullName"
		// 				placeholder="Enter full name"
		// 				value={fullName}
		// 				onChange={(e) => setFullName(e.target.value)}
		// 				required
		// 			/>
		// 		</div>
		// 		<div>
		// 			<label htmlFor="address">Address</label>
		// 			<input
		// 				type="text"
		// 				id="address"
		// 				placeholder="Enter address"
		// 				value={address}
		// 				onChange={(e) => setAddress(e.target.value)}
		// 				required
		// 			/>
		// 		</div>
		// 		<div>
		// 			<label htmlFor="city">City</label>
		// 			<input
		// 				type="text"
		// 				id="city"
		// 				placeholder="Enter city"
		// 				value={city}
		// 				onChange={(e) => setCity(e.target.value)}
		// 				required
		// 			/>
		// 		</div>
		// 		<div>
		// 			<label htmlFor="postalCode">Postal Code</label>
		// 			<input
		// 				type="text"
		// 				id="postalCode"
		// 				placeholder="Enter postal code"
		// 				value={postalCode}
		// 				onChange={(e) => setPostalCode(e.target.value)}
		// 				required
		// 			/>
		// 		</div>
		// 		<div>
		// 			<label htmlFor="country">Country</label>
		// 			<input
		//  type="text"
		// id="country"
		// placeholder="Enter country"
		// value={country}
		// onChange={(e) => setCountry(e.target.value)}
		// required
		// 			/>
		// 		</div>
		// 		<div>
		// 			<label />
		// 			<button className="primary" type="submit">
		// 				Continue
		// 			</button>
		// 		</div>
		// 	</form>
		// </div>
		<Form labelCol={{ span: 4 }} wrapperCol={{ span: 14 }} layout="horizontal">
			<CheckoutSteps step1 step2 />
			<h1>Shipping Address</h1>
			<Form.Item label="Full Name" rules={[ { required: true } ]}>
				<Input
					type="text"
					id="fullName"
					placeholder="Enter Fullname"
					value={fullName}
					onChange={(e) => setFullName(e.target.value)}
					required
				/>
			</Form.Item>
			<Form.Item label="Address" rules={[ { required: true } ]}>
				<Input
					type="text"
					id="address"
					placeholder="Enter address"
					value={address}
					onChange={(e) => setAddress(e.target.value)}
					required
				/>
			</Form.Item>
			<Form.Item label="City" rules={[ { required: true } ]}>
				<Input
					type="text"
					id="city"
					placeholder="Enter city"
					value={city}
					onChange={(e) => setCity(e.target.value)}
					required
				/>
			</Form.Item>
			<Form.Item label="Postal Code" rules={[ { required: true } ]}>
				<Input
					type="text"
					id="postalCode"
					placeholder="Enter postal code"
					value={postalCode}
					onChange={(e) => setPostalCode(e.target.value)}
					required
				/>
			</Form.Item>
			<Form.Item label="Country" rules={[ { required: true } ]}>
				<Input
					type="text"
					id="country"
					placeholder="Enter country"
					value={country}
					onChange={(e) => setCountry(e.target.value)}
					required
				/>
			</Form.Item>
			<Form.Item wrapperCol={{ offset: 8, span: 16 }}>
				<Button type="primary" onClick={submitHandler}>
					Submit
				</Button>
			</Form.Item>
		</Form>
	);
}
