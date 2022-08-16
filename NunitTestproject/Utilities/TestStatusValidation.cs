using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NunitTestproject.Utilities;
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_POC.Utilities
{
    public class TestStatusValidation
    {
        public IWebDriver driver;
        public ExtentReports extent;

        public static void Tests_validation(IWebDriver driver,ExtentTest test)
        {
       
    
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = TakesScreenshot.takescreenshot("Failedcases", driver);
               test.Log(Status.Fail, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }


            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Skipped)
            {
                string path = TakesScreenshot.takescreenshot("skippedcases", driver);
               test.Log(Status.Skip, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }
        }

        public static void Final_step(IWebDriver driver, ExtentTest test)
        {
            string path = TakesScreenshot.takescreenshot("FinalStep", driver);
            test.Log(Status.Pass, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
        }
    }
}
