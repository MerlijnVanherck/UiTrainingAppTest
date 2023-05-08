namespace hackathon_test;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class PopupsPageTests
{
    private readonly WebDriver driver = new ChromeDriver();

    [TestInitialize]
    public void OnTestInitialize()
    {
        driver.Url = "http://ui-training-application.s3-website-eu-west-1.amazonaws.com/popups";
        driver.Navigate();
    }

    [TestCleanup]
    public void OnTestCleanup()
    {
        driver.Dispose();
    }

    [TestMethod]
    public void ClosePopups()
    {
        var popupsPage = new PopupsPage(driver);
        var dancePage = new DancePage(driver);

        Assert.IsTrue(popupsPage.OnPage());

        Assert.IsTrue(popupsPage.CloseNumberOfPopups(9));

        Assert.IsTrue(popupsPage.IsButtonVisible());

        popupsPage.ClickButton();

        Assert.IsTrue(popupsPage.AreCoconutsVisible());

        popupsPage.ClickNumberOfCoconuts(15);

        Assert.IsTrue(popupsPage.IsButtonVisible());

        popupsPage.ClickButton();

        Assert.IsTrue(dancePage.OnPage());
    }
}