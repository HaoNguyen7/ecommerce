import React from 'react'
import EditableTable from '../../components/Table/TableLayout'
import {Button} from 'antd';
import './index.css'
import {Link} from 'react-router-dom'
const Category = () => {
  return (
    <>
      <Button className='marginBottom' type="primary"><Link to="create">Tạo danh mục mới</Link></Button>
      <EditableTable />
    </>
  )
}

export default Category