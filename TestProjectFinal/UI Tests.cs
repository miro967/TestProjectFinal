using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

[TestFixture]
public class tests
{
#pragma warning disable CA1859 
#pragma warning disable NUnit1032 
    private IWebDriver driver;
#pragma warning restore NUnit1032 
#pragma warning restore CA1859 
    private LoginPage loginPage;
    private HomePage homePage;


    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        loginPage = new LoginPage(driver);
        homePage = new HomePage(driver);
    }

    [Test]
    public void TC01_ValidLogin_NavigatesToHomePage()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        Assert.That(homePage.IsNavigationDisplayed(), "Navigation bar should be visible after login.");
    }

    [Test]
    public void TC02_InvalidUserName_WrongPassword_ShowErrorMessage()
    {
        loginPage.EnterUsername("invalidUser");
        loginPage.EnterPassword("wrongPassword");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    }

    [Test]
    public void TC03_MissingPassword_ShowsErrorMessage()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Password is required"));
    }

    [Test]
    public void TC04_MissingUserName_ShowsErrorMessage()
    {
        loginPage.EnterUsername("");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Username is required"));
    }

    [Test]
    public void TC05_InvalidUsername_ShowsErrorMessage()
    {
        loginPage.EnterUsername("invalidUser");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
    }

    [Test]
    public void TC06_MissingCredentials_ShowsErrorMessage()
    {
        loginPage.EnterUsername("");
        loginPage.EnterPassword("");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Username is required"));
    }

    [Test]
    public void TC07_LockedOutUser_ShouldShowError()
    {
        loginPage.EnterUsername("locked_out_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        string error = loginPage.GetErrorMessage();
        Assert.That(error, Is.EqualTo("Epic sadface: Sorry, this user has been locked out.")); 
    }

    [Test]
    public void TC08_LogoutButtonVisible_AfterMenuClick()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();
        homePage.ClickBurgerMenu();

        Thread.Sleep(1000);
        Assert.That(homePage.IsLogoutButtonVisible(), "Logout button should be displayed.");
    }

    [Test]
    public void TC09_FooterIsVisible_OnHomePage()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();
        Actions action = new Actions(driver);
        action.MoveToElement(driver.FindElement(homePage.footer));

        Assert.That(homePage.IsFooterDisplayed(), "Footer should be visible on the page.");
    }

    [Test]
    public void TC10_HamburgerMenu_ShouldAppearOnSmallScreens()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();
        Thread.Sleep(1000);
        driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
        Assert.That(homePage.IsHamburgerMenuVisible(), "Hamburger menu should be visible on small screen.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}