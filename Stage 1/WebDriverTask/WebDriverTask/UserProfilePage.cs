using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Bogus;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

public class UserProfilePage
{
    private IWebDriver driver;
    private DefaultWait<IWebDriver> wait;
    private Faker faker;
    private string randomLastName;

    public UserProfilePage(IWebDriver driver, DefaultWait<IWebDriver> wait)
    {
        this.driver = driver;
        faker = new Faker();
        this.wait = wait;
    }

    // Опреление элементов страницы профиля пользователя: Яндекс 
    private IWebElement UserButtonYandex => driver.FindElement(By.CssSelector("img.user-pic__image"));
    private IWebElement AccountSettingsButtonYandex => driver.FindElement(By.CssSelector("a.menu__item[href='https://passport.yandex.ru?'] span.menu__text"));
    private IWebElement AboutMeButtonYandex => driver.FindElement(By.CssSelector("a.Card_root__9eeMa[data-log*='page.home.personal-data-card']"));

    private IWebElement LastNameInputYandex => driver.FindElement(By.CssSelector("input[placeholder='Фамилия']"));
    private IWebElement SaveButtonYandex => driver.FindElement(By.CssSelector("button[data-testid='personal-data-submit']"));
    private IWebElement ChangeInfoButtonYandex => driver.FindElement(By.CssSelector("div[data-testid='profile-user-info'][role='button']"));

    public void TouchUserButton()
    {
        // Нажатие кнопки "User" : Яндекс браузер
        UserButtonYandex.Click();
    }

    public void TouchAccountSettingsButton()
    {
        this.wait.Until(driver => AccountSettingsButtonYandex.Displayed);

        // Нажатие кнопки "Настройки аккаунта" : Яндекс браузер
        AccountSettingsButtonYandex.Click();
    }

    public void TouchAboutMeButton()
    {
        this.wait.Until(driver => AboutMeButtonYandex.Displayed);

        // Нажатие кнопки "Обо мне" : Яндекс браузер
        AboutMeButtonYandex.Click();
    }

    public void ChangeNickname()
    {
        wait.Until(driver => LastNameInputYandex.Displayed);
        randomLastName = GenerateRandomLastName();

        // Изменение псевдонима пользователя : Яндекс браузер
        LastNameInputYandex.Clear();
        LastNameInputYandex.SendKeys(randomLastName);

        // Нажатие кнопки "Сохранить" : Яндекс браузер
        SaveButtonYandex.Click();

        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.Modal-Cell.Modal-Cell_align_middle")));
    }

    public bool IsNicknameChanged()
    {
        driver.Navigate().Refresh();
        wait.Until(driver => ChangeInfoButtonYandex.Displayed);

        // Проверка, изменился ли псевдоним пользователя : Яндекс браузер
        ChangeInfoButtonYandex.Click();

        wait.Until(driver => LastNameInputYandex.Displayed);
        string actualNickname = LastNameInputYandex.GetAttribute("value");

        return actualNickname.Equals(randomLastName);
    }

    public string GenerateRandomLastName()
    {
        return faker.Lorem.Word();
    }
}