using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.PageObjects
{
    public class HomePage
    {
        

        public HomePage(IWebDriver driver)
        {
            PropertyCollection.driver = driver;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#site-header > div > div.logo > a > img")]
        private IWebElement logo;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > div > div > div > div:nth-child(2) > button")]
        public IWebElement copyUrlButton;
        
        [FindsBy(How = How.CssSelector, Using = "# site-header > div > div.user-control > div.menu > div.menu-info > span.subtitle2")]
        private IWebElement userNameElement;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > div > div > div > h2")]
        private IWebElement productNameCaption;

        public void goToPage()
        {

        }
        

    }

}
