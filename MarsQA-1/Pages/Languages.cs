using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MarsApplicationOnboarding.Pages
{
    public class Languages
    {
        private readonly IWebDriver driver;
        private readonly ElementUtil eleUtil;
        public Languages(IWebDriver driver)
        {
            this.driver = driver;
            eleUtil = new ElementUtil(driver);

        }
        // By locators
        private readonly By addnewbutton = By.XPath("//div[text()='Add New']");
        private readonly By languagefield = By.XPath("//input[@placeholder='Add Language']");
        private readonly By languagelevel = By.Name("level");
        private readonly By addlangbutton = By.XPath("//input[@value='Add']");
        private readonly By languagerecord = By.XPath("(//div[text()='Add New']/ancestor::thead/following-sibling::tbody[last()]/tr/td)[1]");
        private readonly By editicon = By.XPath("//tbody[(1)]/tr[1]/td[3]/span[1]/i[1]");
        private readonly By updatebutton = By.XPath("//input[@value='Update']");
        private readonly By lastrecordedit = By.XPath("//tbody[last()]/tr[1]/td[3]/span[1]/i[1]");
        private readonly By deletelanguageicon = By.XPath("//i[@class='remove icon']");
      
        public ReadOnlyCollection<IWebElement> rows => driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody"));
        private readonly By notificationtext = By.XPath("//div[@class='ns-box-inner']");

        public void AddLanguage(string language, string level)
        {
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click on add new button
            eleUtil.doClick(addnewbutton);
            // Enter Language
            eleUtil.doSendKeys(languagefield, language);
            // Enter Language level
            eleUtil.doSendKeys(languagelevel, level);
            // Click language level
            eleUtil.doClick(languagelevel);
            // Click add button
            eleUtil.doClick(addlangbutton);
        }

        public void AddLanguage(string language, string level,string newlanguage,string newlanguagelevel)
        {
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click on add new button
            eleUtil.doClick(addnewbutton);
            // Enter Language
            eleUtil.doSendKeys(languagefield, language);
            // Enter Language level
            eleUtil.doSendKeys(languagelevel, level);
            // Click language level
            eleUtil.doClick(languagelevel);
            // Click add button
            eleUtil.doClick(addlangbutton);
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click on add new button
            eleUtil.doClick(addnewbutton);
            // Enter Language
            eleUtil.doSendKeys(languagefield, newlanguage);
            // Enter Language level
            eleUtil.doSendKeys(languagelevel, newlanguagelevel);
            // Click language level
            eleUtil.doClick(languagelevel);
            // Click add button
            eleUtil.doClick(addlangbutton);
            
        }
        public void EditLanguage(string newlanguage, string newlanguagelevel)

        {
           Wait.WaitToBeClickable(driver, editicon, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(editicon);
            eleUtil.doClick(languagefield);
            eleUtil.doClear(languagefield);
            eleUtil.doSendKeys(languagefield, newlanguage);
            eleUtil.doClick(languagelevel);
            eleUtil.doSendKeys(languagelevel, newlanguagelevel);   
            eleUtil.doClick(updatebutton);
            Thread.Sleep(2000);
            
        }
        public void EditLangWithoutChange()
        {
            Wait.WaitToBeVisible(driver, lastrecordedit, Wait.LONG_DEFAULT_WAIT);
            // click on edit icon of last record  
            eleUtil.doClick(lastrecordedit);
            //click on updatebutton
            eleUtil.doClick(updatebutton);
        }

        public void DeleteLanguage(string languageName)
        {
            By deleteLanguage = By.XPath("//td[text()='" + languageName + "']/following-sibling::td/span[@class='button'][2]");
            // click on delete icon of language passed
            Wait.WaitToBeClickable(driver, deleteLanguage, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(deleteLanguage);
            Thread.Sleep(2000);
        }
        public void ClearLanguages()
        {
            int totalrows = rows.Count;
            Console.WriteLine(totalrows);

            for (int i = 0; i < totalrows; i = i + 1)
            {
                Wait.WaitToBeVisible(driver, deletelanguageicon, Wait.MEDIUM_DEFAULT_WAIT);
                // click on delete icon
                eleUtil.doClick(deletelanguageicon);
                Thread.Sleep(2000);
            }
           
        }

        public string GetLanguageRecord()
        {
            Wait.WaitToBeVisible(driver, languagerecord, Wait.LONG_DEFAULT_WAIT);
            //get text of language record 
            return driver.FindElement(languagerecord).Text;
        }
        public string NotificationTextInfo()
        {
            Wait.WaitToBeVisible(driver, notificationtext, Wait.LONG_DEFAULT_WAIT);
            //get text of notification popped up
            return eleUtil.getText(notificationtext);
        }

    }
}
