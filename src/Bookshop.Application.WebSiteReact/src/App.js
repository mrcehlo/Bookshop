import React, { Component } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import TopBar from './components/TopBar';


class App extends Component {
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
                </Grid>
            </Grid>
          </div>

      </React.Fragment>
    );
  }
}

export default App;
