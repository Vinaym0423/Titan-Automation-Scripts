using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.MarkupUtils;
using NunitTestproject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Diagnostics;

namespace NunitTestproject.TestScripts {
    [TestFixture]
    public class Tests {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        //Launch the chrome browser and navigate to Url
        [OneTimeSetUp]
        public void Setup() {
            driver = new ChromeDriver();
            driver .Url = "https://demooilcompany.mytitan.net/app/ATGWebConnect.aspx?facility=188141";
            driver .Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\Admin\Csharp\NunitTestproject\NunitTestproject\Reports\Reports.html");
            extent .AttachReporter(htmlreporter);
            test = extent.CreateTest("FFS EVO Tank Status verify");
            
        }
        //Tests to  provide credentials in Titan Login Screen
        [Test, Order(1)]
        public void Titan_Screen() {
            test .Log(Status.Info, "Titan login screen ");
            bool ele = driver.FindElement(By.XPath("//input[@placeholder='User Name']")).Displayed;
            if (ele == true) Console.WriteLine("*** Titan Login screen is displayed ***");
            else Console.WriteLine("*** Titan Login Screen is Not displayed ***");
            test .Log(Status.Pass, "Titan login screen is displayed");
            driver .FindElement(By.XPath("//input[@placeholder='User Name']")).SendKeys("GaugeTesting2");
            driver .FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Testing123!");
            driver .FindElement(By.XPath("//input[@name='ctl00$Content$logOn']")).Click();
            Console .WriteLine("*** Titan login successfull ***");
            test .Log(Status.Pass, "Titan Login Successful");
        }
        //Test to provide credentials in EVO 600 iframe login screen
        [Test, Order(2)]
        public void Atg_webconnect() {
            test .Log(Status.Info, "EVO 600 ATG Webconnect Screen  ");
            bool ele = driver.FindElement(By.XPath("//div[.='ATG Web Connect']")).Displayed;
            test .Log(Status.Pass, "EVO 600  Atg_Webconnect is displayed ");
            //Assert.IsTrue(ele);
            if (ele == true) Console.Write("*** ATG Webconnect Screen is displayed ***");
            else Console.WriteLine("*** ATG Webconnect screen is not displayed ***");
            driver .SwitchTo().Frame(0);
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
            string path = TakesScreenshot.takescreenshot("FinalStep", driver);
           test.Log(Status.Pass, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            test.Log(Status.Pass, "EVO 600 tank status is displayed ");
            
        }
        //Test to Validate the tests results
        [TearDown]
        public void Tests_validation() {

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed) {
                string path = TakesScreenshot.takescreenshot("Failedcases", driver);
                test .Log(Status.Fail, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }


            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Skipped) {
                string path = TakesScreenshot.takescreenshot("skippedcases", driver);
                test .Log(Status.Skip, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }
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
