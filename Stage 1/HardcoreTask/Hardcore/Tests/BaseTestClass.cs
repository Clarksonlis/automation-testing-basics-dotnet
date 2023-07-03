using Hardcore.Tests.Bots;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Hardcore.Tests.Configuration;
using System;
using Microsoft.Extensions.Configuration;

namespace Hardcore.Tests.Tests
{
    [TestFixture]
    public class BaseTestClass
    {
        protected IWebDriver _driver;
        protected ActionBot _actionBot;
        protected DefaultWait<IWebDriver> _wait;
        protected ITakesScreenshot takesScreenshot;

        private readonly IConfiguration _config;

        public BaseTestClass()
        {
            // Инициализация конфигурации
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _config = configBuilder.Build();
        }

        [SetUp]
        public virtual void Setup()
        {
            this._driver = GetDriver();
            this._wait = this.GetWaiter();
            this._actionBot = this.GetActionBot();
            this._driver.Manage().Window.Maximize();
            takesScreenshot = (ITakesScreenshot)this._driver;
        }

        protected IWebDriver GetDriver()
        {
            BrowserType browserType = Enum.Parse<BrowserType>(_config["Browser"]);
            return Managers.WebDriverManager.GetWebDriver(browserType);
        }

        protected DefaultWait<IWebDriver> GetWaiter()
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
        }

        protected ActionBot GetActionBot()
        {
            return new ActionBot(this._driver, this._wait);
        }

        [TearDown]
        public virtual void TearDown()
        {
            // Завершение работы WebDriver
            _driver.Quit();
        }
    }
}