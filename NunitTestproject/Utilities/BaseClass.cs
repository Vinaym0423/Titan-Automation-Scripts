using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_POC.Utilities
{
    public class BaseClass :E
    {

        
        public static string takescreenshot(string type, IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"D:\\Titan Automation\\Titan-Automation-Scripts\\NunitTestproject\\Screenshots\\{type}.png";
            //string path = $"D:\\Screenshots\\{type}.png";
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);

            return path;
        }

        public static void Tests_Status_Validation(IWebDriver driver, ExtentTest test)
        {


            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = BaseClass.takescreenshot("Failedcases", driver);
                test.Log(Status.Fail, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }


            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Skipped)
            {
                string path = BaseClass.takescreenshot("Skippedcases", driver);
                test.Log(Status.Skip, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
            }
      }

        public static void Final_Step_Screenshot(IWebDriver driver, ExtentTest test)
        {
            string path = BaseClass.takescreenshot("FinalStep", driver);
            test.Log(Status.Pass, (AventStack.ExtentReports.MarkupUtils.IMarkup)test.AddScreenCaptureFromPath(path));
        }
    }
}
