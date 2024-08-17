using MarsApplicationOnboarding.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Login loginMars;
        private readonly Skills skills;
        public SkillsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginMars = new Login(driver);
            skills = new Skills(driver);
        }
        [Given(@"User logs into the application and navigates to Skills Section")]
        public void GivenUserLogsIntoTheApplicationAndNavigatesToSkillsSection()
        {
            loginMars.LoginActions();
        }

        [When(@"User adds '([^']*)' '([^']*)'")]
        public void WhenUserAdds(string Skill, string Skilllevel)
        {

            skills.AddSkill(Skill, Skilllevel);
        }

        [Then(@"Profile is updated with '([^']*)' and '([^']*)'")]
        public void ThenProfileIsUpdatedWithAnd(string Skill, string Skilllevel)
        {
            string Actualskill = skills.GetSkillName();
            Assert.That(Actualskill, Is.EqualTo(Skill));
        }

        [Given(@"User is logged in and navigates to profile skill section")]
        public void GivenUserIsLoggedInAndNavigatesToProfileSkillSection()
        {
            loginMars.LoginActions();
        }

        [When(@"User updates the record with '([^']*)' and '([^']*)'")]
        public void WhenUserUpdatesTheRecordWithAnd(string Skill, string Skilllevel)
        {
            skills.EditSkill(Skill, Skilllevel);
        }
        [Then(@"profile gets updated with updated '([^']*)' and '([^']*)'")]
        public void ThenProfileGetsUpdatedWithUpdatedAnd(string newSkill, string newSkilllevel)
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = newSkill + " has been updated to your skills";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));

        }

        [Given(@"User is logged in and navigates to Skill delete section")]
        public void GivenUserIsLoggedInAndNavigatesToSkillDeleteSection()
        {
            loginMars.LoginActions();
        }

        [When(@"User deletes '([^']*)' from skills")]
        public void WhenUserDeletesskillFromSkills(string skill)
        {
            skills.DeleteSkill(skill);
        }

        [Then(@"'([^']*)' Should be deleted from list")]
        public void ThenShouldBeDeletedFromList(string skill)
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = skill + " has been deleted";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));

        }

        [When(@"User tries to add new skill record with invalid data '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewSkillRecordWithInvalidDataAnd(string Skill, string Skilllevel)
        {
            skills.AddSkill(Skill, Skilllevel);
        }
        [Then(@"Skill record should not be added")]
        public void ThenSkillRecordShouldNotBeAdded()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "Please enter skill and experience level";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to add new skill record with already existing data '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewSkillRecordWithAlreadyExistingDataAnd(string Skill, string Skilllevel)
        {
            skills.AddSkill(Skill, Skilllevel);
        }

        [Then(@"User should not be able to add Skill record")]
        public void ThenUserShouldNotBeAbleToAddSkillRecord()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "This skill is already exist in your skill list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to update existing skill record without editing Skill or Skilllevel")]
        public void WhenUserTriesToUpdateExistingSkillRecordWithoutEditingSkillOrSkilllevel()
        {
            skills.EditSkillWithoutChange();
        }

        [Then(@"User Should get an error record is not modified")]
        public void ThenUserShouldGetAnErrorRecordIsNotModified()
        {
            string poppeduptext = skills.NotificationInfo();
            string Expectedtext = "This skill is already added to your skill list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }


    }
}
