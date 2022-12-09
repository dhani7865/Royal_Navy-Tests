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
    public class NextTaskRegressionTest
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

            string reportPath = projectPath + "TestReport\\Royal Navy Next Task Button Regression Test 29-11-2022.html";


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
        public void test_NextTaskRegressionTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - Next Task Regression Test").Info("Test Started");

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
            // Clicking on the Next Task Button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(3) img"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Next Task Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector("input:nth-child(8)"));


            // Test 3
            // Clicking the Contact Answered button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input:nth-child(8)"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the StatusID");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();

            // Test 4
            // Clicking the Finish button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".script-stage:nth-child(8) > .icon"))).Click();

            // driver.FindElement(By.CssSelector(".script-stage:nth-child(8) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Contact Answered button");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            // Test 5
            // Selecting the call reason
            // wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("CallReasons_0__isSelected"))).Click();

            driver.FindElement(By.Id("CallReasons_0__isSelected")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the call reason");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Selecting the media ID
            // wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("SelectedMedia_ID")));

            var dropdown = driver.FindElement(By.Id("SelectedMedia_ID"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Facebook");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the media ID");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            // Selecting the marketingCampaign_ID
            // wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("SelectedMarketingCampaign_ID")));

            dropdown = driver.FindElement(By.Id("SelectedMarketingCampaign_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Teleperformance");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the marketingCampaign_ID");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Selecting the Outcome_ID
            // wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedOutcome_ID")));

            dropdown = driver.FindElement(By.Id("SelectedOutcome_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Still uncertain");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Outcome_ID");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Entering the notes
            driver.FindElement(By.Id("Notes")).Clear();
            driver.FindElement(By.Id("Notes")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the notes");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Clicking the finish button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cti"))).Click();

            // driver.FindElement(By.CssSelector(".cti")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the finish button");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Clicking the Next Task button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(3) img"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Next Task button");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Clicking the No Answer button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".narrowbtn:nth-child(7)"))).Click();

            // driver.FindElement(By.CssSelector(".narrowbtn:nth-child(7)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the No Answer button");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Selecting the date and time
            driver.FindElement(By.Id("ScheduleDate")).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ScheduleDate"))).SendKeys("03/12/2022");

            // driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            // driver.FindElement(By.LinkText("4")).Click();

            // wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ScheduleDate"))).SendKeys("10/12/2022");


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the date and time");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Test 15
            // Clicking the continue button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input:nth-child(11)"))).Click();

            // driver.FindElement(By.CssSelector("input:nth-child(11)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the continue button");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Task 16
            // Clicking the Next Task button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(3) img"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Next Task button");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Clicking the Abandon button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".narrowbtn:nth-child(5)"))).Click();

            // driver.FindElement(By.CssSelector(".narrowbtn:nth-child(5)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Abandon button");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Clicking the Next Task button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(3) img"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Next Task button");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Clicking the Cancel button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".narrowbtn:nth-child(4)"))).Click();

            // driver.FindElement(By.CssSelector(".narrowbtn:nth-child(4)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Cancel button");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Clicking the Next Task button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(3) img"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Next Task button");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            // Test 21
            // Clicking the Deceased button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".narrowbtn:nth-child(3)"))).Click();

            // driver.FindElement(By.CssSelector(".narrowbtn:nth-child(3)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Deceased button");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();

            /*
            // Test 22
            // Clicking the ok button
            // Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("You have indicated that the recipient is deceased, click OK to Confirm"));
            // Check the presence of alert
            IAlert alert = driver.SwitchTo().Alert();
            // Alert present; set the flag
            presentFlag = true;
            // if present consume the alert
            alert.Accept();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the ok button");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();
            

            // Test 23
            // Clicking the Next Task button
            driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Next Task button");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();
            */

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
