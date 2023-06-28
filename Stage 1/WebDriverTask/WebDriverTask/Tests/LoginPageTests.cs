using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverTaskTests.Pages;

namespace WebDriverTaskTests.Tests;

[TestFixture]
public class LoginPageTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private DefaultWait<IWebDriver> wait;

    [SetUp]
    public void Setup()
    {
        // Инициализация веб-драйвера : Chrome
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));

        // Инициализация страницы
        loginPage = new LoginPage(driver, wait);
    }

    [TearDown]
    public void Cleanup()
    {
        // Закрытие веб-драйвера
        driver.Quit();
    }

    [Test]
    public void TestLoginWithCorrectCredentials()
    {
        // Вход в почту Яндекс с правильными логином и паролем
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);
        loginPage.LoginUserNameYandex(Constants.LoginYandex);
        loginPage.LoginPasswordYandex(Constants.Password);

        //Проверка для утверждения успешного входа
        Assert.IsTrue(loginPage.IsLoginDisplayedYandex(), "Login was not correct.");
    }

    [Test]
    [TestCase("DaryadaryaEpamTestt")]
    [TestCase("")]
    public void TestLoginWithIncorrectCredentials(string login)
    {
        // Вход в почту Яндекс с неправильными логином и паролем
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);

        loginPage.LoginUserNameYandex(login);

        //Проверка для невозможности входа входа
        Assert.IsTrue(loginPage.IsHintMessageDisplayedYandex(), "Error message must be displayed.");
    }
}