import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"

const Delivered = () => {
    const [deliveredItems, setDeliveredItems] = useState([])
    const [pageIndex, setPageIndex] = useState(0)
    const [totalPage, setTotalPage] = useState(0)

    const getDeliveredItems = () => {
        axios.get("https://localhost:5001/api/Delivered/history")
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

    useEffect(()=>{
        getDeliveredItems()
    }, [deliveredItems])

    return(
        <div>
            <Card title="Đơn hàng đã giao">
                <div className='delivered-list'>
                    {deliveredItems.map((item)=>{
                        const {} = item
                        return(
                            <h3>Delivered Item</h3>
                        )
                    })}
                </div>
            </Card>
        </div>
    )
}

export default Delivered