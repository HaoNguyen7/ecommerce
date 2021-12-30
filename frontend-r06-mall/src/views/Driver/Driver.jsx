import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"

const Driver = () => {
    const [shop,setShop] = useState({});
    const findShortestShop = () => {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log("Latitude is :", position.coords.latitude);
            console.log("Longitude is :", position.coords.longitude);
            const params = {ViDo: position.coords.latitude, KinhDo:position.coords.longitude}
            console.log(localStorage.getItem('token'))

            axios({
                method: 'get',
                url: `https://localhost:44391/Driver/shortest_shop`,
                headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`},
                params: params
            })
            .then(res => {
                window.open(`https://www.google.com/maps/dir/'${position.coords.latitude},${position.coords.longitude}'/${res.data.tenCuaHang}`);
                setShop(res.data)
            })
            .catch((error) => {
                console.error(error);
            })  
        });
    }
    return (
        <div>
            <Card title="Cửa hàng gần nhất" extra={<Button onClick={findShortestShop}>Tìm cửa hàng gần nhất</Button>}>
            <Card
                title={shop.tenCuaHang}
                extra={<a href="#">More</a>}
                style={{ width: 500 }} // background: state ? "gray" : "transparent" }}
                hoverable={true}
                >
                <p>{shop.moTa}</p>
                <p>{shop.danhGia}</p>
                <p>{shop.soDienThoai}</p>
                </Card>
            </Card>
        </div>
    )
}

export default Driver
