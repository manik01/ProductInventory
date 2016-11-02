using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProductInventory.SeleniumHelpers;
using ProductInventory.Utilities;

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

        

        /// <summary>
        /// JQuery selector example
        /// </summary>
        public IWebElement LoginButton {
            get
            {
                return _driver.FindElementByJQuery("input[name='btnSubmit']");
            }
        }

        public void SubscribeToProducts(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);

            SubscribeLink.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            SubscribeLink.SendKeys(Constants.UserEmail);

            SubscribeButton.Click();
          
        }
    }
}

