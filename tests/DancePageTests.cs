namespace hackathon_test;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class DancePageTests
{
    private readonly WebDriver driver = new ChromeDriver();

    [TestInitialize]
    public void OnTestInitialize()
    {
        driver.Url = "http://ui-training-application.s3-website-eu-west-1.amazonaws.com/dance";
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
        var dancePage = new DancePage(driver);

        Assert.IsTrue(dancePage.OnPage());

        Assert.IsTrue(dancePage.IsKongVisible());
        Assert.IsFalse(dancePage.IsBananaVisible());

        dancePage.ClickKong();
        
        Assert.IsTrue(dancePage.IsBananaVisible());
    }
}