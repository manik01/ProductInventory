﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProductInventory.SeleniumHelpers;

namespace ProductInventory.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_LoginLink")]
        public IWebElement SignInLink { get; set; }

        [FindsBy(How = How.Id, Using = "uid")]
        public IWebElement UserIdField { get; set; }

        [FindsBy(How = How.Id, Using = "passw")]
        public IWebElement PasswordField { get; set; }

        /// <summary>
        /// JQuery selector example
        /// </summary>
        public IWebElement LoginButton {
            get
            {
                return _driver.FindElementByJQuery("input[name='btnSubmit']");
            }
        }

        public void LoginAsAdmin(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();
            UserIdField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            UserIdField.SendKeys("admin'--");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }
    }
}

