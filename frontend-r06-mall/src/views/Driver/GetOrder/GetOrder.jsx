import React, {useState,useEffect} from 'react'
import axios from 'axios'
import {Card, Button} from 'antd'
const GetOrder = () => {
    const [order,setOrder] = useState()
    const onClick = () => {
        const body = {
            "tenTinhTrang":"Thanh cong",
            "donHangId":"ababf0fc-2990-4744-9d5e-1316efdbaa22",
            "ghiChu":"Rat tot",
            "ngayThucHien":"2021-12-31"
        }
        axios({
            method: 'post',
            url: `http://localhost:8080/tinhtrang`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`,
                        "Content-Type": "application/json",
                        withCredentials: true},
            data: body
        })
        .then(res => {
            setOrder(res.data)
            
            console.log(res.data)
            console.log(order)
        })
        .catch((error) => {
            console.error(error);
        }) 
      };
      useEffect(() => {
        console.log('useEffect has been called!');
        const params = {id:'ABABF0FC-2990-4744-9D5E-1316EFDBAA22',tinhtrang:0}

        axios({
            method: 'get',
            url: `http://localhost:8080/order_driver/${params.id}`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`,
                        "Content-Type": "application/json",
                        withCredentials: true},
            params: params
        })
        .then(res => {
            setOrder(res.data)
            
            console.log(res.data)
            console.log(order)
        })
        .catch((error) => {
            console.error(error);
        }) 
      }, []);
    return (
        <div>
            <Card title="Tiếp nhận đơn hàng" extra={<Button onClick={onClick}>Hoàn tất đơn hàng</Button>}>
                 <Card
                 title={order?.donHangId}
                 extra={<a href="#">More</a>}
                 style={{ width: 500 }} // background: state ? "gray" : "transparent" }}
                 hoverable={true}
                 >
                 <p>{order?.thoiGian}</p>
                 <p>{order?.tinhTrangThanhToan}</p>
                 </Card>
            </Card>
        </div>
    )
}

export default GetOrder
