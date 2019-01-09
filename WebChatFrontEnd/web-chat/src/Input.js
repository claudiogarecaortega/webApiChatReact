import {Component} from "react";
import React from "react";
import axios from "axios";
class Input extends Component {
  constructor(props) {
    super(props);
    
    this.state = {
      token: JSON.parse(localStorage["appState"]).user.jwtToken,
    userId:JSON.parse(localStorage["appState"]).user.id,
    text: "",
      idChatRoom:props.idChatRoom
    
    };
  }
  
 

  onChange(e) {
    this.setState({text: e.target.value});
  }

  onSubmit(e) {
    e.preventDefault();
    
    const token=this.state.token;
    axios.defaults.headers.common['Authorization'] = token;
    axios
      .post("http://localhost:51036/api/chatroom/SendTextMessageToChatRoom",
      {TextMessage:this.state.text,IdChatRoom:this.state.idChatRoom})
      .then(response => {
        console.log(response);
        return response;
      })
      .then(json => {
        if (!json.data.jsonResult.hasError) {
          this.setState({text: ""});
          this.props.onSendMessage();
        } 
        else alert("Login Failed!");
      })
      .catch(error => {
        alert(`An Error Occured! ${error}`);
      });
  }

  render() {
    return (
      <div className="Input">
        <form onSubmit={e => this.onSubmit(e)}>
          <input
            onChange={e => this.onChange(e)}
            value={this.state.text}
            type="text"
            placeholder="Enter your message and press ENTER"
            autofocus="true"
          />
          <button>Send</button>
        </form>
      </div>
    );
  }
}

export default Input;
