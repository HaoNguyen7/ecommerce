import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"
import "./Delivered.css"

// const data = [
//     {
//         DonHangId: 111111,
//         TinhTrangThanhToan: 'Đã thanh toán',
//         TinhTrangGiao: 'Đang giao hàng',
//         KhachHang: {
//             TenKhachHang: 'Nguyễn Văn A',
//             DiaChi: 'số nhà 1'
//         }
//     },
//     {
//         DonHangId: 222222,
//         TinhTrangThanhToan: 'Đã thanh toán',
//         TinhTrangGiao: 'Đã giao hàng',
//         KhachHang: {
//             TenKhachHang: 'Nguyễn Văn B',
//             DiaChi: 'số nhà 2'
//         }
//     },
//     {
//         DonHangId: 333333,
//         TinhTrangThanhToan: 'Chưa thanh toán',
//         TinhTrangGiao: 'Đang giao hàng',
//         KhachHang: {
//             TenKhachHang: 'Nguyễn Văn C',
//             DiaChi: 'số nhà 3'
//         }
//     }
// ]

const Delivered = () => {
    const [deliveredItems, setDeliveredItems] = useState([])

    const getDeliveredItems = () => {
        axios({
            method: 'get',
            url: `https://localhost:44391/api/Delivered/history`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`}
        })
        .then(res=>{
            const result = res.data
            setDeliveredItems(result)
        })
        .catch((error)=>{
            console.log(error)
        })
    }
    useEffect(()=>{
        getDeliveredItems()
    }, [])

    const showMore = () =>{

    }

    return(
        <div>
            <Card title="Đơn hàng đã giao">
                <div className='label'>
                    <h3>Mã đơn hàng</h3>
                    <h3>Tình trạng thanh toán</h3>
                    <h3>Tình trạng giao hàng</h3>
                    <h3>Tên khách hàng</h3>
                    <h3>Địa chỉ giao hàng</h3>
                </div>
                <div className='delivered-list'>
                    {deliveredItems.map((item)=>{
                        const {DonHangId, TinhTrangThanhToan, TinhTrangGiao, KhachHang} = item
                        return(
                            <div className='delivered-items'>
                                <h3> {DonHangId}</h3>
                                <h3> {TinhTrangThanhToan}</h3>
                                <h3> {TinhTrangGiao}</h3>
                                <h3> {KhachHang.TenKhachHang}</h3>
                                <h3> {KhachHang.DiaChi}</h3>
                            </div>
                        )
                    })}
                </div>
                <a 
                    className='show-more-btn'
                    onClick={showMore}
                >
                    Xem thêm...
                </a>
            </Card>
        </div>
    )
}

export default Delivered