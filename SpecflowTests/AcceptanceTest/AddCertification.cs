using System;
using System.Threading;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature4Steps
    {
        [Given(@"I clicked on the certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Education tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }
        
        [When(@"I add a new certification")]
        public void WhenIAddANewCertification()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();

            //Add certification/award
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")).SendKeys("ISTQB Foundation Certificate");

            //Add certified from
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")).SendKeys("Certified from ISTQB");

            //Click on Year button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")).Click();

            //Choose the Year
            IWebElement Year = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option"))[2];
            Year.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")).Click();
        }
        
        [When(@"I edit the added certification")]
        public void WhenIEditTheAddedCertification()
        {
            //Click on Edit button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i")).Click();

            //Clear Certification/Award textfield
            IWebElement CertificationTextfield = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input"));
            CertificationTextfield.Clear();
            CertificationTextfield.SendKeys("ISTQB Agile certificate");

            //Click on Update button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
        }
        
        [When(@"I delete the added certification")]
        public void WhenIDeleteTheAddedCertification()
        {
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i")).Click();
        }
        
        [Then(@"that certification should be displayed on my listings")]
        public void ThenThatCertificationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");
                IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                System.Collections.Generic.IList<IWebElement> allTableValues = tableElement.FindElements(By.TagName("td"));
                foreach (IWebElement row in allTableValues)
                {
                    if (row.Text.Equals("ISTQB Foundation Certificate"))
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certification Successfully");
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
        
        [Then(@"that certification should be edited and displayed on my listings")]
        public void ThenThatCertificationShouldBeEditedAndDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Certification");
                IWebElement tableElement = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));
                System.Collections.Generic.IList<IWebElement> allTableValues = tableElement.FindElements(By.TagName("td"));
                foreach (IWebElement row in allTableValues)
                {
                    if (row.Text.Equals("ISTQB Agile certificate"))
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, updated a Certification Successfully");
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
        
        [Then(@"that certification should be deleted from the listings")]
        public void ThenThatCertificationShouldBeDeletedFromTheListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Certification");

                Thread.Sleep(1000);
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ActualValue == null)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Certification Successfully");
                    // SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationDeleted");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted  Certification Successfully");
            }
        }
    }
    }

