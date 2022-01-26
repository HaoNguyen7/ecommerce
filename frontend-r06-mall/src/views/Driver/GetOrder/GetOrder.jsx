import React, {useState,useEffect} from 'react'
import axios from 'axios'
import {Card, Button, Table, Row, Col,Typography, Input, Tag, Alert} from 'antd'
import {useSelector} from 'react-redux'
import moment from 'moment'
import './GetOrder.css'
const GetOrder = () => {
    const { Text } = Typography;
    const {TextArea} = Input;
    const userSignin = useSelector((state) => state.userSignin);
    const [order,setOrder] = useState()
    const [orderDetail,setOrderDetail] = useState([])
    const [note,setNote]=useState()
    const [customer,setCustomer] = useState()
    const [isAccept,setIsAccpet] = useState(false)
    const [message,setMessage] = useState()
    const [isSuccess,setIsSuccess] = useState(false);
    const columns = [
        {
          title: 'Tên sản phẩm',
          dataIndex: 'sanPham',
          key: 'sanPham',
          render: sanPham => <a>{sanPham.tenSanPham}</a>,
        },
        {
          title: 'Số lượng',
          dataIndex: 'soLuong',
          key: 'soLuong',
        },
        {
          title: 'Đơn vị',
          dataIndex: 'sanPham',
          key: 'sanPham',
          render: sanPham => <p>{sanPham.donVi}</p>,
        },
        {
          title: 'Đơn giá',
          dataIndex: 'sanPham',
          key: 'sanPham',
          render: sanPham => <p>{sanPham.donGia.toLocaleString('it-IT', {style : 'currency', currency : 'VND'})}</p>,
        },
        {
          title: 'Thành tiền',
          dataIndex:['sanPham','donGia'],
          key: 'soLuong',
          render: (text,record) => <p>{(text * record.soLuong).toLocaleString('it-IT', {style : 'currency', currency : 'VND'})}</p>,
        },
      ];

    const onClick = () => {
        const body = {
            "tenTinhTrang":"Thành công",
            "donHangId":order.donHangId,
            "ghiChu": note,
            "ngayThucHien":`${moment().format('YYYY-MM-DD')}`
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
            setMessage("Hoàn tất đơn hàng!")
            setIsSuccess(true)
            console.log(res.data)
        })
        .catch((error) => {
            console.error(error);
        }) 
      };
      useEffect(() => {
        console.log('useEffect has been called!');
        const params = {id: `${userSignin.userInfo.id}` ,tinhtrang:0}

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
            axios({
                method: 'get',
                url: `https://localhost:5001/api/Order/view/driver/${res.data.donHangId}`,
                headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`},
            }).then(response =>{
                setOrderDetail(response.data);
            }).catch((error)=> {
                console.log(error)
            })
            axios({
              method: 'get',
              url: `https://localhost:5001/customer/${res.data.khachHangId}`,
              headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`},
              }).then(response =>{
                  setCustomer(response.data);
              }).catch((error)=> {
                  console.log(error)
              })
        })
        .catch((error) => {
            console.error(error);
        }) 
      }, []);

      const onInputChange = (e) =>{
        setNote(e.target.value)
      }

      const onAccpet = () => {
        setIsAccpet(true)
      }
    return (
        <div>
            <Card title="Tiếp nhận đơn hàng">
            
              <Row>
                <Col span={12} offset={8}>
                  <Card
                  title={`Mã đơn hàng: ${order?.donHangId}`}
                  extra={<a href="#">More</a>}
                  style={{ width: 600 }} 
                  hoverable={true}
                  >
                    <Row>
                      <Col span={12}>
                        <Row>
                          <Col>Ngày: &ensp;</Col>
                          <Col> {order?.thoiGian}</Col>
                        </Row>
                        <Row>
                          <Col>Tên khách hàng: &ensp;</Col>
                          <Col> {customer?.tenKhachHang}</Col>
                        </Row>
                      </Col>
                      <Col span={12}>
                        <Row>
                          <Col>Tình trạng thanh toán: &ensp;</Col>
                          <Col> {order?.tinhTrangThanhToan ? 
                            <Tag color="#87d068">Đã thanh toán</Tag> : 
                            <Tag color="#f50">Chưa thanh toán</Tag>}</Col>
                        </Row>
                        <Row>
                          <Col>Số điện thoại: &ensp;</Col>
                          <Col> {customer?.soDienThoai}</Col>
                        </Row>
                      </Col>
                      <Row>
                          <Col>Địa chỉ: &ensp;</Col>
                          <Col> {order?.diaChi}</Col>
                        </Row>
                    </Row>
                    <br />
                  {isAccept && <><Table columns={columns} dataSource={orderDetail} 
                      summary={pageData => {
                        let total = 0;
                
                        pageData.forEach(({ soLuong, sanPham}) => {
                          total += soLuong * sanPham.donGia;
                        });
                        return(<>
                        <Table.Summary.Row>
                        <Table.Summary.Cell>Tổng cộng</Table.Summary.Cell>
                        <Table.Summary.Cell />
                        <Table.Summary.Cell />
                        <Table.Summary.Cell />
                        <Table.Summary.Cell>
                          <Text>{total.toLocaleString('it-IT', {style : 'currency', currency : 'VND'})}</Text>
                        </Table.Summary.Cell>
                    </Table.Summary.Row></>)}}/> 
                    <p>Ghi chú</p>   
                    <TextArea onChange={onInputChange} rows={4} />
                    <Button onClick={onClick} block className='success-btn'>Hoàn tất đơn hàng</Button>
                    </>}    
                    {!isAccept && <Button block className='success-btn' onClick={onAccpet}>Chấp nhận</Button>}
                  </Card>
                </Col>
              </Row>
              {isSuccess && <Alert message={message} type="success" showIcon />}
            </Card>
        </div>
    )
}

export default GetOrder
