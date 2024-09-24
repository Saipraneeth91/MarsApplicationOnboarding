using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsApplicationOnboarding.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        private readonly ElementUtil eleUtil;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            eleUtil = new ElementUtil(driver);
        }
        //By Locators
        private readonly By signin = By.XPath("//a[normalize-space()='Sign In']");
        private readonly By emailaddress = By.XPath("//input[@placeholder='Email address']");
        private readonly By password = By.XPath("//input[@placeholder='Password']");
        private readonly By login = By.XPath("//button[contains(text(),'Login')]");
        private readonly By welcometext = By.XPath("//div/div[1]/div[2]/div/span");

        public void LoginActions()
        {
            try
            {
                
                //navigate to Mars Application
                driver.Navigate().GoToUrl("http://localhost:5000/");
                //click sign in
                Thread.Sleep(2000);
                eleUtil.doClick(signin);
                //enter email address
                eleUtil.doSendKeys(emailaddress, "saipraneethg.91@gmail.com");
                // enter password
                eleUtil.doSendKeys(password, "Praneeth@1");
                // click login
                eleUtil.doClick(login);
                Thread.Sleep(2000);
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"WebDriverException occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception occurred: {ex.Message}");
                throw;
            }
        }
        public string GetWelcomeText()
        {
            return eleUtil.getText(welcometext);
        }

    }
}
