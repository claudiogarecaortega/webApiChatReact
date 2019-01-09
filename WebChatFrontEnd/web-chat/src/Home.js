import React from "react";
import axios from "axios";

const styles = {
  fontFamily: "sans-serif",
  textAlign: "center"
};

export default class Home extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = {
      token: JSON.parse(localStorage["appState"]).user.jwtToken,
      userId:JSON.parse(localStorage["appState"]).user.id,
      chatRooms: [],
      idChatRoom:0
    };
  }
  openChatRoom(idChatRoom)
  {
    this.setState({idChatRoom:idChatRoom});
    this.props.joinRoom( idChatRoom);
  }

  componentDidMount() {
    const token=this.state.token;
    const config = { headers: { 
     } 
    };
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/GetChatRooms",{},
      config)
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
         if (!json.data.jsonResult.hasError) {
          this.setState({ chatRooms: json.data.chatRooms });
        } 
        else alert("Login Failed!");
      })
      .catch(error => {
        alert(`An Error Occured! ${error}`);
      });
  }

  render() {
    return (
      <div style={styles}>
        <h2>Welcome Home {"\u2728"}</h2>
        <p>List of all chat Rooms on the system</p>
        <ul>
        {this.state.chatRooms.map(user => 
        <ol style={{padding:15,border:"1px solid #cccccc", width:250, textAlign:"left",marginBottom:15,marginLeft:"auto", marginRight:"auto"}}>
        <p>Name: {user.name}</p>
        <p>Description: {user.description}</p>
        <button
          style={{ padding: 10, backgroundColor: "green", color: "white" }}
          onClick={this.props.askToJoin.bind(this, user.id)}>
          Ask to Join{" "}
        </button>
        <button
          style={{ padding: 10, backgroundColor: "blue", color: "white" }}
          onClick={this.props.manageRoom}>
          Mannage{" "}
        </button>
        <button
          style={{ padding: 10, backgroundColor: "gray", color: "white" }}
          onClick={this.openChatRoom.bind(this,user.id)}>
          Join{" "}
        </button>
        </ol>)}
        </ul>
        <button
          style={{ padding: 10, backgroundColor: "red", color: "white" }}
          onClick={this.props.logoutUser}>
          Logout{" "}
        </button>
        <button
          style={{ padding: 10, backgroundColor: "red", color: "white" }}
          onClick={this.props.createChatRoom}
        >
          Crear Chat Room{" "}
        </button>

      </div>
    );
  }
}