import React, { useState, useEffect } from 'react'
import { Button, Card, Row, Col, Avatar } from "antd"
import { useParams, Link } from 'react-router-dom'
import './OrderHistory.css'
import axios from 'axios'

// const data = {
//     DonHangId: 111111,
//     DonHangSanPham: {
//             SanPham: {
//                     TenSanPham: 'Sản phẩm test',
//                     DonGia: 1000
//                 },
//             SoLuong: 2
//     },
//     TinhTrangDonHang: [
//         'Chờ xác nhận', 'Đã xác nhận', 'Đang giao hàng', 'Giao hàng thành công'
//     ],
//     KhachHang: {
//         TenKhachHang: 'Nguyen Van A',
//         DiaChi: 'Số nhà 1, đường CMT8',
//         SoDienThoai: '0984523175'
//     }
// }

export default function SingleOrder(){
    const {donHangId} = useParams()
    const [order, setOrder] = useState(null)

    const getOrder = () => {
        axios({
            method: 'get',
            url: `https://localhost:5001/api/Order/view/${donHangId}`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`}
        })
        .then(res=>{
            const result = res.data
            console.log(result)
            setOrder(result)
        })
        .catch((error)=>{
            console.log(error)
        })
    }
    useEffect(()=>{
        getOrder()
    }, [])

    console.log('Hi')

    return(
        <Card title='Chi tiết đơn hàng'>
            <div className='order-detail'>
                <h3>Mã đơn hàng: {donHangId}</h3>
                {/* <p className='product-name'><span>Tên mặt hàng:</span> {order.DonHangSanPham.SanPham.TenSanPham}</p>
                <p className='quantity'><span>Số lượng:</span> {order.DonHangSanPham.SoLuong} sản phẩm</p>
                <p className='price'><span>Đơn giá:</span> đ{order.DonHangSanPham.SanPham.DonGia}</p>
                <p className='total'><span>Thành tiền:</span> đ{order.DonHangSanPham.SanPham.DonGia*order.DonHangSanPham.SoLuong}</p> */}
                {/* <p className='status'><span>Tình trạng đơn hàng:</span></p>
                <div className='address'>
                    <span>Địa chỉ nhận hàng:</span>
                    <p>{order.khachHang.tenKhachHang}</p>
                    <p>{order.khachHang.soDienThoai}</p>
                    <p>{order.khachHang.diaChi}</p>
                </div> */}
            </div>
                    <Button type="primary"  href={`/order/tracking/${donHangId}`}>
      Theo dõi đơn hàng
    </Button>
        </Card>

    )
}