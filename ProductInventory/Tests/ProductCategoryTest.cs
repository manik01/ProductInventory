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
        public void SubscribeToFutureProductsShouldSucceed()
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

        [Test]
        public void ShouldAccessUpcomingProductsWithPriceDetails()
        {
            // Arrange
            var productPage = new ProductPage(_driver);
            FeatuerPage featurePage;

            // Act
            var monthNames = Extensions.GetAllMonthNames();

            foreach (var month in monthNames)
            {
                productPage.AccessProductInfo(_baseUrl, month);

                // Need to wait until the results are displayed on the web page
                Thread.Sleep(10000);

                featurePage = new FeatuerPage(_driver);
                var webElements = featurePage.GetAllWebElements();

                //Assert
                foreach (var property in webElements)
                {
                    Assert.IsTrue(!string.IsNullOrEmpty(((IWebElement) property).Text));
                }

            }
        }
    }
}


