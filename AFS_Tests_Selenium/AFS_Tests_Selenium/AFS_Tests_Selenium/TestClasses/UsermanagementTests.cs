using AFS_Tests_Selenium.PageObjects;
using AFS_Tests_Selenium.PageObjects.Team;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium
{
    [TestClass]
    public class UsermanagementTests : BaseTest
    {
        UsersPage usersPage = new UsersPage(PropertyCollection.driver);
        AddUserPage addUserPage;
        String firstName;
        String lastName;
        String email;
        String role;
        String authType;


        
            
        public void prepareUsermanagementTest()
        {
            LoginPage loginPage = new LoginPage(PropertyCollection.driver);
            BasePage.openPage("");
            homePage = loginPage.login("admin", "admin", loginPage);            
            PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.copyUrlButton));
        }      

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\usersCreation.csv", "usersCreation#csv",
                DataAccessMethod.Sequential), DeploymentItem("usersCreation.csv"), DeploymentItem("chromedriver.exe")]
        public void createNewUser()
        {
            userName = getCredentialsFromFile("userName");
            password = getCredentialsFromFile("password");
            firstName = getCredentialsFromFile("firstName");
            lastName = getCredentialsFromFile("lastName");
            email = getCredentialsFromFile("email");

            prepareUsermanagementTest();
            navPanel.teamBtn.Click();
            PropertyCollection.wait.Until(ExpectedConditions.ElementToBeClickable(usersPage.addUserBtn));
            addUserPage = usersPage.addUserPopup(usersPage);            
            
        }
    }
}
