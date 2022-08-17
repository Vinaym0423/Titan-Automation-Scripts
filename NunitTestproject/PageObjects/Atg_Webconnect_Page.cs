using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_POC.PageObjects
{
    public  class Atg_Webconnect_Page
    {
        public IWebDriver driver;
        public Atg_Webconnect_Page(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[.='ATG Web Connect']")]
        public IWebElement atgwebconnect_text { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='idUser']")]
        public IWebElement iframe_username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='idPassword']")]
        public IWebElement iframe_password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement iframe_signin { get; set; }


        
        public void Atg_Webconnect_Screen()
        {
         Boolean verify = atgwebconnect_text.Displayed;
            if (verify == true)
                Console.WriteLine(" User is in Atg Webconnect screen");
            else
                Console.WriteLine("User not redirected to  Atg Webconnect Screen");
        }

       

        public void Iframe_Username(string un)
        {
            iframe_username.SendKeys(un);

        }

        public void Iframe_Passsword(string pwd)
        {
            iframe_password.SendKeys(pwd);
        }

        public void Iframe_Signin_Button()
        {
            iframe_signin.Click();
        }

        //All methods are  called in single method 
        public void Evo_iframe_login(string un,string pwd)
        {
            Atg_Webconnect_Screen();
            Iframe_Username(un);
            Iframe_Passsword(pwd);
            Iframe_Signin_Button();
        }
    }

}
