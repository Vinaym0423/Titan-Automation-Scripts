using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace Selenium_Csharp_POC.PageObjects
{
    public class Titan_Login_Page
    {
        public IWebDriver driver;
        public Titan_Login_Page(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='User Name']")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$Content$logOn']")]
        public IWebElement logonbutton { get; set; }

        public void Titan_Screen_Verify() {
            Boolean verify = username.Displayed;
            if (verify == true)
                Console.WriteLine(" User is in Titan Login screen");
            else
                Console.WriteLine("User not redirected to Titan Login Screen");
        } 
        public void Username_Textfield(String un)
        {
            username.SendKeys(un);
        }

        public void Password_Textfield(String pwd)
        {
            password.SendKeys(pwd);
        }

        public void Logon_Button()
        {
            logonbutton.Click();
        }

        //All methods are  called in single method for deductions of lines of code in implementatio class
        public void Titancred(String un, String pwd)
        {
            Titan_Screen_Verify();
            Username_Textfield(un);
            Password_Textfield(pwd);
            Logon_Button();

        }
        
    }
}
