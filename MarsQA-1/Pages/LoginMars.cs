using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsApplicationOnboarding.Pages
{
    public class LoginMars
    {
        private readonly IWebDriver driver;
        private readonly ElementUtil eleUtil;
        public LoginMars(IWebDriver driver)
        {
            this.driver = driver;
            eleUtil = new ElementUtil(driver);
        }
        //By Locators
        private readonly By signin = By.XPath("//a[contains(text(),'Sign In')]");
        private readonly By emailaddress = By.XPath("//input[@placeholder='Email address']");
        private readonly By password = By.XPath("//input[@placeholder='Password']");
        private readonly By login = By.XPath("//button[contains(text(),'Login')]");

        public void LoginActions()
        {
            //navigate to Mars Application
            driver.Navigate().GoToUrl("http://localhost:5000/");
            //click sign in
            eleUtil.doClick(signin);
            //enter email address
            eleUtil.doSendKeys(emailaddress, "saipraneethg.91@gmail.com");
            // enter password
            eleUtil.doSendKeys(password, "Praneeth@1");
            // click login
            eleUtil.doClick(login);
            Thread.Sleep(3000);
        }

    }
}
