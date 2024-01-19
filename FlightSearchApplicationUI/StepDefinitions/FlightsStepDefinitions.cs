using FlightSearchApplicationUI.Pages;
using FlightSearchApplicationUI.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearchApplicationUI.StepDefinitions
{
    [Binding,Scope(Feature = "Flights")]
    public class FlightsStepDefinitions
    {
        private readonly IWebDriver driver;

        public FlightsStepDefinitions(IWebDriver driver) => this.driver = driver;
        public HomePage HomePage => new(driver);

      

        [StepDefinition(@"I am on the flight search page")]
        public void CheckFlightSearchPage()
        {
            Assert.AreEqual(Utilities.BaseURL, driver.Url);
            Assert.AreEqual("Flights App", driver.Title);
        }

        [StepDefinition(@"I select the from city as '([^']*)'")]
        public void TypeTheFirstCity(string value)
        {
            HomePage.TypeFromFlight(value);
        }

        [StepDefinition(@"I select the to city as '([^']*)'")]
        public void TypeTheSecondCity(string value)
        {
            HomePage.TypeToFlight(value);
        }

        [StepDefinition(@"I verify that the departure city is not the same as the destination city")]
        public void VerifyDepCityAndDesCity()
        {
            Assert.IsTrue(HomePage.VerifyDepCityAndDesCity());
        }

        [StepDefinition(@"I should see a list of available flights")]
        public void CheckAvailableFlights()
        {            
            Assert.That(HomePage.GetListOfFlights, Is.Not.Zero);
        }

        [StepDefinition(@"I should check the details of each flight in the list")]
        public void CheckFoundedAndListOfFlights()
        {            
            Assert.AreEqual(HomePage.GetFoundedFlights, HomePage.GetListOfFlights);
        }

    }
}
