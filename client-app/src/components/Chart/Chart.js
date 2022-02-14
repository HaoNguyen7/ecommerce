import React, {useState, useEffect} from 'react'
import { BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';


const Chart = ({data}) => {
    return(
        <BarChart
                    width={500}
                    height={300}
                    data={data}
                    margin={{
                        top: 5,
                        right: 30,
                        left: 20,
                        bottom: 5,
                    }}
                    >
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="tenSanPham" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="soLuong" fill="#8884d8" />
                </BarChart>
    )
}

export default Chart