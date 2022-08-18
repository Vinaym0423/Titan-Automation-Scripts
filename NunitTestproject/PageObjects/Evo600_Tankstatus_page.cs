using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_POC.PageObjects
{
    public class Evo600_Tankstatus_page
    {
        public IWebDriver driver;
        public Evo600_Tankstatus_page(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[.='Tank Status']")]
        public IWebElement Tankstatustext { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://demooilcompany.mytitan.net/proxy/188141/tg/fms-tank-status/t/1']")]
        public IWebElement Tank1 { get; set; }

        public void Evo600TankstatusScreen()
        {
          Boolean verify =Tankstatustext.Displayed;
            if (verify == true)
            {
                Console.WriteLine("User is in Evo 600 Tank status screen");
            }
            else
            {
                Console.WriteLine("User not redirected to Evo 600 Tank status screen");
            }
        }

        public void Evo600_Tankstatus_Verify()
        {
            Boolean verify = Tank1.Displayed;
            if (verify == true)
            {
                Console.WriteLine("Evo 600 Tank status displayed as expected");
            }
            else
            {
                Console.WriteLine("Evo 600 Tank status not displayed as expected");
            }
        }

        //All methods are  called in single method 
        public void Evo600_tanksStatus()
        {
            Evo600TankstatusScreen();
            Evo600_Tankstatus_Verify();
        }
    }
}
