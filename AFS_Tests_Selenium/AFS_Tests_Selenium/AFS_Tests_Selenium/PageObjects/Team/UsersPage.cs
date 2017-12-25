using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AFS_Tests_Selenium.PageObjects.Team
{
    class UsersPage : BasePage
    {        

        public UsersPage(IWebDriver driver) 
        {
            PropertyCollection.driver = driver;            
            PageFactory.InitElements(driver, this);
        }
        // Add user button
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > div > div.sub-header > div > div > button")]
        public IWebElement addUserBtn;

        //Search input control
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > div > div.sub-header > div > div > btn-search > div > input")]
        public IWebElement searchInput;

        //Open add user popup

    public AddUserPage addUserPopup(UsersPage usersPage)
        {
            usersPage.addUserBtn.Click();
            return new AddUserPage(PropertyCollection.driver);
        }




    }
}
