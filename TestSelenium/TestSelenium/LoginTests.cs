using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestSelenium.PageObjects;



namespace TestSelenium
{
    public class LoginTests
    {

        [SetUp]
        public void Setup() {            
            PropertyCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        NavigationPanel navPanel = new NavigationPanel(PropertyCollection.driver);
        HomePage homePage = new HomePage(PropertyCollection.driver);
        
        [TestCaseSource("TestCases")]
        public String Login(String userName, String password)
        {           
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            loginPage.goToPage();
            homePage = loginPage.login(userName, password, loginPage);
            //wait.Until(ExpectedConditions.ElementToBeSelected(loginPage.multipleLoginForm));
            Boolean multipleSession = false;
            //Thread.Sleep(15000);
            try
            {
                PropertyCollection.wait.Until(ExpectedConditions
                .InvisibilityOfElementLocated(By.CssSelector("#pleaseWaitDiv > div > div > div.modal-header > h4")));
            
                if (loginPage.multipleLoginForm.Displayed)
                {
                    multipleSession = true;
                }
            }catch (NoSuchElementException e)
            {
            }catch(WebDriverTimeoutException e)
            {
            }
                    
            //If multiple dialog appeared, we start new session
            if ( multipleSession == true)
            {
                //Click on new "Create new session button"
                loginPage.newSessionBtn.Click();
                Console.WriteLine("Login with creation new Session executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);                
                Console.WriteLine("Log Out successfull");
                return navPanel.userNameLabel.Text;
            } else {                             
                Console.WriteLine("Login executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);
                
                Console.WriteLine("Log Out successfull");
                return navPanel.userNameLabel.Text;
            }    
                                     
        }

    [TearDown]
        public void TestTearDown()
        {
            homePage.logOut();
            //PropertyCollection.driver.Close();
            //PropertyCollection.driver.Quit();
            //PropertyCollection.driver.Dispose();
        }

        public static List<TestCaseData> TestCases
        {
            get
            {
                String fileDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(fileDirectoryPath + @"\..\..\users.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ';' }, StringSplitOptions.None);

                            String userName = split[0];
                            String password = split[1];
                            String expectedUser = split[2];
                            var testCase = new TestCaseData(userName,password).Returns(expectedUser);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }

    }
}

