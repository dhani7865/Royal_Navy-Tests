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
    public class CareersAdminRegressionTest
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

            string reportPath = projectPath + "TestReport\\Royal Navy Careers Admin Button Regression Test 29-11-2022.html";


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
        public void test_CareersAdminRegressionTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - Careers Admin Regression Test").Info("Test Started");

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
            // Clicking on the Careers Admin Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(8) span"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Careers Admin Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();


            // Test 3
            // Selecting the Career Area ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedCareerArea_ID")));

            var dropdown = driver.FindElement(By.Id("SelectedCareerArea_ID"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Engineering");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Area ID");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();


            // Test 4
            // Clicking the Filter Roles Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input:nth-child(7)")));
            driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Roles Button");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            driver.FindElement(By.Id("modal-bg")).Click();
            System.Threading.Thread.Sleep(5000);

            // Test 5
            // Clicking the edit button for a career admin
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Edit"))).Click();

            // driver.FindElement(By.CssSelector("tr:nth-child(3) a")).Click();

            // driver.FindElement(By.XPath("//input[@type='submit' and @value='Filter roles']")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the edit button for a career admin");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Selecting the Career Job Level Id
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerJobLevelId")));

            dropdown = driver.FindElement(By.Id("CareerJobLevelId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Officer");


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Job Level Id");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            // Clicking the save buton
            driver.FindElement(By.CssSelector("input:nth-child(32)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the save buton");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // driver.FindElement(By.CssSelector("modal-bg")).Click();
            // System.Threading.Thread.Sleep(2000);


            // Test 8
            // Clicking the Create New Role button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Create New Role"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Create New Role button");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Entering the E3Role
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("E3Role")));

            driver.FindElement(By.Id("E3Role")).SendKeys("Twenty two Test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the E3Role");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Entering the provider ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ProviderId"))).Click();

            // driver.FindElement(By.Id("ProviderId")).Click();
            driver.FindElement(By.Id("ProviderId")).SendKeys("13");


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the provider ID");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Entering the Website URL
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("WebsiteURL")));

            driver.FindElement(By.Id("WebsiteURL")).Click();
            driver.FindElement(By.Id("WebsiteURL")).SendKeys("Twenty four test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Website URL");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Entering the Description
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Description")));

            driver.FindElement(By.Id("Description")).Click();
            driver.FindElement(By.Id("Description")).SendKeys("Twenty four Test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Description");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Test 13
            // Selecting the Career Service ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerService_ID")));

            dropdown = driver.FindElement(By.Id("CareerService_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Engineering Line");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Service ID");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Selecting the Career Job Level Id
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerJobLevelId")));

            dropdown = driver.FindElement(By.Id("CareerJobLevelId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Other Rank");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Job Level Id");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Test 15
            // Selecting the Career Area ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerArea_ID")));

            dropdown = driver.FindElement(By.Id("CareerArea_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Logistics");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Area ID");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Test 16
            // Selecting the Career Field Id
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerFieldId")));

            dropdown = driver.FindElement(By.Id("CareerFieldId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Not Applicable");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Field Id");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Selecting the Career Journey ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerJourney_ID")));

            dropdown = driver.FindElement(By.Id("CareerJourney_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Inspire3Engineering");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Journey ID");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Selecting the Career Minimum Height Id
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("CareerMinimumHeightId")));

            dropdown = driver.FindElement(By.Id("CareerMinimumHeightId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("145 cm");


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Career Minimum Height Id");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Clicking the IsActive check box
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".field-holder:nth-child(28) .forCheckbox"))).Click();


            // driver.FindElement(By.CssSelector(".field-holder:nth-child(28) .forCheckbox")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the IsActive check box");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();


            // Test 20
            // Clicking the Create button
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='submit' and @value='Create']"))).Click();

            // driver.FindElement(By.CssSelector("input:nth-child(31)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Create button");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();


            // Test 21
            // Entering the Search Website Description
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SearchInternalDescription"))).SendKeys("Sixth Test");

            // driver.FindElement(By.Id("SearchInternalDescription")).Click();
            // driver.FindElement(By.Id("SearchInternalDescription")).SendKeys("Fifth Test	");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Search Website Description");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();


            // Test 22
            // Clicking the Filter Roles Button
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='submit' and @value='Filter roles']"))).Click();

            // driver.FindElement(By.CssSelector("input:nth-child(7)")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(10000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Filter Roles Button");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();


            // Test 23
            // Clicking the Career Services button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Career Services"))).Click();


            // driver.FindElement(By.LinkText("Career Services")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Career Services button");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();

            // Test 24
            // Clicking the Edit button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Edit"))).Click();

            // driver.FindElement(By.CssSelector("tr:nth-child(3) a")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Edit button");
            test.Log(Status.Pass, "Test 24 Passed");
            extent.Flush();

            // Test 25
            // Entering the ServiceLine
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ServiceLine"))).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ServiceLine"))).SendKeys("0799999999");

            // driver.FindElement(By.Id("ServiceLine")).Click();
            // driver.FindElement(By.Id("ServiceLine")).SendKeys("0799999999");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the ServiceLine");
            test.Log(Status.Pass, "Test 25 Passed");
            extent.Flush();

            // Test 26
            // Entering the Fulfilment Service Line
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FulfilmentServiceLine"))).Clear();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("FulfilmentServiceLine"))).SendKeys("0799999999");

            // driver.FindElement(By.Id("FulfilmentServiceLine")).Clear();
            // driver.FindElement(By.Id("FulfilmentServiceLine")).SendKeys("0799999999");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Fulfilment Service Line");
            test.Log(Status.Pass, "Test 26 Passed");
            extent.Flush();

            // Test 27
            // Clicking the Save button
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='submit' and @value='Save']"))).Click();

            // wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("input:nth-child(5)"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Save button");
            test.Log(Status.Pass, "Test 27 Passed");
            extent.Flush();

            // Test 28
            // Clicking the Careers Admin button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Careers Admin"))).Click();

            // driver.FindElement(By.LinkText("Careers Admin")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Careers Admin button");
            test.Log(Status.Pass, "Test 28 Passed");
            extent.Flush();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("modal-bg"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);

            // Test 29
            // Clicking the Career Journeys button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Career Journeys"))).Click();

            // driver.FindElement(By.LinkText("Career Journeys")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Career Journeys button");
            test.Log(Status.Pass, "Test 29 Passed");
            extent.Flush();


            // Test 29
            // Selecting a career journey
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".initial-data:nth-child(1) > td:nth-child(12)"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ExpandedHistoryTop > td:nth-child(12)"))).Click();

            // driver.FindElement(By.CssSelector(".initial-data:nth-child(1) > td:nth-child(12)")).Click();
            // driver.FindElement(By.CssSelector(".ExpandedHistoryTop > td:nth-child(12)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting a career journey");
            test.Log(Status.Pass, "Test 29 Passed");
            extent.Flush();


            // Test 30
            // Clicking the Careers Admin button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Careers Admin"))).Click();

            // driver.FindElement(By.LinkText("Careers Admin")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Careers Admin button");
            test.Log(Status.Pass, "Test 30 Passed");
            extent.Flush();

            // Test 31
            // Clicking the Export Careers button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Export Careers"))).Click();

            // driver.FindElement(By.LinkText("Export Careers")).Click();
            // wait.Until(ExpectedConditions.ElementIsVisible(By.Id("p:nth-child(3)"))).Click();

            // driver.FindElement(By.CssSelector("p:nth-child(3)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(10000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Export Careers Button");
            test.Log(Status.Pass, "Test 31 Passed");
            extent.Flush();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("modal-bg"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);

            // Test 32
            // Clicking the Home button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Home"))).Click();

            // driver.FindElement(By.LinkText("Home")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Home button");
            test.Log(Status.Pass, "Test 32 Passed");
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
