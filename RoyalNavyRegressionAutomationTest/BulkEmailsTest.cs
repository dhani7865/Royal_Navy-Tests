using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Xunit;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System.Runtime.Remoting.Contexts;
using SeleniumExtras.WaitHelpers;

namespace ROYAL_NAVY_SELENIUM_TESTS
{
    [TestCategory("Royal Navy Regression Automation Test")]

    [TestClass]
    public class BulkEmailsTest
    {
        private static ExtentReports extent;

        private String test_url = "https://tpoxygen-rn-recruitment-qa/";


        private IWebDriver _driver;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                }

                return _driver;
            }

        }

        public string Title
        {
            get { return driver.Title; }
        }

        public void Goto(string url)
        {
            driver.Url = url;
        }

        public void Close()
        {
            driver.Quit();
        }



        // Start method for extent reports
        [OneTimeSetUp]
        public static void ExtentStart()
        {
            extent = new ExtentReports();

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "TestReport\\Royal Navy Bulk Emails Button Regression Test 30-11-2022.html";


            var htmlReporter = new ExtentV3HtmlReporter(reportPath);

            extent.AttachReporter(htmlReporter);

        }



        public void ExtentClose()
        {
            extent.Flush();
        }


        [TestMethod]
        // Creating a public static method for the radio buttons and creating a for each loop to get the attribute ID for the radio buttons
        public static void SelectRadioButtonWithIdStarting(string Id, IWebDriver driver)
        {
            var elements = driver.FindElements(By.XPath("//input[@type='radio']"));
            var isClicked = false;

            foreach (var item in elements)
            {
                if (item.Displayed && item.Enabled && isClicked == false)
                {
                    var radio = item.GetAttribute("id");
                    if (radio.StartsWith(Id))
                    {
                        item.Click();
                        isClicked = true;
                    }
                }
            }
            NUnit.Framework.Assert.IsTrue(isClicked);
        }

        // Scroll into view method
        private static void ScrollintoView(IWebDriver driver, By bySelector)
        {
            var element = driver.FindElement(bySelector);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }


        [TestMethod]
        public void test_BulkEmailsTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - Bulk Emails Regression Test").Info("Test Started");

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            // Test 1
            // Going to the url
            Goto(test_url);

            // Perform wait to check the output
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "RAF QA Oxygon Launched");
            test.Log(Status.Pass, "Test 1 Passed");
            extent.Flush();


            // Test 2
            // Clicking on the Bulk Emails Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(13) img"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Bulk Emails Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();


            // Test 3
            // Clicking the Create Bulk Email button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Create Bulk Email"))).Click();

            // driver.FindElement(By.LinkText("Create Bulk Email")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Create Bulk Email button");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();

            // Test 4
            // Selecting the RmxEventId
            var dropdown = driver.FindElement(By.Id("RmxEventId"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Test RMX Marine Removal");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the RmxEventId");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            // Test 5
            // Entering the Value
            driver.FindElement(By.Id("Value")).Click();
            driver.FindElement(By.Id("Value")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Value");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Entering the Description
            driver.FindElement(By.Id("Description")).Click();
            driver.FindElement(By.Id("Description")).SendKeys("description");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Description");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            // Selecting the EventDate
            driver.FindElement(By.Id("EventDate")).Click();
            driver.FindElement(By.LinkText("28")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the EventDate");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Entering the EventPostcode
            driver.FindElement(By.Id("EventPostcode")).Click();
            driver.FindElement(By.Id("EventPostcode")).SendKeys("BS1 1BA");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the EventPostcode");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Selecting the AllRoles
            driver.FindElement(By.Id("AllRoles")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the AllRoles");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Selecting the ApplicationStartDate
            driver.FindElement(By.Id("ApplicationStartDate")).Click();
            driver.FindElement(By.LinkText("19")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the ApplicationStartDate");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Selecting the ApplicationEndDate
            driver.FindElement(By.Id("ApplicationEndDate")).Click();
            driver.FindElement(By.LinkText("20")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the ApplicationEndDate");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Clicking the Preview Button
            driver.FindElement(By.CssSelector("input:nth-child(27)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Preview Button");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Bulk Email Admin"));

            // Test 13
            // Clicking the Bulk Email Admin Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Bulk Email Admin"))).Click();

            // driver.FindElement(By.LinkText("Bulk Email Admin")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Bulk Email Admin Button");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Clicking the Bulk Email Templates Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Bulk Email Templates"))).Click();

            // driver.FindElement(By.LinkText("Bulk Email Templates")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Bulk Email Templates Button");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Test 15
            // Clicking the Create Bulk Email Template Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Create Bulk Email Template"))).Click();

            // driver.FindElement(By.LinkText("Create Bulk Email Template")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Create Bulk Email Template Button");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Test 16
            // Entering the Value
            driver.FindElement(By.Id("Value")).SendKeys("tester");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Value");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Entering the Description
            driver.FindElement(By.Id("Description")).Click();
            driver.FindElement(By.Id("Description")).SendKeys("Description");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Description");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Selecting the Type ID
            dropdown = driver.FindElement(By.Id("Type_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("AFCOReferral");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Type ID");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Entering the Body
            driver.FindElement(By.Id("Body")).Click();
            driver.FindElement(By.Id("Body")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Body");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Clicking the Save button
            driver.FindElement(By.CssSelector("input:nth-child(9)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Save button");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            /*
            // Test 21
            // Clicking on the toast message to close the message
            driver.FindElement(By.CssSelector("h1:nth-child(2)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the toast message to close the message");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();
            */

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Bulk Email Admin"));

            // Test 22
            // Clicking the Bulk Email Admin button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Bulk Email Admin"))).Click();

            // driver.FindElement(By.LinkText("Bulk Email Admin")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Bulk Email Admin button");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();

            // Test 23
            // Clicking the Bulk Email Reminder Sms button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Bulk Email Reminder Sms"))).Click();

            // driver.FindElement(By.LinkText("Bulk Email Reminder Sms")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Bulk Email Reminder Sms button");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();

            // Test 24
            // Clicking the edit button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Edit"))).Click();

            // driver.FindElement(By.LinkText("Edit")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the edit button");
            test.Log(Status.Pass, "Test 24 Passed");
            extent.Flush();


            // Test 25
            // Clicking the save button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input:nth-child(7)"))).Click();


            // driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Save Button");
            test.Log(Status.Pass, "Test 26 Passed");
            extent.Flush();

            // Test 26
            // Clicking on the toast message to close the toast message
            driver.FindElement(By.CssSelector("h1:nth-child(2)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the toast message to close the toast message");
            test.Log(Status.Pass, "Test 26 Passed");
            extent.Flush();

            // Test 27
            // Clicking the Delete button
            driver.FindElement(By.LinkText("Delete")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Delete button");
            test.Log(Status.Pass, "Test 27 Passed");
            extent.Flush();


            // Test 28
            // Clicking on the toast message to close the toast message
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("p:nth-child(3)"))).Click();

            // driver.FindElement(By.CssSelector("p:nth-child(3)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the toast message to close the toast message");
            test.Log(Status.Pass, "Test 28 Passed");
            extent.Flush();


            // Clicking the toast message
            // driver.FindElement(By.Id("modal-bg")).Click();

            // test 29
            // Clicking on the Create Bulk Email Reminder SMS button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Create Bulk Email Reminder SMS"))).Click();

            // driver.FindElement(By.LinkText("Create Bulk Email Reminder SMS")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Create Bulk Email Reminder SMS button");
            test.Log(Status.Pass, "Test 29 Passed");
            extent.Flush();


            // Test 30
            // Entering the Sms Sender
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("SmsSender"))).Click();

            // driver.FindElement(By.Id("SmsSender")).Click();
            driver.FindElement(By.Id("SmsSender")).SendKeys("SMS");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Sms Sender");
            test.Log(Status.Pass, "Test 30 Passed");
            extent.Flush();

            // Test 31
            // Entering the SmsMessageText
            driver.FindElement(By.Id("SmsMessageText")).Click();
            driver.FindElement(By.Id("SmsMessageText")).SendKeys("SMS Text");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the SmsMessageText");
            test.Log(Status.Pass, "Test 31 Passed");
            extent.Flush();

            // Test 32
            // Entering the RecipientMobileNumbers
            driver.FindElement(By.Id("RecipientMobileNumbers")).Click();
            driver.FindElement(By.Id("RecipientMobileNumbers")).SendKeys("0788888888");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the RecipientMobileNumbers");
            test.Log(Status.Pass, "Test 32 Passed");
            extent.Flush();

            // Test 33
            // Clicking the save button
            driver.FindElement(By.CssSelector("input:nth-child(6)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the save button");
            test.Log(Status.Pass, "Test 33 Passed");
            extent.Flush();

            // Test 34
            // Clicking on the toast message to close the toast message
            driver.FindElement(By.CssSelector("h1:nth-child(2)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the toast message to close the toast message");
            test.Log(Status.Pass, "Test 34 Passed");
            extent.Flush();

            // Test 35
            // Clicking the Bulk Email Admin button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Bulk Email Admin"))).Click();

            // driver.FindElement(By.LinkText("Bulk Email Admin")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Bulk Email Admin button");
            test.Log(Status.Pass, "Test 35 Passed");
            extent.Flush();

            // Test 36
            // Clicking the Home button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Home"))).Click();

            // driver.FindElement(By.LinkText("Home")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Home button");
            test.Log(Status.Pass, "Test 36 Passed");
            extent.Flush();

            // quit driver after all tests completed
            driver.Quit();

        }

        [TearDown]
        public void close_Browser()
        {
            Close();
        }
    }
}
