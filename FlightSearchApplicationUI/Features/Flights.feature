Feature: Flights
In order to plan my trip
As a user
I want to search for available flights


Scenario: Valid List for Flights
    * I am on the flight search page
    * I select the from city as 'Istanbul'
    * I select the to city as 'Los Angeles'
    * I verify that the departure city is not the same as the destination city
    * I should see a list of available flights
    * I should check the details of each flight in the list

Scenario: Invalid Search for Flights
    * I am on the flight search page
    * I select the from city as 'Istanbul'
    * I select the to city as 'Istanbul'
    * I verify that the departure city is not the same as the destination city

