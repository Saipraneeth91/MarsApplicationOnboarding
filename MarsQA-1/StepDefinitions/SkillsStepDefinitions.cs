using MarsApplicationOnboarding.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Login loginMars;
        private readonly Skills skills;
        private readonly ScenarioContext _scenarioContext;
        public SkillsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            loginMars = new Login(driver);
            skills = new Skills(driver);
            _scenarioContext = scenarioContext;
        }
        [Given(@"User Login to the Application and navigates to Skill section")]
        public void GivenUserLoginToTheApplicationAndNavigatesToSkillSection()
        {
            loginMars.LoginActions();
        }

        [When(@"User tries to add '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddAnd(string skill, string level)
        {
            // Store the language in ScenarioContext
            _scenarioContext["language"] = skill;
            _scenarioContext["languagelevel"] = level;
             skills.AddSkill(skill, level);
        }

        [When(@"User tries to add new  '([^']*)' and '([^']*)' for already existing '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewAndForAlreadyExistingAnd(string skill, string level, string newskill, string newlevel)
        {
            _scenarioContext["skill"] = skill;
            _scenarioContext["level"] = level;
            skills.AddSkill(skill, level, newskill, newlevel);
        }

        [Then(@"User should get an error This Skill is already exist in your Skill list.")]
        public void ThenUserShouldGetAnErrorThisSkillIsAlreadyExistInYourSkillList_()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "This skill is already exist in your skill list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to add a new record with invalid '([^']*)' and valid '([^']*)'")]
        public void WhenUserTriesToAddANewRecordWithInvalidAndValid(string skill, string level)
        {
            skills.AddSkill(skill, level);
        }

        [Then(@"User should get an error Please enter Skill and level")]
        public void ThenUserShouldGetAnErrorPleaseEnterSkillAndLevel()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "Please enter skill and experience level";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to add a new record with valid data '([^']*)' and invalid '([^']*)'")]
        public void WhenUserTriesToAddANewRecordWithValidDataAndInvalid(string skill, string level)
        {
            skills.AddSkill(skill, level);
        }

        [When(@"User tries to add a new record with invalid '([^']*)' and invalid '([^']*)'")]
        public void WhenUserTriesToAddANewRecordWithInvalidAndInvalid(string skill, string level)
        {
            skills.AddSkill(skill, level);
        }

        [When(@"User tries to add a new record with extreme long'([^']*)' and valid '([^']*)'")]
        public void WhenUserTriesToAddANewRecordWithExtremeLongAndValid(string skill, string level)
        {
            skills.AddSkill(skill, level);
        }

        [Then(@"'([^']*)' record should not be added to profile")]
        public void ThenRecordShouldNotBeAddedToProfile(string skill)
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "TestcasepreparationtestdatamanagementcoordinationForeignExchangestSITe2eUATcommunicationtestautomationSQLISTQBrequirementsanalysistestplanningSystemtestingintegrationtestingdefecttrackingtestmetricsKYCAMLScrumJIRAbbackendtestingAPItestingSeleniumSpecFlowBDDCapitalMarketsBFSIBanking has been added to your skills";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User edits the record of '([^']*)' and '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserEditsTheRecordOfAndToAnd(string skill, string level, string newskill, string newlevel)
        {
            _scenarioContext["skill"] = newskill;
            _scenarioContext["level"] = newlevel;
            skills.AddSkill(skill, level);
            skills.EditSkill(newskill, newlevel);
        }

        [Then(@"User Should be able to update profile with new updated '([^']*)' and '([^']*)' values")]
        public void ThenUserShouldBeAbleToUpdateProfileWithNewUpdatedAndValues(string newskill, string expertnewskilllevel)
        {
            string Actualskill = skills.GetSkillName();
            Assert.That(Actualskill, Is.EqualTo(newskill));
        }

        [Given(@"User is logged in and navigates to Skill section")]
        public void GivenUserIsLoggedInAndNavigatesToSkillSection()
        {
            loginMars.LoginActions();
        }

        [When(@"User tries to update an existing record without editing '([^']*)' or '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToUpdateAnExistingRecordWithoutEditingOrToAnd(string skill, string level, string newskill, string newlevel)
        {
            skills.AddSkill(skill, level);
            skills.EditSkill(newskill, newlevel);
        }

        [Then(@"User should get an error This Skill is already added to your Skill list.")]
        public void ThenUserShouldGetAnErrorThisSkillIsAlreadyAddedToYourSkillList_()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "This skill is already added to your skill list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to update an existing record '([^']*)' '([^']*)' with blank '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateAnExistingRecordWithBlank(string skill, string level, string newskill, string newlevel)
        {
            skills.AddSkill(skill,level);
            skills.EditSkill(newskill, newlevel);
        }

        [When(@"User tries to update an existing record '([^']*)' '([^']*)' with  '([^']*)' and blank '([^']*)'")]
        public void WhenUserTriesToUpdateAnExistingRecordWithAndBlank(string skill, string level, string newskill, string newlevel)
        {
            skills.AddSkill(skill, level);
            skills.EditSkill(newskill, newlevel);
        }

        [When(@"User tries to update an existing record of '([^']*)' '([^']*)' with new record with extreme long binary input '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToUpdateAnExistingRecordOfWithNewRecordWithExtremeLongBinaryInputAnd(string skill, string level, string newskill, string newlevel)
        {
            skills.AddSkill(skill, level);
            skills.EditSkill(newskill, newlevel);
        }

        [Then(@"Skill record should not be edited with '([^']*)'")]
        public void ThenSkillRecordShouldNotBeEditedWith(string newskill)
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = newskill + " has been updated to your skills";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to delete '([^']*)' '([^']*)' from profile")]
        public void WhenUserTriesToDeleteFromProfile(string skill, string level)
        {
            skills.AddSkill(skill,level);
            skills.DeleteSkill(skill);
        }


        [Then(@"'([^']*)' Should be deleted from profile")]
        public void ThenShouldBeDeletedFromProfile(string skill)
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = skill + " has been deleted";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }
    }
}
