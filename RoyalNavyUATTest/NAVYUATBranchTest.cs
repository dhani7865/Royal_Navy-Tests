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
    [TestCategory("Royal Navy UAT Test")]

    [TestClass]
    public class NAVYUATBranchTest
    {
        private static ExtentReports extent;

        private String test_url = "https://uat-www.royalnavy.mod.uk/careers/register";


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

            string reportPath = projectPath + "TestReport\\Royal NAVY UAT Branch Test 30-11-2022.html";


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
        public void test_NAVYUATBranchTest()
        {

            ExtentStart();
            var test = extent.CreateTest("Royal Navy - NAVY UAT Branch Test").Info("Test Started");

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
            // Accept Cookies
            driver.FindElement(By.CssSelector(".accept-cookies-button")).Click();
            System.Threading.Thread.Sleep(2000);

            // Test 3
            // Clicking on the I'm interested in a specific branch button
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#careerssections_0_pnlTypeOfRequest .form__field:nth-child(2) > label"))).Click();

            // driver.FindElement(By.CssSelector("#careerssections_0_pnlTypeOfRequest .form__field:nth-child(2) > label")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking on the I'm interested in a specific branch button");
            test.Log(Status.Pass, "Test 3 Passed");
            extent.Flush();

            // Test 4
            // Clicking the OK button
            driver.FindElement(By.LinkText("OK")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the OK button");
            test.Log(Status.Pass, "Test 4 Passed");
            extent.Flush();

            // Test 5
            // Selecting WHICH BRANCH ARE YOU INTERESTED IN?
            driver.FindElement(By.CssSelector(".form__row:nth-child(3) > .has-tooltip:nth-child(7) > label")).Click();
            driver.FindElement(By.CssSelector(".form__row:nth-child(3) > .form__field:nth-child(7) .form-field-selected__link")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting WHICH BRANCH ARE YOU INTERESTED IN?");
            test.Log(Status.Pass, "Test 5 Passed");
            extent.Flush();

            // Test 6
            // Selecting WHICH SERVICE ARE YOU INTERESTED IN?
            driver.FindElement(By.CssSelector(".form__field:nth-child(10) > label")).Click();
            driver.FindElement(By.CssSelector(".form__field:nth-child(10) .form-field-selected__link")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting WHICH SERVICE ARE YOU INTERESTED IN?");
            test.Log(Status.Pass, "Test 6 Passed");
            extent.Flush();

            // Test 7
            // Entering the Firstname
            driver.FindElement(By.Id("careerssections_0_txtFirstName")).Click();
            driver.FindElement(By.Id("careerssections_0_txtFirstName")).SendKeys("Aviation");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Firstname");
            test.Log(Status.Pass, "Test 7 Passed");
            extent.Flush();

            // Test 8
            // Entering the Surname
            driver.FindElement(By.Id("careerssections_0_txtSurname")).Click();
            driver.FindElement(By.Id("careerssections_0_txtSurname")).SendKeys("Second");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Surname");
            test.Log(Status.Pass, "Test 8 Passed");
            extent.Flush();

            // Test 9
            // Entering the DOB
            driver.FindElement(By.Id("careerssections_0_txtDOB")).Click();
            driver.FindElement(By.Id("careerssections_0_txtDOB")).SendKeys("02/02/1990");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the DOB");
            test.Log(Status.Pass, "Test 9 Passed");
            extent.Flush();

            // Test 10
            // Entering the email
            driver.FindElement(By.Id("careerssections_0_txtEmail")).Click();
            driver.FindElement(By.Id("careerssections_0_txtEmail")).SendKeys("dhanyaal.rashid@teleperformance.co.uk");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the email");
            test.Log(Status.Pass, "Test 10 Passed");
            extent.Flush();

            // Test 11
            // Entering the confirm email
            driver.FindElement(By.Id("careerssections_0_txtcfmEmail")).SendKeys("dhanyaal.rashid@teleperformance.co.uk");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the confirm email");
            test.Log(Status.Pass, "Test 11 Passed");
            extent.Flush();

            // Test 12
            // Entering the Mobile No
            driver.FindElement(By.Id("careerssections_0_txtMobileNo")).SendKeys("07982871086");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Mobile No");
            test.Log(Status.Pass, "Test 12 Passed");
            extent.Flush();

            // Test 13
            // Entering the Other Telephone No
            driver.FindElement(By.Id("careerssections_0_txtOtherNo")).SendKeys("07982871086");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Other Telephone No");
            test.Log(Status.Pass, "Test 13 Passed");
            extent.Flush();

            // Scrolling back into view and finding the element for the button to click on
            ScrollintoView(driver, By.CssSelector("#careerssections_0_ddlCountryOfOrigin_chosen span"));

            // Test 14
            // Selecting the COUNTRY OF ORIGIN
            // Selecting united kingdom
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#careerssections_0_ddlCountryOfOrigin_chosen span"))).Click();

            driver.FindElement(By.CssSelector("#careerssections_0_ddlCountryOfOrigin_chosen span")).Click();
            driver.FindElement(By.CssSelector("#careerssections_0_ddlCountryOfOrigin_chosen .active-result:nth-child(2)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the COUNTRY OF ORIGIN");
            test.Log(Status.Pass, "Test 14 Passed");
            extent.Flush();


            // Test 15
            // Entering the Postcode
            driver.FindElement(By.Id("careerssections_0_txtPostcode")).Click();
            driver.FindElement(By.Id("careerssections_0_txtPostcode")).SendKeys("BS1 3LG");

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Entering the Postcode");
            test.Log(Status.Pass, "Test 15 Passed");
            extent.Flush();


            // Test 16
            // Selecting No for HAVE YOU PREVIOUSLY SERVED IN THE UK MILITARY?
            bool isVisible = false;

            while (isVisible == false)
            {
                var np = driver.FindElement(By.XPath("//label[@for='careerssections_0_rbResidentYes']"));
                driver.FindElement(By.XPath("//label[@for='careerssections_0_rbMilitaryServiceNo']")).Click();

                isVisible = np.Enabled && np.Displayed;
            }
            // driver.FindElement(By.XPath("//label[@for='careerssections_0_rbMilitaryServiceNo']")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting No for HAVE YOU PREVIOUSLY SERVED IN THE UK MILITARY?");
            test.Log(Status.Pass, "Test 16 Passed");
            extent.Flush();

            // Test 17
            // Selecting YES for HAVE YOU BEEN RESIDENT IN THE UK FOR THE LAST FIVE YEARS?
            driver.FindElement(By.XPath("//label[@for='careerssections_0_rbResidentYes']")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting YES for HAVE YOU BEEN RESIDENT IN THE UK FOR THE LAST FIVE YEARS?");
            test.Log(Status.Pass, "Test 17 Passed");
            extent.Flush();


            // Test 18
            // Selecting Female for the DIVERSITY
            // driver.FindElement(By.CssSelector(".form__row--reducedmargin:nth-child(3) > .form__field:nth-child(2) > label")).Click();
            driver.FindElement(By.CssSelector(".form__row:nth-child(3) > .form__field--inline:nth-child(1) > label")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting Female for the DIVERSITY");
            test.Log(Status.Pass, "Test 18 Passed");
            extent.Flush();


            // Test 19
            // Selecting the ETHNICITY
            driver.FindElement(By.CssSelector("#careerssections_0_ddlEthnicity_chosen span")).Click();
            driver.FindElement(By.CssSelector("#careerssections_0_ddlEthnicity_chosen .active-result:nth-child(2)")).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the ETHNICITY");
            test.Log(Status.Pass, "Test 19 Passed");
            extent.Flush();

            // Test 20
            // Selecting the Nationality
            driver.FindElement(By.CssSelector("#careerssections_0_ddlNationality_chosen span")).Click();
            driver.FindElement(By.CssSelector("#careerssections_0_ddlNationality_chosen .active-result:nth-child(2)")).Click();

            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Selecting the Nationality");
            test.Log(Status.Pass, "Test 20 Passed");
            extent.Flush();

            // Test 21
            // Clicking the submit button
            // driver.FindElement(By.Id("careerssections_0_btnSubmit")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("careerssections_0_btnSubmit"))).Click();


            // 5 seconds implicit wait (C# code)
            System.Threading.Thread.Sleep(5000);
            // Logging the test in the extent report and pass status
            test.Log(Status.Info, "Clicking the submit button");
            test.Log(Status.Pass, "Test 20 Passed");
            test.Log(Status.Pass, "Test 21 Passed");
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
