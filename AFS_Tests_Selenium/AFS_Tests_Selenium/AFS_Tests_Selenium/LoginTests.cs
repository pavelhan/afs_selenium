using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFS_Tests_Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;

namespace AFS_Tests_Selenium
{
    [TestClass]
    public class LoginTests
    {
        NavigationPanel navPanel;
        HomePage homePage;
        String fileDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        String userName;
        String password;
        public static String pathToClassFile = AppDomain.CurrentDomain.BaseDirectory;


        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
      
        public String getCredentialsFromFile(string columnHeading)
        {
            return TestContext.DataRow[columnHeading].ToString();
        }

        //Take screenshots method
        private static void takeScreenshot(String folderPath, String fileName)
        {
            if (!Directory.Exists(pathToClassFile + "\\" + folderPath))
            {
                Directory.CreateDirectory(pathToClassFile + "\\" + folderPath);
            }
            ITakesScreenshot screenshotHolder = PropertyCollection.driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHolder.GetScreenshot();
            screenshot.SaveAsFile(pathToClassFile + "\\" + folderPath + "\\"
                + fileName + ".jpeg", ScreenshotImageFormat.Jpeg);
        }

        [TestInitialize()]
        public void Startup()
        {       if(PropertyCollection.driver == null)
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
            if(navPanel != null)
            {
                navPanel = null;
            }
            
            //PropertyCollection.driver.Quit();
        }


        /// <summary>
        /// Simple login with sequence of users from the "users.csv" list
        /// </summary>
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\users.csv", "users#csv",
            DataAccessMethod.Sequential), DeploymentItem("users.csv"), DeploymentItem("chromedriver.exe")]
        public void LoginSimple()
        {
            try{
                userName = getCredentialsFromFile("userName");
                password = getCredentialsFromFile("password");            
                String userProfileName = getCredentialsFromFile("result");
                LoginPage loginPage = new LoginPage(PropertyCollection.driver);
                loginPage.goToPage();
                //Actual Login
                homePage = loginPage.login(userName, password, loginPage);                      
                Console.WriteLine("Login executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);                
                Assert.AreEqual(userProfileName, navPanel.userNameLabel.Text);
            }
            catch (NoSuchElementException e)
            {
                takeScreenshot( "LoginSimpleTestFolder", "LoginSimple");
                Assert.Fail("Login failed. Some element not found after login");
            }
        }


        /// <summary>
        /// Multiple session login with creation of new session
        /// </summary>
        [Ignore]
        [TestMethod]             
        public void LoginMultipleSessions()
        {                        
            userName = "t1";
            password = "t1";
            Boolean multipleSession = false;
            String userProfileName = "t1";
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            loginPage.goToPage();
            //Actual Login
            homePage = loginPage.login(userName, password, loginPage);           
            try
            {
                //PropertyCollection.wait.Until(ExpectedConditions
                //.InvisibilityOfElementLocated(By.CssSelector("#pleaseWaitDiv > div > div > div.modal-header > h4")));
                //Thread.Sleep(2000);
                if(PropertyCollection.wait.Until(ExpectedConditions.TextToBePresentInElement(loginPage.multipleLoginForm, "Connecting to Altium NEXUS Server...")))
                {
                    if (loginPage.multipleLoginForm.Displayed)
                    {
                        multipleSession = true;
                    }                    
                }                                                           
            }
            catch (NoSuchElementException e)
            {
                Console.Write(e.InnerException.Message);                
            }
            catch (WebDriverTimeoutException e)
            {
                takeScreenshot("LoginMultipleSessionsTestFolder", "LoginMultipleSessions");
                Assert.Fail("Multiple login popup didn't appear.");
            }

            //If multiple dialog appeared, we start new session
            if (multipleSession == true)
            {
                //Click on new "Create new session button"
                loginPage.newSessionBtn.Click();
                Console.WriteLine("Login with creation new Session executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);                
                Assert.AreEqual(userProfileName, navPanel.userNameLabel.Text);
            }
            else
            {
                Console.WriteLine("Login executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);

                Console.WriteLine("Log Out successfull");
                Assert.AreEqual(userProfileName, navPanel.userNameLabel.Text);
            }
        }

        /// <summary>
        /// Simple login with invalid user name
        /// </summary>
        [TestMethod]        
        public void WrongUserNameLogin()
        {
            try
            {
                userName = "invalidUserName";
                password = "admin";                
                LoginPage loginPage = new LoginPage(PropertyCollection.driver);
                loginPage.goToPage();
                //Actual Login
                loginPage.login(userName, password, loginPage);                
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.invalidCredPopup));
                Assert.AreEqual("Invalid UserName/Password combination", 
                    loginPage.invalidCredPopup.Text);
            }
            catch (Exception e)
            {
                takeScreenshot("WrongUserNameTestFolder", "WrongUserNameLogin");
                Assert.Fail("Assertion of wrong credentials popup failed, please review screenshot");
            }
        }

        /// <summary>
        /// Simple login with invalid password
        /// </summary>
        [TestMethod]
        public void WrongPasswordLogin()
        {
            try
            {
                userName = "admin";
                password = "wrongPassword";
                LoginPage loginPage = new LoginPage(PropertyCollection.driver);
                loginPage.goToPage();
                //Actual Login
                loginPage.login(userName, password, loginPage);
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.invalidCredPopup));
                Assert.AreEqual("Invalid UserName/Password combination",
                    loginPage.invalidCredPopup.Text);
            }
            catch (Exception e)
            {
                takeScreenshot("WrongPasswordLoginTestFolder", "WrongPasswordLogin");
                Assert.Fail("Assertion of wrong credentials popup failed, please review screenshot");
            }
        }

        /// <summary>
        /// Empty user name login
        /// </summary>
        [TestMethod]
        public void EmptyUserNameLogin()
        {
            try
            {
                userName = "";
                password = "admin";
                LoginPage loginPage = new LoginPage(PropertyCollection.driver);
                loginPage.goToPage();
                //Actual Login
                loginPage.login(userName, password, loginPage);
                PropertyCollection.wait.Until(ExpectedConditions.TextToBePresentInElement(loginPage.userNameFieldValidationError,
                    "User Name is required"));                
                Assert.AreEqual("User Name is required",
                    loginPage.userNameFieldValidationError.Text);
            }
            catch (NoSuchElementException e)
            {
                Console.Write("Unable to find validation field element");
            }
            catch (Exception e)
            {
                takeScreenshot("EmptyUserNameLoginTestFolder", "EmptyUserNameLogin");
                Assert.Fail("Assertion of validation error failed, please review screenshot");
            }
        }

    }
}
