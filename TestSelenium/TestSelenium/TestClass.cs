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
            PropertyCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
     
        [Test]
        public void Login()
        {
            
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            loginPage.goToPage();
            HomePage homePage = loginPage.login("admin", "admin", loginPage);
            //wait.Until(ExpectedConditions.ElementToBeSelected(loginPage.multipleLoginForm));
            Boolean multipleSession = false;
            //Thread.Sleep(15000);
            PropertyCollection.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#pleaseWaitDiv > div > div > div.modal-header > h4")));
            if (loginPage.multipleLoginForm.Displayed)
            {
                multipleSession = true;
            }
                    
            //If multiple dialog appeared, we start new session
            if ( multipleSession == true)
            {
                //Click on new "Create new session button"
                loginPage.newSessionBtn.Click();
                Console.WriteLine("Login with creation new Session executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);
                homePage.logOut();
                Console.WriteLine("Log Out successfull");
            } else {                             
                Console.WriteLine("Login executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);
                homePage.logOut();
                Console.WriteLine("Log Out successfull");
            }
            

            

        }

        [TearDown]
        public void TestTearDown()
        {
            PropertyCollection.driver.Close();
            PropertyCollection.driver.Quit();
        }
    }
}
