import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"
import "./Delivered.css"

const Delivered = () => {
    const [deliveredItems, setDeliveredItems] = useState([])
    const [pageIndex, setPageIndex] = useState(0)
    const [totalPage, setTotalPage] = useState(0)

    const getDeliveredItems = () => {
        axios({
            method: 'get',
            url: `https://localhost:5001/api/Delivered/history`,
            headers: { 'Authorization':`Bearer ${localStorage.getItem('token')}`}
        })
        .then(res=>{
            const result = res.data
            setDeliveredItems(result.data)
            setPageIndex(result.pageIndex)
            setTotalPage(result.totalPage)
        })
        .catch((error)=>{
            console.log(error)
        })
    }

    const showMore = () =>{

    }

    useEffect(()=>{
        getDeliveredItems()
    }, [])

    return(
        <div>
            <Card title="Đơn hàng đã giao">
                <div className='delivered-list'>
                    {deliveredItems.map((item)=>{
                        const {} = item
                        return(
                            <div className='delivered-item'>
                                <h3>Đơn hàng đã vận chuyển</h3>
                            </div>
                        )
                    })}
                </div>
                <a 
                    className='show-more-btn'
                    onClick={showMore()}
                >
                    Xem thêm...
                </a>
            </Card>
        </div>
    )
}

export default Delivered