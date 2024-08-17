using MarsApplicationOnboarding.Pages;
using NUnit.Framework;
using MarsApplicationOnboarding.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition
    {
        private readonly IWebDriver driver;
        private readonly LoginMars loginMars;
        private readonly Languages languages;

        public LanguageStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
            loginMars = new LoginMars(driver);
            languages = new Languages(driver);

        }
        [Given(@"When i Login to the Application and navigates to language section")]
        public void GivenWhenILoginToTheApplication()
        {
            loginMars.LoginActions();
        }

        [When(@"i add '([^']*)' and '([^']*)'")]
        public void WhenIAddAnd(string language, string languagelevel)
        {

            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"'([^']*)' and '([^']*)' should be added succesfully")]
        public void ThenLanguageAndLanglevelShouldBeAddedSuccesfully(string language, string languagelevel)
        {
            string Actuallanguage = languages.GetLanguageRecord();
            Assert.That(Actuallanguage, Is.EqualTo(language));

        }

        [Given(@"User is logged in and navigates to profile")]
        public void GivenUserIsLoggedInAndNavigatesToProfile()
        {
            loginMars.LoginActions();
        }

        [When(@"User edits the record with '([^']*)' and '([^']*)'")]
        public void WhenUserEditsTheRecordWithAnd(string newlanguage, string newlanguagelevel)
        {
            languages.EditLanguage(newlanguage, newlanguagelevel);

        }

        [Then(@"profile gets updated with modified '([^']*)' and '([^']*)' values")]
        public void ThenProfileGetsUpdatedWithModifiedAndValues(string newlanguage, string newlanguagelevel)
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = newlanguage + " has been updated to your languages";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));

        }

        [Given(@"User is logged in and navigates to delete section")]
        public void GivenUserIsLoggedInAndNavigatesToDeleteSection()
        {
            loginMars.LoginActions();

        }

        [When(@"User deletes '([^']*)' from profile")]
        public void WhenUserDeletesFromProfile(string language)
        {
            languages.DeleteLanguage(language);

        }

        [Then(@"'([^']*)' Should be deleted")]
        public void ThenShouldBeDeleted(string language)
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = language + " has been deleted from your languages";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));


        }

        [When(@"User tries to add new record with invalid data '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithInvalidDataAndLanguagelevel(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"language record should not be added")]
        public void ThenLanguageRecordShouldNotBeAdded()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "Please enter language and level";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }
        [When(@"User tries to add new record with already existing data '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithAlreadyExistingDataAnd(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"user should not be able to add record")]
        public void ThenUserShouldNotBeAbleToAddRecord()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "This language is already exist in your language list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to update existing record without editing language or languagelevel")]
        public void WhenUserTriesToUpdateExistingRecordWithoutEditingLanguageOrLanguagelevel()
        {
            languages.EditLangWithoutChange();
        }

        [Then(@"User Should get an error displayed and record is not modified")]
        public void ThenUserShouldGetAnErrorDisplayedAndRecordIsNotModified()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "This language is already added to your language list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }



    }
}
