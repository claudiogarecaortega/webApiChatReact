import {Component} from "react";
import React from "react";

class Messages extends Component {
  render() {
    const {messages} = this.props;
    return (
      <ul className="Messages-list">
        {messages.map(m => this.renderMessage(m))}
      </ul>
    );
  }

  renderMessage(message) {
    const {userOwner,userOwnerId, textMessage,dateSend} = message;
    const {currentMember} = this.props;
    const messageFromMe = userOwnerId === currentMember;
    const className = messageFromMe ?
      "Messages-message currentMember" : "Messages-message";
    return (
      <li className={className}>
      <span
        className="avatar"
        style={{backgroundColor: 'gray'}}
      />
        <div className="Message-content">
          <div className="username">
            {userOwner}
          </div>
          <div className="text">{textMessage}</div>
          <div className="text-date">{dateSend}</div>
        </div>
      </li>
    );
  }
}

export default Messages;
