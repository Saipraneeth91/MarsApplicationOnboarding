using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using TechTalk.SpecFlow;
using MarsApplicationOnboarding.Pages;

namespace MarsApplicationOnboarding.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private static bool isFirst = true;
        private IWebDriver driver;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(driver);
        }
        [BeforeScenario("@Skills")]
        public void ClearSkills()
        {
            if (isFirst)
            {
                var login = new Login(driver);
                var skills = new Skills(driver);
                login.LoginActions();
                skills.ClearSkills();
                isFirst = false;

            }
        }
        [BeforeScenario("@Lang")]
        public void ClearLang()
        {
            if (isFirst)
            {
                var login = new Login(driver);
                var lang = new Languages(driver);
                login.LoginActions();
                lang.ClearLanguages();
                isFirst = false;

            }

        }

        [AfterScenario()]
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