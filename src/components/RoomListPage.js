import React from 'react';
import { Link } from 'react-router-dom';
const RoomListPage = () => (
   <div>
      <h1>Lista sal</h1>
      <Link to="/rooms/reservation">V1</Link>
      <Link to="/rooms/list"> V2</Link>
   </div>
);

export default RoomListPage;