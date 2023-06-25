using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
    private IWebElement usernameInputYandex => driver.FindElement(By.Id("passp-field-login"));
    private IWebElement loginButtonYandex => driver.FindElement(By.Id("passp:sign-in"));
    private IWebElement passwordInputYandex => driver.FindElement(By.Id("passp-field-passwd"));

    // Определение элементов страницы почтового ящика  : Google
    private IWebElement usernameInputGoogle => driver.FindElement(By.Id("identifierId"));
    private IWebElement loginButtonGoogle => driver.FindElement(By.CssSelector("div.FliLIb#identifierNext div.VfPpkd-dgl2Hf-ppHlrf-sM5MNb button.VfPpkd-LgbsSe"));
    private IWebElement passwordInputGoogle => driver.FindElement(By.CssSelector("input[type='password']"));
    private IWebElement nextButtonGoogle => driver.FindElement(By.CssSelector("div.FliLIb#passwordNext div.VfPpkd-dgl2Hf-ppHlrf-sM5MNb button.VfPpkd-LgbsSe"));


    public void LoginUserNameYandex(string username)
    {
        this.wait.Until(driver => driver.FindElement(By.Id("passp:sign-in")).Displayed);

        // Ввод логина : Яндекс 
        usernameInputYandex.SendKeys(username);
        loginButtonYandex.Click();
    }

    public void LoginUserNameGoogle(string username)
    {
        this.wait.Until(driver => driver.FindElement(By.Id("identifierId")).Displayed);

        // Ввод логина : Google 
        usernameInputGoogle.SendKeys(username);
        loginButtonGoogle.Click();
    }

    public void LoginPasswordYandex(string password)
    {
        this.wait.Until(driver => driver.FindElement(By.Id("passp-field-passwd")).Displayed);

        // Ввод пароля : Яндекс 
        passwordInputYandex.SendKeys(password);
        loginButtonYandex.Click();
    }

    public void LoginPasswordGoogle(string password)
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("input[type='password']")).Displayed);

        // Ввод пароля : Google 
        passwordInputGoogle.SendKeys(password);
        nextButtonGoogle.Click();
    }

    public bool IsLoginDisplayedYandex()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("img.user-pic__image")).Displayed);

        return driver.FindElement(By.CssSelector("img.user-pic__image")).Displayed;
    }

    public bool IsHintMessageDisplayedYandex()
    {
        this.wait.Until(driver => driver.FindElement(By.Id("field:input-login:hint")).Displayed);

        return driver.FindElement(By.Id("field:input-login:hint")).Displayed;
    }
}