using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProductInventory.SeleniumHelpers;
using ProductInventory.Utilities;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

        [FindsBy(How = How.Id, Using = "remind_email_input")]
        public IWebElement SubscribeLink { get; set; }

        [FindsBy(How = How.Id, Using = "remind_email_submit")]
        public IWebElement SubscribeButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "flash flash_success")]
        public IWebElement SuccessMessageField { get; set; }

        [FindsBy(How = How.ClassName, Using = "flash flash_success")]
        public IWebElement FeatureMonth { get; set; }
 

        public void SubscribeToProducts(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);

            SubscribeLink.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            SubscribeLink.SendKeys(Constants.UserEmail);

            SubscribeButton.Click();
          
        }

        public void AccessProductInfo(string baseUrl, string month )
        {

            _driver.Navigate().GoToUrl(baseUrl);
            _driver.Navigate().GoToUrl(String.Format("{0}{1}/{2}",baseUrl,Constants.Month,month));

            
        }
    }
}

