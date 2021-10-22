import './css/App.scss';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect,
} from "react-router-dom";
import {UserView} from "./views/User.view";
import {Footer} from "./views/partial/Footer.partial";
import {Header} from "./views/partial/Header.partial";

function App() {
  return (
    <Router>
      <div>
        <Header/>
        <Switch >
        <Redirect exact from="/" to="home" />
          <Route path="/home">
            <UserView/>
          </Route>
        </Switch>
        <Footer/>
      </div>
    </Router>
  );
}

export default App;
