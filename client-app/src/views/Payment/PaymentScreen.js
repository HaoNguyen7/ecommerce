import React, { useEffect, useState } from 'react';
import CheckoutSteps from '../../components/CheckoutSteps';
import { Form, Input, Button, Radio, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import { savePaymentMethod } from '../../actions/cartActions';
import { useDispatch, useSelector } from 'react-redux';
export default function PaymentScreen(props) {
	const cart = useSelector((state) => state.cart);
	const { shippingAddress } = cart;
	const navigate = useNavigate();

	useEffect(() => {
		if (!shippingAddress.address) {
			navigate('/shipping');
		}
	}, []);
	const [ paymentMethod, setPaymentMethod ] = useState('PayPal');
	const dispatch = useDispatch();
	const submitHandler = (e) => {
		e.preventDefault();
		dispatch(savePaymentMethod(paymentMethod));
		navigate('/placeorder');
	};
	return (
		<Form labelCol={{ span: 4 }} wrapperCol={{ span: 14 }} layout="horizontal">
			<CheckoutSteps step1 step2 step3 />
			<h1>Choose Payment Method</h1>
			<Radio.Group
				onChange={(e) => {
					setPaymentMethod(e.target.value);
				}}
				value={paymentMethod}
			>
				<Space direction="vertical">
					<Radio value="PayPal" id="PayPal">
						PayPal
					</Radio>
					<Radio value="directPay" id="directPay">
						Direct Payment
					</Radio>
				</Space>
			</Radio.Group>
			<Form.Item wrapperCol={{ offset: 8, span: 16 }}>
				<Button type="primary" onClick={submitHandler}>
					Submit
				</Button>
			</Form.Item>
		</Form>
	);
}
