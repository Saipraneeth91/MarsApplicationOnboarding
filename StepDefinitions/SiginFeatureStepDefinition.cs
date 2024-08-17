using MarsApplicationOnboarding.Pages;
using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class SiginFeatureStepDefinition

    {
        private readonly IWebDriver driver;
        private readonly LoginMars loginMars;
        public SiginFeatureStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
            loginMars = new LoginMars(driver);
        }

        [Given(@"User enters valid Emailaddress and Password")]
        public void GivenUserEntersValidEmailaddressAndPassword()
        {
            loginMars.LoginActions();
        }

        [Then(@"User Must be loggedin to the Application and able to see profile Page")]
        public void ThenUserMustBeLoggedinToTheApplicationAndAbleToSeeProfilePage()
        {
            Console.WriteLine("Pass");
        }
    }
}
