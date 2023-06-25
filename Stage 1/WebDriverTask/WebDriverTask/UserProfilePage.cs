using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

public class UserProfilePage
{
    private IWebDriver driver;
    private DefaultWait<IWebDriver> wait;


    public UserProfilePage(IWebDriver driver, DefaultWait<IWebDriver> wait)
    {
        this.driver = driver;
        this.wait = wait;
    }

    // Опреление элементов страницы профиля пользователя: Яндекс 
    private IWebElement userButtonYandex => driver.FindElement(By.CssSelector("img.user-pic__image"));
    private IWebElement accountSettingsButtonYandex => driver.FindElement(By.CssSelector("a.menu__item[href='https://passport.yandex.ru?'] span.menu__text"));
    private IWebElement aboutMeButtonYandex => driver.FindElement(By.CssSelector("a.Card_root__9eeMa[data-log*='page.home.personal-data-card']"));

    private IWebElement lastNameInputYandex => driver.FindElement(By.CssSelector("input[placeholder='Фамилия']"));
    private IWebElement saveButtonYandex => driver.FindElement(By.CssSelector("button[data-testid='personal-data-submit']"));
    private IWebElement changeInfoButtonYandex => driver.FindElement(By.CssSelector("div[data-testid='profile-user-info'][role='button']"));

    public void TouchUserButton()
    {
        // Нажатие кнопки "User" : Яндекс браузер
        userButtonYandex.Click();
    }

    public void TouchAccountSettingsButton()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("a.menu__item[href='https://passport.yandex.ru?'] span.menu__text")).Displayed);

        // Нажатие кнопки "Настройки аккаунта" : Яндекс браузер
        accountSettingsButtonYandex.Click();
    }

    public void TouchAboutMeButton()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("a.Card_root__9eeMa[data-log*='page.home.personal-data-card']")).Displayed);

        // Нажатие кнопки "Обо мне" : Яндекс браузер
        aboutMeButtonYandex.Click();
    }

    public void ChangeNickname(string newLastName)
    {
        wait.Until(driver => driver.FindElement(By.CssSelector("input[placeholder='Фамилия']")).Displayed);

        // Изменение псевдонима пользователя : Яндекс браузер
        lastNameInputYandex.Clear();
        lastNameInputYandex.SendKeys(newLastName);

        // Нажатие кнопки "Сохранить" : Яндекс браузер
        saveButtonYandex.Click();

        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.Modal-Cell.Modal-Cell_align_middle")));
    }

    public bool IsNicknameChanged(string expectedNickname)
    {
        // Проверка, изменился ли псевдоним пользователя : Яндекс браузер
        changeInfoButtonYandex.Click();

        wait.Until(driver => driver.FindElement(By.CssSelector("input[placeholder='Фамилия']")).Displayed);
        string actualNickname = lastNameInputYandex.GetAttribute("value");

        return actualNickname.Equals(expectedNickname);
    }
}