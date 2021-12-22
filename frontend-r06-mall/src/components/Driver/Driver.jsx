import React, { useState, useEffect } from 'react'
import axios from "axios";

export const Driver = () => {
   
    const findShortestShop = () => {
        navigator.geolocation.getCurrentPosition((position) => {
            console.log("Latitude is :", position.coords.latitude);
            console.log("Longitude is :", position.coords.longitude);
            const params = {ViDo: position.coords.latitude, KinhDo:position.coords.longitude}
            axios({
                method: 'get',
                url: `https://localhost:44391/Driver`,
                headers: { 'Content-Type': 'application/json', },
                params: params
            })
            .then(res => {
                window.open(`https://www.google.com/maps/dir/'${position.coords.latitude},${position.coords.longitude}'/${res.data.tenCuaHang}`);
                console.log(res)
            })
            .catch((error) => {
                console.error(error);
            })  
        });
    }
    return (
        <div>
            <button onClick={findShortestShop}>Find Shortest Shop</button>
        </div>
    )
}
