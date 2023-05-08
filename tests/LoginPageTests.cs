namespace hackathon_test;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class LoginPageTests
{
    private readonly WebDriver driver = new ChromeDriver();

    [TestInitialize]
    public void OnTestInitialize()
    {
        driver.Url = "http://ui-training-application.s3-website-eu-west-1.amazonaws.com/";
        driver.Navigate();
    }

    [TestCleanup]
    public void OnTestCleanup()
    {
        driver.Dispose();
    }

    [TestMethod]
    public void LogIn()
    {
        var loginPage = new LoginPage(driver);
        var registrationPage = new RegistrationPage(driver);

        Assert.IsTrue(loginPage.OnPage());
        
        loginPage.EnterUsername("admin");
        loginPage.EnterPassword("admin");
        loginPage.ClickLogin();

        Assert.IsTrue(registrationPage.OnPage());
    }
}