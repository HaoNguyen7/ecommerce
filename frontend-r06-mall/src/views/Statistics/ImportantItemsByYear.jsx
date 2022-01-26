import React, { useState, useEffect } from 'react'
import Chart from '../../components/Chart/Chart'
import { Button, Card, Row, Col, Avatar } from "antd"
import { Link } from 'react-router-dom'
import axios from 'axios'
import { UserOutlined } from '@ant-design/icons';


const ImportantItems = () => {
    const [items, setItems] = useState([])
    const [year, setYear] = useState()

    const getImportantItems = () => {
        axios({
            method: 'get',
            url: `http://localhost:8080/importantItemsByYear/${year}`
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
    }, [year])

    return(
        <div>
            <Card title='Thống kê các mặt hàng thiết yếu'>
                <input 
                    type="text" 
                    placeholder='Nhập năm bạn muốn thống kê...' 
                    onChange={(e)=>{setYear(e.target.value)}}
                    style={{width: '250px'}}
                />
                <h2>Top 10 mặt hàng được mua nhiều nhất trong năm {year}</h2>
                <Chart data={items}/>
                <Link to='/'>Quay lại mua sắm...</Link>
            </Card>
        </div>
    )
}

export default ImportantItems