import React, { useState, useEffect } from 'react'
import axios from "axios";
import {Button,Card} from "antd"

const Delivered = () => {

    const showDelivered = () => {
        
    }

    return(
        <div>
            <Card 
                title="Đơn hàng đã giao" 
                extra={<Button onClick={showDelivered}>Đơn hàng đã giao</Button>}>

            </Card>
        </div>
    )
}

export default Delivered