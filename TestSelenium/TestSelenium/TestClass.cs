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

        [SetUp]
        public void Setup() {
            
        }
     
        [Test]
        public void Login()
        {
            WebDriverWait wait = new WebDriverWait(PropertyCollection.driver, TimeSpan.FromSeconds(20));
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            loginPage.goToPage();
            HomePage homePage = loginPage.login("admin", "admin", loginPage);
            //wait.Until(ExpectedConditions.ElementToBeSelected(loginPage.multipleLoginForm));
            if(wait.Until(ExpectedConditions.TextToBePresentInElement(loginPage.multipleLoginForm, "Connecting to Altium NEXUS Server...")))           
            {
            loginPage.newSessionBtn.Click();
            }
            Console.WriteLine("login executed");
            
            wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
            //Thread.Sleep(5000);
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
