# SW4BED-01

## Introduction
Welcome to the SW4BED-01 repository.

## Getting started
Node.js is required to install and run the slides. Go to the [Node.js](https://nodejs.org/) and download the latest LTS (long-term support) version and install it on you machine.

We recommend using [Visual Studio Code](https://code.visualstudio.com/) as the Integrated Development Environmen (IDE) for this course.

Check that everything is installed correctly by running the following commands in a terminal `node -v` and `npm -v`. (If you get some output, everything should be all good). 

## Slides
The slides in this course is built with [reveal.js](https://revealjs.com) that is a HTML presentation framework.

When running the slides for the first time, you will need to download the dependencies using the Node package manager (npm). Run `npm install` in the terminal in the `./slides` directory.

Run the slides by typing `npm start` and open a browser and go to [http://0.0.0.0:8000](http://0.0.0.0:8000) (or [http://localhost:8000](http://localhost:8000) if you are on Windows).

## Example code
We will be showing example code for each lesson. The code is split up into various projects. 

When running an example project for the first time, you will need to download the dependencies using the Node package manager (`npm`). Run `npm install` in the terminal in the `./examples/<LESSON_FOLDER>`.