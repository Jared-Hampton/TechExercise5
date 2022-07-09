using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TechExercise5
{
    public class Tests
    {
        String test_url = "https://www.google.com";
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver("C:/Program Files/Google/Chrome/Application");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://Google.com");

            var title = driver.Title;
            Assert.AreEqual("Google", title);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);


            var searchBox = driver.FindElement(By.Name("q"));
            var searchButton = driver.FindElement(By.Name("btnK"));

            searchBox.SendKeys("Selenium");
            searchButton.Click();

            searchBox = driver.FindElement(By.Name("q"));
            var value = searchBox.GetAttribute("value");
            Assert.AreEqual("Selenium", value);
        }
        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");

            var title = driver.Title;
            Assert.AreEqual("Bootstrap demo", title);
        }

        [TearDown]
        public void close_browser()
        {
            driver.Quit();
        }
    }
}