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
    public class AFCOManagerRegressionTest
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

            string reportPath = projectPath + "TestReport\\Royal Navy AFCO Manager Button Regression Test 29-11-2022.html";


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
        public void test_AFCOManagerRegressionTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - AFCO Manager Regression Test").Info("Test Started");

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
            // Clicking on the AFCO Manager Button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(7) img"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the AFCO Manager Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();


            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Home"));

            // Test 3
            // Clicking the Home button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Home"))).Click();

            // driver.FindElement(By.LinkText("Home")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Home button");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();

            // Test 4
            // Clicking on the AFCO Manager button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li:nth-child(7) img"))).Click();

            // driver.FindElement(By.CssSelector("li:nth-child(7) img")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the DRS Feedback button");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            // Test 5
            // Entering test for the name
            driver.FindElement(By.Id("Name")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering test for the name");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Clicking the select button
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".isValid:nth-child(1)"))).Click();

            driver.FindElement(By.CssSelector(".isValid:nth-child(1)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the select button");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("tr:nth-child(2) a"))).Click();

            // driver.FindElement(By.CssSelector("tr:nth-child(2) a")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            // test.Log(Status.Info, "Clicking the select button");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Entering the email address
            driver.FindElement(By.Id("AfcoDetails_EmailAddress")).Clear();
            driver.FindElement(By.Id("AfcoDetails_EmailAddress")).SendKeys("123@gmail.com");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the email address");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Entering the postcode
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_Postcode")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_Postcode")).SendKeys("BS1 3LG");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the postcode");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Entering the phone number
            driver.FindElement(By.Id("AfcoDetails_PrimaryPhoneNumber")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryPhoneNumber")).SendKeys("0788888888");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the phone number");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Clicking the update button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input:nth-child(17)"))).Click();

            // driver.FindElement(By.CssSelector("input:nth-child(17)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(4000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the update button");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Clicking the Add new AFCO button
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Add new AFCO"))).Click();

            // driver.FindElement(By.LinkText("Add new AFCO")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(4000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Add new AFCO button");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Test 13
            // Entering the Afco Details Name
            driver.FindElement(By.Id("AfcoDetails_Name")).Clear();
            driver.FindElement(By.Id("AfcoDetails_Name")).SendKeys("first");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Afco Details Name");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Selecting the Type ID
            var dropdown = driver.FindElement(By.Id("AfcoDetails_TypeId"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("RMR");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Type ID");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Test 15
            // Selecting the Region ID
            dropdown = driver.FindElement(By.Id("AfcoDetails_RegionId"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Northern England");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Region ID");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Test 16
            // Entering the address line 1
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_AddressLine1")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_AddressLine1")).SendKeys("teleperformance");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the address line 1");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Entering the PostalTown
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_PostalTown")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_PostalTown")).SendKeys("Bristol");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the PostalTown");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Entering the Postcode
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_Postcode")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryAddress_Postcode")).SendKeys("BS1 3LG");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Postcode");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Entering the Phone Number
            driver.FindElement(By.Id("AfcoDetails_PrimaryPhoneNumber")).Clear();
            driver.FindElement(By.Id("AfcoDetails_PrimaryPhoneNumber")).SendKeys("07554402128");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Phone Number");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Entering the Email Address
            driver.FindElement(By.Id("AfcoDetails_EmailAddress")).Clear();
            driver.FindElement(By.Id("AfcoDetails_EmailAddress")).SendKeys("dhanyaal.rashid@teleperformance.co.uk");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Email Address");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            // Test 21
            // Entering the Directions
            driver.FindElement(By.Id("AfcoDetails_Directions")).Clear();
            driver.FindElement(By.Id("AfcoDetails_Directions")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Directions");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();

            // Test 22
            // Entering the Bhol Instructions
            driver.FindElement(By.Id("AfcoDetails_BholInstructions")).Clear();
            driver.FindElement(By.Id("AfcoDetails_BholInstructions")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Bhol Instructions");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();

            // Test 23
            // Entering the Other Instructions
            driver.FindElement(By.Id("AfcoDetails_OtherInstructions")).Clear();
            driver.FindElement(By.Id("AfcoDetails_OtherInstructions")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Other Instructions");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();

            // Test 24
            // Clicking the add button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input:nth-child(16)"))).Click();

            // driver.FindElement(By.CssSelector("input:nth-child(16)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the add button");
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
