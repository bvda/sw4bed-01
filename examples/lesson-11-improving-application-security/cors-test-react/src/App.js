import React, { useState, useEffect } from 'react';
import axios from 'axios';
 
const URL = 'https://localhost:5001/weatherforecast'
const HTTP_BODY = { data: "hej" }

function App() {
  
  const [fetchStatus, setFetchStatus] = useState(null)
  const [axiosStatus, setAxiosStatus] = useState(null)
  const [fetchNoCorsStatus, setFetchNoCorsStatus] = useState(null)
  const [axiosNoCorsStatus, setAxiosNoCorsStatus] = useState(null)

  
  useEffect(() => {
    usingFetch(`${URL}/cors`,setFetchStatus)
  }, [])

  useEffect(() => {
    usingAxios(`${URL}/cors`, setAxiosStatus)
  }, [])

  useEffect(() => {
    usingFetch(`${URL}/nocors`,setFetchNoCorsStatus)
  }, [])

  useEffect(() => {
    usingAxios(`${URL}/nocors`, setAxiosNoCorsStatus)
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

  let isFetchingNoCorsAxios = ''
  if(axiosNoCorsStatus === null) {
    isFetchingNoCorsAxios = 'Loading...'
  } else {
    isFetchingNoCorsAxios = axiosNoCorsStatus ? 'Success': 'Fail'
  }

  let isFetchingNoCorsFetch = ''
  if(fetchNoCorsStatus === null) {
    isFetchingNoCorsFetch = 'Loading...'
  } else {
    isFetchingNoCorsFetch = fetchNoCorsStatus ? 'Success': 'Fail'
  }

  return (
    <div className="App">
      <div>
        <h1>CORS test app</h1>
        <ul>
          <li>CORS configured
            <ul>
              <li>Fetch: {isFetchingFetch}</li>
              <li>Axios: {isFetchingAxios}</li>
            </ul>
          </li>
          <li>CORS not configured
            <ul>
              <li>Fetch: {isFetchingNoCorsFetch}</li>
              <li>Axios: {isFetchingNoCorsAxios}</li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  );
}

function usingFetch(url, handleStatusChange) {

  const HTTP_METHOD = 'POST' 
  const CONTENT_TYPE = {
    'Content-Type': 'application/json'
  }

  fetch(url, {
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

function usingAxios(url, handleStatusChange) {
  axios.post(url, HTTP_BODY)
  .then(function (response) {
    handleStatusChange(true)
    console.log(response);
  }).catch(function (error) {
    handleStatusChange(false)
    console.log(error);
  })
}

export default App;
