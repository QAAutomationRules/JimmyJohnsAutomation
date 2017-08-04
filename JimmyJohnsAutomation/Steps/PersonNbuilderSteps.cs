using JimmyJohnsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JimmyJohnsAutomation.Data;
using JimmyJohnsAutomation.WebDriverExtensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JimmyJohnsAutomation.Steps
{
    [Binding]
    public sealed class PersonNbuilderSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("IWebDriver");


        [When(@"I create a new account with an NBuilder Person")]
        public void WhenICreateANewAccountWithAnNBuilderPerson()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage(driver);
            createAccountPage.CreateAccount();
        }

    }
}
