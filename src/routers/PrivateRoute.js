import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import Header from '../components/Header';
import Nav from '../components/Nav';

export const PrivateRoute = ({
   component: Component,
   ...rest
}) => (
   <Route {...rest} component={(props) => (
         <div className="flex-wrapper">
            <Nav />
            <div className="content-wrapper">
                  <Header />
                  <Component {...props} />
            </div>
         </div>
      ) 
   } />
);


export default PrivateRoute;