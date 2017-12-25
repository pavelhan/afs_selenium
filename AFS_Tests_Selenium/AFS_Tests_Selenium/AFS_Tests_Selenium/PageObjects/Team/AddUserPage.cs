using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium.PageObjects.Team
{
    class AddUserPage : BasePage
    {
        public AddUserPage(IWebDriver driver)
        {
            PropertyCollection.driver = driver;            
            PageFactory.InitElements(driver, this);
        }

        //User name input
        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement userNameInput;

        //Password input
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement passwordInput;

        //Email input
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement emailInput;

        //Role specification
        [FindsBy(How = How.Id, Using = "token-input-")]
        public IWebElement roleInput;

        // First name input
        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement firstNameInput;

        //Last name input
        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement lastNameInput;

        //Dropdown with authentication type (Built in, Windows)
        [FindsBy(How = How.Id, Using = "AuthType")]
        public IWebElement authTypeInput;

        //Save user button
        [FindsBy(How = How.CssSelector, Using = "#editUserModal > div > div > div.modal-footer > button")]
        public IWebElement saveBtn;


    }
}
