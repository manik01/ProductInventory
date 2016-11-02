using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using ProductInventory.PageObjects;
using ProductInventory.SeleniumHelpers;
using ProductInventory.Utilities;
using System.Threading;

namespace ProductInventory.Tests
{
    [TestFixture]
    public class AltoroMutualTests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
            _verificationErrors.ToString().Should().BeEmpty("No verification errors are expected.");
        }

        [Test]
        public void LoginWithValidCredentialsShouldSucceed()
        {
            // Arrange
            var productPage = new ProductPage(_driver);

            // Act
            productPage.SubscribeToProducts(_baseUrl);

            // Need to wait until the results are displayed on the web page
            
            Thread.Sleep(10000);

            // Assert
            productPage.SuccessMessageField.Text.StartsWith(
                "Thanks! We will notify you of our new shoes at this email:"
                , true, CultureInfo.InvariantCulture).Should().BeTrue();
            
        }
    }
}


