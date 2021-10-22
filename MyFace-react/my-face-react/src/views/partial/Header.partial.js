import react from 'react';
import {Link} from "react-router-dom";

export function Header(){
    return(
        <nav className="main-navbar">
            <ul>
                <li>
                    <Link to="/">Home</Link>
                </li>
                <li>
                    <Link to="/users">Users</Link>
                </li>
            </ul>
        </nav>
    )
}