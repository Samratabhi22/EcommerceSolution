using EcommerceProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace EcommerceProject.Utilities
{

    internal class BaseClass
    {
       public WebDriverUtility wdu = new WebDriverUtility();
       public IWebDriver driver;
        
        [SetUp]
        public void launchBrowser()
        {
           String browserName=ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
           
            wdu.maximizeWindow(driver);
            wdu.implicitWait(driver);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
           
        }
        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;


                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }


        }

        [TearDown]
        public void closeBrowser()
        {
           driver.Quit();  
        }
    }
}
