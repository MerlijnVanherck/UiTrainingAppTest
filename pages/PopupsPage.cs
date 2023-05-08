using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace hackathon_test;

internal class PopupsPage
{
    private readonly IWebDriver Driver;

    public static By PopupsSelector { get; } = By.TagName("app-pop-ups");
    public static By ClosePopupSelector { get; } = By.XPath("//*[contains(@id, 'button-close-')]");
    public static By HappyButtonSelector { get; } = By.XPath("//*[@data-cy='login']");
    public static By CoconutSelector { get; } = By.XPath("//*[@class='snow']/img");

    public PopupsPage(IWebDriver driver)
    {
        Driver = driver;
    }

    internal bool CloseNumberOfPopups(int number, int maxAttempts = 100)
    {
        var successfull = true;
        int attempts = 0;

        for (int i = 0; i < number; attempts++)
        {
            successfull = ClosePopup();

            if (successfull)
                i++;

            if (attempts > maxAttempts)
                return false;
        }
        
        return successfull;
    }

    internal bool ClosePopup()
    {
        ICollection<IWebElement> closeIcons;

        try
        {
            closeIcons = Driver.FindElements(ClosePopupSelector);
        }
        catch (NoSuchElementException)
        {
            return false;
        }

        foreach (var icon in closeIcons)
        {
            try
            {
                icon.Click();
                icon.Click();
            }
            catch (ElementClickInterceptedException)
            {
                continue;
            }
            catch (ElementNotInteractableException)
            {
                continue;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }

        return false;
    }

    internal bool IsButtonVisible()
    {        
        try
        {
            return Driver.FindElement(HappyButtonSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    internal void ClickButton()
    {
        Driver.FindElement(HappyButtonSelector).Click();
    }

    internal bool AreCoconutsVisible()
    {    
        try
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            wait.Until(d => d.FindElement(CoconutSelector).Displayed);
            
            return Driver.FindElement(CoconutSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    
    internal bool ClickNumberOfCoconuts(int number)
    {
        var successfull = true;

        for (int i = 0; i < number; i++)
        {
            successfull = ClickCoconut();

            if (!successfull)
                break;
        }
        
        return successfull;
    }

    internal bool ClickCoconut()
    {
        ICollection<IWebElement> coconuts;

        try
        {
            coconuts = Driver.FindElements(CoconutSelector);
        }
        catch (NoSuchElementException)
        {
            return false;
        }

        foreach (var icon in coconuts)
        {
            try
            {
                icon.Click();
                return true;
            }
            catch (ElementClickInterceptedException)
            {
                continue;
            }
        }

        return false;
    }

    internal bool OnPage()
    {
        TimeSpan oldTimeSpan = Driver.Manage().Timeouts().ImplicitWait;

        try
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            return Driver.FindElement(PopupsSelector).Displayed;
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
