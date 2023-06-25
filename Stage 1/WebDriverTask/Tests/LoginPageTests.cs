using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Tests;

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
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        driver = new ChromeDriver(path + @"\drivers\");
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
    public void TestLoginWithIncorrectCredentials()
    {
        // Вход в почту Яндекс с неправильными логином и паролем
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);

        loginPage.LoginUserNameYandex("DaryadaryaEpamTestt");

        //Проверка для невозможности входа входа
        Assert.IsTrue(loginPage.IsHintMessageDisplayedYandex(), "Error message must be displayed.");
    }

    [Test]
    public void TestLoginWithEmptyCredentials()
    {
        // Вход в почту Яндекс с пустым логином
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);

        loginPage.LoginUserNameYandex("");

        //Проверка для невозможности входа входа
        Assert.IsTrue(loginPage.IsHintMessageDisplayedYandex(), "Error message must be displayed");
    }   
}