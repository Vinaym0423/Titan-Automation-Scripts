using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Selenium_Csharp_POC.PageObjects;
using Selenium_Csharp_POC.Utilities;
using Xunit.Sdk;

namespace NunitTestproject.TestScripts
{
    [TestFixture]
    public class Fail_Case 
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        //Launch the browser and navigate to Url
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demooilcompany.mytitan.net/app/ATGWebConnect.aspx?facility=188141";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
         test = BaseClass.Extent_reports("Failed Cases");
        }

        //Wrong titan credentials provided for tests failure
        [Test, Order(1)]
        public void Titan_Screen()
        {
            test.Log(Status.Info, " Titan login screen is displayed ");
            Titan_Login_Page login = new Titan_Login_Page(driver);
            login.Titan_Screen_Verify();
            login.Username_Textfield("ABC");  //Wrong username
            login.Password_Textfield("123");  //Wrong password
            login.Logon_Button();
            test.Log(Status.Pass, " Titan login screen succesful ");
        }

        //These Test will fail as expected
        [Test,Order(2)]
        public void Atg_webconnect_screen()
        {
            Atg_Webconnect_Page atg = new Atg_Webconnect_Page(driver);
            atg.Atg_Webconnect_Screen();
        }



        [Test]
        [Ignore("Ignore these Test")]
      public void Skip()
        {

        }

        //Validate the Tests results 
        [TearDown]
        public void Tests_validation()
        {
   
            BaseClass.Tests_Status_Validation(driver,test);
        }

        

        [OneTimeTearDown]
        public void Close_browser()
        {
            driver.Close();
            extent.Flush();
        }
    }
}
