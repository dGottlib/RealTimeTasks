import React from 'react';
import { UseAuthorizeDataContext } from '../AuthorizeContext';
import Login from '../Pages/Login';
import { Route } from 'react-router-dom';

const PrivateRoute = ({ component, ...options }) => {
    const { user } = UseAuthorizeDataContext();
    const finalComponent = !!user ? component : Login;
    return <Route {...options} component={finalComponent} />;
};

export default PrivateRoute;