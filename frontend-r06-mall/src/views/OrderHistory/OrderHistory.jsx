import React, { useState, useEffect } from 'react'
import { Button, Card, Row, Col, Avatar } from "antd"
import { Link } from 'react-router-dom'
import './OrderHistory.css'
import axios from 'axios'

// const data = [
//     {
//         DonHangId: 111111,
//         DonHangSanPham: {
//                 SanPham: {
//                         TenSanPham: 'Sản phẩm test',
//                         DonGia: 1000
//                     },
//                 SoLuong: 2
//         }
//     },
//     {
//         DonHangId: 222222,
//         DonHangSanPham: {
//                 SanPham:{
//                         TenSanPham: 'Sản phẩm test 2',
//                         DonGia: 1500
//                     },
//                 SoLuong: 1
//             }
        
//     }
// ]

const OrderHistory = () =>{
    const [orderItems, setOrderItems] = useState([])

    const getOrderItems = () => {
        axios({
            method: 'get',
            url: `https://localhost:5001/api/Order/history`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`}
        })
        .then(res=>{
            const result = res.data
            setOrderItems(result)
        })
        .catch((error)=>{
            console.log(error)
        })
    }
    useEffect(()=>{
        getOrderItems()
    }, [])

    return(
        <div>
            <Card title="Đơn hàng đã mua">
                <div className='order-list'>
                    {orderItems.map((item)=>{
                        const {donHangId, donHangSanPham} = item
                        return(
                            <div className='single-item'>
                                <h3 className='product-name'>{donHangSanPham.sanPham? donHangSanPham.sanPham.tenSanPham : '' }</h3>
                                <p className='quantity'>x{donHangSanPham.soLuong}</p>
                                <p className='price'>đ{donHangSanPham.sanPham ? donHangSanPham.sanPham.donGia : ''}</p>
                                <div className='total-section'>
                                    <p>{donHangSanPham.soLuong} sản phẩm</p>
                                    <h3>Thành tiền: 
                                        <span className='total-price'> đ{donHangSanPham.sanPham ? donHangSanPham.SoLuong* donHangSanPham.sanPham.donGia : ''}</span>
                                    </h3>
                                </div>
                                <Link to={`/order_history/${donHangId}`}>Xem chi tiết...</Link>
                            </div>
                        )
                    })}
                </div>
            </Card>
        </div>
    )
}

export default OrderHistory