using System;
using System.Threading;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private object driver;

        [Given(@"I clicked on the language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }
        
        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys("English");

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the Language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[1];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }

        [When(@"I edit the added language")]
        public void WhenIEditTheAddedLanguage()
        {
            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")).Click();

            //Clear Text field
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input")).Clear();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input")).SendKeys("Chinese");

            //Click on Update button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
        }

        [When(@"I delete the added language")]
        public void WhenIDeleteTheAddedLanguage()
        {
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")).Click();
           
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                System.Collections.Generic.IList<IWebElement> allTableValues = tableElement.FindElements(By.TagName("td"));
                foreach (IWebElement row in allTableValues)
                {
                    if (row.Text.Equals("English"))
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        return;
                    }
                }
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        
        [Then(@"that language should be edited and displayed on my listings")]
        public void ThenThatLanguageShouldBeEditedAndDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");
                IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                System.Collections.Generic.IList<IWebElement> allTableValues = tableElement.FindElements(By.TagName("td"));
                foreach (IWebElement row in allTableValues)
                {
                    if (row.Text.Equals("Chinese"))
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        return;
                    }
                }
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
         
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        [Then(@"that language should be deleted from the listings")]
        public void ThenThatLanguageShouldBeDeletedFromTheListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ActualValue == null)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Language Successfully");
                    // SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Language Successfully");
            }
        }
    }
}
