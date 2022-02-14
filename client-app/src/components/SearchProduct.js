import React from 'react';
import { Input } from 'antd';
import { useNavigate } from 'react-router-dom';
const { Search } = Input;

export default function SearchProduct({ setKeyword }) {
  const navigate = useNavigate();
  const onSearch = (value) => {
    setKeyword(value);
    navigate(`/search?keyword=${value}`);
  };

  return (
    <div>
      <Search
        placeholder="Nhập sản phẩm cần tìm"
        style={{ width: 1080 }}
        onSearch={onSearch}
        enterButton
      />
    </div>
  );
}
