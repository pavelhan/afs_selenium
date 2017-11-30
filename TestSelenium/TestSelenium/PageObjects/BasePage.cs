using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.PageObjects
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        protected static String applicationPort = ":9780";
        private static String host = "nexus-server-tr";
        protected static String BaseUrl = "http://" + host;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public abstract void openPage();

        
        public IWebDriver getWebDriver()
        {
            return driver;
        }
    }
}
