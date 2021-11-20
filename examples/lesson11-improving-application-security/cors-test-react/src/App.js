import React from 'react';
import logo from './logo.svg';
import axios from 'axios';
import './App.css';

// const url = 'https://cors-fixes.azurewebsites.net/weatherforecast' 
const url = 'https://localhost:5001/weatherforecast'

function App() {
  axios.post(url, 
    { data: "hej" }
  ).then(function (response) {
    console.log(response);
  }).catch(function (error) {
    console.log(error);
  })

  fetch(url, {
    method: 'POST',
      headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
    body: JSON.stringify({ data: "hej" })
  })
  .then(response => response.json())
  .then(data => console.log(data))


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
