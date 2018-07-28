import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import Book from './Book';
import {getAllBooks} from '../libs/BookshopAPI';
import { Link } from "react-router-dom";
import Button from '@material-ui/core/Button';
import AddIcon from '@material-ui/icons/Add';
import "./Home.css";

class Home extends Component {
  constructor(props) {
    super(props);

    this.state = {
           isLoading: true,
           books: []
       };
  }

  returnBooks() {
        return getAllBooks()
    };

  async componentDidMount() {
       try {
        const books = this.returnBooks().then(books => this.setState({books}));

       } catch (e) {
           alert(e);
       }
       this.setState({ isLoading: false });
   }

  renderBookList(books){
    return [].concat(books).map(
         (book, i) =>
         <Book key={i} {...book} />
       )
  }


  render() {
    return (
      <Grid container justify="center" spacing={24}>
        <Grid item xs={5} sm={6} m={9}>
          <p>
            [work in progress]
          </p>

          {!this.state.isLoading && this.renderBookList(this.state.books)}

          <div className="buttonAddContainer">
            <Button variant="fab" color="primary" aria-label="Add" className="button buttonAdd">
              <Link to="/books/new"> <AddIcon /> </Link>
            </Button>
          </div>

        </Grid>
      </Grid>
    );
  }
}

export default Home;
