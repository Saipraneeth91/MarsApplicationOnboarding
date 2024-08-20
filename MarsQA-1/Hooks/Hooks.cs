using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using TechTalk.SpecFlow;
using MarsApplicationOnboarding.Pages;
using System;

namespace MarsApplicationOnboarding.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(driver);
             ClearLang();
             ClearSkills(); //Clears all the languages &Skills before scenario execution
        }
        public void ClearLang()
        { 
            var login = new Login(driver);
            var lang = new Languages(driver);
            login.LoginActions();
            lang.ClearLanguages();
        }
        public void ClearSkills()
        {
            var skills = new Skills(driver);
            skills.ClearSkills(); 
        }

        [AfterScenario(Order = 1)]
        public void ClearTestSpecificLanguagesAfterScenario()
        {
            var lang = new Languages(driver);
            var skills = new Skills(driver);

            // Retrieve the language value from ScenarioContext
            if (_scenarioContext.TryGetValue("language", out string language))
            {
                lang.DeleteLanguage(language);      
              // Deletes only the language added by this scenario after execution
            }
            if (_scenarioContext.TryGetValue("skill", out string skill))
            {
                skills.DeleteSkill(skill);
                // Deletes only the Skills added by this scenario after execution
            }

        }

        [AfterScenario(Order = 2)]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}