import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Link, useNavigate } from 'react-router-dom';
import { createOrder } from '../../actions/orderActions';
import CheckoutSteps from '../../components/CheckoutSteps';
import Axios from 'axios';
import { emptyCart } from '../../actions/cartActions';
import { PayPalButton } from 'react-paypal-button-v2';

export default function PlaceOrderScreen(props) {
	const cart = useSelector((state) => state.cart);
	const c = useSelector((state) => state.cart);
	const paymentMethod = cart.paymentMethod;
	console.log(paymentMethod);
	const dispatch = useDispatch();
	const navigate = useNavigate();
	useEffect(() => {
		if (!cart.paymentMethod) {
			navigate('/payment');
		}
	}, []);
	const orderCreate = useSelector((state) => state.orderCreate);
	const toPrice = (num) => Number(num.toFixed(2));
	cart.itemsPrice = toPrice(cart.cartItems.reduce((a, c) => a + c.qty * c.price, 0));
	cart.shippingPrice = 0; //tien shipping chua biet?
	cart.totalPrice = cart.shippingPrice + cart.itemsPrice;
	cart.totalPrice = 300000;
	const [ orderId, setOrderId ] = useState('');
	const placeholderHandler = async () => {
		const listsp = cart.cartItems;
		const data = cart;
		Axios({
			method: 'post',
			url: 'https://localhost:5001/api/Cart/Create',
			headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' },
			data: data
		})
			.then((res) => {
				console.log(res);
				console.log(res.data);
				setOrderId(res.data);
			})
			.catch((error) => {
				console.error(error);
			});
		dispatch(emptyCart());
	};
	const [ sdkReady, setSdkReady ] = useState(false);

	useEffect(
		() => {
			const addPayPalScript = async () => {
				const { data } = Axios.get('https://localhost:5001/api/Cart/payPal');
				const script = document.createElement('script');
				script.type = 'text/javascript';
				script.src = `https://www.paypal.com/sdk/js?client-id=${data}`;
				script.async = true;
				script.onload = () => {
					setSdkReady(true);
				};
				document.body.appendChild(script);
			};
			if (!window.paypal) {
				addPayPalScript();
			} else {
				setSdkReady(true);
			}
		},
		[ sdkReady ]
	);
	const successPaymentHandler = () => {
		console.log('da thanh toan bang PayPal nhung chua cap nhat db');
		//const { data } = Axios.put(`https://localhost:5001/api/Cart/${orderId}/pay`);
		Axios({
			method: 'put',
			url: `https://localhost:5001/api/Cart/${orderId}/pay`,
			headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' }
		})
			.then((res) => {
				console.log(res);
			})
			.catch((error) => {
				console.error(error);
			});
	};
	return (
		<div>
			<CheckoutSteps step1 step2 step3 step4 />
			<div className="row top">
				<div className="col-2">
					<ul>
						<li>
							<div className="card card-body">
								<h2>Shipping</h2>
								<p>
									<strong>Name: </strong>
									{cart.shippingAddress.fullName} <br />
									<strong>Address </strong>
									{cart.shippingAddress.address},
									{cart.shippingAddress.city},
									{cart.shippingAddress.country}
								</p>
							</div>
						</li>
						<li>
							<div className="card card-body">
								<h2>Payment Method</h2>
								<p>
									<strong>Name: </strong>
									{cart.paymentMethod} <br />
								</p>
							</div>
						</li>
						<li>
							<div className="card card-body">
								<h2>Order items</h2>
								<ul>
									{cart.cartItems.map((item) => (
										<li key={item.product}>
											<div className="row">
												<div>
													<img
														src={
															item.img ? (
																item.img
															) : (
																'https://elearning-bucket2.s3.us-east-2.amazonaws.com/2022-01-05T05-40-25.924Z-react-logo.png'
															)
														}
														alt={item.name}
														className="small"
													/>
												</div>
												<div className="min-30">
													<Link to={`/product/${item.product}`}>{item.name}</Link>
												</div>
												<div>
													{item.qty} x ${item.price} = ${item.qty * item.price}
												</div>
											</div>
										</li>
									))}
								</ul>
							</div>
						</li>
					</ul>
				</div>
				<div className="col-1">
					<div className="card card-body">
						<ul>
							<li>
								<h2>Order Summary</h2>
							</li>
							<li>
								<div className="row">
									<div>Items</div>
									<div>${cart.itemsPrice}</div>
								</div>
							</li>
							<li>
								<div className="row">
									<div>Shipping</div>
									<div>${cart.shippingPrice}</div>
								</div>
							</li>
							<li>
								<div className="row">
									<div>
										<strong>Total</strong>
									</div>
									<div>
										<strong>${cart.totalPrice}</strong>
									</div>
								</div>
							</li>
							<li>
								{paymentMethod === 'directPay' ? (
									<button
										type="button"
										onClick={placeholderHandler}
										disabled={cart.cartItems.length === 0}
										className="primary block"
									>
										Tao Don Hang
									</button>
								) : (
									<PayPalButton
										amount={cart.totalPrice}
										onSuccess={successPaymentHandler}
										onClick={placeholderHandler}
									/>
								)}
							</li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	);
}
