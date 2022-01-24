import React, { useEffect, useState } from 'react';
import SearchProduct from '../../components/SearchProduct';
import { Button, List, Select } from 'antd';
import { useSearchParams } from 'react-router-dom';
import ItemCard from '../../components/Item/ItemCard';
import axios from 'axios';

const { Option } = Select;

export default function ProductSearch({ location }) {
  let [searchParams, setSearchParams] = useSearchParams();
  const [keyword, setKeyword] = useState(searchParams.get('keyword'));
  const [category, setCategory] = useState(searchParams.get('category'));
  const [sortOrder, setSortOrder] = useState(searchParams.get('sortOrder'));

  const [productList, setProductList] = useState([]);

  useEffect(() => {
    getProducts();
  }, [searchParams]);
  console.log(keyword);
  console.log(category);

  const getProducts = async () => {
    const { data } = await axios.get(`https://localhost:5001/api/Product`, {
      params: {
        categoryId: category,
        searchString: keyword,
        sortOrder: sortOrder,
      },
    });

    setProductList(data);
  };

  function handleChange(value) {
    console.log(`selected ${value}`);
    setSortOrder(value);
    setSearchParams({
      sortOrder: value,
      keyword: keyword,
      categoryId: category,
    });
  }

  return (
    <div>
      <h1>{category}</h1>
      <h1>{keyword}</h1>
      <SearchProduct setKeyword={setKeyword} />

      <span>Giá</span>
      <Select defaultValue="" style={{ width: 150 }} onChange={handleChange}>
        <Option value="price_asc">Thấp đến cao</Option>
        <Option value="price_desc">Cao đến thấp</Option>
      </Select>
      <span>Ngày đăng</span>
      <Select defaultValue="" style={{ width: 150 }} onChange={handleChange}>
        <Option value="date_desc">Mới nhất xếp trước</Option>
        <Option value="date_asc">Cũ nhất xếp trước</Option>
      </Select>

      <List
        header={
          <div>
            <h1>Sản phẩm có thể bạn sẽ thích</h1>
          </div>
        }
        bordered={true}
        grid={{ gutter: 4, column: 5 }}
        pagination={{
          onChange: (page) => {
            console.log(page);
          },
          pageSize: 20,
        }}
        dataSource={productList}
        renderItem={(item) => (
          <List.Item>
            <ItemCard item={item} />
          </List.Item>
        )}
      />
    </div>
  );
}
