import React from "react";
import './App.css';
import "antd/dist/antd.css"
import { Layout } from "antd";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AppHeader from './components/Header/header';
import HomePage from "./views/Homepage/homepage";
import SignUp from "./views/SignUp/signUp"
import LogIn from "./views/Login/login";
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
            <Route path="/" element={<HomePage/>} />
            <Route path="/login" element={<LogIn/>} />
            <Route path="/signup" element={<SignUp/>}/>
          </Routes>
        </Content>
      </Router>
    </Layout>
  );
}

export default App;
