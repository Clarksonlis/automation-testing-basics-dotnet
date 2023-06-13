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
            // Находим элемент по локаторам:

            //CssSelector:
            //IWebElement bbcIcon = driver.FindElement(By.CssSelector("#header-content > div > div > div > div > a"));

            //ClassName:
            //IWebElement bbcIcon = driver.FindElement(By.ClassName("ssrcss-dkv2k4-NavigationLink-LogoLink"));

            //XPath:
            IWebElement bbcIcon = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/nav/div[1]/div/div[1]/a"));


            // Проверяем, что иконка BBC присутствует на странице
            Assert.IsTrue(bbcIcon.Displayed, "BBC icon is not displayed.");

        }

        [Test]
        public void CheckSearchField()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/sport/");

            // Находим элемент по локаторам:
            //CssSelector:
            //IWebElement searchField = driver.FindElement(By.CssSelector("#header-content > nav > div.ssrcss-1ocoo3l-Wrap.e42f8511 > div > div.ssrcss-69nf57-LastGlobalNavigationItem.e1gviwgp24 > div.ssrcss-1j3alh1-GlobalNavigationItem.e1gviwgp23 > a"));

            //ClassName:
            //IWebElement searchField = driver.FindElement(By.ClassName("ssrcss-tvuym4-NavigationLink-SearchLink"));

            //XPath:
            IWebElement searchField = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/nav/div[1]/div/div[3]/div[2]/a"));

            string currentUrl = driver.Url;

            // Кликаем на кнопку
            searchField.Click();

            // Получаем новый URL после клика
            string redirectedUrl = driver.Url;

            // Ожидаемый URL целевой страницы
            string expectedUrl = "https://www.bbc.co.uk/search?d=SPORT_GNL";

            // Проверяем, что полученный URL соответствует ожидаемому URL
            Assert.AreEqual(expectedUrl, redirectedUrl, "Button does not redirect to the expected page.");
        }

        [Test]
        public void FindSportButton()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/sport/");

            // Находим элемент по локаторам:
            //CssSelector:
            //IWebElement sportButton = driver.FindElement(By.CssSelector("#header-content > div > div > div > div > a"));

            //ClassName:
            //IWebElement sportButton = driver.FindElement(By.ClassName("ssrcss-1vyfvn-LogoLink"));

            //XPath:
            IWebElement sportButton = driver.FindElement(By.XPath("//*[@id=\"header-content\"]/div/div/div/div/a"));

            string currentUrl = driver.Url;

            // Кликаем на кнопку
            sportButton.Click();

            // Получаем новый URL после клика
            string redirectedUrl = driver.Url;

            // Ожидаемый URL целевой страницы
            string expectedUrl = "https://www.bbc.com/sport"; 

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