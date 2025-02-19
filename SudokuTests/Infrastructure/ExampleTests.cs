using Infrastructure.Factories;
using Infrastructure.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Infrastructure
{
    [TestClass]
    public class ExampleTests
    {
        private IWebDriver driver;

        [Test]
        public void TestLogin()
        {
            var user = UserFactory.CreateFakeUser();
            var loginPage = new LoginPage(driver);
            loginPage.Login(user);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(loginPage.IsLoginSuccessful());
        }
        [Test]
        public void TestUserRegistration()
        {
            var registrationPage = new RegistrationPage(driver);
            registrationPage.Register("newuser", "password123");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Url.Contains("success"), "Registration failed!");
        }
        [Test]
        public void TestCheckoutButtonExists()
        {
            var homePage = new HomePage(driver);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(homePage.CheckoutButtonVisible(), "Checkout button is not visible!");
        }
        [Test]
        public void TestAddItemToCart()
        {
            var productPage = new ProductPage(driver);
            productPage.AddItemToCart("Item 1");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Url.Contains("cart"), "Item not added to cart!");
        }



    }
}
