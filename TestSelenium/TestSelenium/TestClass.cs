using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestSelenium.PageObjects;


namespace TestSelenium
{
    public class TestClass
    {
        /*public static IWebDriver driver = new ChromeDriver();

        

        [Test]
        public void myFirstTest()
        {
            driver.Navigate().GoToUrl("http://google.com");
            Assert.AreEqual("Google",driver.Title);

            driver.Close();
            driver.Quit();
        }

    */
        [Test]
        public void Login()
        {
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            loginPage.goToPage();
            HomePage homePage = loginPage.login("admin", "admin", loginPage);
            WebDriverWait wait = new WebDriverWait(PropertyCollection.driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
            Assert.AreEqual("Home", PropertyCollection.driver.Title);

        }

        [TearDown]
        public void TestTearDown()
        {
            PropertyCollection.driver.Close();
            PropertyCollection.driver.Quit();
        }
    }
}
