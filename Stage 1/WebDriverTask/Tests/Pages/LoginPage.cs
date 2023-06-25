using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTaskTests.Pages;

public class LoginPage
{
    private IWebDriver driver;
    private DefaultWait<IWebDriver> wait;

    public LoginPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
    {
        this.driver = driver;
        this.wait = wait;
    }

    // Определение элементов страницы почтового ящика  : Яндекс 
    private IWebElement UsernameInputYandex => driver.FindElement(By.Id("passp-field-login"));
    private IWebElement LoginButtonYandex => driver.FindElement(By.Id("passp:sign-in"));
    private IWebElement PasswordInputYandex => driver.FindElement(By.Id("passp-field-passwd"));
    private IWebElement UserIconYandex => driver.FindElement(By.CssSelector("img.user-pic__image"));
    private IWebElement ErrorLoginLabelYandex => driver.FindElement(By.Id("field:input-login:hint"));

    // Определение элементов страницы почтового ящика  : Google
    private IWebElement UsernameInputGoogle => driver.FindElement(By.Id("identifierId"));
    private IWebElement LoginButtonGoogle => driver.FindElement(By.CssSelector("div.FliLIb#identifierNext div.VfPpkd-dgl2Hf-ppHlrf-sM5MNb button.VfPpkd-LgbsSe"));
    private IWebElement PasswordInputGoogle => driver.FindElement(By.CssSelector("input[type='password']"));
    private IWebElement NextButtonGoogle => driver.FindElement(By.CssSelector("div.FliLIb#passwordNext div.VfPpkd-dgl2Hf-ppHlrf-sM5MNb button.VfPpkd-LgbsSe"));


    public void LoginUserNameYandex(string username)
    {
        this.wait.Until(driver => LoginButtonYandex.Displayed);

        // Ввод логина : Яндекс 
        UsernameInputYandex.SendKeys(username);
        LoginButtonYandex.Click();
    }

    public void LoginUserNameGoogle(string username)
    {
        this.wait.Until(driver => UsernameInputGoogle.Displayed);

        // Ввод логина : Google 
        UsernameInputGoogle.SendKeys(username);
        LoginButtonGoogle.Click();
    }

    public void LoginPasswordYandex(string password)
    {
        this.wait.Until(driver => PasswordInputYandex.Displayed);

        // Ввод пароля : Яндекс 
        PasswordInputYandex.SendKeys(password);
        LoginButtonYandex.Click();
    }

    public void LoginPasswordGoogle(string password)
    {
        this.wait.Until(driver => PasswordInputGoogle.Displayed);

        // Ввод пароля : Google 
        PasswordInputGoogle.SendKeys(password);
        NextButtonGoogle.Click();
    }

    public bool IsLoginDisplayedYandex()
    {
        this.wait.Until(driver => UserIconYandex.Displayed);

        return UserIconYandex.Displayed;
    }

    public bool IsHintMessageDisplayedYandex()
    {
        this.wait.Until(driver => ErrorLoginLabelYandex.Displayed);

        return ErrorLoginLabelYandex.Displayed;
    }
}