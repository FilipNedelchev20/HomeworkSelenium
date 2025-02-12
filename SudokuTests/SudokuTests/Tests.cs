using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            IWebElement newGameButton = driver.FindElement(By.XPath("//button[contains(text(), 'New game')]"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(newGameButton.Displayed, "The 'New Game' button is not displayed.");
        }

        [Test]
        public void ChangeDifficultyToHard()
        {
            IWebElement difficultyButton = driver.FindElement(By.ClassName("difficulty"));
            difficultyButton.Click();

            IWebElement hardOption = driver.FindElement(By.XPath("//button[contains(text(), 'Hard')]"));
            hardOption.Click();

            IWebElement selectedDifficulty = driver.FindElement(By.ClassName("difficulty"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Hard", selectedDifficulty.Text, "Difficulty did not change to Hard.");
        }

        [Test]
        public void StartNewGame()
        {
            IWebElement newGameButton = driver.FindElement(By.XPath("//button[contains(text(), 'New game')]"));
            newGameButton.Click();

            IWebElement sudokuGrid = driver.FindElement(By.ClassName("game-container"));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(sudokuGrid.Displayed, "Sudoku grid did not load properly.");
        }

        [Test]
        public void EnterNumberInCell()
        {
            IWebElement firstCell = driver.FindElement(By.XPath("//div[contains(@class, 'cell') and not(contains(@class, 'given'))]"));
            firstCell.Click();

            IWebElement numberButton = driver.FindElement(By.XPath("//button[contains(text(), '5')]"));
            numberButton.Click();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("5", firstCell.Text, "Number was not entered correctly.");
        }

        [Test]
        public void UndoMove()
        {
            IWebElement firstCell = driver.FindElement(By.XPath("//div[contains(@class, 'cell') and not(contains(@class, 'given'))]"));
            firstCell.Click();

            IWebElement numberButton = driver.FindElement(By.XPath("//button[contains(text(), '3')]"));
            numberButton.Click();

            IWebElement undoButton = driver.FindElement(By.XPath("//button[contains(text(), 'Undo')]"));
            undoButton.Click();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", firstCell.Text, "Undo did not remove the number.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
