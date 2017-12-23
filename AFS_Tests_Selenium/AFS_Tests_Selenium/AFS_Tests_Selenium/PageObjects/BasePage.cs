using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium.PageObjects
{
    public class BasePage
    {
        private IWebDriver driver;
        protected static String applicationPort = "9780";
        protected static String host = "nexus-trunk";
        //protected static String BaseUrl = "http://" + host;
        protected static String protocol = "http";

        

        public static void openPage(String pageName)
        {
            PropertyCollection.driver.Navigate().GoToUrl(getServerUrl() + pageName);
        }


        public IWebDriver getWebDriver()
        {
            return driver;
        }

        public static String getServerUrl()
        {
            return protocol + "://" + host + ":" + applicationPort;
        }
    }
}
