import React, { Component } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import HomeIcon from '@material-ui/icons/Home';
import Typography from '@material-ui/core/Typography';
import { Link } from "react-router-dom";



class TopBar extends Component {

  render() {
    return (
      <div className="TopBar">
        <AppBar position="static">
          <Toolbar>
            <IconButton className="homeButton" color="inherit" aria-label="Home">
              <Link to="/"> <HomeIcon /> </Link>
            </IconButton>
            <Typography variant="title" color="inherit" className="flex">
              Bookshop
            </Typography>
          </Toolbar>
        </AppBar>
      </div>
    );
  }

}
export default TopBar;
