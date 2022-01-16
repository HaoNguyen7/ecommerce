import React, { useState, useEffect } from 'react'
import axios from "axios";
import { Button, Card, Row, Col, Avatar, Tag } from "antd"
import { UserOutlined } from '@ant-design/icons';
const Driver = () => {
    const [shop, setShop] = useState({});
    const findShortestShop = () => {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log("Latitude is :", position.coords.latitude);
            console.log("Longitude is :", position.coords.longitude);
            const params = { ViDo: position.coords.latitude, KinhDo: position.coords.longitude }

            axios({
                method: 'get',
                url: `https://localhost:44391/Driver/shortest_shop`,
                headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
                params: params
            })
                .then(res => {
                    window.open(`https://www.google.com/maps/dir/'${position.coords.latitude},${position.coords.longitude}'/${res.data.tenCuaHang}`);
                    setShop(res.data)
                    console.log(res.data);
                })
                .catch((error) => {
                    console.error(error);
                })
        });
    }
    return (
        <div>
            <Card title="Cửa hàng gần nhất" extra={<Button onClick={findShortestShop}>Tìm cửa hàng gần nhất</Button>}>
                <Row>
                    <Col span={12} offset={8}>
                        <Card
                            title={shop.tenCuaHang}
                            extra={<a href="#">More</a>}
                            style={{ width: 500 }} // background: state ? "gray" : "transparent" }}
                            hoverable={true}
                        >
                            <Row>
                            <Col span={12} offset={8}>
                                <Avatar shape="square" src="https://st.nhipcaudautu.vn/staticFile/Subject/2019/12/19/bach-hoa-xanh_1973422.jpg" size={128} icon={<UserOutlined />} />
                            </Col>
                            </Row>
                            <br/>
                            <br />
                            <Col>
                                <Row>
                                    <Col span={12}><p>Mô tả:</p></Col>
                                    <Col span={12}><p>{shop.moTa}</p></Col>
                                </Row>
                                <Row>
                                    <Col span={12}><p>Đánh giá:</p></Col>
                                    <Col span={12}><p>{shop.danhGia}</p></Col>
                                </Row>
                                <Row>
                                    <Col span={12}><p>Số điện thoại:</p></Col>
                                    <Col span={12}><p>{shop.soDienThoai}</p></Col>
                                </Row>
                                <Row>
                                    <Col span={12}><p>Địa chỉ:</p></Col>
                                    <Col span={12}> <p>{shop.diaChi}</p></Col>
                                </Row>
                                <Row>
                                    <Col span={12}><p>Tình trạng:</p></Col>
                                    <Col span={12}> <p>{shop.tinhTrang ? 
                                        <Tag color="#87d068">Mở cửa</Tag> : 
                                        <Tag color="#f50">Đóng cửa</Tag>}</p>
                                    </Col>
                                </Row>
                            </Col>
                        </Card>
                    </Col>
                </Row>
            </Card>
        </div>
    )
}

export default Driver
