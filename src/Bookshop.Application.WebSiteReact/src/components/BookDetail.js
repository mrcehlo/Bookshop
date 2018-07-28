import React, {Component} from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import {getSingleBook} from '../libs/BookshopAPI';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import Icon from '@material-ui/core/Icon';

const styles = theme => ({
  container: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  textField: {
    marginLeft: theme.spacing.unit,
    marginRight: theme.spacing.unit,
    width: 200,
     height: "50%",
  },
  menu: {
    width: 200,
  },
  button: {
    margin: theme.spacing.unit,
  },
  leftIcon: {
    marginRight: theme.spacing.unit,
  },
  rightIcon: {
    marginLeft: theme.spacing.unit,
  },
  iconSmall: {
    fontSize: 20,
  },
});

class BookDetail extends Component {
  constructor(props) {
    super(props);

    this.state = {isLoading: true, ...props};

  }

  getCurrentBook(isbn){
    return getSingleBook(isbn);
  }

  handleChange(event) {
   this.setState({[event.target.id]: event.target.value});
 }

  async componentDidMount() {
       try {

        this.getCurrentBook(this.state.match.params.isbn).then(book => this.setState({...book}));

        console.log(this.state);

       } catch (e) {
           alert(e);
       }
       this.setState({ isLoading: false });
   }

  render() {
    const { classes } = this.props;

    return (

      <Grid container justify="center" spacing={24}>
        <Grid item xs={5} sm={6} m={9}>

          <form className={classes.container} noValidate autoComplete="off">
            <TextField
              id="title"
              placeHolder="Title"
              className={classes.textField}
              value={this.state.title}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="author"
              placeHolder="Author name"
              className={classes.textField}
              value={this.state.author}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="publisher"
              placeHolder="Publisher"
              className={classes.textField}
              value={this.state.publisher}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="quantity"
              placeHolder="Quantity"
              className={classes.textField}
              type="number"
              value={this.state.quantity}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="price"
              placeHolder="Price"
              className={classes.textField}
              type="number"
              value={this.state.price}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="bookShelfLocalization"
              placeHolder="Localization on bookshelf"
              className={classes.textField}
              value={this.state.bookShelfLocalization}
              margin="normal"
              onChange={this.handleChange}
            />
            <div>
              <Button variant="contained" color="secondary" className={classes.button}>
                Delete
                <DeleteIcon className={classes.rightIcon} />
              </Button>
              <Button variant="contained" color="primary" className={classes.button}>
                Save
                <Icon className={classes.rightIcon}>send</Icon>
              </Button>
            </div>
          </form>
        </Grid>
      </Grid>
    );
  }
}

TextField.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(BookDetail);
