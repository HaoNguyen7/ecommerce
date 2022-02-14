import Axios from 'axios';
import React, { useEffect, useState } from 'react';
import jwt_decode from 'jwt-decode';
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

	const toOrderHandler = async (id) => {
		const ttdh = 'Đang vận chuyển';
		await Axios({
			method: 'post',
			url: `http://localhost:8080/order/${id}/update`,
			headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' },
			data: ttdh
		})
			.then((res) => {
				console.log(res);
				console.log(res.data);
			})
			.catch((error) => {
				console.error(error);
			});
			let idTaiXe = jwt_decode(localStorage.getItem("token")).Id;
			await Axios({
				method: 'put',
				url: `http://localhost:8080/add-tx-for-dh/${idTaiXe}/${id}`,
				})
				.then((res) => {
					alert("Nhận đơn thành công")
				})
				.catch((error) => {
					alert("Nhận đơn thành công")
					console.error(error);
				});
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
