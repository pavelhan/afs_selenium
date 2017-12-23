using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium.PageObjects
{
    /// <summary>
    /// Class that describes Navigation panel in WEB UI. Contains all navigation buttons except of admin buttons. Also contains user corner elements.
    /// </summary>
    public class NavigationPanel
    {
        protected IWebDriver driver;

        public NavigationPanel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Home page navigation
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li.active > a > span.text")]
        public IWebElement homePageBtn;

        /// <summary>
        /// Team page navigation
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(2) > a > span.text")]
        public IWebElement teamBtn;

        /// <summary>
        /// Projects page navigation
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(3) > a > span.text")]
        public IWebElement projectsBtn;

        /// <summary>
        /// Navigation to Explorer page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(4) > a > span.text")]
        public IWebElement explorerBtn;

        /// <summary>
        ///Stream page navigation
        ///</summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(5) > a > span.text")]
        public IWebElement streamBtn;

        /// <summary>
        /// Part request navigation
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(6) > a > span.text")]
        public IWebElement partRequestBtn;

        /// <summary>
        /// Tasks page navigation
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(7) > a > span.text")]
        public IWebElement tasksBtn;

        /// <summary>
        /// Admin button
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "body > div.outer-wrapper > div > aside > div > ul > li:nth-child(8) > a > span.text")]
        public IWebElement adminBtn;

        /// <summary>
        /// User icon button
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#site-header > div > div.user-control > div.menu > div.avatar > a")]
        public IWebElement avatar;

        [FindsBy(How = How.CssSelector, Using = "#site-header > nav > div > ul > li > a")]
        public IWebElement logOutBtn;

        /// <summary>
        /// User name label
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#site-header > div > div.user-control > div.menu > div.menu-info > span.subtitle2")]
        public IWebElement userNameLabel;



    }
}
