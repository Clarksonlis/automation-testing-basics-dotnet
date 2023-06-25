using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Tests;

[TestFixture]
public class UserProfilePageTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private UserProfilePage userProfilePage;
    private DefaultWait<IWebDriver> wait;

    [SetUp]
    public void Setup()
    {
        // Инициализация веб-драйвера : Chrome
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        driver = new ChromeDriver(path + @"\drivers\");
        driver.Manage().Window.Maximize();
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));

        // Инициализация страниц
        loginPage = new LoginPage(driver, wait);
        userProfilePage = new UserProfilePage(driver, wait);
    }

    [TearDown]
    public void Cleanup()
    {
        // Закрытие веб-драйвера
        driver.Quit();
    }

    [Test]
    public void TestChangeNickname()
    {
        // Вход в почту Яндекс
        driver.Navigate().GoToUrl(Constants.BaseUrlYandex);

        loginPage.LoginUserNameYandex(Constants.LoginYandex);
        loginPage.LoginPasswordYandex(Constants.Password);
        loginPage.IsLoginDisplayedYandex();

        // Переход на страницу настроек
        userProfilePage.TouchUserButton();
        userProfilePage.TouchAccountSettingsButton();
        userProfilePage.TouchAboutMeButton();

        // Изменение псевдонима(фамилии) пользователя
        userProfilePage.ChangeNickname(Constants.NewLastName);

        // Проверка, что псевдоним изменился
        Assert.IsTrue(userProfilePage.IsNicknameChanged(Constants.NewLastName), "Nickname change error.");
    }
}