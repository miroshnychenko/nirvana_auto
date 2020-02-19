using System;
using OpenQA.Selenium;

namespace NIRVANA_AUTOMATION.src.Blocks
{
    public class LoginBlock
    {
        private IWebDriver _driver;

        public LoginBlock(IWebDriver driver)
        {
            _driver = driver;
        }

        //All actions with Login block should be described here
        public void EnterUsername(String userName)
        {
            var Locators = new Locators(_driver);

            Locators.Username.Click();
            Locators.Username.SendKeys(userName);
        }

        public void EnterPassword(String password)
        {
            var Locators = new Locators(_driver);
            Locators.Password.Click();
            Locators.Password.SendKeys(password);
        }

        public void SubmitLoginForm()
        {
            var Locators = new Locators(_driver);
            Locators.LoginButtonSubmit.Click();
        }

        public void DoLogin(String username, String password)
        {
            EnterUsername(username);
            EnterPassword(password);
            SubmitLoginForm();
        }
    }
}
