import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
import { Layout } from 'antd';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AppHeader from './components/Header/header';
import HomePage from './views/Homepage/homepage';
import SignUp from './views/SignUp/signUp';
import LogIn from './views/Login/login';
import Upload from './views/Upload/Upload.jsx';
import Driver from './views/Driver/Driver.jsx';
import Shipper from './views/Driver/Shipper/Shipper.jsx';
import SellRegister from './views/SellRegister/sellRegister';
import RegisterShipper from './views/Driver/RegisterShipper/RegisterShipper.jsx';
import GetOrder from './views/Driver/GetOrder/GetOrder';
import CartScreen from './views/Cart/CartScreen';
import ManageRegisterStore from './views/ManageRegisterStore/manageRegisterStore';
const { Header, Content, Footer } = Layout;
function App() {
	return (
		<Layout className="mainLayout">
			<Router>
				<Header>
					<AppHeader />
				</Header>
				<Content>
					<Routes>
						<Route path="/" element={<HomePage />} />
						<Route path="/login" element={<LogIn />} />
						<Route path="/signup" element={<SignUp />} />
						<Route path="/upload" element={<Upload />} />
						<Route path="/nearest_store" element={<Driver />} />
						<Route path="/nearest_shipper" element={<Shipper />} />
						<Route path="/sellregister" element={<SellRegister />} />
						<Route path="/register_driver" element={<RegisterShipper />} />
						<Route path="/get_order" element={<GetOrder />} />
						<Route path="/cart" element={<CartScreen />} />
						<Route path="/manage-register-shop" element={<ManageRegisterStore />}/>
					</Routes>
				</Content>
			</Router>
		</Layout>
	);
}

export default App;
