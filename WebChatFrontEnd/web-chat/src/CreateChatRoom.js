import React from "react";
import { Link } from "react-router-dom";

const CreateChatRoom = ({ history, createChatRoom = f => f }) => {
  let _name, _description;

  const handleCreation = e => {
    e.preventDefault();

    createChatRoom(_name.value, _description.value);
  };
  return (
    <div id="main">
      <form id="login-form" action="" onSubmit={handleCreation} method="post">
        <h3 style={{ padding: 15 }}>Creation Form</h3>
        <input
          ref={input => (_name = input)}
          style={styles.input}
          autoComplete="off"
          id="name-input"
          name="name"
          type="text"
          className="center-block"
          placeholder="Name"
        />
        <input
          ref={input => (_description = input)}
          style={styles.input}
          autoComplete="off"
          id="description-input"
          name="description"
          type="text"
          className="center-block"
          placeholder="Description"
        />
    <button
          type="submit"
          style={styles.button}
          className="landing-page-btn center-block text-center"
          id="email-login-btn"
          href="#facebook"
        >
          Create
        </button>

        <Link style={styles.button} to="/">
          Cancel
        </Link>
      </form>
    </div>
  );
};
const styles = {
  input: {
    backgroundColor: "white",
    border: "1px solid #cccccc",
    padding: 15,
    float: "left",
    clear: "right",
    width: "80%",
    margin: 15
  },
  button: {
    height: 44,
    boxShadow: "0px 8px 15px rgba(0, 0, 0, 0.1)",
    border: "none",
    backgroundColor: "red",
    margin: 15,
    float: "left",
    clear: "both",
    width: "85%",
    color: "white",
    padding: 15
  },
  link: {
    width: "100%",
    float: "left",
    clear: "both",
    textAlign: "center"
  }
};

export default CreateChatRoom;
