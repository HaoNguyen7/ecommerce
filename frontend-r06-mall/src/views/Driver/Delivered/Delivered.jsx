import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"
import "./Delivered.css"

// const data = [
//     {
//         DonHangId: 111111,
//         TinhTrangThanhToan: 'Đã thanh toán',
//         TinhTrangGiao: 'Đang giao hàng',
//         DonHangSanPham:[
//             {
//                 SanPham:[
//                     {
//                         TenSanPham: 'Sản phẩm 1',
//                         DonGia: 1000
//                     },
//                     {
//                         TenSanPham: 'Sản phẩm 2',
//                         DonGia: 1000
//                     }
//                 ]
//             }
//         ],
//         KhachHang: {
//             TenKhachHang: 'Nguyễn Văn A',
//             DiaChi: 'số nhà 1'
//         }
//     },
//     {
//         DonHangId: 222222,
//         TinhTrangThanhToan: 'Đã thanh toán',
//         TinhTrangGiao: 'Đã giao hàng',
//         DonHangSanPham:[
//             {
//                 SanPham:[
//                     {
//                         TenSanPham: 'Sản phẩm 3',
//                         DonGia: 1000
//                     },
//                     {
//                         TenSanPham: 'Sản phẩm 4',
//                         DonGia: 1000
//                     }
//                 ]
//             }
//         ],
//         KhachHang: {
//             TenKhachHang: 'Nguyễn Văn B',
//             DiaChi: 'số nhà 2'
//         }
//     },
//     {
//         DonHangId: 333333,
//         TinhTrangThanhToan: 'Chưa thanh toán',
//         TinhTrangGiao: 'Đang giao hàng',
//         DonHangSanPham:[
//             {
//                 SanPham:[
//                     {
//                         TenSanPham: 'Sản phẩm 5',
//                         DonGia: 1000
//                     },
//                     {
//                         TenSanPham: 'Sản phẩm 6',
//                         DonGia: 1000
//                     }
//                 ]
//             }
//         ],
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
            url: `https://localhost:5001/api/Delivered/history`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`}
        })
        .then(res=>{
            const result = res.data
            console.log(result)
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
            <div className='delivered-list'>
                    {deliveredItems.map((item)=>{
                        return(
                            <div className='delivered-items'>
                                <h3><span className='label'>Mã đơn hàng:</span> {item.donHangId}</h3>
                                <h3><span className='label'>Tình trạng thanh toán</span> 
                                    {item.tinhTrangThanhToan? 'Đã thanh toán' : 'Chưa thanh toán'}
                                </h3>
                                <h3><span className='label'>Tình trạng giao hàng</span> {item.tinhTrangGiao}</h3>
                                <h3><span className='label'>Tên khách hàng</span> Tên khách hàng</h3>
                                <h3><span className='label'>Địa chỉ giao hàng</span> {item.diaChi}</h3>
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