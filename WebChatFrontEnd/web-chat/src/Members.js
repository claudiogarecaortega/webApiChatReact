import {Component} from "react";
import React from "react";

class Members extends Component {
  render() {
      
    const {members} = this.props;
    return (
      <ul className="Messages-list">
        {members.map(m => this.renderMessage(m))}
      </ul>
    );
  }

  renderMessage(message) {
    const {userName,aproved} = message;
    return (
      <li className="Messages-message currentMember">
     
        <div className="Message-content">
          <div className="username">
            {userName}
          </div>
          
        </div>
      </li>
    );
  }
}

export default Members;
