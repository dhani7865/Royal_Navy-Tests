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
    public class StartScriptRegressionTest
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

            string reportPath = projectPath + "TestReport\\Royal Navy Start Script Button Regression Test 29-11-2022.html";


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
        public void test_StartScriptRegressionTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - Start Script Regression Test").Info("Test Started");

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
            // Clicking on the Start Script Button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li:nth-child(1) img"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(2000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Start Script Button");
            test.Log(Status.Pass, "Test 2 Passed");
            extent.Flush();

            // Test 3
            // Selecting the SelectedCareerService_ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("SelectedCareerService_ID")));

            var dropdown = driver.FindElement(By.Id("SelectedCareerService_ID"));

            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Royal Navy");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the SelectedCareerService_ID");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.Id("Firstname"));

            // Test 4
            // Entering the Firstname
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("Firstname")));

            driver.FindElement(By.Id("Firstname")).Click();
            driver.FindElement(By.Id("Firstname")).SendKeys("Navy");


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Firstname");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            // Test 5
            // Entering the Lastname
            driver.FindElement(By.Id("Lastname")).SendKeys("Test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Lastname");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Clicking the continue button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".isValid:nth-child(1)"))).Click();

            //driver.FindElement(By.XPath("//input[@type='submit' and @value ='Continue']")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the continue button");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();



            // Test 7
            // Clicking the contact button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".script-stage:nth-child(2) > .icon"))).Click();

            // driver.FindElement(By.CssSelector(".active")).Click();
            // driver.FindElement(By.CssSelector(".script-stage:nth-child(2) > .icon")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the contact button");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Entering the Postcode
            driver.FindElement(By.Id("Postcode")).Click();
            driver.FindElement(By.Id("Postcode")).SendKeys("BS1 3LG");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Postcode");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Entering the Email
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("dhanyaal.rashid@teleperformance.co.uk");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Email");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Entering the DateOfBirth
            driver.FindElement(By.Id("DateOfBirth")).Click();
            driver.FindElement(By.Id("DateOfBirth")).SendKeys("01/01/2000");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the DateOfBirth");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Clicking the search button
            driver.FindElement(By.CssSelector(".isValid:nth-child(1)")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the search button");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.LinkText("Create a new Contact"));

            // Test 12
            // Clicking the Create a new Contact button
            // driver.FindElement(By.LinkText("Create a new Contact")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Create a new Contact"))).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Create a new Contact button");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Test 13
            // Selecting the Gender ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Gender_ID")));

            dropdown = driver.FindElement(By.Id("Gender_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Male");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Gender ID");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Test 14
            // Selecting the qualification ID
            dropdown = driver.FindElement(By.Id("Qualification_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("AS or A Level or Higher or equivalent");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the qualification ID");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();

            // Test 15
            // Selecting the EmploymentStatus_ID
            dropdown = driver.FindElement(By.Id("EmploymentStatus_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Employed");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Employment Status ID");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();

            // Test 16
            // Selecting the Date Left Education
            driver.FindElement(By.Id("LeftEducation")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.Id("ui-datepicker-div")).Click();
            driver.FindElement(By.LinkText("5")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Date Left Education");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Selecting the Ethnicity_ID
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Ethnicity_ID")));

            dropdown = driver.FindElement(By.Id("Ethnicity_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Pakistani");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Ethnicity_ID");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();

            // Test 18
            // Selecting the Nationality_ID
            dropdown = driver.FindElement(By.Id("Nationality_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("British");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Nationality_ID");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();

            // Test 19
            // Entering the Mobile Telephone
            driver.FindElement(By.Id("ContactMethods_1__Value")).Click();
            driver.FindElement(By.Id("ContactMethods_1__Value")).SendKeys("07982871086");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Mobile Telephone");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Selecting No
            driver.FindElement(By.XPath("(//input[@id=\'IsFutureContactDisabled\'])[2]")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting No");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            // Test 21
            // Selecting the Preferred Contact Method ID
            dropdown = driver.FindElement(By.Id("PreferredContactMethodID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Email");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Preferred Contact Method ID");
            test.Log(Status.Pass, "Test 21 Passed");
            extent.Flush();

            // Test 22
            // Selecting the address type ID
            dropdown = driver.FindElement(By.Id("Addresses_0__Type_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Home");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the address type ID");
            test.Log(Status.Pass, "Test 22 Passed");
            extent.Flush();

            // Test 23
            // Clicking on the lookup button and waiting for the dropdown to appear and selecting the Address from the dropdown
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("lookup"))).Click();

            // Finding the element and address from the dopdown and clicking on the element. 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Addresses_0__SelectedSearchResult")));

            dropdown = driver.FindElement(By.Id("Addresses_0__SelectedSearchResult"));

            System.Threading.Thread.Sleep(5000);


            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Teleperformance, Spectrum House, Bond Street, BRISTOL");

            System.Threading.Thread.Sleep(5000);


            // Selecting the address from the search result and double clicking on the element
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("use"))).Click();

            // driver.FindElement(By.ClassName("use")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the lookup button and waiting for the dropdown to appear and selecting the Address from the dropdown");
            test.Log(Status.Pass, "Test 23 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector("form > input:nth-child(9)"));

            // Test 24
            // Clicking the create contact button
            driver.FindElement(By.CssSelector("form > input:nth-child(9)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the create contact button");
            test.Log(Status.Pass, "Test 24 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector(".script-stage:nth-child(3) > .icon"));

            // Test 25
            // Clicking the Application Enquiry button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".script-stage:nth-child(3) > .icon"))).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Application Enquiry button");
            test.Log(Status.Pass, "Test 25 Passed");
            extent.Flush();

            // Test 26
            // Clicking the New application enquiry button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("New application enquiry"))).Click();

            // driver.FindElement(By.LinkText("New application enquiry")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Application Enquiry button");
            test.Log(Status.Pass, "Test 26 Passed");
            extent.Flush();

            // Test 27
            // Searching for Search Type
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("SearchType"))).Click();

            // driver.FindElement(By.Id("SearchType")).Click();
            driver.FindElement(By.Id("SearchType")).Click();

            driver.FindElement(By.LinkText("Select")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Searchiung for Search Type");
            test.Log(Status.Pass, "Test 27 Passed");
            extent.Flush();

            // Test 28
            // Selecting the sub status
            driver.FindElement(By.Id("SelectedSubStatus_ID")).Click();
            {
                dropdown = driver.FindElement(By.Id("SelectedSubStatus_ID"));
                dropdown.FindElement(By.XPath("//option[. = 'Ready to apply']")).Click();
            }

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the sub status");
            test.Log(Status.Pass, "Test 28 Passed");
            extent.Flush();

            // Test 29
            // Clicking the continue button
            driver.FindElement(By.CssSelector("form > input")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the continue button");
            test.Log(Status.Pass, "Test 29 Passed");
            extent.Flush();

            /*
            // Test 30
            // Clicking the view roles button 
            driver.FindElement(By.CssSelector(".script-stage:nth-child(4) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the view roles button");
            test.Log(Status.Pass, "Test 30 Passed");
            extent.Flush();
            */

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector(".script-stage:nth-child(5) > .icon"));

            // Test 31
            // Clicking the Schedule Callback button
            driver.FindElement(By.CssSelector(".script-stage:nth-child(5) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Schedule Callback button");
            test.Log(Status.Pass, "Test 31 Passed");
            extent.Flush();

            // Test 32
            // Selecting the Callback Date
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("CallbackDate"))).Click();

            driver.FindElement(By.Id("CallbackDate")).Click();
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("31"))).Click();

            driver.FindElement(By.LinkText("29")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Callback Date");
            test.Log(Status.Pass, "Test 32 Passed");
            extent.Flush();

            // Test 33
            // Selecting the task slot
            driver.FindElement(By.Id("TaskSlot_ID")).Click();
            {
                dropdown = driver.FindElement(By.Id("TaskSlot_ID"));
                dropdown.FindElement(By.XPath("//option[. = 'Morning (From 8:00)']")).Click();
            }

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the task slot");
            test.Log(Status.Pass, "Test 33 Passed");
            extent.Flush();

            // Test 34
            // Entering the Notes
            driver.FindElement(By.Id("Notes")).Click();
            driver.FindElement(By.Id("Notes")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Notes");
            test.Log(Status.Pass, "Test 34 Passed");
            extent.Flush();

            // Test 35
            // Clicking the save button
            driver.FindElement(By.Name("command")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the save button");
            test.Log(Status.Pass, "Test 35 Passed");
            extent.Flush();


            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector(".script-stage:nth-child(6) > .icon"));

            // Test 36
            // Clicking on the Fulfilment button
            // driver.FindElement(By.CssSelector(".script-stage:nth-child(6) > .icon")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".script-stage:nth-child(6) > .icon"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the Fulfilment button");
            test.Log(Status.Pass, "Test 36 Passed");
            extent.Flush();

            // Test 37
            // Clicking ther Send Brochure button
            driver.FindElement(By.LinkText("Send Brochure")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking ther Send Brochure button");
            test.Log(Status.Pass, "Test 37 Passed");

            // Test 38
            // extent flush and selecting a brochure
            // extent.Flush();
            driver.FindElement(By.LinkText("Select")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Extent flush and selecting a brochure");
            test.Log(Status.Pass, "Test 38 Passed");

            // Test 39
            // Clicking the confirm button
            driver.FindElement(By.Id("confirmId")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(6000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the confirm button");
            test.Log(Status.Pass, "Test 39 Passed");

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector(".script-stage:nth-child(6) > .icon"));

            // Test 40
            // Clicking the Fulfilment button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".script-stage:nth-child(6) > .icon"))).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(8000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Fulfilment button");
            test.Log(Status.Pass, "Test 40 Passed");

            // Test 41
            // Clicking the Send Bespoke Email button
            driver.FindElement(By.LinkText("Send Bespoke Email")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Send Bespoke Email button");
            test.Log(Status.Pass, "Test 41 Passed");

            // Test 42
            // Entering the Email Subject
            driver.FindElement(By.Id("EmailSubject")).Click();
            driver.FindElement(By.Id("EmailSubject")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Email Subject");
            test.Log(Status.Pass, "Test 42 Passed");

            // Test 43
            // Entering the Email Text
            driver.FindElement(By.Id("EmailText")).Click();
            driver.FindElement(By.Id("EmailText")).SendKeys("test");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Email Text");
            test.Log(Status.Pass, "Test 43 Passed");

            // Test 44
            // Clicking the Send button
            driver.FindElement(By.CssSelector("input:nth-child(4)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Send button");
            test.Log(Status.Pass, "Test 44 Passed");

            // Test 45
            // Clicking the Promotion button
            driver.FindElement(By.CssSelector(".script-stage:nth-child(7) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the Promotion button");
            test.Log(Status.Pass, "Test 45 Passed");


            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector(".script-stage:nth-child(8) > .icon"));

            // test 46
            // Clicking the finish button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".script-stage:nth-child(8) > .icon"))).Click();

            // driver.FindElement(By.CssSelector(".script-stage:nth-child(8) > .icon")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the finish button");
            test.Log(Status.Pass, "Test 46 Passed");

            // Test 47
            // Selecting the Call Reasons
            driver.FindElement(By.Id("CallReasons_0__isSelected")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Call Reasons");
            test.Log(Status.Pass, "Test 48 Passed");

            // Test 49
            // Selecting the media ID
            driver.FindElement(By.Id("SelectedMedia_ID")).Click();
            {
                dropdown = driver.FindElement(By.Id("SelectedMedia_ID"));
                dropdown.FindElement(By.XPath("//option[. = 'LinkedIn']")).Click();
            }

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the media ID");
            test.Log(Status.Pass, "Test 49 Passed");

            // Test 50
            // Selecting the MarketingCampaign_ID
            driver.FindElement(By.Id("SelectedMarketingCampaign_ID")).Click();
            {
                dropdown = driver.FindElement(By.Id("SelectedMarketingCampaign_ID"));
                dropdown.FindElement(By.XPath("//option[. = 'Teleperformance']")).Click();
            }

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the MarketingCampaign_ID");
            test.Log(Status.Pass, "Test 50 Passed");

            // Test 51
            // Selecting the Outcome_ID
            dropdown = driver.FindElement(By.Id("SelectedOutcome_ID"));

            selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("DRS closure December 21");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(3000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Outcome_ID");
            test.Log(Status.Pass, "Test 51 Passed");

            // Test 52
            // Clicking the finish button
            driver.FindElement(By.CssSelector(".cti")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the finish button");
            test.Log(Status.Pass, "Test 52 Passed");

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
