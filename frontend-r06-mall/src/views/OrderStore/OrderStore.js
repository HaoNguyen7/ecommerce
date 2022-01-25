import Axios from 'axios';
import React, { useEffect, useState } from 'react';

export default function OrderStore(props) {
	const [ listdh, setListdh ] = useState([]);
	const [ loading, setLoading ] = useState(true);
	const [ tinhtrang, setTinhtrang ] = useState(false); //khi update thi set tinhtrang = true =>> reload component
	useEffect(
		() => {
			console.log(1234);
			Axios.get('http://localhost:8080/order/waiting').then((res) => {
				const { data } = res;
				console.log('data', data);
				setListdh(data);
				setLoading(false);
			});
		},
		[ loading ]
	);
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
