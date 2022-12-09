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
    public class CareerAdviserReferralsRegressionTest
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

            string reportPath = projectPath + "TestReport\\Royal Navy Career Adviser Referrals Button Regression Test 30-11-2022.html";


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
        public void test_CareerAdviserReferralsRegressionTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - Career Adviser Referrals Regression Test").Info("Test Started");

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
            // Clicking on the Career Adviser Referrals Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(14) span"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Career Adviser Referrals Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();

            // Test 3
            // Selecting the status ID and clicking the filter tasks button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("StatusId"))).Click();

            // driver.FindElement(By.Id("StatusId")).Click();

            var dropdown = driver.FindElement(By.Id("StatusId"));
            dropdown.FindElement(By.XPath("//option[. = 'Completed']")).Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div:nth-child(7) > input"))).Click();

            // driver.FindElement(By.CssSelector("div:nth-child(7) > input")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the status ID and clicking the filter tasks button");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();


            // Test 4
            // Selecting a career adviser
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Select"))).Click();

            // driver.FindElement(By.LinkText("Select")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting a career adviser");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();


            // Test 5
            // Clicking the Contact Answered button
            driver.FindElement(By.CssSelector("input:nth-child(8)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            // test.Log(Status.Info, "Clicking the Contact Answered button");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Clicking the Finish button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".script-stage:nth-child(8) > .icon"))).Click();

            // driver.FindElement(By.CssSelector(".script-stage:nth-child(8) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Finish button");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            // Selecting a call reason
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CallReasons_1__isSelected"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting a call reason");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Selecting the Media_ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedMedia_ID")));

            dropdown = driver.FindElement(By.Id("SelectedMedia_ID"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Twitter");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Media_ID");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Selecting the MarketingCampaign_ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedMarketingCampaign_ID")));

            dropdown = driver.FindElement(By.Id("SelectedMarketingCampaign_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Teleperformance");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the MarketingCampaign_ID");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Selecting the Outcome_ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedOutcome_ID")));

            dropdown = driver.FindElement(By.Id("SelectedOutcome_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("DRS closure December 21");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Outcome_ID");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Clicking the finish button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cti"))).Click();

            // driver.FindElement(By.CssSelector(".cti")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the finish button");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Clicking on the Career Adviser Referrals button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(14) span"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(14) span")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Career Adviser Referrals button");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Test 13
            // Selecting the status ID
            /*
            dropdown = driver.FindElement(By.Id("StatusId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Cancelled");
            */

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("StatusId"))).Click();

            // driver.FindElement(By.Id("StatusId")).Click();

            dropdown = driver.FindElement(By.Id("StatusId"));
            dropdown.FindElement(By.XPath("//option[. = 'Cancelled']")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the status ID");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Clicking the Filter Tasks button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-child(7) > input"))).Click();

            // driver.FindElement(By.CssSelector("div:nth-child(7) > input")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Tasks button");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Select"));

            // Test 15
            // Selecting a Career Adviser Referral
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Select"))).Click();

            // driver.FindElement(By.LinkText("Select")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting a Career Adviser Referral");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Test 16
            // Clicking the Cancel button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".narrowbtn:nth-child(4)"))).Click();

            // driver.FindElement(By.CssSelector(".narrowbtn:nth-child(4)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Cancel button");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Clicking on the Career Adviser Referrals button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(14) span"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Career Adviser Referrals button");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Selecting the Status Id
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(("StatusId"))));

            dropdown = driver.FindElement(By.Id("StatusId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Completed");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Status Id");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Clicking the Filter Tasks button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-child(7) > input"))).Click();

            // driver.FindElement(By.CssSelector("div:nth-child(7) > input")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Tasks button");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Selecting the StatusId
            dropdown = driver.FindElement(By.Id("StatusId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Cancelled (De-Duped)");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Status Id");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            // Test 21
            // Clicking the Filter Tasks button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-child(7) > input"))).Click();

            // driver.FindElement(By.CssSelector("div:nth-child(7) > input")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(6000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Tasks button");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();

            // Test 22
            // Selecting the StatusId
            dropdown = driver.FindElement(By.Id("StatusId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Deceased");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the StatusId");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();

            // Test 23
            // Clicking the Filter Tasks button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-child(7) > input"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(6000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Tasks button");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Home"));

            // Test 24
            // Clicking the Home button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Home"))).Click();

            // driver.FindElement(By.LinkText("Home")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(6000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Home button");
            test.Log(Status.Pass, "Test 24 Passed");
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
