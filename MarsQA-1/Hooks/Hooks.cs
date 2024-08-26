using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using MarsApplicationOnboarding.Pages;

namespace MarsApplicationOnboarding.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver driver;
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Initialize the WebDriver instance
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Clear languages and skills before test execution
            ClearLang();
            ClearSkills();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Register the WebDriver instance with the container
            // each scenario gets a fresh WebDriver instance
            if (!_container.IsRegistered<IWebDriver>())
            {
                _container.RegisterInstanceAs(driver);
            }
        }

        public static void ClearLang()
        {
            if (driver != null)
            {
                var login = new Login(driver);
                var lang = new Languages(driver);
                login.LoginActions();
                lang.ClearLanguages();
            }
        }

        public static void ClearSkills()
        {
            if (driver != null)
            {
                var skills = new Skills(driver);
                skills.ClearSkills();
            }
        }

        [AfterScenario(Order = 1)]
        public void ClearTestSpecificLanguagesAfterScenario()
        {
            if (driver != null)
            {
                var lang = new Languages(driver);
                var skills = new Skills(driver);

                // Retrieve the language value from ScenarioContext
                if (_scenarioContext.TryGetValue("language", out string language))
                {
                    lang.DeleteLanguage(language);
                }
                if (_scenarioContext.TryGetValue("skill", out string skill))
                {
                    skills.DeleteSkill(skill);
                }
            }
        }

        [AfterScenario(Order = 2)]
        public void LogoutAndQuitAfterScenario()
        {
            if (driver != null)
            {
                var login = new Login(driver);
                

                // Quit the WebDriver instance after each scenario
                driver.Quit();

                // Reinitialize WebDriver for the next scenario
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                // Register the new WebDriver instance with the container
                // Avoid re-registering if it's already registered
                if (!_container.IsRegistered<IWebDriver>())
                {
                    _container.RegisterInstanceAs(driver);
                }
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
          
            if (driver != null)
            
                {
                    driver.Quit();
                    driver = null; 
                }
            }
        }
    }

