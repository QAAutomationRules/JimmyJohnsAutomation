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

        [FindsBy(How = How.Id, Using = "linkOderLogin")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public IWebDriver Driver { get; set; }

        public void GoToHomePage()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings ["HomePageURL"]);
        }

        public void GoToLoginPage()
        {
            LoginButton.Click();
        }


    }
}
