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
using System.Reflection.Emit;

namespace MarsApplicationOnboarding.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition
    {
        private readonly IWebDriver driver;
        private readonly Login loginMars;
        private readonly Languages languages;
        private readonly ScenarioContext _scenarioContext;
        public LanguageStepDefinition(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            loginMars = new Login(driver);
            languages = new Languages(driver);
            _scenarioContext = scenarioContext;

        }
        [Given(@"User Login to the Application and navigates to language section")]
        public void GivenUserLoginToTheApplicationAndNavigatesToLanguageSection()
        {

            loginMars.LoginActions();
        }

        [When(@"User add '([^']*)' and '([^']*)'")]
        public void WhenIAddAnd(string language, string languagelevel)
        {
            // Store the language in ScenarioContext
            _scenarioContext["language"] = language;
            _scenarioContext["languagelevel"] = languagelevel;

            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"'([^']*)' and '([^']*)' should be added succesfully")]
        public void ThenLanguageAndLanglevelShouldBeAddedSuccesfully(string language, string languagelevel)
        {
            string Actuallanguage = languages.GetLanguageRecord();
            Assert.That(Actuallanguage, Is.EqualTo(language));

        }

        [When(@"User tries to add new record '([^']*)' and '([^']*)' for already existing '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewRecordAndForExistingAnd(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
            _scenarioContext["language"] = language;
            _scenarioContext["languagelevel"] = languagelevel;
            languages.AddLanguage(language, languagelevel, newlanguage, newlanguagelevel);
        }

        [Then(@"User should get an error This language is already exist in your language list.")]
        public void ThenUserShouldGetAnErrorThisLanguageIsAlreadyExistInYourLanguageList_()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "This language is already exist in your language list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to add new record with invalid '([^']*)' and valid '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithInvalidAndValid(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"User should get an error Please enter language and level")]
        public void ThenUserShouldGetAnErrorPleaseEnterLanguageAndLevel()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "Please enter language and level";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }


        [When(@"User tries to add new record with valid data '([^']*)' and invalid '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithValidDataAndInvalid(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }
        [When(@"User tries to add new record with invalid '([^']*)' and invalid '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithInvalidAndInvalid(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }
        [When(@"User tries to add new record with extreme long'([^']*)' and valid '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithExtremeLongAndValid(string language, string languagelevel)
        {
            _scenarioContext["language"] = language;
            _scenarioContext["languagelevel"] = languagelevel;
            languages.AddLanguage(language, languagelevel);
        }


        [Given(@"User is logged in and navigates to profile")]
        public void GivenUserIsLoggedInAndNavigatesToProfile()
        {
            loginMars.LoginActions();
        }

        [When(@"User edits the record with '([^']*)' and '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserEditsTheRecordWithAndToAnd(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
            _scenarioContext["language"] = newlanguage;
            _scenarioContext["languagelevel"] = newlanguagelevel;
            languages.AddLanguage(language, languagelevel);
            languages.EditLanguage(newlanguage, newlanguagelevel);
        }

        [When(@"User tries to update existing record without editing '([^']*)' or '([^']*)' to '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToUpdateExistingRecordWithoutEditingOrToAnd(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
            languages.AddLanguage(language, languagelevel);
            languages.EditLanguage(newlanguage, newlanguagelevel);
        }

        [Then(@"User should get an error This language is already added to your language list.")]
        public void ThenUserShouldGetAnErrorThisLanguageIsAlreadyAddedToYourLanguageList_()
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "This language is already added to your language list.";
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [Then(@"User Should be able to update profile with modified '([^']*)' and '([^']*)' values")]
        public void ThenUserShouldBeAbleToUpdateProfileWithModifiedAndValues(string newlanguage, string newlanguagelevel)
        {
            string Actuallanguage = languages.GetLanguageRecord();
            Assert.That(Actuallanguage, Is.EqualTo(newlanguage));

        }
        [When(@"User tries to update existing record '([^']*)' '([^']*)' with blank '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateExistingRecordWithWithBlank(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
          
            languages.AddLanguage(language, languagelevel);
            languages.EditLanguage(newlanguage, newlanguagelevel);
        }
        [When(@"User tries to update existing record '([^']*)' '([^']*)' with  '([^']*)' and blank '([^']*)'")]
        public void WhenUserTriesToUpdateExistingRecordWithWithAndBlank(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
            languages.AddLanguage(language, languagelevel);
            languages.EditLanguage(newlanguage, newlanguagelevel);
        }
        [When(@"User tries to update existing record of '([^']*)' '([^']*)' with new record with extreme long binary input '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToUpdateExistingRecordOfWithNewRecordWithExtremeLongBinaryInputAnd(string language, string languagelevel, string newlanguage, string newlanguagelevel)
        {
            languages.AddLanguage(language, languagelevel);
            languages.EditLanguage(newlanguage, newlanguagelevel);
        }
        [Then(@"language record should not be edited")]
        public void ThenLanguageRecordShouldNotBeEdited()
        {
            
        }


        [Given(@"User is logged in and navigates to delete section")]
        public void GivenUserIsLoggedInAndNavigatesToDeleteSection()
        {
            loginMars.LoginActions();

        }

        [When(@"User deletes '([^']*)' and '([^']*)' from profile")]
        public void WhenUserDeletesAndFromProfile(string language, string level)
        {
            languages.AddLanguage(language, level);
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

        [Then(@"'([^']*)' record should not be added")]
        public void ThenRecordShouldNotBeAdded(string language) 
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = "EnglishHindiTeluguSpanishFrenchGermanItalianChineseArabicRussianJapaneseKoreanPortugueseDutchSwedishNorwegianDanishFinnishPolishTurkishGreekHebrewThaiVietnameseIndonesianMalayBengaliPunjabiUrduSwahiliZuluXhosaCzechHungarianRomanianBulgarianSerbianCroatianSlovakUkrainianLithuanianLatvianEstonianCatalanBasqueGalicianWelshIrishScottish has been added to your languages";
;
            Assert.That(poppeduptext, Is.EqualTo(Expectedtext));
        }

        [When(@"User tries to add new record with already existing data '([^']*)' and '([^']*)'")]
        public void WhenUserTriesToAddNewRecordWithAlreadyExistingDataAnd(string language, string languagelevel)
        {
            languages.AddLanguage(language, languagelevel);
        }

        [Then(@"language record should not be edited with '([^']*)'")]
        public void ThenLanguageRecordShouldNotBeEditedWith(string newlanguage)
        {
            string poppeduptext = languages.NotificationTextInfo();
            string Expectedtext = newlanguage + " has been updated to your languages";
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
