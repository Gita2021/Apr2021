using ConsoleApp1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //launch turnup portal
            IWebDriver driver = new ChromeDriver(@"D:\NewRepo");

            //page objects for login
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps(driver);

            // home page objects
            HomePage homeObj = new HomePage();
            homeObj.navigateToTM(driver);

            // tm page objectts
            TMPage tmObj = new TMPage();
            tmObj.createTM(driver);
            tmObj.editTM(driver);
            tmObj.deleteTM(driver);







        }
    }
}
