import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import Header from '../components/Header';

export const PublicRoute = ({
   component: Component,
   ...rest
}) => (
   <Route {...rest} component={(props) => (
         <div>
            <Component {...props} />
         </div>
      ) 
   } />
);


export default PublicRoute;