using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.PageObjects
{
    class AdminMenu : NavigationPanel
    {
        

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li.active > a")]
        private IWebElement settingsBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(2) > a")]
        private IWebElement vcsBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(3) > a")]
        private IWebElement configurationsBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(4) > a")]
        private IWebElement partProvidersBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(5) > a")]
        private IWebElement processesBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(6) > a")]
        private IWebElement healthBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(7) > a")]
        private IWebElement licensesBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(8) > a")]
        private IWebElement installationsBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > ul > li:nth-child(9) > a")]
        private IWebElement statusBtn;

        public AdminMenu(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            NavigationPanel navPanel = new NavigationPanel(base.driver);
            navPanel.adminBtn.Click();                                    
        }
    }
}
