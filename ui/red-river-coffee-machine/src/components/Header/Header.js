import React from "react";
import logo from "./logo.svg";
import { Image } from "@chakra-ui/react";

const Header = () => {
  return (
    <header style={headerStyle}>
      <div>
        <Image boxSize="50px" objectFit="cover" src={logo} alt="logo" />
      </div>
      <div>Red River Coffee Machine</div>
    </header>
  )
}

const headerStyle = {
  backgroundColor: "#ADF8F8",
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  padding: "15px 20px",
};

export default Header;
