using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace EcommerceProject.TestScripts
{
    [TestFixture]
    public class Test1
    {
        
        [SetUp]
        public void BeforeMethod()
        {
            TestContext.Out.WriteLine("This is from BeforeMethod");
            
        }
        [Test,Order(2)]
        [Category("a")]
        public void test1()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            TestContext.Out.WriteLine("This is from test1 method");
            driver.Close();
        }
        [Test,Order(1)]
        [Category("a")]
        public void test2()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            IWebDriver driver = new EdgeDriver();
            TestContext.Out.WriteLine("This is from test1 method");
            driver.Close();
            TestContext.Out.WriteLine("This is from test2 method");
        }

        [TearDown]
        public void AfterMethod()
        {
            TestContext.Out.WriteLine("This is from AfterMethod");
        }
        [OneTimeSetUp]
        public void BeforeClass()
        {
            TestContext.Out.WriteLine("This is from BeforeClass");
        }
        [OneTimeTearDown]
        public void AfterClass()
        {
            TestContext.Out.WriteLine("This is from AfterClass");
        }

    }
}
