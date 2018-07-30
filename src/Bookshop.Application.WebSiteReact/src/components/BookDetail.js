import React, {Component} from 'react';
import { withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import {getSingleBook, updateBook, deleteBook, createBook} from '../libs/BookshopAPI';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import Icon from '@material-ui/core/Icon';
import './BookDetail.css';
import ResponsiveDialog from "./ResponsiveDialog";

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

    this.state = {isLoading: true,
                  isNewBook: false,
                  ...props};

  }

  getCurrentBook(isbn){
    return getSingleBook(isbn);
  }

  handleChange = event => {
          this.setState({
              [event.target.id]: event.target.value
          });
      }

  async componentDidMount() {
       try {

        // Validates if the page was open from the "add" buttom on HomeIcon
        if(this.state.match.params.isbn !== "new"){
          this.getCurrentBook(this.state.match.params.isbn).then(book => this.setState({...book}));
        }
        else {
          const book = {
            "isbn": "",
            "title": "",
            "author": "",
            "publisher": "",
            "price": 0,
            "bookShelfLocalization": "",
            "quantity": 0
          }
          this.setState({isNewBook: true, ...book});
        }

      } catch (err) {
         if(err.response !== undefined && err.response.status === 400){
           this.dialog.showDialog(err.response.data.messages)
         }
         else{
           alert(err);
         }
       }
       this.setState({ isLoading: false });
   }

   removeBook(){
     return deleteBook(this.state.match.params.isbn);
   }
   saveBook(book, isNewBook) {
        if(isNewBook){
          return createBook(book);
        }
        else{
          return updateBook(book);
        }
    }

   handleSave = async event => {
       event.preventDefault();

       this.setState({ isLoading: true });

       this.saveBook({
           title: this.state.title,
           author: this.state.author,
           publisher: this.state.publisher,
           isbn: this.state.isbn,
           quantity: this.state.quantity,
           price: this.state.price,
           bookShelfLocalization: this.state.bookShelfLocalization
       }, this.state.isNewBook)
           .then(res => {
               this.props.history.push("/books");
           })
           .catch(err => {
             this.setState({ isLoading: false });
             if(err.response !== undefined && err.response.status === 400){
                this.dialog.showDialog(err.response.data.messages)
             }
             else{
               alert(err);
             }
      });
   }

   handleDelete = async event => {
        event.preventDefault();

        try {
            await this.removeBook();
            this.props.history.push("/books");
        } catch (err) {
          if(err.response !== undefined && err.response.status === 400){
            this.dialog.showDialog(err.response.data.messages)
          }
          else{
            alert(err);
          }
        }
    }

  returnHideElementStyle(isNewBook, classes){
     if(!isNewBook)
     {
       return (
         <Button onClick={this.handleDelete} variant="contained" color="secondary" className={classes.button}>
           Delete
           <DeleteIcon className={classes.rightIcon} />
         </Button>
       )
     }
  }


  render() {
    const { classes } = this.props;

    return (

      <Grid container justify="center" spacing={24}>
        <Grid item xs={5} sm={6} m={9}>
          <ResponsiveDialog ref={dialogInstance => { this.dialog = dialogInstance; }} />
          <form className={classes.container} onSubmit={this.handleSave} noValidate autoComplete="off">
            <TextField
              id="title"
              placeholder="Title"
              className={classes.textField}
              value={this.state.title}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="author"
              placeholder="Author name"
              className={classes.textField}
              value={this.state.author}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="publisher"
              placeholder="Publisher"
              className={classes.textField}
              value={this.state.publisher}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="quantity"
              placeholder="Quantity"
              className={classes.textField}
              type="number"
              value={this.state.quantity}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="price"
              placeholder="Price"
              className={classes.textField}
              type="number"
              value={this.state.price}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="bookShelfLocalization"
              placeholder="Localization on bookshelf"
              className={classes.textField}
              value={this.state.bookShelfLocalization}
              margin="normal"
              onChange={this.handleChange}
            />
            <TextField
              id="isbn"
              placeholder="ISBN identifier"
              className={classes.textField}
              value={this.state.isbn}
              margin="normal"
              onChange={this.handleChange}
            />

            <div className="buttomWrapper">
              <Button type="submit" variant="contained" color="primary" className={classes.button}>
                Save
                <Icon className={classes.rightIcon}>send</Icon>
              </Button>
              {this.returnHideElementStyle(this.state.isNewBook, classes)}
            </div>

          </form>
        </Grid>
      </Grid>
    );
  }
}

export default withStyles(styles)(BookDetail);
