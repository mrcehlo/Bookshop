import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "./App";

export default () =>
    <Switch>
        <Route path="/" exact component={Home} />
        <Route path="/books" exact component={Home} />
    </Switch>;
