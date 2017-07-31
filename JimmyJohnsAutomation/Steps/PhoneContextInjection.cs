using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JimmyJohnsAutomation.Data;
using JimmyJohnsAutomation.Pages;
using JimmyJohnsAutomation.WebDriverExtensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JimmyJohnsAutomation.Steps
{
    [Binding]
    public sealed class PhoneContextInjection
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("IWebDriver");

        private readonly PhoneData phoneData;

        public PhoneContextInjection(PhoneData phoneData)
        {
            this.phoneData = phoneData;
        }

        [Given(@"I have a phone number ""(.*)""")]
        public void GivenIHaveAPhoneNumber(string phoneNumber)
        {
            phoneData.Phone = phoneNumber;
        }

        [Then(@"the phone number is added to the phone number field")]
        public void ThenThePhoneNumberIsAddedToThePhoneNumberField()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage(driver);
            createAccountPage.PhoneNumberTextBox.SetText(phoneData.Phone);
        }

    }
}
