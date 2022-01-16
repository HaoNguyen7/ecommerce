import React from 'react';
import { Card, Button } from 'antd';
import './storeInforCard.css';
import axios from "axios";
function StoreInfoCard({storeInfor, removeItem}) {  

  const onClickActive = async ()=>{
    
    await axios({
      method: "POST",
      url: "https://localhost:5001/Accounts/grant-role-cuahang",
      data: {
        id: storeInfor.userId,
			},
    }).then(() => {
    }).catch((err) => console.log(err))
    
    console.log(storeInfor.cuaHangId)
    await axios({
      method: "PUT",
      url: "https://localhost:5001/Store/active-store",
      data: {
        id: storeInfor.cuaHangId,
      },
    }).then( () => {
      alert("Kích hoạt thành công cửa hàng ", storeInfor.tenCuaHang);
      removeItem(storeInfor.cuaHangId)
    }).catch((err) => console.log(err))
  }
  return (
    <div>
      <Card title={storeInfor.tenCuaHang} extra={<Button type="primary" onClick={onClickActive}>Active</Button>} className='card-store'>
      <p><strong>Mã số thuế:</strong> {storeInfor.maSoThue}</p>
      <p><strong>Địa chỉ:</strong> {storeInfor.diaChi}</p>
      <p><strong>Chủ cửa hàng:</strong> {storeInfor.userId}</p>
    </Card>
    </div>
  );
}

export default StoreInfoCard;