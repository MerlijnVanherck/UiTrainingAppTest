using OpenQA.Selenium;

namespace hackathon_test;

internal class DancePage
{
    private readonly IWebDriver Driver;

    public static By MonkeySelector { get; } = By.TagName("app-monkey");
    public static By KongSelector { get; } = By.XPath("//*[@data-cy='kong']");
    public static By BananaSelector { get; } = By.XPath("//*[@data-cy='banana']");

    public DancePage(IWebDriver driver)
    {
        Driver = driver;
    }

    internal void ClickKong()
    {
        Driver.FindElement(KongSelector).Click();
    }

    internal bool IsKongVisible()
    {        
        try
        {
            return Driver.FindElement(KongSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    internal bool IsBananaVisible()
    {        
        try
        {
            return Driver.FindElement(BananaSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    internal bool OnPage()
    {
        TimeSpan oldTimeSpan = Driver.Manage().Timeouts().ImplicitWait;

        try
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            return Driver.FindElement(MonkeySelector).Displayed;
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
