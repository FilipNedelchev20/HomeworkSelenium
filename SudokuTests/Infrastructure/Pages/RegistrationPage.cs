using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pages
{
    public class RegistrationPage
    {
        private IWebDriver _driver;
        private By _usernameField => By.Id("username");
        private By _passwordField => By.Id("password");
        private By _confirmPasswordField => By.Id("confirmPassword");
        private By _registerButton => By.Id("registerButton");

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Register(string username, string password)
        {
            _driver.FindElement(_usernameField).SendKeys(username);
            _driver.FindElement(_passwordField).SendKeys(password);
            _driver.FindElement(_confirmPasswordField).SendKeys(password);
            _driver.FindElement(_registerButton).Click();
        }
    }

}
