import React, {Component} from 'react';
import TextField from '@material-ui/core/TextField';
import {getSingleBook} from '../libs/BookshopAPI';

class BookDetail extends Component {
  constructor(props) {
    super(props);

    this.state = {isLoading: true, ...props};

  }

  getCurrentBook(isbn){
    return getSingleBook(isbn);
  }

  async componentDidMount() {
       try {

        this.getCurrentBook(this.state.isbn).then(book => this.setState({...book}));

       } catch (e) {
           alert(e);
       }
       this.setState({ isLoading: false });
   }

  render() {
    return (
      <form className="container" noValidate autoComplete="off">
        <TextField
          id="title"
          label="Title"
          className="textField"
          value={this.state.title}
          margin="normal"
        />
        <TextField
          id="author"
          label="Author name"
          className="textField"
          value={this.state.author}
          margin="normal"
        />
        <TextField
          id="publisher"
          label="Publisher"
          className="textField"
          value={this.state.publisher}
          margin="normal"
        />
        <TextField
          id="quantity"
          label="Quantity"
          className="textField"
          type="number"
          value={this.state.quantity}
          margin="normal"
        />
        <TextField
          id="price"
          label="Price"
          className="textField"
          type="number"
          value={this.state.price}
          margin="normal"
        />
        <TextField
          id="bookShelfLocalization"
          label="Localization on bookshelf"
          className="textField"
          value={this.state.bookShelfLocalization}
          margin="normal"
        />
      </form>
    );
  }
}
export default BookDetail
