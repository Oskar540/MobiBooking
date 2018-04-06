import React from 'react';
import { Link } from 'react-router-dom';

export const LoginPage = () => (
  <div>
    <div>
      <h1>mobiBooking</h1>
      <p>Tag line for app.</p>
      <form onSubmit="">
        <input type="text" placeholder="podaj login" />
        <input type="text" placeholder="podaj hasło" />
        <Link to="/dashboard">Zaloguj</Link>
      </form>
    </div>
  </div>
);

export default LoginPage;