import Axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Navigate } from 'react-router-dom';
//import './OrderShipper.css';
export default function OrderShipper(props) {
	const [ listdh, setListdh ] = useState([]);
	const [ loading, setLoading ] = useState(true);
	useEffect(
		() => {
			console.log(1234);
			Axios.get('http://localhost:8080/order/unpicked').then((res) => {
				const { data } = res;
				console.log('data', data);
				setListdh(data);
				setLoading(false);
			});
		},
		[ loading ]
	);

	const toOrderHandler = (id) => {
		//to order with specific id
	};
	return (
		<div className="row top">
			<ul>
				{listdh.map((dh) => (
					<li key={dh.donHangId}>
						<div>
							<div className="row">Đơn Giá: {dh.tongTien} VNĐ</div>
							<div>Mã đơn hàng :{dh.donHangId}</div>
							<div>Địa chỉ nhận hàng: {dh.diaChi}</div>
							<div>
								<button onClick={() => toOrderHandler(dh.donHangId)}>To Order</button>
							</div>
						</div>
					</li>
				))}
			</ul>
		</div>
	);
}
