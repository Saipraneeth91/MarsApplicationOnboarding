using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsApplicationOnboarding.Utilities
{
    public class ElementUtil
    {
        private IWebDriver driver;

        public ElementUtil(IWebDriver driver)
        {

            this.driver = driver;
        }
        public void doSendKeys(By locator, string value)
        {
            getElement(locator).SendKeys(value);
        }
        public IWebElement getElement(By locator)
        {
            return driver.FindElement(locator);
        }
        public void doClick(By locator)
        {
            getElement(locator).Click();
        }

    }
}
