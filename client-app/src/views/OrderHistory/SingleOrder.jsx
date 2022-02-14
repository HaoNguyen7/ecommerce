import React, { useState, useEffect } from 'react'
import { Button, Card, Row, Col, Avatar } from "antd"
import { useParams, Link } from 'react-router-dom'
import './OrderHistory.css'
import axios from 'axios'


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
                {order?<div>
                    <div className='product-detail'>
                        <span>Sản phẩm đã mua</span>
                        {order.donHangSanPham.map((item)=>{
                            return(
                                <div>
                                    <p>Tên sản phẩm: {item.sanPham.tenSanPham}</p>
                                    <p>Đơn giá: {item.sanPham.donGia} VND</p>
                                    <p>Số lượng: {item.soLuong}</p>
                                </div>
                            )
                        })}
                    </div>
                    <div className='address'>
                        <span>Địa chỉ nhận hàng:</span>
                        <p>{order.khachHang.tenKhachHang}</p>
                        <p>{order.khachHang.soDienThoai}</p>
                        <p>{order.khachHang.diaChi}</p>
                    </div> 
                    <h3>Tình trạng thanh toán: <span style={{color: 'red'}}>{order.tinhTrangThanhToan?'Đã thanh toán':'Chưa thanh toán'}</span></h3>
                    <h3>Tình trạng giao hàng: <span style={{color: 'red'}}>{order.tinhTrangGiao}</span></h3>
                    <h3>Tổng tiền đơn hàng: <span style={{color: 'red'}}>{order.tongTien} VND</span></h3>
                </div>:(false)}
            </div>
                    <Button type="primary"  href={`/order/tracking/${donHangId}`}>
      Theo dõi đơn hàng
    </Button>
        </Card>

    )
}