import React from 'react';
import { Router, Route, Switch, Link, NavLink } from 'react-router-dom';
import createHistory from 'history/createBrowserHistory';
import DashboardPage from '../components/DashboardPage';
import AddRoomPage from '../components/AddRoomPage';
import AddUserPage from '../components/AddUserPage';
import RoomBookingPage from '../components/RoomBookingPage';
import RoomListPage from '../components/RoomListPage';
import ReservationListPage from '../components/ReservationListPage';
import UsersPage from '../components/UsersPage';
import Header from '../components/Header';
import SettingsPage from '../components/SettingsPage';
import NotFoundPage from '../components/NotFoundPage';
import LoginPage from '../components/LoginPage';
import PrivateRoute from './PrivateRoute';
import PublicRoute from './PublicRoute';

export const history = createHistory();

const AppRouter = () => (
  <Router history={history}>
    <div>
      <Switch>
        <PublicRoute path="/" component={LoginPage} exact={true} />
        <PrivateRoute path="/dashboard" component={DashboardPage} />
        <PrivateRoute path="/book" component={RoomBookingPage} />
        <PrivateRoute path="/rooms/list" component={RoomListPage} />
        <PrivateRoute path="/rooms/reservation" component={ReservationListPage} />
        <PrivateRoute path="/add-room" component={AddRoomPage} />
        <PrivateRoute path="/users" component={UsersPage} />
        <PrivateRoute path="/add-user" component={AddUserPage} />
        <PrivateRoute path="/settings" component={SettingsPage} />
        <PrivateRoute component={NotFoundPage} />
      </Switch>
    </div>
  </Router>
);

export default AppRouter;