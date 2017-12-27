using AFS_Tests_Selenium.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium
{
    public class BaseTest
    {
        protected NavigationPanel navPanel;
        protected HomePage homePage;
        protected String fileDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        protected String userName;
        protected String password;
        public static String pathToClassFile = AppDomain.CurrentDomain.BaseDirectory;

        [TestInitialize()]
        public void Startup()
        {
            if (PropertyCollection.driver == null)
                PropertyCollection.driver = new ChromeDriver();
            navPanel = new NavigationPanel(PropertyCollection.driver);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            if (homePage != null)
            {
                homePage.logOut();
            }
            PropertyCollection.driver.Close();
            if (PropertyCollection.driver != null)
            {
                PropertyCollection.driver = null;
            }
            if (navPanel != null)
            {
                navPanel = null;
            }

            //PropertyCollection.driver.Quit();
        }
        

        protected TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public String getCredentialsFromFile(string columnHeading)
        {
            return TestContext.DataRow[columnHeading].ToString();
        }

        public bool isElementPresent(IWebElement element)
        {
            bool isElementPresent = false;
            int _seconds = 10;
            for(int i = 1; i <= _seconds; i++)
            {
                Thread.Sleep(1000);
                if(element.Displayed & element.Enabled)
                {
                    isElementPresent = true;
                }
                else
                {
                    isElementPresent = false;
                    if(i == 10)
                    {
                        throw new TimeoutException("Couldn't find element for 10 sec");
                    }
                }                
            }
            return isElementPresent;
        }
    }
}
