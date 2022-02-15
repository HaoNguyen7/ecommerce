import React, {useState} from 'react'
import { Layout, Menu, Breadcrumb } from 'antd';
import 'antd/dist/antd.css';
import {
  DesktopOutlined,
  PieChartOutlined,
  BarsOutlined,
  TeamOutlined,
  UserOutlined,
} from '@ant-design/icons';
import { Link, Outlet } from 'react-router-dom';
const { Header, Content, Footer, Sider } = Layout;
const { SubMenu } = Menu;
const Dashboard = () => {
  const [collapsed,setCollapsed] = useState(false)

  const onCollapse = collapsed => {
    console.log(collapsed);
    setCollapsed(collapsed);
  };
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Sider collapsible collapsed={collapsed} onCollapse={onCollapse}>
        <div className="logo" />
        <nav>
          <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
            <Menu.Item key="1" icon={<PieChartOutlined />}>
              Home
              <Link to="/"/>
            </Menu.Item>
            <Menu.Item key="2" icon={<DesktopOutlined />}>
              <Link to="product"/>
              Product
            </Menu.Item>
            <SubMenu key="sub1" icon={<UserOutlined />} title="User">
              
              <Menu.Item key="3"><Link to="user/tom" >Tom</Link></Menu.Item>
              <Menu.Item key="4">Bill</Menu.Item>
              <Menu.Item key="5">Alex</Menu.Item>
            </SubMenu>
            <SubMenu key="sub2" icon={<TeamOutlined />} title="Team">
              <Menu.Item key="6">Team 1</Menu.Item>
              <Menu.Item key="8">Team 2</Menu.Item>
            </SubMenu>
            <Menu.Item key="9" icon={<BarsOutlined />}>
              <Link to="category">
                Category              
              </Link>
            </Menu.Item>
            <Menu.Item key="10" icon={<BarsOutlined />}>
              <Link to="customer">
                Customer              
              </Link>
            </Menu.Item>
            <Menu.Item key="11" icon={<BarsOutlined />}>
              <Link to="order">
                Order              
              </Link>
            </Menu.Item>
          </Menu>
        </nav>
      </Sider>
      <Layout className="site-layout">
        <Header className="site-layout-background" style={{ padding: 0 }} />
        <Content style={{ margin: '0 16px' }}>
          <Breadcrumb style={{ margin: '16px 0' }}>
            <Breadcrumb.Item>User</Breadcrumb.Item>
            <Breadcrumb.Item>Bill</Breadcrumb.Item>
          </Breadcrumb>
          <div className="site-layout-background" style={{ padding: 24, minHeight: 360 }}>
          <Outlet />
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>General Store 2022</Footer>
      </Layout>
    </Layout>
  )
}

export default Dashboard