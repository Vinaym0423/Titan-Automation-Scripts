using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_Csharp_POC.PageObjects;
using NunitTestproject.Utilities;
using NUnit.Framework.Interfaces;
using Selenium_Csharp_POC.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Selenium_Csharp_POC.TestScripts
{
    [TestFixture]
    public class Evo600_UI_Scenario : TestStatusValidation
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        //Browser initialization
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Launch the browser
            driver.Url = "https://demooilcompany.mytitan.net/app/ATGWebConnect.aspx?facility=188141";  //Navigate to url
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);   //Waiter for inspecting the lately loading elements
            extent = new ExtentReports(); //Extent Reports object creation
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\Admin\Csharp\NunitTestproject\NunitTestproject\Reports\Reports.html");
            extent.AttachReporter(htmlreporter);
            this.test = extent.CreateTest("UI Scenario of 'FFS EVO 600' Tank Status Verification"); //Test name in Extent report 
        }

        //Titan Login Screen
        [Test, Order(1)]
        public void Titanlogin()
        {
            TitanLoginpage login = new TitanLoginpage(driver);
            login.Titan_Screen_Verify(); //Verify the Titan login screen displayed
            login.Username_Textfield("GaugeTesting2"); //Provide username
            login.Password_Textfield("Testing123!"); //Provide password
            login.Logon_Button(); //Click on logon button
        }


        //ATG Webconnect and EVO 600 Iframe
        [Test, Order(2)]
        public void Evo600_iframe()
        {
            AtgWebconnectPage atg = new AtgWebconnectPage(driver);
            atg.Atg_Webconnect_Screen();  //Verify the ATG WEBCONNECT screen
            driver.SwitchTo().Frame(0);  //Switch the driver to IFrame
            atg.Iframe_Username("admin");  //Provide username in Iframe
            atg.Iframe_Passsword("admin"); //Provide password in Iframe
            atg.Iframe_Signin_Button(); //Click on Sigin button
        }

        //Tanks Status Screen
        [Test,Order(3)]
        public void Evo600_TankStatus()
        {
            Evo600_Tankstatus_page status = new Evo600_Tankstatus_page(driver);
            status.Evo600_Tankstatus_Screen();  //Verify the Tankstatus screen is displayed
            status.Evo600_Tankstatus_Verify();  //Verify the Tanks status is displayed
            TestStatusValidation.Final_step(driver, test);
        }



        //Verify the Failed and Skipped Tests and Capture screenshots
        [TearDown]
        public void Tests_validation()
        {
          
            TestStatusValidation.Tests_validation(driver, test);

        }

        
        [OneTimeTearDown]
        public void Teardown()
        {
            extent.Flush();    //Refresh the extent reports
            driver.Close();   //close the browser
        }
    }
}
