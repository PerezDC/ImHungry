<p align="center">
  <img src = "https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/Im%20Hungry.png">
</p>

---

# PROJECT: ImHungry
This is my repository for a web application I will be developing, *I'm Hungry*! 
This web application was created throughout the Microsoft Software and Systems Academy, Cloud App Developer Program, Cohort 8.

---

## I'm Hungry Description
* The purpose of I'm Hungry is to connect open-minded individuals with local food establishments.
* This is done by connecting users with APIs, such as Yelp!'s REST API, through an easy to use web-based application.
* Users can search using two options: 
  * geolocation input from their device
  * manual zipcode input.
* Users will have the option of adjusting their search radius to provide nearby food establishments.
* Users will receive a random nearby food establishment and decide to *keep* or *try again*.
* If a User decides to *keep* the location they are given, they will be given further information regarding that establishment.

---

## Table of Contents
- [X] [Database Conceptual Design](#Entity-Relationship-Diagram) (ERD)
- [X] Database Creation (SQL Scripts) | [See Here](https://github.com/PerezDC/ImHungry/blob/master/ImHungryDBScript.sql)
- [X] [UI/UX (Wire-frame sketches)](#Wire-frames)
- [X] [User Stories](#User-Stories)
- [X] [Use Cases](Use-Cases)
- [X] [Use-Case Diagram](#Use-Case-Diagram)
- [X] [Requirements List](#Requirements-List)
- [X] [Test Table](#Test-Table)
- [X] [Prototype](#Prototype)
- [X] Create Project Board | [See Here](https://github.com/users/PerezDC/projects/1)

---
## Entity Relationship Diagram
[Back to Table of Contents ↑](#Table-of-contents)
![ImHungryERD](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/I'm%20Hungry%20ERD.png)

---
## Wire-frames
[Back to top ↑](#Table-of-contents)
![Wireframe1](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/Wireframe%201.PNG)
![Wireframe2](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/Wireframe%202.PNG)
![Wireframe3](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/Wireframe%203.PNG)
![Wireframe4](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/Wireframe%204.PNG)

---
## User Stories
[Back to Table of Contents ↑](#Table-of-contents)
ID | User Story
---|:----------
1|As a user, I want to browse local restaurants so that I can experience restaurants I typically will not visit.
2|As a user, I want to search for restaurants using my device’s location so that I do not have to manually type in a zip code.
3|As a user, I want to search for restaurants using a typed in zip code so that I do not have to share my device’s current location.
4|As a user, I want to adjust my search radius so that I can find a nearby restaurant within a specific distance.
5|As a user, I want to save my recently visited restaurants so that I can visit again in the future.

---
##  Use Cases
[Back to Table of Contents ↑](#Table-of-contents)
ID | Use Case
---|:--------
1|Given user visits home page, when they click ‘Log In’, show login form.
2|Given user visits home page, when they click ‘Continue as Guest’ button, direct to search page.
3|Given user visits home page, when they click ‘Not a member?’ link, show user registration form.
4|Given user action, when they login, display welcome back message with their last visited restaurant and ‘like’ or ‘dislike’ button.
5|Given user action, when they click the ‘Use my location’ button, devices geolocation is received from device if allowed.
6|Given user action, when they click the ‘Search by ZIP’ button, display Input Zip Code form.
7|Given user action, when they click the ‘Settings’ button, display user settings list.
8|Given user action, when they select a search option, display results page.
9|Given user action, when they select ‘Spin Again’ button, display new random result from search query.
10|Given user action, when they select ‘Directions’ button, reroute user to directions application of their choice.

---
## Use-Case Diagram
[Back to Table of Contents ↑](#Table-of-contents)
![UML-V2](https://github.com/PerezDC/ImHungry1/blob/master/ImageFiles/ImHungryUseCaseDiagram.jpg)

---
## Requirements List
[Back to Table of Contents ↑](#Table-of-contents)
ID | Requirement | Test Method | Test ID | Tested
:---|:------------|:------------|:--------|:-------|
1.|System shall allow registered users to log in. | Inpection | T1 | Yes
1.1.|System shall allow registered users to input username and password. | Test | T2 | Yes
1.2.|System shall validate login credentials in database. | Test | T3 | No
1.3.|System shall forward validated users to welcome page. | Demonstration | T4 | No
2.|System shall allow users to continue as guest. | Demonstration | T5 | No
2.1.|System shall forward guest to search page. | Demonstration | T5 | No
3.|System shall allow users to register an account. | Test | T6 | No
3.1.|System shall allow users to input new login credentials. | Inspection | T7 | No
3.2.|System shall validate input formatting. | Inspection | T7 | Yes
3.3.|System shall forward newly registered users to welcome page walk-through. | Demonstration | T8 | No
4.|System shall allow registered users to rate last visited location. | Demonstration | T9 | No
5.|System shall allow users to provide a search location. | Demonstration | T10, T11 | No
5.1.|System shall allow users to provide device geolocation if appropriate button is clicked. | Demonstration | T10 | No
5.2.|System shall provide users with zip code input form if appropriate button is clicked. | Inspection | T11 | No
5.2.1.|System shall validate input is in correct format. | Demonstration | T12 | No
5.3.|System shall forward users to results interface once search location data has been inputted. | Demonstration | T13 | No
6.|System shall allow users to adjust search radius with slider. | Demonstration | T14 | No
7.|System shall submit formatted query to REST API. | Inspection | T15 | No
7.1.|System shall index search results into user database. | Inspection | T16 | No
7.2.|System shall filter results from query and delete restaurants rated as ‘disliked’. | Demonstration | T17 | No
8.|System shall display results interface and implement database results. | Demonstration | T18 | No
8.1.|System shall present a random result to user. | Demonstration | T19 | No
8.2.|System shall allow user to fetch a new random result if button is clicked. | Demonstration | T20 | No
8.3.|System shall save last result as visited if application is closed or left idle. | Inspection | T21 | No

---
## Test Table
[Back to Table of Contents ↑](#Table-of-contents)
Test ID | Req ID | Test Procedure | Current Status
:-------|:-------|:---------------|:---------------|:----------|
T1 | 1 | Check Log In button. Input form should be displayed. | Tested
T2 | 1.1 | Check if Register Now link displays input form. | Tested
T3 | 1.2, 3.2 | Check input form constraints, username and email address in correct formats. | Tested
T4 | 1.3 | Check if logged in user or newly registered user is forwarded to Welcome Page. | Not Tested
T5 | 2, 2.1 | Check Continue as Guest button, users should be forwarded to Search Page. | Not Tested
T6 | 3 | Check if new user form populated user database. | Not Tested
T7 | 3.1, 3.2 | Check new user input form constraints, inputted data should adhere to formatting. | Not Tested
T8 | 3.3 | Check if newly registered users are forwarded to Welcome Page with intro walk-through. | Not Tested
T9 | 4, 1.3, 8.3 | Revisiting users should be able to rate their last visited establishment. | Not Tested
T10 | 5, 5.1 | Check if Use My Location button fetches device's geolocation. | Not Tested
T11 | 5, 5.2 | Check if input form displays if Search By Zip button is clicked. | Not Tested
T12 | 5.2.1 | Check if the input form only accepts int value of 5 (i.e. 92592). | Not Tested
T13 | 5.3 | Users should be forwarded to the Results Page | Not Tested
T14 | 6 | Users should be able to adjust search radius from .5 miles to 25 miles using a slider. | Not Tested
T15 | 7 | Check if query is properly formatted for Yelp!'s REST API. | Not Tested
T16 | 7.1 | Check if search results are inputted into the user's database. | Not Tested
T17 | 7.2 | Check if user's preferences are applied to query. | Not Tested
T18 | 8 | Check if search results are displayed to the user. | Not Tested
T19 | 8.1 | Check to see if the provided result was random. | Not Tested
T20 | 8.2 | Users should be able to receive another random result if Try Again button is clicked. | Not Tested
T21 | 8.3 | Registered users will have their last result saved to their database. | Not Tested

### What percent of requirements are (currently) covered by test cases?
### What percent of test cases are currently passing?
### What level of Validation could be expected after Verification? (Acceptance Tests?)

---
## Prototype
[Back to Table of Contents ↑](#Table-of-contents)
#### Live prototype can be accessed [here](https://xd.adobe.com/view/7212bf40-0c9e-433a-ae18-7a7315ff4667-2741/).
#### More information regarding I'm Hungry Prototype can be viewed [here](https://github.com/PerezDC/ImHungry1/blob/master/Prototype/README.md).
![PrototypeGIF](https://github.com/PerezDC/ImHungry1/blob/master/Prototype/ImageFiles/ImHungryPrototypeToGif.gif)
