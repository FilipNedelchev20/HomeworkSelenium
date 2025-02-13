using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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
        public void EnterNumberInCell()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            System.Threading.Thread.Sleep(3000); 
            IWebElement cell = driver.FindElement(By.XPath("//div[@class='cell' and not(contains(@class, 'given'))]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", cell);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerText = '5';", cell);
        }





        [Test]
        public void UndoMove()
        {
            driver.Navigate().GoToUrl("https://sudoku.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement cell = wait.Until(d =>
            {
                var element = d.FindElement(By.XPath("//div[@class='sudoku-board']//div[contains(@class, 'cell') and not(contains(@class, 'given'))]"));
                return (element.Displayed && element.Enabled) ? element : null;
            });

            if (cell != null)
            {
                cell.Click();
                cell.SendKeys("5");

                IWebElement undoButton = driver.FindElement(By.XPath("//button[contains(text(), 'Undo')]"));
                undoButton.Click();
            }
            else
            {
                Console.WriteLine("Cell not found or not interactable.");
            }
        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
