

using AppiumSummatorTests.Window;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests.Tests
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver; // Works with Generics
        //private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        private AppiumLocalService appiumLocal;

        [SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\SummatorDesktopApp.exe");

            appiumLocal = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocal.Start();

            this.driver = new WindowsDriver<WindowsElement>(appiumLocal, options);
        }

        [TearDown]
        public void ShutDownApp()
        {
            driver.Quit();
            appiumLocal.Dispose();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_POM()
        {
            var window = new SummatorWindow(driver);
            string value1 = "5";
            string value2 = "15";
            string result = window.Calculate(value1, value2);

            Assert.AreEqual("20", result);
        }
    }
}
