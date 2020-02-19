using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
namespace NIRVANA_AUTOMATION.src
{
    public class Base
    {
        public IWebDriver _driver { get; private set; }

        public void TestInitBase()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            {
                Url = "https://nj.betamerica.com"
            };
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }

        public void CleanUpBase()
        {
            _driver.Quit();
        }
    }
}
