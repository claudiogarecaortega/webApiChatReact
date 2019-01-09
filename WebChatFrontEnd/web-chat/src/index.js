import React from "react";
import { render } from "react-dom";
import { BrowserRouter, Route, Switch, withRouter } from "react-router-dom";
import Home from "./Home";

import Login from "./Login";
import Register from "./Register";
import CreateChatRoom from "./CreateChatRoom";
import ChatRoom from "./chatroom";

import axios from "axios";
import $ from "jquery";
class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoggedIn: false,
      user: {},
      idchatRoom:0
    };
  }
  _loginUser = (email, password) => {
    $("#login-form button")
      .attr("disabled", "disabled")
      .html(
        '<i class="fa fa-spinner fa-spin fa-1x fa-fw"></i><span class="sr-only">Loading...</span>'
      );
    const config = { headers: { 'Content-Type': 'application/json' } };
    axios
      .post(
          "http://localhost:51036/api/authentication/login", 
          { Email: email, Password:password},
          config)
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
          alert("Login Successful!");
          const { name, id, email, jwtToken } = json.data;

          let userData = {
            name,
            id,
            email,
            jwtToken,
            timestamp: new Date().toString()
          };
          let appState = {
            isLoggedIn: true,
            user: userData
          };
          localStorage["appState"] = JSON.stringify(appState);
          this.setState({
            isLoggedIn: appState.isLoggedIn,
            user: appState.user
          });
        } else alert("Login Failed!");

        $("#login-form button")
          .removeAttr("disabled")
          .html("Login");
      })
      .catch(error => {
        alert(`An Error Occured! ${error} `);
        $("#login-form button")
          .removeAttr("disabled")
          .html("Login");
      });
  };

  _registerUser = (name, email, password) => {
    $("#email-login-btn")
      .attr("disabled", "disabled")
      .html(
        '<i class="fa fa-spinner fa-spin fa-1x fa-fw"></i><span class="sr-only">Loading...</span>'
      );

      axios
      .post("http://localhost:51036/api/account/Create", {Name:name,UserName:name,Password:password,Email:email})
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
       if (!json.data.jsonResult.hasError) {
          const { name, id, email, jwtToken } = json.data;
  
          alert(`Registration Successful!`);
         let userData = {
            name,
            id,
            email,
            jwtToken,
            timestamp: new Date().toString()
          };
          let appState = {
            isLoggedIn: true,
            user: userData
          };
          // save app state with user date in local storage
          localStorage["appState"] = JSON.stringify(appState);
          this.setState({
            isLoggedIn: appState.isLoggedIn,
            user: appState.user
          });
          // redirect home
          this.props.history.push("/");
        } else {
          alert(`Registration Failed!`);
          $("#email-login-btn")
            .removeAttr("disabled")
            .html("Register");
        }
      })
      .catch(error => {
        alert(`An Error Occured! ${error} `);
        $("#email-login-btn")
          .removeAttr("disabled")
          .html("Register");
      });
  };
  _createChatRoomAction = (name, Description) => {
    $("#email-login-btn")
      .attr("disabled", "disabled")
      .html(
        '<i class="fa fa-spinner fa-spin fa-1x fa-fw"></i><span class="sr-only">Loading...</span>'
      );

    const token=JSON.parse(localStorage["appState"]).user.jwtToken;
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/CreateChatRoom",  
      { Name: name, Description:Description})
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
          alert(`Registration Successful!`);
          this.props.history.push("/");
        } else {
          alert(`Registration Failed!`);
          $("#email-login-btn")
            .removeAttr("disabled")
            .html("Register");
        }
      })
      .catch(error => {
        alert(`An Error Occured! ${error}`);
                $("#email-login-btn")
          .removeAttr("disabled")
          .html("Register");
      });
  };

  _logoutUser = () => {
    let appState = {
      isLoggedIn: false,
      user: {}
    };
    // save app state with user date in local storage
    localStorage["appState"] = JSON.stringify(appState);
    this.setState(appState);
  };
  _askToJoin = (idchatRoom) => {
    const token=JSON.parse(localStorage["appState"]).user.jwtToken;
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/AskJoinParticipantToChatRoom",  
      { IdChatRoom: idchatRoom})
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
          alert(`Registration Successful!`);
          this.props.history.push("/");
        } else {
          
          alert("Registration Failed! "+json.data.jsonResult.errorMessage);
          $("#email-login-btn")
            .removeAttr("disabled")
            .html("Register");
        }
      })
      .catch(error => {
        alert(`An Error Occured! ${error}`);
                $("#email-login-btn")
          .removeAttr("disabled")
          .html("Register");
      });
  };
  _manageRoom = () => {
    let appState = {
      isLoggedIn: true,
      user: {}
    };
    // save app state with user date in local storage
    localStorage["appState"] = JSON.stringify(appState);
    this.setState(appState);
  };
  _createChatRoom = () => {
    this.props.history.push("/CreateChatroom");
  };
  _joinRoom = (idchatroom) => {
  this.setState({idchatRoom:idchatroom})
  this.props.history.push("/chatroom");
  };

  componentDidMount() {
    let state = localStorage["appState"];
    if (state) {
      let AppState = JSON.parse(state);
      console.log(AppState);
      this.setState({ isLoggedIn: AppState.isLoggedIn, user: AppState });
    }
  }

  render() {
    console.log(this.state.isLoggedIn);
    console.log("path name: " + this.props.location.pathname);
    if (
      !this.state.isLoggedIn &&
      this.props.location.pathname !== "/login" &&
      this.props.location.pathname !== "/register"
    ) {
      console.log(
        "you are not loggedin and are not visiting login or register, so go to login page"
      );
      this.props.history.push("/login");
    }
    if (
      this.state.isLoggedIn &&
      (this.props.location.pathname === "/login" ||
        this.props.location.pathname === "/register")
    ) {
      console.log(
        "you are either going to login or register but youre logged in"
      );

      this.props.history.push("/");
    }
    return (
      <Switch data="data">
        <div id="main">
          <Route
            exact
            path="/"
            render={props => (
              <Home
                {...props}
                logoutUser={this._logoutUser}
                askToJoin={this._askToJoin}
                manageRoom={this._manageRoom}
                createChatRoom={this._createChatRoom}
                joinRoom={this._joinRoom}
                user={this.state.user}
              />
            )}
          />

          <Route
            path="/login"
            render={props => <Login {...props} loginUser={this._loginUser} />}
          />
           <Route
            path="/createchatroom"
            render={props => <CreateChatRoom {...props} createChatRoom={this._createChatRoomAction} />}
          />

          <Route
            path="/register"
            render={props => (
              <Register {...props} registerUser={this._registerUser} />
            )}
          />
           <Route
            path="/chatroom"
            render={props => (
              <ChatRoom {...props} id={this.state.idchatRoom} />
            )}
          />
        </div>
      </Switch>
    );
  }
}

const AppContainer = withRouter(props => <App {...props} />);
// console.log(store.getState())
render(
  <BrowserRouter>
    <AppContainer />
  </BrowserRouter>,

  document.getElementById("root")
);
