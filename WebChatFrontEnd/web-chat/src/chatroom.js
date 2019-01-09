import React from "react";
import axios from "axios";
import Messages from "./Messages";
import Members from "./Members";
import Input from "./Input";
import './chatroom.css';
import { Link } from "react-router-dom";
export default class ChatRoom extends React.Component {
  constructor(props) {
    super(props);
    
    this.state = {
      token: JSON.parse(localStorage["appState"]).user.jwtToken,
      userId:JSON.parse(localStorage["appState"]).user.id,
      messages: [],
      members : [],
      idChatRoom:props.id,
      member:"",
      chatRoomName:"",
      currentMemberId:0
    };
  }
  onSendMessage = () => {
    const token=this.state.token;
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/GetSendTextMessageChatRoom",{IdChatRoom:this.state.idChatRoom}
      )
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
                    this.setState({chatRoomName:json.data.name, currentMemberId:json.data.id, messages: json.data.chatRoomMessages });
        } else 
        {
          alert("Login Failed!");
          this.props.history.push("/");
        }
      })
      .catch(error => {
        debugger
          alert(`An Error Occured! ${error} `);
          this.props.history.push("/");
            
      });
  }
  componentDidMount() {
    const token=this.state.token;
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/GetSendTextMessageChatRoom",{IdChatRoom:this.state.idChatRoom}
      )
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
      
        this.setState({chatRoomName:json.data.name, members:json.data.participant,currentMemberId:json.data, messages: json.data.chatRoomMessages });
                  
        } 
        else{
          alert(`An Error Occured! ${json.data.jsonResult.errorMessage}`);
          this.props.history.push("/");
        }
      })
      .catch(error => {
        alert(`An Error Occured! ${error} `);
        this.props.history.push("/");
      });
  }

  render() {
    return (
      <div className="AppMessage">
        <div className="App-header-message">
          <h1>{this.state.chatRoomName}</h1>
        </div>
        <div>
        <div>
          <h4>Members</h4>
        </div>
        <Members
          members={this.state.members}
        
        />
        </div>
        
        <Messages
          messages={this.state.messages}
          currentMember={this.state.currentMemberId}
        />
        <Input
          onSendMessage={this.onSendMessage}
          idChatRoom={this.state.idChatRoom}
        />
         <Link  to="/">
          Back
        </Link>
        </div>
    );
  }
}