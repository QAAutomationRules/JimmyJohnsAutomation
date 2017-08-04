using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Faker;
using OpenQA.Selenium.Support.UI;
using Faker.Extensions;
using JimmyJohnsAutomation.Data;
using JimmyJohnsAutomation.WebDriverExtensions;
using JimmyJohnsAutomation.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protractor;

namespace JimmyJohnsAutomation.Steps
{
    [Binding]
    public sealed class CreateAccountSteps
    {
       
        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("IWebDriver");


        [When(@"I create a new account with a Page Object")]
        public void WhenICreateANewAccountWithAPageObject()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage(driver);
            createAccountPage.CreateAccount();
            
        }

        
        [Then(@"the Jimmy John user is created")]
        public void ThenTheJimmyJohnUserIsCreated()
        {
            //IWebElement StartAnOrderText = 
            //    driver.FindElement(By.XPath("//h1[contains(text(),'Start an Order')]"));
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h1[contains(text(),'Start an Order')]")));
        }


    }
}
