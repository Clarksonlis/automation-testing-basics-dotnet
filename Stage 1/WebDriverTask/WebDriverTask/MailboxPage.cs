using OpenQA.Selenium;
using Bogus;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

public class MailboxPage
{
    private IWebDriver driver;
    private Faker faker;
    private string randomEmail;
    private DefaultWait<IWebDriver> wait;

    public MailboxPage(IWebDriver driver, DefaultWait<IWebDriver> wait)
    {
        this.driver = driver;
        faker = new Faker();
        this.wait = wait;
    }

    // Определение элементов страницы почтового ящика : Яндекс 
    private IWebElement composeButtonYandex => driver.FindElement(By.CssSelector("a.Button2[href=\"#compose\"]"));
    private IWebElement recipientInputYandex => driver.FindElement(By.CssSelector("div#compose-field-1[title='Кому'][aria-label='Кому']"));
    private IWebElement randomEmailInputYandex => driver.FindElement(By.CssSelector("div#cke_1_contents [aria-label=\"Напишите что-нибудь\"][title=\"Напишите что-нибудь\"]"));
    private IWebElement sendButtonYandex => driver.FindElement(By.CssSelector("div.ComposeControlPanel-Part > div.new__root--3qgLa > button.Button2_view_action"));

    // Определение элементов страницы почтового ящика  : Google
    private IWebElement inboxEmailsGoogle => driver.FindElement(By.CssSelector("a[aria-label*='Входящие']"));
    private IWebElement newEmailGoogle => driver.FindElement(By.CssSelector("tr.zA.zE:first-child"));
    private IWebElement newEmailSenderGoogle => driver.FindElement(By.CssSelector("tr.zA.zE:first-child span[email='daryadaryaepamtest@yandex.ru']"));
    private IWebElement labelNewGoogle => driver.FindElement(By.XPath("//div[contains(text(), 'Новое')]"));
    private IWebElement emailContentGoogle => driver.FindElement(By.CssSelector("div.a3s.aiL > div:not(.yj6qo):not(.adL):not(:empty)"));
    private IWebElement replyButtonGoogle => driver.FindElement(By.CssSelector("div[aria-label='Ответить']"));
    private IWebElement responseEmailInputGoogle => driver.FindElement(By.CssSelector("div[aria-label='Текст письма']"));
    private IWebElement sendButtonGoogle => driver.FindElement(By.CssSelector("div[id^=':'][aria-label^='Отправить']"));

    public void SubmitNewEmailYandex()
    {
        // Нажатие кнопки "Написать письмо" : Яндекс 
        composeButtonYandex.Click();
    }

    public void ComposeNewEmailYandex(string recipient)
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("div#compose-field-1[title='Кому'][aria-label='Кому']")).Displayed);
        randomEmail = GenerateRandomEmail();

        // Заполнение поля получателя и ввода письма : Яндекс 
        recipientInputYandex.SendKeys(recipient);
        randomEmailInputYandex.SendKeys(randomEmail);
    }

    public void SendNewEmailYandex()
    {
        // Нажатие кнопки "Отправить" : Яндекс 
        sendButtonYandex.Click();
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div#compose-field-1[title='Кому'][aria-label='Кому']")));
    }

    public bool IsEmailReceivedGoogle(string sender)
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("a[aria-label*='Входящие']")).Displayed);

        inboxEmailsGoogle.Click();
        string senderName = newEmailSenderGoogle.GetAttribute("email");
        string labelNewText = labelNewGoogle.Text;

        // Проверка непрочитанного письма : Google
        if (senderName.Contains(sender) && labelNewText.Equals("Новое"))
        {
            newEmailGoogle.Click();

            return true;
        }

        return false;
    }

    public bool IsEmailCorrect()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("div[aria-label='Ответить']")).Displayed);

        string emailText = emailContentGoogle.Text;

        // Сравнение содержимого непрочитанного письма с randomEmail : Google
        if (emailText.Equals(randomEmail))
        {
            replyButtonGoogle.Click();

            return true;
        }

        return false;
    }

    public void ReadEmailAndSendResponse()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("div[aria-label='Текст письма']")).Displayed);

        string responseEmail = GenerateRandomEmail();

        // Составление и ввод ответного письма
        responseEmailInputGoogle.SendKeys(responseEmail);

        // Отправление ответного письма
        sendButtonGoogle.Click();
    }

    public bool IsEmailResponsedGoogle()
    {
        this.wait.Until(driver => driver.FindElement(By.CssSelector("div.vh > span.aT > span.bAq")).Displayed);

        return driver.FindElement(By.CssSelector("div.vh > span.aT > span.bAq")).Displayed;
    }

    public string GenerateRandomEmail()
    {
        return faker.Lorem.Paragraph();
    }
}