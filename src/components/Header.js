import React from 'react';
import { Link } from 'react-router-dom'; 

export const Header = () => (
  <div className="header-wrapper">
    <header>
      <div>
        <Link to="/">Logout</Link>
      </div>
    </header>
  </div>
);
export default Header;