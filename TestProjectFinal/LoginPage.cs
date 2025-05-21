using OpenQA.Selenium;

public class LoginPage

{

    private readonly IWebDriver driver;

    // Locators

    private readonly By usernameField = By.Id("user-name");

    private readonly By passwordField = By.Id("password");

    private readonly By loginButton = By.Id("login-button");

    private readonly By errorMessage = By.CssSelector("h3[data-test='error']");

    // Constructor

    public LoginPage(IWebDriver driver)

    {

        this.driver = driver;

    }

    // Actions

    public void EnterUsername(string username) => driver.FindElement(usernameField).SendKeys(username);

    public void EnterPassword(string password) => driver.FindElement(passwordField).SendKeys(password);

    public void ClickLogin() => driver.FindElement(loginButton).Click();

    public string GetErrorMessage() => driver.FindElement(errorMessage).Text;

    public bool IsAtLoginPage()
    {
        return driver.FindElement(loginButton).Displayed;
    }

}