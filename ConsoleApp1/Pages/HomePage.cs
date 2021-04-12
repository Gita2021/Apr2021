using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1.Pages
{
    class HomePage
    {
        public void navigateToTM(IWebDriver driver)
        {
            //****create TM
            //open Administration tab

            IWebElement Administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administration.Click();
            Thread.Sleep(500);


            //select Time & Material from Administration tab
            IWebElement TimeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeMaterial.Click();
            Thread.Sleep(500);
        }
    }
}
