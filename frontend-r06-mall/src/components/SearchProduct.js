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
        placeholder="input search text"
        style={{ width: 500 }}
        onSearch={onSearch}
        enterButton
      />
    </div>
  );
}
