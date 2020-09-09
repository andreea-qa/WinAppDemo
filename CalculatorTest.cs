using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDemo
{
    [TestClass]
    public class CalculatorTest
    {
        private static WindowsDriver<WindowsElement> session;
        const string calcApp = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        [TestInitialize]
        public void BeforeTests()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", calcApp);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }
        

        [TestMethod]
        public void VerifyAdditionWorksAsExpected()
        {
            session.FindElementByAccessibilityId("num8Button").Click();
            session.FindElementByAccessibilityId("plusButton").Click();
            session.FindElementByAccessibilityId("num3Button").Click();
            session.FindElementByAccessibilityId("equalButton").Click();
            Console.WriteLine(session.FindElementByAccessibilityId("CalculatorResults").Text);
            Assert.IsTrue(session.FindElementByAccessibilityId("CalculatorResults").Text.Equals("Display is 11"));
        }

        [TestMethod]
        public void VerifySubtractionWorksAsExpected()
        {
            session.FindElementByName("Nine").Click();
            session.FindElementByName("Minus").Click();
            session.FindElementByName("Four").Click();
            session.FindElementByName("Equals").Click();
            Console.WriteLine(session.FindElementByAccessibilityId("CalculatorResults").Text);
            Assert.IsTrue(session.FindElementByAccessibilityId("CalculatorResults").Text.Equals("Display is 5"));
        }

        [TestMethod]
        public void VerifyMultiplicationWorksAsExpected()
        {
            session.FindElementByXPath("//Button[@Name='Six']").Click();
            session.FindElementByXPath("//Button[@Name='Multiply by']").Click();
            session.FindElementByXPath("//Button[@Name='Seven']").Click();
            session.FindElementByXPath("//Button[@Name='Equals']").Click();
            Console.WriteLine(session.FindElementByAccessibilityId("CalculatorResults").Text);
            Assert.IsTrue(session.FindElementByAccessibilityId("CalculatorResults").Text.Equals("Display is 42"));
        }

        [TestMethod]
        public void VerifyDivisionWorksAsExpected()
        {
            session.FindElementByAccessibilityId("CalculatorResults").SendKeys("15/3");
            session.FindElementByAccessibilityId("CalculatorResults").SendKeys(Keys.Enter);
            Console.WriteLine(session.FindElementByAccessibilityId("CalculatorResults").Text);
            Assert.IsTrue(session.FindElementByAccessibilityId("CalculatorResults").Text.Equals("Display is 5"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (session != null) 
            {
                session.Quit();
                session = null;
            }
        }
    }
}
