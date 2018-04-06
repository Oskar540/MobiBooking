import React from 'react';
import { Link } from 'react-router-dom';
export const Nav = () => (
   <nav>
      <div>mobiBooking</div>
      <ul>
         <li>
            <Link to="/dashboard">Dashboard</Link>
         </li>
         <li>
            <ul>Rezerwacja sali
               <li>
                  <Link to="/book">Zarezerwuj salę</Link>
               </li>
               <li>
                  <Link to="/rooms/reservation">Lista sal/rezerwacje</Link>
               </li>
               <li>
                  <Link to="/add-room">Dodaj salę</Link>
               </li>
            </ul>
         </li>
         <li>
            <Link to="/users">Użytkownicy</Link>
         </li>
         <li>
            <Link to="/settings">Ustawienia</Link>
         </li>
      </ul>
   </nav>
);
export default Nav;