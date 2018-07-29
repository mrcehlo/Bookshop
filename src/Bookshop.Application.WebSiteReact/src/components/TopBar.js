import React, { Component } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import HomeIcon from '@material-ui/icons/Home';
import Typography from '@material-ui/core/Typography';
import './TopBar.css';



class TopBar extends Component {

  handleHome = event => {
        this.props.history.push("/");
   }

  render() {
    return (
      <div className="TopBar extendedTopBar">
        <AppBar position="fixed">
          <Toolbar>
            <IconButton  onClick={this.handleHome} className="homeButton" color="inherit" aria-label="Home">
              <HomeIcon />
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
