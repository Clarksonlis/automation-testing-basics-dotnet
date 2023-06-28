using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverTaskTests.Pages;

namespace WebDriverTaskTests.Tests;

[TestFixture]
public class MailBoxTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private MailboxPage mailboxPage;
    private DefaultWait<IWebDriver> wait;


    [SetUp]
    public void Setup()
    {
        // Инициализация веб-драйвера : Chrome
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));

        // Инициализация страниц
        loginPage = new LoginPage(driver, wait);
        mailboxPage = new MailboxPage(driver, wait);
    }

    [TearDown]
    public void Cleanup()
    {
        // Закрытие веб-драйвера
        driver.Quit();
    }

    [Test]
    public void TestWriteNewEmailAndSendResponseEmail()
    {
        // Вход в почту Яндекс
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);

        loginPage.LoginUserNameYandex(Constants.LoginYandex);
        loginPage.LoginPasswordYandex(Constants.Password);
        loginPage.IsLoginDisplayedYandex();

        // Составление и отправка письма на сервис Google
        mailboxPage.SubmitNewEmailYandex();
        mailboxPage.ComposeNewEmailYandex(Constants.LoginGoogle);
        mailboxPage.SendNewEmailYandex();

        // Вход в почту Google
        driver.Navigate().GoToUrl(Constants.BaseUrlGoogle);

        loginPage.LoginUserNameGoogle(Constants.LoginGoogle);
        loginPage.LoginPasswordGoogle(Constants.Password);

        // Проверка непрочитанного письма
        mailboxPage.IsEmailReceivedGoogle(Constants.LoginYandex);
        mailboxPage.IsEmailCorrect();

        //Проверка текста письма и отправка ответа
        mailboxPage.ReadEmailAndSendResponse();

        //Проверка отправки письма
        Assert.IsTrue(mailboxPage.IsEmailResponsedGoogle(), "Message delivery error.");
    }
}