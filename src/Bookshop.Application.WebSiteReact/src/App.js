import React, { Component } from 'react';
import Grid from '@material-ui/core/Grid';
import TopBar from './components/TopBar';
import Book from './components/Book';
import {getAllBooks} from './libs/BookshopAPI';
import { withRouter } from "react-router-dom";
import Routes from "./Routes";

class App extends Component {
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
        this.returnBooks().then(books => this.setState({books}));

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

          <div className="App">
            <Grid container justify="center" spacing={24}>
                <Grid item xs={12}>
                  <TopBar />
                </Grid>
            </Grid>
            <Routes />
          </div>
    );
  }
}

export default withRouter(App);
