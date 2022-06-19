import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import AuthorizeContextComponent from './AuthorizeContext';
import Layout from './Components/Layout';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Signup from './Pages/Signup';
import Logout from './Pages/Logout';
import PrivateRoute from './Components/PrivateRoute';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <AuthorizeContextComponent>
        <Layout>
          <PrivateRoute exact path='/' component={Home} />
          <Route exact path='/Login' component={Login} />
          <Route exact path='/Signup' component={Signup} />
          <Route exact path='/Logout' component={Logout} />   
        </Layout>
      </AuthorizeContextComponent>
    );
  }
}