using OpenQA.Selenium;

namespace hackathon_test;

internal class LoginPage
{
    private readonly IWebDriver Driver;

    public static By LoginFormSelector { get; } = By.TagName("app-login");
    public static By UsernameSelector { get; } = By.XPath("//*[@data-cy='user-name']");
    public static By PasswordSelector { get; } = By.XPath("//*[@data-cy='password']");
    public static By LoginButtonSelector { get; } = By.Id("login-button");

    public LoginPage(IWebDriver driver)
    {
        Driver = driver;
    }

    internal void EnterUsername(string username)
    {
        Driver.FindElement(UsernameSelector).SendKeys(username);
    }

    internal void EnterPassword(string password)
    {
        Driver.FindElement(PasswordSelector).SendKeys(password);
    }

    internal void ClickLogin()
    {
        Driver.FindElement(LoginButtonSelector).Click();
    }

    internal bool OnPage()
    {
        TimeSpan oldTimeSpan = Driver.Manage().Timeouts().ImplicitWait;

        try
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            return Driver.FindElement(LoginFormSelector).Displayed;
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
