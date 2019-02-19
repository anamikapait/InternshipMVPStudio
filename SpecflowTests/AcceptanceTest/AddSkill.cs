using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using SpecflowTests.Utils;
using System;
using System.Threading;
using TechTalk.SpecFlow;
namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();
        }
        
        [When(@"I add a new Skill")]
        public void WhenIAddANewSkill()
        {

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys("Dancing");

            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the Skill level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
        }

        /*[When(@"I enter a new Skill")]
        public void WhenIEnterANewSkill()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit the added Skill")]
        public void WhenIEditTheAddedSkill()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I delete the added Skill")]
        public void WhenIDeleteTheAddedSkill()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I didnot choose the Skill level")]
        public void WhenIDidnotChooseTheSkillLevel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I clicked on the cancel button")]
        public void WhenIClickedOnTheCancelButton()
        {
            ScenarioContext.Current.Pending();
        }*/

        [Then(@"that Skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Dancing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    // SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        
        /*[Then(@"that Skill should be edited and displayed on my listings")]
        public void ThenThatSkillShouldBeEditedAndDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that Skill should be deleted from the listings")]
        public void ThenThatSkillShouldBeDeletedFromTheListings()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a popup should appear on the screen")]
        public void ThenAPopupShouldAppearOnTheScreen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Skill should not be displayed on my listings")]
        public void ThenTheSkillShouldNotBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
