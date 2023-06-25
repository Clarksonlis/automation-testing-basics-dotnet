using OpenQA.Selenium;
using Bogus;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverTaskTests.Pages;

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
    private IWebElement ComposeButtonYandex => driver.FindElement(By.CssSelector("a.Button2[href=\"#compose\"]"));
    private IWebElement RecipientInputYandex => driver.FindElement(By.CssSelector("div#compose-field-1[title='Кому'][aria-label='Кому']"));
    private IWebElement RandomEmailInputYandex => driver.FindElement(By.CssSelector("div#cke_1_contents [aria-label=\"Напишите что-нибудь\"][title=\"Напишите что-нибудь\"]"));
    private IWebElement SendButtonYandex => driver.FindElement(By.CssSelector("div.ComposeControlPanel-Part > div.new__root--3qgLa > button.Button2_view_action"));

    // Определение элементов страницы почтового ящика  : Google
    private IWebElement InboxEmailsGoogle => driver.FindElement(By.CssSelector("a[aria-label*='Входящие']"));
    private IWebElement NewEmailGoogle => driver.FindElement(By.CssSelector("tr.zA.zE:first-child"));
    private IWebElement NewEmailSenderGoogle => driver.FindElement(By.CssSelector("tr.zA.zE:first-child span[email='daryadaryaepamtest@yandex.ru']"));
    private IWebElement LabelNewGoogle => driver.FindElement(By.XPath("//div[contains(text(), 'Новое')]"));
    private IWebElement EmailContentGoogle => driver.FindElement(By.CssSelector("div.a3s.aiL > div:not(.yj6qo):not(.adL):not(:empty)"));
    private IWebElement ReplyButtonGoogle => driver.FindElement(By.CssSelector("div[aria-label='Ответить']"));
    private IWebElement ResponseEmailInputGoogle => driver.FindElement(By.CssSelector("div[aria-label='Текст письма']"));
    private IWebElement SendButtonGoogle => driver.FindElement(By.CssSelector("div[id^=':'][aria-label^='Отправить']"));
    private IWebElement EmailIsSentGoogle => driver.FindElement(By.CssSelector("div.vh > span.aT > span.bAq"));

    public void SubmitNewEmailYandex()
    {
        // Нажатие кнопки "Написать письмо" : Яндекс 
        ComposeButtonYandex.Click();
    }

    public void ComposeNewEmailYandex(string recipient)
    {
        this.wait.Until(driver => RecipientInputYandex.Displayed);
        randomEmail = GenerateRandomEmail();

        // Заполнение поля получателя и ввода письма : Яндекс 
        RecipientInputYandex.SendKeys(recipient);
        RandomEmailInputYandex.SendKeys(randomEmail);
    }

    public void SendNewEmailYandex()
    {
        // Нажатие кнопки "Отправить" : Яндекс 
        SendButtonYandex.Click();
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div#compose-field-1[title='Кому'][aria-label='Кому']")));
    }

    public bool IsEmailReceivedGoogle(string sender)
    {
        this.wait.Until(driver => InboxEmailsGoogle.Displayed);

        InboxEmailsGoogle.Click();
        string senderName = NewEmailSenderGoogle.GetAttribute("email");
        string labelNewText = LabelNewGoogle.Text;

        // Проверка непрочитанного письма : Google
        if (senderName.Contains(sender) && labelNewText.Equals("Новое"))
        {
            NewEmailGoogle.Click();

            return true;
        }

        return false;
    }

    public bool IsEmailCorrect()
    {
        this.wait.Until(driver => ReplyButtonGoogle.Displayed);

        string emailText = EmailContentGoogle.Text;

        // Сравнение содержимого непрочитанного письма с randomEmail : Google
        if (emailText.Equals(randomEmail))
        {
            ReplyButtonGoogle.Click();

            return true;
        }

        return false;
    }

    public void ReadEmailAndSendResponse()
    {
        this.wait.Until(driver => ResponseEmailInputGoogle.Displayed);

        string responseEmail = GenerateRandomEmail();

        // Составление и ввод ответного письма
        ResponseEmailInputGoogle.SendKeys(responseEmail);

        // Отправление ответного письма
        SendButtonGoogle.Click();
    }

    public bool IsEmailResponsedGoogle()
    {
        this.wait.Until(driver => EmailIsSentGoogle.Displayed);

        return EmailIsSentGoogle.Displayed;
    }

    public string GenerateRandomEmail()
    {
        return faker.Lorem.Paragraph();
    }
}