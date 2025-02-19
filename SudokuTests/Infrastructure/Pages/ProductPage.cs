using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pages
{
    using OpenQA.Selenium;

    public class ProductPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the driver
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Add item to cart method
        public void AddItemToCart(string itemName)
        {
            // Find the item by its name or some identifier
            var item = _driver.FindElement(By.XPath($"//div[contains(text(), '{itemName}')]"));
            var addToCartButton = item.FindElement(By.XPath(".//button[contains(text(), 'Add to cart')]"));
            addToCartButton.Click();
        }
    }

}
