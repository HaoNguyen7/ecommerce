import React, { useState } from 'react'
import { Button, Card } from "antd"
import axios from 'axios'
const Shipper = () => {
    const [driver, setDriver] = useState({});
    const findShortestShipper = () => {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log("Latitude is :", position.coords.latitude);
            console.log("Longitude is :", position.coords.longitude);
            const params = { ViDo: position.coords.latitude, KinhDo: position.coords.longitude }
            console.log(localStorage.getItem('token'))

            axios({
                method: 'get',
                url: `https://localhost:44391/Driver/shortest_shipper`,
                headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
                params: params
            })
                .then(res => {
                    // window.open(`https://www.google.com/maps/dir/'${position.coords.latitude},${position.coords.longitude}'/${res.data.tenCuaHang}`);
                    setDriver(res.data)
                })
                .catch((error) => {
                    console.error(error);
                })
        });
    }
    return (
        <div>
            <Card title="Tài xế gần nhất" extra={<Button onClick={findShortestShipper}>Tìm tài xế gần nhất</Button>}>
                <Card
                    title={driver.tenNguoiGiaoHang}
                    extra={<a href="#">More</a>}
                    style={{ width: 500 }} // background: state ? "gray" : "transparent" }}
                    hoverable={true}
                >
                    <p>{driver.diaChi}</p>
                    <p>{driver.vungHoatDong}</p>
                    <p>{driver.soDienThoai}</p>
                </Card>
            </Card>
        </div>
    )
}

export default Shipper
