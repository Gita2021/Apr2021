using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1.Pages
{
    class TMPage
    {
        public void createTM(IWebDriver driver)
        {
            //select 'create new' button
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();
            Thread.Sleep(500);

            //select type code time from dropdown:
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();


            //enter code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("0001");
            Thread.Sleep(1000);

            //enter description
            IWebElement description1 = driver.FindElement(By.XPath("//*[@id='Description']"));
            description1.SendKeys("sample0001");
            Thread.Sleep(1000);

            //enter price
            IWebElement price1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price1.Click();
            IWebElement price2 = driver.FindElement(By.Id("Price"));
            price2.SendKeys("777");
            Thread.Sleep(500);
            //click 'select file' - todo later
            //IWebElement selectFile = driver.FindElement(By.Id("files"));
            //selectFile.Click();

            //save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1000);

            //goto last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
            Thread.Sleep(2500);

            //validate if last row contains new record created

            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (actualDescription.Text == "sample0001")
            {
                Console.WriteLine("TM created, test passed");
            }
            else
            {
                Console.WriteLine("TM test failed");
            }
            Thread.Sleep(3500);
        }
        public void editTM(IWebDriver driver)
        {
            //****Edit TM
            ////click Edit button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            Thread.Sleep(2500);

            //edit code
            IWebElement element = driver.FindElement(By.Name("Code"));
            element.Clear();
            element.SendKeys("1234");
            /// driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("0002");
            Thread.Sleep(2500);

            //save record
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(3500);

            //goto last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
            Thread.Sleep(3500);
            //validate if last row contains updated record 
            IWebElement updatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            if (updatedCode.Text == "1234")
            {
                Console.WriteLine("Record updated, edit successful");
            }
            else
            {
                Console.WriteLine("Record not updated, edit not successful");
            }
            Thread.Sleep(3500);
        }
        public void deleteTM(IWebDriver driver)
        {
            //****Delete TM
            //delete record
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();
            Thread.Sleep(2500);
            //click ok in pop up
            driver.SwitchTo().Alert().Accept();

            //**verify if record deleted
            //check record count
            ////*[@id="tmsGrid"]/div[4]/span[2]
            Console.WriteLine("Record is deleted");

            

        }
    }
}
