using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NIRVANA_AUTOMATION.src.Blocks
{
    public class HeaderBlock
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HeaderBlock(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        //All actions with Header should be described here
        public void ClickLoginButton()
        { 
            var Locators = new Locators(_driver);
            //For some reason it cant find Login button, added explicit wait
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@title='Login']")));
            Locators.LoginButton.Click();
        }
    }
}
