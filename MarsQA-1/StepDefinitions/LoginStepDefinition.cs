using MarsApplicationOnboarding.Pages;
using MarsApplicationOnboarding.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinition

    {
        private readonly IWebDriver driver;
        private readonly Login loginMars;
        public LoginFeatureStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
            loginMars = new Login(driver);
        }

        [Given(@"User enters valid Emailaddress and Password")]
        public void GivenUserEntersValidEmailaddressAndPassword()
        {
            loginMars.LoginActions();
        }

        [Then(@"User Must be loggedin to the Application and able to see profile Page")]
        public void ThenUserMustBeLoggedinToTheApplicationAndAbleToSeeProfilePage()
        {
            string Actualtext = loginMars.GetWelcomeText();
            string Expectedtext = "Hi Sai";
            Assert.That(Actualtext, Is.EqualTo(Expectedtext));
        }
    }
}
