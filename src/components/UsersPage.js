import React from 'react';
import { Link } from 'react-router-dom';

const UsersPage = () => (
   <div>
      <h1>UsersPage</h1>
      <Link to="/add-user">Dodaj użytkownika</Link>
   </div>
);

export default UsersPage;