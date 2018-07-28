import React, { Component } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import TopBar from './components/TopBar';
import Book from './components/Book';
import {getAllBooks} from './libs/BookshopAPI';


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
        const books = this.returnBooks().then(books => this.setState({books}));
        
       } catch (e) {
           alert(e);
       }
       this.setState({ isLoading: false });
   }

  logReturn(books){
     [].concat(books).map(
        (book, i) =>
        console.log(book)
      )
  }

  renderBookList(books){
    return [].concat(books).map(
         (book, i) =>
         <Book key={i} {...book} />
       )
  }


  render() {
    return (
      <React.Fragment>
          <CssBaseline />

          <div className="App">
            <Grid container justify="center" spacing={24}>
                <Grid item xs={12}>
                  <TopBar />
                </Grid>

                <Grid item xs={5} sm={6} m={9}>
                  <p>
                    [work in progress]
                  </p>

                  {!this.state.isLoading && this.renderBookList(this.state.books)}

                </Grid>
            </Grid>
          </div>

      </React.Fragment>
    );
  }
}

export default App;
