using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using JimmyJohnsAutomation.WebDriverExtensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using JimmyJohnsAutomation.Data;

namespace JimmyJohnsAutomation.Pages
{
    public class CreateAccountPage
    {

        #region WebElements
        /// <summary>
        /// //
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@name='FirstName']")]
        [CacheLookup]
        public IWebElement FirstNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='LastName']")]
        [CacheLookup]
        public IWebElement LastNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_0']")]
        [CacheLookup]
        public IWebElement PhoneNumberTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        [CacheLookup]
        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='emailConfirm']")]
        [CacheLookup]
        public IWebElement ConfirmEmailTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        [CacheLookup]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='passwordConfirm']")]
        [CacheLookup]
        public IWebElement PasswordConfirmTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='chkTermsAndConditions']")]
        [CacheLookup]
        public IWebElement TermsAndConditionsCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='createAccountBtn']")]
        [CacheLookup]
        public IWebElement CreateAccountButton { get; set; }


        #endregion


        #region Constructor

        public CreateAccountPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public IWebDriver Driver { get; set; }


        #endregion


        #region Actions

        public void CreateAccount()
        {
            PersonData pdata = Data.GenerateData.GetPersonData();

            string email = pdata.EmailAddress;
            string password = pdata.Password + "9";

            FirstNameTextBox.SetText(pdata.FirstName);
            LastNameTextBox.SetText(pdata.LastName);
            PhoneNumberTextBox.SetText(pdata.TelephoneNumber);
            EmailTextBox.SetText(email);
            ConfirmEmailTextBox.SetText(email);
            PasswordTextBox.SetText(password);
            PasswordConfirmTextBox.SetText(password);
            TermsAndConditionsCheckBox.SetCheckbox(true);
            CreateAccountButton.Click();
        }


        public void CreateAccountWithNBuilderList()
        {
            IList<PersonData> pdata = Data.GenerateData.GetListOfPersonData();

            string email = pdata[0].EmailAddress;
            string password = pdata[0].Password + "9";

            FirstNameTextBox.SetText(pdata[0].FirstName);
            LastNameTextBox.SetText(pdata[0].LastName);
            PhoneNumberTextBox.SetText(pdata[0].TelephoneNumber);
            EmailTextBox.SetText(email);
            ConfirmEmailTextBox.SetText(email);
            PasswordTextBox.SetText(password);
            PasswordConfirmTextBox.SetText(password);
            TermsAndConditionsCheckBox.SetCheckbox(true);
            CreateAccountButton.Click();
        }

        #endregion 

    }
}
