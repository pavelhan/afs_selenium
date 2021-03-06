﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium.PageObjects
{
    public class LoginPage
    {
        

        public LoginPage(IWebDriver driver)
        {
            PropertyCollection.driver = driver;            
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "#formLogin > div:nth-child(8) > div > button")]
        private IWebElement loginBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='myModalLabel']")]
        public IWebElement multipleLoginForm;

        [FindsBy(How = How.CssSelector, Using = "#extraLoginParametersModal > div.modal-dialog > div > div.modal-body > div.list-group > a:nth-child(2)")]
        public IWebElement newSessionBtn;

        [FindsBy(How = How.CssSelector, Using = "#pleaseWaitDiv > div > div > div.modal-header > h4")]
        public IWebElement waitPopup;

        public void goToPage()
        {
            PropertyCollection.driver.Navigate().GoToUrl("http://nexus-trunk:9780");
        }

        public HomePage login(String userName, String password, LoginPage page)
        {
            page.userName.SendKeys(userName);
            //Console.WriteLine("SendKeys to username succeeded");
            page.password.SendKeys(password);
            //Console.WriteLine("SendKeys to password succeeded");
            page.loginBtn.Click();
            //Console.WriteLine("Login click successful");

            return new HomePage(PropertyCollection.driver);
        }
        
    }
}
