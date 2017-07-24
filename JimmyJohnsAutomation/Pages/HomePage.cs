﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace JimmyJohnsAutomation.Pages
{
    public class HomePage
    {

        #region WebElements

        [FindsBy(How = How.Id, Using = "linkOderLogin")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        #endregion


        #region Constructor

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public IWebDriver Driver { get; set; }

        #endregion


        #region Actions

        public HomePage GoToHomePage()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings ["HomePageURL"]);

            return new HomePage(this.Driver);
        }

        public LoginPage GoToLoginPage()
        {
            LoginButton.Click();

            return new LoginPage(this.Driver);
        }

        #endregion
    }
}
