using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SudokuTests
{
    public class SudokuTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sudoku.com");
        }

        [Test]
        public void CheckTitle()
        {
            NUnit.Framework.Assert.AreEqual("Play Free Sudoku online - solve web sudoku puzzles", driver.Title);
        }

        [Test]
        public void CheckNewGameButtonExists()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            System.Threading.Thread.Sleep(3000); 
            IWebElement newGameButton = driver.FindElement(By.Id("new-game-button"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(newGameButton.Enabled, "New Game button exists but is not enabled.");
        }




        [Test]
        public void ChangeDifficultyToHard()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            System.Threading.Thread.Sleep(3000); 
            IWebElement newGameButton = driver.FindElement(By.Id("new-game-button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", newGameButton);
            System.Threading.Thread.Sleep(1000); 
            IWebElement hardDifficulty = driver.FindElement(By.Id("link-hard-classic"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", hardDifficulty);
        }







        [Test]
        public void StartNewGame()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            System.Threading.Thread.Sleep(3000);
            IWebElement newGameButton = driver.FindElement(By.Id("new-game-button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", newGameButton);
        }


        [Test]
        public void FooterIsDisplayed()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            Thread.Sleep(2000); 

            IWebElement footer = driver.FindElement(By.TagName("footer"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(footer.Displayed, "Footer is not displayed on the page.");
        }




        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
