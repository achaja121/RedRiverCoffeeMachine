# RedRiverCoffeeMachine

# About the project
The idea behind the project was to give the user flexibility to add and choose their preferred add ons.
Would you like a chocolate in your coffee? Just call addExtra endpoint and voila! You will now have an option to enjoy a mocha :)

# Local set up
This project requires a database. To ensure (hopefully) smooth set up:

1. Navigate to appsettings.json and ensure that the connection string is corect
2. Open Package Manager Console, set RedRiverCoffeeMachine.DataAccess project as default and run Update-Database

The api is fully functional on it own, however, I have added very basic UI to make calling the api a bit easier.
In order to run the React app the Node.js is required. To run the app run npm start in ui\red-river-coffee-machine folder.

# Adding extras
Unfortunately the functionality to add new add ons to the drink is not currently covered by the UI, however, the api/DrinkExtras/addExtras endpoint can be called from swagger or Postman.
