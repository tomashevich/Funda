import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, guys!</h1>
        <p>This is a Funda test assignment web application.</p>
       
        <p>It's calls Funda partner API, retrieve data and calculate top 10 makelaars in Amsterdam.</p>
            <p>Use menu on top of the page to fetch the data.</p>
            <p>No data in most cases means that API reject too many requests. Just wait a minute and retry.</p>
            <p>You can find the details of implementation in a Readme file in sourcecode directory.</p>
            <p>... I  hope it works on your computer :)</p>
      </div>
    );
  }
}
