import React, { useState } from 'react'
import { Button, Card, Row, Col, Avatar } from "antd"
import axios from 'axios'
import moment from 'moment'
import { UserOutlined } from '@ant-design/icons';

const Shipper = () => {
    const style = { padding: '8px 0' };
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
                    console.log(res.data)
                })
                .catch((error) => {
                    console.error(error);
                })
        });
    }
    return (
        <div>
            <Card title="Tài xế gần nhất" extra={<Button onClick={findShortestShipper}>Tìm tài xế gần nhất</Button>}>
                <Row>
                    <Col span={12} offset={8}>
                        <Card
                        title={`Tài xế ${driver.tenNguoiGiaoHang}`}
                        extra={<a href="#">More</a>}
                        style={{ width: 500 }} // background: state ? "gray" : "transparent" }}
                        hoverable={true}>
                            <Row>
                            <Col span={12} offset={8}>
                                <Avatar shape="circle" size={128} icon={<UserOutlined />} />
                            </Col>
                            </Row>
                            <br/>
                            <br />
                            <Row>
                                <Col style={style} span={12}>
                                <div style={style}>
                                    <p>Địa chỉ:</p>
                                    <p>Vùng hoạt động:</p>
                                    <p>Số điện thoại:</p>
                                    <p>Ngày đăng ký:</p>
                                </div>
                                </Col>
                                <Col style={style} span={12}>
                                <div style={style}>
                                    <p>{driver.diaChi}</p>
                                    <p>{driver.vungHoatDong}</p>
                                    <p>{driver.soDienThoai}</p>
                                    <p>{moment(driver.ngayDangKy).format('YYYY MM DD')}</p>
                                </div>
                                </Col>
                            </Row>
                        </Card>
                    </Col>
                </Row>
            </Card>
        </div>
    )
}

export default Shipper
