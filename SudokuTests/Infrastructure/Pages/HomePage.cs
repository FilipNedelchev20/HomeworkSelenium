using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchBar => driver.FindElement(By.Id("search-bar"));
        public IWebElement FirstProduct => driver.FindElement(By.CssSelector(".product-item:first-child"));
        public IWebElement CartIcon => driver.FindElement(By.Id("cart-icon"));

        public void SearchProduct(string productName)
        {
            SearchBar.SendKeys(productName);
            SearchBar.SendKeys(Keys.Enter);
        }

        public void GoToCart()
        {
            CartIcon.Click();
        }
        public bool CheckoutButtonVisible()
        {
            try
            {
                var checkoutButton =    driver.FindElement(By.Id("checkout-button"));
                return checkoutButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

}
