using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_POC.Utilities
{
    public class Extent_Class
    {

        public static ExtentTest Report()
        {
            ExtentReports extent = new ExtentReports(); //Extent Reports object creation
            string reportpath = "D://Titan Automation//Titan-Automation-Scripts//NunitTestproject//Reports//Reports.html";
            var htmlreporter = new ExtentHtmlReporter("");
            extent.AttachReporter(htmlreporter);
            ExtentTest test = extent.CreateTest("UI Scenario of  Tank Status Verification"); //Test name in Extent report 
            return test;
        }
    }
}
