import React, { useState, useEffect } from 'react'
import Chart from '../../components/Chart/Chart'
import { Button, Card, Row, Col, Avatar } from "antd"
import { Link } from 'react-router-dom'
import axios from 'axios'
import { UserOutlined } from '@ant-design/icons';

// const data = [
//     {
//         soLuong: 21,
//         sanPhamId: '111111',
//         tenSanPham: 'Sản phẩm 1'
//     },
//     {
//         soLuong: 17,
//         sanPhamId: '111112',
//         tenSanPham: 'Sản phẩm 2'
//     },
//     {
//         soLuong: 12,
//         sanPhamId: '111113',
//         tenSanPham: 'Sản phẩm 3'
//     },
//     {
//         soLuong: 8,
//         sanPhamId: '111114',
//         tenSanPham: 'Sản phẩm 4'
//     },
//     {
//         soLuong: 25,
//         sanPhamId: '111115',
//         tenSanPham: 'Sản phẩm 5'
//     },
//     {
//         soLuong: 30,
//         sanPhamId: '111116',
//         tenSanPham: 'Sản phẩm 6'
//     },
//     {
//         soLuong: 11,
//         sanPhamId: '111117',
//         tenSanPham: 'Sản phẩm 7'
//     },
//     {
//         soLuong: 24,
//         sanPhamId: '111118',
//         tenSanPham: 'Sản phẩm 8'
//     },
//     {
//         soLuong: 21,
//         sanPhamId: '111119',
//         tenSanPham: 'Sản phẩm 9'
//     },
//     {
//         soLuong: 13,
//         sanPhamId: '111110',
//         tenSanPham: 'Sản phẩm 10'
//     },
// ]

const ImportantItems = () => {
    const [items, setItems] = useState([])

    const getImportantItems = () => {
        axios({
            method: 'get',
            url: `http://localhost:8080/importantItems`
        })
        .then(res=>{
            const result = res.data.data
            setItems(result)
        })
        .catch((error)=>{
            console.log(error)
        })
    }
    useEffect(()=>{
        getImportantItems()
    }, [])

    return(
        <div>
            <Card title='Thống kê các mặt hàng thiết yếu'>
                <h2>Top 10 mặt hàng được mua nhiều nhất</h2>
                <Chart data={items}/>
                <Link to='/'>Quay lại mua sắm...</Link>
            </Card>
        </div>
    )
}

export default ImportantItems