import Axios from 'axios';
import React, { useEffect, useState } from 'react';
import jwt_decode from 'jwt-decode';
export default function OrderStore(props) {
	const [ listdh, setListdh ] = useState([]);
	const [ loading, setLoading ] = useState(true);
	const [ tinhtrang, setTinhtrang ] = useState(false); //khi update thi set tinhtrang = true =>> reload component
	const [ idStore, setidStore ] = useState('');
	let idUser = jwt_decode(localStorage.getItem('token')).Id;
	useEffect(
		() => {
			let params = { pageSize: 50 };
			params.id = localStorage.getItem('userInfo').id;
			const getStore = async () => {
				await Axios({
					method: 'GET',
					url: 'https://localhost:5001/Store/get-store-by-user',
					headers: { Authorization: `Bearer ${localStorage.getItem('token')}` },
					params: params
				})
					.then((res) => {
						console.log(res);
						console.log('cuaHangId:', res.data.data[0].cuaHangId); //đã có được cửa hàng id
						setidStore(localStorage.getItem('userInfo').id);
						console.log(idStore);
					})
					.catch((err) => console.log(err));
			};
			getStore();
			getOrder();
		},
		[ loading ]
	);
	const getOrder = async () => {
		// await Axios.get(`http://localhost:8080/order/waiting/${idStore}`).then((res) => {
		// 	const { data } = res;
		// 	console.log('data', data);
		// 	setListdh(data);
		// 	setLoading(false);
		// });
		await Axios({
			method: 'GET',
			url: `http://localhost:8080/order/waiting/${idUser}`,
			headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' }
		}).then((res) => {
			const { data } = res;
			console.log('data', data);
			setListdh(data);
			setLoading(false);
		});
	};
	const updateOrderHandler = (id) => {
		const ttdh = 'Đang đóng gói';
		Axios({
			method: 'post',
			url: `http://localhost:8080/order/${id}/update`,
			headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' },
			data: ttdh
		})
			.then((res) => {
				console.log(res);
				console.log(res.data);
				setTinhtrang(true);
			})
			.catch((error) => {
				console.error(error);
			});
	};
	return (
		<div className="row top">
			<ul>
				<button onClick={getOrder}>Load Đơn hàng</button>
				{listdh.map((dh) => (
					<li key={dh.donHangId}>
						<div>
							<div className="row">Đơn Giá: {dh.tongTien} VNĐ</div>
							<div>Mã đơn hàng :{dh.donHangId}</div>
							<div>Địa chỉ nhận hàng: {dh.diaChi}</div>
							<div>Tình trạng đơn hàng: {dh.tinhTrangDonHangsByDonHangId[0].tenTinhTrang}</div>
							<div>
								<button onClick={() => updateOrderHandler(dh.donHangId)}>Update Đang đóng gói</button>
							</div>
						</div>
					</li>
				))}
			</ul>
		</div>
	);
}
