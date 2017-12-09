using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFS_Tests_Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace AFS_Tests_Selenium
{
    [TestClass]
    public class LoginTests
    {
        NavigationPanel navPanel;
        HomePage homePage;
        String fileDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        //public static String filePath = @"D:\SeleniumC#\AFS_Tests_Selenium\AFS_Tests_Selenium\AFS_Tests_Selenium\bin\Debug\users.xlsx";
        //public static String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 12.0;'", filePath);

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

        [TestInitialize()]
        public void Startup()
        {       if(PropertyCollection.driver == null)
                PropertyCollection.driver = new ChromeDriver();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            homePage.logOut();
            PropertyCollection.driver.Close();
            PropertyCollection.driver = null;
            //PropertyCollection.driver.Quit();
        }


        [TestMethod]      
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\users.csv","users#csv",
            DataAccessMethod.Sequential), DeploymentItem("users.csv"), DeploymentItem("chromedriver.exe")]      
        public void Login()
        {
            navPanel = new NavigationPanel(PropertyCollection.driver);
            homePage = new HomePage(PropertyCollection.driver);
            String userName = getCredentialsFromFile("userName");
            String password = getCredentialsFromFile("password");
            String userProfileName = getCredentialsFromFile("result");
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
            }
            catch (NoSuchElementException e)
            {
            }
            catch (WebDriverTimeoutException e)
            {
            }

            //If multiple dialog appeared, we start new session
            if (multipleSession == true)
            {
                //Click on new "Create new session button"
                loginPage.newSessionBtn.Click();
                Console.WriteLine("Login with creation new Session executed");
                PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
                Assert.AreEqual("Home", PropertyCollection.driver.Title);
                Console.WriteLine("Log Out successfull");
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
    }
}
