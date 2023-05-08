using OpenQA.Selenium;

namespace hackathon_test;

internal class RegistrationPage
{
    private readonly IWebDriver Driver;

    public static By RegistrationFormSelector { get; } = By.TagName("app-registration");
    public static By FirstNameSelector { get; } = By.XPath("//*[@data-cy='user-name']");
    public static By LastNameSelector { get; } = By.XPath("//*[@data-cy='lastName']");
    public static By PhoneNumberSelector { get; } = By.XPath("//*[@data-cy='phone']");
    public static By AttendeesSelector { get; } = By.XPath("//*[@data-cy='attendees']");
    public static By EmailSelector { get; } = By.XPath("//*[@data-cy='email']");
    public static By RegisterButtonSelector { get; } = By.XPath("//*[@data-cy='login']");

    public RegistrationPage(IWebDriver driver)
    {
        Driver = driver;
    }

    internal void EnterFirstName(string firstName)
    {
        Driver.FindElement(FirstNameSelector).SendKeys(firstName);
    }

    internal void EnterLastName(string lastName)
    {
        Driver.FindElement(LastNameSelector).SendKeys(lastName);
    }

    internal void EnterPhoneNumber(string phoneNumber)
    {
        Driver.FindElement(PhoneNumberSelector).SendKeys(phoneNumber);
    }

    internal void EnterAttendees(string attendees)
    {
        Driver.FindElement(AttendeesSelector).SendKeys(attendees);
    }

    internal void EnterEmail(string email)
    {
        Driver.FindElement(EmailSelector).SendKeys(email);
    }

    internal void ClickRegister()
    {
        Driver.FindElement(RegisterButtonSelector).Click();
    }

    internal bool OnPage()
    {
        TimeSpan oldTimeSpan = Driver.Manage().Timeouts().ImplicitWait;

        try
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            return Driver.FindElement(RegistrationFormSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        finally
        {
            Driver.Manage().Timeouts().ImplicitWait = oldTimeSpan;
        }
    }
}
