import React, { useState, useEffect } from 'react';
import axios from 'axios';
import StoreInfoCard from "../../components/StoreInfoCard/storeInforCard"
import "./manageRegisterStore.css"
function ManageRegisterStore() {
  var [listStore, setListStore] = useState([])
  useEffect(() => {
    axios({
      method: "GET",
      url: "https://localhost:5001/Store/get-inactive-store",
      headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}` },
    }).then((res) => {
      listStore = res.data.data;
      setListStore(res.data.data)
      console.log(listStore)
    }).catch((err) => console.log(err))
  }, []);
  
  let removeItem = (id) => {
    listStore = listStore.filter(value => value.cuaHangId !== id)
    setListStore(listStore)
  }
  return (
    <div className='manage-register-screen'>
      {listStore.map((store, i) => <StoreInfoCard storeInfor={store} key={store.cuaHangId}  removeItem={removeItem}/>)}
    </div>
  );
}

export default ManageRegisterStore;