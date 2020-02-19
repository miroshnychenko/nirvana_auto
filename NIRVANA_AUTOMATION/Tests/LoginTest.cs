using System;
using NIRVANA_AUTOMATION.src;
using NIRVANA_AUTOMATION.src.Blocks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NIRVANA_AUTOMATION
{
    public class Tests
    {
        [TestFixture]
        public class LoginTest
        {
            public IWebDriver _driver;
            public LoginBlock LoginBlock;
            public HeaderBlock HeaderBlock;
            public WebDriverWait _wait;
            public Locators Locators;

            [SetUp]
            public void SetUp()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _driver.Navigate().GoToUrl("https://nj.betamerica.com");
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                HeaderBlock = new HeaderBlock(_driver, _wait);
                LoginBlock = new LoginBlock(_driver);
                Locators = new Locators(_driver);
            }

            [TearDown]
            public void TearDown()
            {
                _driver.Quit();
                _driver = null;
            }


            [Test]
            public void LoginWithValidCredentials()
            {
                //Click on Login button
                HeaderBlock.ClickLoginButton();
                //Login with credential (see method in LoginBlock.cs)
                LoginBlock.DoLogin("SBTest8v3dot9", "Sb123456");
                //Check if Inbox button is present. Would be good to have more cheks, this is just first element found in Locators (Balance element, Deposit button, etc.)
                Assert.True(Locators.InboxButtonInHeader.Displayed);
            }

            [Test]
            public void LoginWithInalidCredentials()
            { 
                //Click on Login button
                HeaderBlock.ClickLoginButton();
                //Login with credential (see method in LoginBlock.cs)
                LoginBlock.DoLogin("qqwwee332211", "12345678");
                Assert.True(Locators.LoginError.Displayed);
                Assert.AreEqual("Username and Password do not match", Locators.LoginError.Text);
            }
        }
    }
}