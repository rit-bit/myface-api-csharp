import './css/App.scss';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect
} from "react-router-dom";
import {UserView} from "./views/User.view";
import {Footer} from "./views/Footer.partial";

function App() {
  return (
    <Router>
      <div>
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

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch >
        <Redirect exact from="/" to="posts" />
          <Route path="/posts">
            <div>Test</div>
          </Route>
          <Route path="/users">
            <UserView/>
          </Route>
        </Switch>
      </div>
      <Footer/>
    </Router>
  );
}

export default App;
