using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
namespace NunitTestproject.Utilities
{
    public class TakesScreenshot
    {
        public static string takescreenshot(string type, IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"D:\\Titan Automation\\Titan-Automation-Scripts\\NunitTestproject\\Screenshots\\{type}.png";
           //string path = $"D:\\Screenshots\\{type}.png";
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            
            return path;
        }
    }
}