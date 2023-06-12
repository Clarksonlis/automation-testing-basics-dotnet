using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SeleniumCsharp
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void VerifyLogo()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/sport/");
            IWebElement bbcIcon = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/nav/div[1]/div/div[1]/a"));

            // Проверяем, что иконка BBC присутствует на странице
            Assert.IsTrue(bbcIcon.Displayed, "BBC icon is not displayed.");
        }

        [Test]
        public void CheckSearchField()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/sport/");
            IWebElement searchField = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/nav/div[1]/div/div[3]/div[2]/a"));
            string currentUrl = driver.Url;

            // Кликаем на кнопку
            searchField.Click();

            // Получаем новый URL после клика
            string redirectedUrl = driver.Url;

            // Ожидаемый URL целевой страницы
            string expectedUrl = "https://www.bbc.co.uk/search?d=SPORT_GNL"; // Замените на фактический URL целевой страницы

            // Проверяем, что полученный URL соответствует ожидаемому URL
            Assert.AreEqual(expectedUrl, redirectedUrl, "Button does not redirect to the expected page.");
        }

        [Test]
        public void FindSportButton()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/sport/");
            IWebElement sportButton = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/div/div/div/div/a"));

            string currentUrl = driver.Url;

            // Кликаем на кнопку
            sportButton.Click();

            // Получаем новый URL после клика
            string redirectedUrl = driver.Url;

            // Ожидаемый URL целевой страницы
            string expectedUrl = "https://www.bbc.com/sport"; // Замените на фактический URL целевой страницы

            // Проверяем, что полученный URL соответствует ожидаемому URL
            Assert.AreEqual(expectedUrl, redirectedUrl, "Button does not redirect to the expected page.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}