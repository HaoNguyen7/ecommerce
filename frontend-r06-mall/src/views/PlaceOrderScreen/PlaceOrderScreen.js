import React, { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { Link, useNavigate } from 'react-router-dom';
import CheckoutSteps from '../../components/CheckoutSteps';

export default function PlaceOrderScreen(props) {
	const cart = useSelector((state) => state.cart);
	const navigate = useNavigate();
	useEffect(() => {
		if (!cart.paymentMethod) {
			navigate('/payment');
		}
	}, []);

	const toPrice = (num) => Number(num.toFixed(2));
	cart.itemsPrice = toPrice(cart.cartItems.reduce((a, c) => a + c.qty * c.price, 0));
	cart.shippingPrice = 0; //tien shipping chua biet?
	cart.totalPrice = cart.shippingPrice + cart.itemsPrice;
	const placeholderHandler = () => {
		//place order action
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
									<strong>Name:</strong>
									{cart.shippingAddress.fullName} <br />
									<strong>Address</strong>
									{cart.shippingAddress.address},
									{cart.shippingAddress.city}, {cart.shippingAddress.postalCode},
									{cart.shippingAddress.country}
								</p>
							</div>
						</li>
						<li>
							<div className="card card-body">
								<h2>Shipping</h2>
								<p>
									<strong>Name:</strong>
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
								<button
									type="button"
									onClick={placeholderHandler}
									disabled={cart.cartItems.length === 0}
									className="primary block"
								>
									Place Order
								</button>
							</li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	);
}
