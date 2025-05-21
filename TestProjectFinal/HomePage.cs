using OpenQA.Selenium;

public class HomePage

{

    private readonly IWebDriver driver;

    // Locators

    private readonly By logoutButton = By.Id("logout_sidebar_link");

    private readonly By navigationBar = By.Id("react-burger-menu-btn");

    private readonly By homeLink = By.ClassName("header_label");

    public readonly By footer = By.ClassName("footer");

    // Constructor

    public HomePage(IWebDriver driver)

    {

        this.driver = driver;

    }

    // Actions

    public void ClickLogout() => driver.FindElement(logoutButton).Click();

    public void ClickBurgerMenu () => driver.FindElement(navigationBar).Click();

    public bool IsNavigationDisplayed() => driver.FindElement(navigationBar).Displayed;

    public void ClickHomeLink() => driver.FindElement(homeLink).Click();

    public bool IsLogoutButtonVisible() => driver.FindElement(logoutButton).Displayed;

    public void ElementFooter() => driver.FindElement(footer);
        
    public bool IsFooterDisplayed() => driver.FindElement(footer).Displayed;
    
    public bool IsHamburgerMenuVisible() => driver.FindElement(By.Id("react-burger-menu-btn")).Displayed;

}

