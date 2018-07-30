import React, {Component} from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

class ResponsiveDialog extends Component {
  state = {
    open: false,
    messages: []
  };

  showDialog (messages){
    this.setState({open: true, messages});
  }

  handleClose = () => {
    this.setState({ open: false })
  };

  handleMessage(messages){
      return (
        <ul>
          {messages.map((msg, i) =>
              <li>{msg.message}</li>
            )}
        </ul>
      );
  }

  render() {

    return (
      <div>
        <Dialog
          open={this.state.open}
          onClose={this.handleClose}
          aria-labelledby="responsive-dialog-title"
        >
          <DialogTitle id="responsive-dialog-title">{"Error"}</DialogTitle>
          <DialogContent>
            <DialogContentText>
              {this.handleMessage(this.state.messages)}
            </DialogContentText>
          </DialogContent>
          <DialogActions>
            <Button onClick={this.handleClose} color="primary">
              Close
            </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}

export default ResponsiveDialog;
