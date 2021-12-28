import React, { useState } from 'react';

import { Menu, Button } from 'antd';
import { HomeOutlined } from '@ant-design/icons';
const { SubMenu } = Menu;

function HomePage() {
  const [current, setCurrent] = useState("main");

  const handleClick = e => {
    console.log('click ', e);
    setCurrent(e.key);
  };

  return (
    <div >
     HomePage
    </div>
  );
}

export default HomePage;