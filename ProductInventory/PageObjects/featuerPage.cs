using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProductInventory.SeleniumHelpers;
using ProductInventory.Utilities;

namespace ProductInventory.PageObjects
{
    public class FeatuerPage
    {
         private readonly IWebDriver _driver;

        public FeatuerPage(IWebDriver driver)
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

        

        /// <summary>
        /// JQuery selector example
        /// </summary>
        public IWebElement SubmitButton {
            get
            {
                return _driver.FindElementByJQuery("input[name='btnSubmit']");
            }
        }

        public IEnumerable<object> GetAllWebElements()
        {
            return _driver.FindElements(By.XPath("//ul[@id='shoe_list']/li/div/tr"));
        }

  
    }
  }
