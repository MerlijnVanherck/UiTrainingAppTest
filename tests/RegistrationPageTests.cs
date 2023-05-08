namespace hackathon_test;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

[TestClass]
public class RegistrationPageTests
{
    private readonly WebDriver driver = new ChromeDriver();

    [TestInitialize]
    public void OnTestInitialize()
    {
        driver.Url = "http://ui-training-application.s3-website-eu-west-1.amazonaws.com/registration";
        driver.Navigate();
    }

    [TestCleanup]
    public void OnTestCleanup()
    {
        driver.Dispose();
    }

    [TestMethod]
    public void Register()
    {
        var registrationPage = new RegistrationPage(driver);
        var popupsPage = new PopupsPage(driver);

        Assert.IsTrue(registrationPage.OnPage());

        registrationPage.EnterFirstName("Merlijn");
        registrationPage.EnterLastName("Vanherck");
        registrationPage.EnterPhoneNumber("0489394506");
        registrationPage.EnterAttendees("2");
        registrationPage.EnterEmail("merlijn.vanherck@bignited.be");
        registrationPage.ClickRegister();

        Assert.IsTrue(popupsPage.OnPage());
    }
}