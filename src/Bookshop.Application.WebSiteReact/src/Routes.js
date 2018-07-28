import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "./components/Home";
import BookDetail from "./components/BookDetail";

export default () =>
      <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/books" exact component={Home} />
          <Route path="/books/:isbn" exact component={BookDetail} />
      </Switch>;
