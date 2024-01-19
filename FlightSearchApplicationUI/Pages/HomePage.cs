using FlightSearchApplicationUI.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FlightSearchApplicationUI.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        private IWebElement FromCombobox => driver.FindElement(By.XPath("//label[text()='From:']/following-sibling::*[input[contains(@id,'headlessui-combobox-input')]]"));
        private IWebElement FromButton => driver.FindElement(By.XPath("//label[text()='From:']/following-sibling::*[button[contains(@id,'headlessui-combobox-button')]]/button"));
        private IWebElement ToButton => driver.FindElement(By.XPath("//label[text()='To:']/following-sibling::*[button[contains(@id,'headlessui-combobox-button')]]/button"));
        private IWebElement ToCombobox => driver.FindElement(By.XPath("//label[text()='To:']/following-sibling::*[input[contains(@id,'headlessui-combobox-input')]]"));

        private IWebElement FromInput => driver.FindElement(By.XPath("//label[text()='From:']/following-sibling::*[input[contains(@id,'headlessui-combobox-input')]]/input"));
        private IWebElement ToInput => driver.FindElement(By.XPath("//label[text()='To:']/following-sibling::*[input[contains(@id,'headlessui-combobox-input')]]/input"));
        private IList<IWebElement> ListOfCities => driver.FindElements(By.XPath("//li[contains(@id,'headlessui-combobox-option')]"));
        private IList<IWebElement> ListOfFlights => driver.FindElements(By.XPath("//ul[@role='list']//li"));
        
        private IWebElement FoundedFlights => driver.FindElement(By.ClassName("mb-10"));

        public HomePage(IWebDriver webDriver) => driver = webDriver;

        public void TypeFromFlight(string value) {
            FromButton.Click();
            IWebElement ulElement = FromCombobox.FindElement(By.TagName("ul"));
            string liXPath = $"//li[contains(@id,'headlessui-combobox-option')]//span[text()='{value}']";
            IWebElement liElement = ulElement.FindElement(By.XPath(liXPath));
            liElement.Click();
        }

        public string GetCityValues(string value)
        {
            
            foreach (IWebElement element in ListOfCities)
            {
                if (element.Text.Contains(value))
                {
                    return GetValues(element.Text);
                }
            }
            return string.Empty;
        }

        public string GetValues(string text) {
            var values = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            return values[0];
        }

        public bool VerifyDepCityAndDesCity()
        {
            if (FromInput.GetAttribute("value") != ToInput.GetAttribute("value"))
                return true;
            else return false;            
        }


        public void TypeToFlight(string value)
        {
            ToButton.Click();
            IWebElement ulElement = ToCombobox.FindElement(By.TagName("ul"));
            string liXPath = $"//li[contains(@id,'headlessui-combobox-option')]//span[text()='{value}']";
            IWebElement liElement = ulElement.FindElement(By.XPath(liXPath));
            liElement.Click();

        }

        public int GetListOfFlights => ListOfFlights.Count;
        public int GetFoundedFlights => Convert.ToInt32(FoundedFlights.Text.Split(' ')[1]);
    }
}
