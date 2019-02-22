using System;
using System.Threading;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
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
            IWebElement Skill = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option"))[1];
            Skill.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
        }

        [When(@"I edit the added Skill")]
        public void WhenIEditTheAddedSkill()
        {
            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")).Click();

            //Add Skill
            IWebElement skillTextfield = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            skillTextfield.Clear();
            skillTextfield.SendKeys("Testing");

            //Click on Update button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
        }

         [When(@"I delete the added Skill")]
         public void WhenIDeleteTheAddedSkill()
         {
          
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")).Click();
         }

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
        
        [Then(@"that Skill should be edited and displayed on my listings")]
        public void ThenThatSkillShouldBeEditedAndDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Singing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    // SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

         [Then(@"that Skill should be deleted from the listings")]
         public void ThenThatSkillShouldBeDeletedFromTheListings()
         {
              try
             {
                 //Start the Reports
                 CommonMethods.ExtentReports();
                 Thread.Sleep(1000);
                 CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");

                 Thread.Sleep(1000);
                 string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                 Thread.Sleep(500);
                 if (ActualValue == null)
                 {
                     CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Skill Successfully");
                     // SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillDeleted");
                 }

                 else
                     CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

             }
             catch (Exception e)
             {
                 CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Skill Successfully");
             }
         }
    }
}
