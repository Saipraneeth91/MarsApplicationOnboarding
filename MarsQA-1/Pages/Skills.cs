using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsApplicationOnboarding.Pages
{
    public class Skills
    {
        private readonly IWebDriver driver;
        private readonly ElementUtil eleUtil;
        public Skills(IWebDriver driver)
        {
            this.driver = driver;
            eleUtil = new ElementUtil(driver);
        }
        //By locators
        private readonly By skillssection = By.XPath("//a[text()='Skills']");
        private readonly By addnewbutton = By.XPath("//div[@class='ui teal button']");
        private readonly By skillfield = By.XPath("//input[@placeholder='Add Skill']");
        private readonly By skilllevel = By.Name("level");
        private readonly By addskillbutton = By.XPath("//input[@value='Add']");
        private readonly By skillname = By.XPath("//th[text()='Skill']/ancestor::thead/following-sibling::tbody[last()]/tr[last()]/td[1]");
        private readonly By editicon = By.XPath("//th[text()='Skill']/ancestor::thead/following-sibling::tbody[1]/tr[1]/td/span[1]");
        private readonly By updatebutton = By.XPath("//input[@value='Update']");
        private readonly By editlastrecord = By.XPath("//th[text()='Skill']/ancestor::thead/following-sibling::tbody[last()]/tr[1]/td/span[1]");
        private readonly By logout = By.XPath("//button[text()='Sign Out']");
        private readonly By deletelastskill = By.XPath("//th[text()='Skill']/ancestor::thead/following-sibling::tbody[last()]/tr[1]/td/span[2]");
        public ReadOnlyCollection<IWebElement> rows => driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        private readonly By notificationtext = By.XPath("//div[@class='ns-box-inner']");

        public void AddSkill(string skill, string level)
        {
            // click to navigate to skill section 
            eleUtil.doClick(skillssection);
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click addnew button
            eleUtil.doClick(addnewbutton);
            //add skill
            eleUtil.doSendKeys(skillfield, skill);
            //add skill level
            eleUtil.doSendKeys(skilllevel, level);
            //click skill level
            eleUtil.doClick(skilllevel);
            // click add button
            eleUtil.doClick(addskillbutton);
            Thread.Sleep(3000);          
        }
        public void AddSkill(string skill, string level, string newskill, string newlevel)
        {
            // click to navigate to skill section 
            eleUtil.doClick(skillssection);
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click addnew button
            eleUtil.doClick(addnewbutton);
            //add skill
            eleUtil.doSendKeys(skillfield, skill);
            //add skill level
            eleUtil.doSendKeys(skilllevel, level);
            //click skill level
            eleUtil.doClick(skilllevel);
            // click add button
            eleUtil.doClick(addskillbutton);
            Wait.WaitToBeClickable(driver, addnewbutton, Wait.LONG_DEFAULT_WAIT);
            // click addnew button
            eleUtil.doClick(addnewbutton);
            //add skill
            eleUtil.doSendKeys(skillfield, newskill);
            //add skill level
            eleUtil.doSendKeys(skilllevel, newlevel);
            //click skill level
            eleUtil.doClick(skilllevel);
            // click add button
            eleUtil.doClick(addskillbutton);
        
           
        }
        public void EditSkill(string newSkill, string newSkilllevel)
        {
            Wait.WaitToBeClickable(driver, skillssection, Wait.LONG_DEFAULT_WAIT);
            //click to navigate to skill section 
            eleUtil.doClick(skillssection);
            // click on edit icon
            eleUtil.doClick(editicon);
            // clear skill
            eleUtil.doClear(skillfield);
            // enter skill
            eleUtil.doClick(skilllevel);
            eleUtil.doSendKeys(skillfield, newSkill);
            // enter skill level
            eleUtil.doClick(skilllevel);
            eleUtil.doSendKeys(skilllevel, newSkilllevel);
            //click on update
            eleUtil.doClick(updatebutton);
            Thread.Sleep(2000);
        }

        public void DeleteSkill(string Skillname)
        {
            // click to navigate to skill section 
            eleUtil.doClick(skillssection);
            // delete skill by skill name passed
            By deletebyskill = By.XPath("//td[text()='" + Skillname + "']/following-sibling::td/span[@class='button'][2]");
            Wait.WaitToBeClickable(driver,deletebyskill, Wait.MEDIUM_DEFAULT_WAIT);
            eleUtil.doClick(deletebyskill);
            //Thread.Sleep(1000);
        }
        public string GetSkillName()
        {
            Wait.WaitToBeVisible(driver, skillname, Wait.SHORT_DEFAULT_WAIT);
            // get text of skill created
            return eleUtil.getText(skillname);
        }
        public string NotificationInfo()
        {
            Wait.WaitToBeVisible(driver, notificationtext, Wait.LONG_DEFAULT_WAIT);
            //get text of notification popped up
            return eleUtil.getText(notificationtext);
        }
        public void ClearSkills()
        {
            Wait.WaitToBeClickable(driver, skillssection, Wait.LONG_DEFAULT_WAIT);
            eleUtil.doClick(skillssection);
            int totalrows = rows.Count;
            Console.WriteLine(totalrows);
            eleUtil.doClick(skillssection);

            for (int i = 0; i < totalrows; i = i + 1)
            {
                Wait.WaitToBeClickable(driver, deletelastskill, Wait.LONG_DEFAULT_WAIT);
                // click on delete icon
                eleUtil.doClick(deletelastskill);
            }
            eleUtil.doClick(logout);

           
        }

    }
}

