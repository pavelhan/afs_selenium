using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.PageObjects
{
    class NavigationPanel
    {
        protected IWebDriver driver;

        public NavigationPanel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > a > span.text")]
        protected IWebElement homePageBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(2) > a > span.text")]
        protected IWebElement teamBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(3) > a > span.text")]
        protected IWebElement projectsBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(4) > a > span.text")]
        protected IWebElement explorerBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(5) > a > span.text")]
        protected IWebElement streamBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(6) > a > span.text")]
        protected IWebElement partRequestBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(7) > a > span.text")]
        protected IWebElement tasksBtn;

        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(8) > a > span.text")]
        public IWebElement adminBtn;

    }
}
