using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDemo
{
    [TestClass]
    public class UnitTest1
    {
        private static WindowsDriver<WindowsElement> session;

        [ClassInitialize]
        public void BeforeTests()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }
        

        [TestMethod]
        public void AddNumbers()
        {
            session.FindElementByAccessibilityId("num8Button").Click();
            session.FindElementByAccessibilityId("plusButton").Click();
            session.FindElementByAccessibilityId("num3Button").Click();
            session.FindElementByName("Equals").Click();
            Console.WriteLine(session.FindElementByAccessibilityId("CalculatorResults").Text);
            Assert.IsTrue(session.FindElementByAccessibilityId("CalculatorResults").Text.Equals("Display is 11"));
        }

        [ClassCleanup]
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
