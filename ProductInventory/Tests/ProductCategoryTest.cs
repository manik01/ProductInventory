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
using ProductInventory.PageObjects;

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
            

            // Assert
            
        }

  
    }
}


