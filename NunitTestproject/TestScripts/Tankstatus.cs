using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Diagnostics;
using Selenium_Csharp_POC.Utilities;
using Selenium_Csharp_POC.PageObjects;

namespace NunitTestproject.TestScripts {
    [TestFixture]
    public class Tests {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        //Launch the chrome browser and navigate to Url
        [OneTimeSetUp]
        public void Setup() {
            driver = new ChromeDriver(); //Launch the browser
            driver.Url = "https://demooilcompany.mytitan.net/app/ATGWebConnect.aspx?facility=188141";  //Navigate to url
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);   //Waiter for inspecting the lately loading elements
            extent = new ExtentReports(); //Extent Reports object creation
            string reportpath = "D://Titan Automation//Titan-Automation-Scripts//NunitTestproject//Reports//Reports.html";
            var htmlreporter = new ExtentHtmlReporter(@reportpath);
            extent.AttachReporter(htmlreporter);
            test = extent.CreateTest("Test Status");
        }

        //Tests to  provide credentials in Titan Login Screen
        [Test, Order(1)]
        public void Titan_Screen() {
            test .Log(Status.Info, "Titan login screen ");
            Titan_Login_Page login = new Titan_Login_Page(driver);
            test.Log(Status.Pass, "Titan login screen is displayed");
            login.Username_Textfield("");
            login.Password_Textfield("");
            login.Logon_Button();
            
            test .Log(Status.Pass, "Titan Login Successful");
        }
        //Test to provide credentials in EVO 600 iframe login screen
        [Test, Order(2)]
        public void Atg_webconnect() {
            test .Log(Status.Info, "EVO 600 ATG Webconnect Screen  ");
            Atg_Webconnect_Page atg = new Atg_Webconnect_Page(driver);
           
            test .Log(Status.Pass, "EVO 600  Atg_Webconnect iframe is displayed ");
            driver .FindElement(By.XPath("//input[@placeholder='User']")).SendKeys("admin");
            driver .FindElement(By.XPath("//input[@id='idPassword']")).SendKeys("admin");
            driver .FindElement(By.XPath("//button[@type='submit']")).Click();
            test .Log(Status.Pass, " EVO 600 Iframe login is succssful ");
        }
        //Test to verify the EVO 600 tanks status
        [Test, Order(3)]
        public void Tank_Status() {
            test .Log(Status.Info, "EVO 600 tank status screen");
            bool ele = driver.FindElement(By.XPath("//a[@href='https://demooilcompany.mytitan.net/proxy/188141/tg/fms-tank-status/t/1']")).Displayed;
            if (ele == true) Console.WriteLine("*** EVO 600 Tanks Status Screen displayed ***");
            else Console.WriteLine("*** EVO 600 Tanks Status screen not displayed ***");
             BaseClass.Final_Step_Screenshot(driver, test);
            test.Log(Status.Pass, "EVO 600 tank status is displayed ");
            
        }
        //Test to Validate the tests results
        [TearDown]
        public void Tests_validation() {

            BaseClass.Tests_Status_Validation(driver, test);
        }
        //Test to close the browser after complete execution
        [OneTimeTearDown]
        public void Close_browser() {
            driver .Close();
            extent .Flush();
        }
    }
    //driver.FindElement(By.XPath(""))
}
