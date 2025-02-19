using Infrastructure.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UsernameField => driver.FindElement(By.Name("username"));
        public IWebElement PasswordField => driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => driver.FindElement(By.Name("login"));

        public void Login(User user)
        {
            UsernameField.SendKeys(user.Username);
            PasswordField.SendKeys(user.Password);
            LoginButton.Click();
        }

        public bool IsLoginSuccessful()
        {
            
            return driver.FindElement(By.Id("welcome-message")).Displayed;
        }
    }


}
