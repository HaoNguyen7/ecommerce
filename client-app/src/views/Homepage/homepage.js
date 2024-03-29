import React, { useEffect, useState } from 'react';
import { Carousel, Button, Card, List, Layout, Input } from 'antd';
import axios from 'axios';
import SearchProduct from '../../components/SearchProduct';
import ItemCard from '../../components/Item/ItemCard';
const { Search } = Input;
const { Content } = Layout;
const { Meta } = Card;

function HomePage() {
  const [keyword, setKeyword] = useState('');
  const [categories, setCategories] = useState([]);
  const [products, setProducts] = useState([]);
  useEffect(() => {
    const getCategories = async () => {
      const res = await axios.get(
        'https://localhost:5001/api/Product/categories'
      );
      const { data } = res;
      setCategories(data);
    };

    const getProducts = async () => {
      const productRes = await axios.get('https://localhost:5001/api/Product');
      const { data: productList } = productRes;
      console.log(productList);
      setProducts(productList);
    };

    getCategories();
    getProducts();
  }, []);

  console.log(categories);

  const contentStyle = {
    height: '360px',
    width: '100%',
    color: '#fff',
    lineHeight: '360px',
    textAlign: 'center',
    'background-image':
      'url("https://salt.tikicdn.com/cache/w1080/ts/banner/e7/9f/00/ca66add76f71afc0a73f06b82ff1980b.jpg.webp")',
  };

  function onChange(a, b, c) {
    console.log(a, b, c);
  }

  return (
    <div>
      {/* {console.log(categories)} */}
      <div style={{ width: 1080, margin: 'auto' }}>
        <SearchProduct setKeyword={setKeyword} />

        <Carousel afterChange={onChange}>
          <div>
            <h3 style={contentStyle}>1</h3>
          </div>
          <div>
            <h3 style={contentStyle}>2</h3>
          </div>
          <div>
            <h3 style={contentStyle}>3</h3>
          </div>
          <div>
            <h3 style={contentStyle}>4</h3>
          </div>
        </Carousel>
      </div>
      <Content
        className="site-layout"
        style={{
          padding: '0 50px',
          marginTop: 64,
        }}
      >
        <List
          grid={{
            gutter: 16,
            xs: 1,
            sm: 2,
            md: 4,
            lg: 4,
            xl: 8,
            xxl: 3,
          }}
          bordered={true}
          header={<h1>Danh mục sản phẩm</h1>}
          dataSource={categories}
          renderItem={(item) => (
            <List.Item>
              {/* <Card>Category</Card> */}
              <Button
                size="large"
                style={{ width: 150 }}
                href={`/search?category=${item.loaiId}`}
              >
                {item.ten}
              </Button>
            </List.Item>
          )}
        />
      </Content>

      <Content
        className="site-layout"
        style={{
          padding: '0 50px',
          marginTop: 64,
          width: '100%',
          justifyContent: 'center',
        }}
      >
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
              console.log(categories);
            },
            pageSize: 20,
          }}
          dataSource={products}
          footer={
            <div>
              <Button>View more</Button>
            </div>
          }
          renderItem={(item) => (
            <List.Item>
              <ItemCard item={item} />
            </List.Item>
          )}
        />
      </Content>
    </div>
  );
}

export default HomePage;
