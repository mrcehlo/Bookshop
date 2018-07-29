import React, { Component } from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import { Link } from "react-router-dom";
import './Book.css'

class Book extends Component {
  constructor(props) {
    super(props);

    this.state = props;

  }

  render() {
    return (
      <div>
       <Card className="card extendedCard">
         <CardContent>
           <Typography className="title" color="textSecondary">
             {this.state.author}
           </Typography>
           <Typography variant="headline" component="h2">
             {this.state.title}
           </Typography>
           <Typography className="pos" color="textSecondary">
             Book details
           </Typography>
           <Typography component="p">
             Price: {this.state.price}<br />
             Quantity: {this.state.quantity}
           </Typography>
         </CardContent>
         <CardActions>
            <Link to={`/books/${this.state.isbn}`}>
              <Button size="small">View more</Button>
            </Link>
         </CardActions>
       </Card>
     </div>
    );
  }

}
export default Book;
