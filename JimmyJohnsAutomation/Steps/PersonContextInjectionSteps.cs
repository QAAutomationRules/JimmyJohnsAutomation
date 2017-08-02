using JimmyJohnsAutomation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JimmyJohnsAutomation.Pages;
using JimmyJohnsAutomation.WebDriverExtensions;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;

namespace JimmyJohnsAutomation.Steps
{
    [Binding]
    public sealed class PersonContextInjectionSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("IWebDriver");

        private readonly PersonData personData;

        public PersonContextInjectionSteps(PersonData personData)
        {
            this.personData = personData;
        }

        [Given(@"I have a first name ""(.*)"" and a last name ""(.*)""")]
        public void GivenIHaveAFirstNameAndALastName(string firstName, string lastName)
        {
            personData.FirstName = firstName;
            personData.LastName = lastName;
        }


        [Then(@"the First Name and Last Name may be shared")]
        public void ThenTheFirstNameAndLastNameMayBeShared()
        {

            

            CreateAccountPage createAccountPage = new CreateAccountPage(driver);
            createAccountPage.FirstNameTextBox.SetText(personData.FirstName);
            createAccountPage.LastNameTextBox.SetText(personData.LastName);
        }


    }

}
