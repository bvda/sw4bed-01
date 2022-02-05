import React, { useState, useEffect } from 'react';
import axios from 'axios';
 
const URL = 'https://localhost:5001/weatherforecast'
const HTTP_BODY = { data: "hej" }

function App() {
  
  const [fetchStatus, setFetchStatus] = useState(null)
  const [axiosStatus, setAxiosStatus] = useState(null)
  
  useEffect(() => {
    usingFetch(setFetchStatus)
  }, [])

  useEffect(() => {
    usingAxios(setAxiosStatus)
  }, [])

  let isFetchingAxios = ''
  if(axiosStatus === null) {
    isFetchingAxios = 'Loading...'
  } else {
    isFetchingAxios = axiosStatus ? 'Success': 'Fail'
  }

  let isFetchingFetch = ''
  if(fetchStatus === null) {
    isFetchingFetch = 'Loading...'
  } else {
    isFetchingFetch = fetchStatus ? 'Success': 'Fail'
  }

  return (
    <div className="App">
      <div>
        <h1>CORS test app</h1>
        <ul>
          <li>Fetch: {isFetchingFetch}</li>
          <li>Axios: {isFetchingAxios}</li>
        </ul>
      </div>
    </div>
  );
}

function usingFetch(handleStatusChange) {

  const HTTP_METHOD = 'POST' 
  const CONTENT_TYPE = {
    'Content-Type': 'application/json'
  }

  fetch(URL, {
    method: HTTP_METHOD,
      headers: CONTENT_TYPE,
    body: JSON.stringify(HTTP_BODY)
  })
  .then(response => response.json())
  .then(data => {
    handleStatusChange(true)
    console.log(data)
  })
  .catch(error => {
    handleStatusChange(false)
    console.log(error.message)
  })
}

function usingAxios(handleStatusChange) {
  axios.post(URL, HTTP_BODY)
  .then(function (response) {
    handleStatusChange(true)
    console.log(response);
  }).catch(function (error) {
    handleStatusChange(false)
    console.log(error);
  })
}

export default App;
