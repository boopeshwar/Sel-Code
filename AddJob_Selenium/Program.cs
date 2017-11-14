using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AddJob_Selenium
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:localhost:64237"); // Open the URL
            FindElement(driver, By.Id("identifierNext"), 40);   

            //Enter Username
            driver.FindElement(By.Id("identifierId" )).SendKeys("dummycal81@gmail.com");
            driver.FindElement(By.Id("identifierNext")).Click();

            //Enter Password
            FindElement(driver, By.XPath("//input[@type='password']"), 40);
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("envirocal");
            driver.FindElement(By.Id("passwordNext")).Click();
            Actions mousehover = new Actions(driver);
            FindElement(driver, By.LinkText("Job Id Creation"), 40);
          //  wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Job Id Creation")));


            mousehover.MoveToElement(driver.FindElement(By.LinkText("Job Id Creation"))).Click().Build().Perform();
            mousehover.MoveToElement(driver.FindElement(By.XPath("//*[@id='addJobMenu']/a/span"))).Click().Build().Perform();


            FindElement(driver, By.XPath("//select[@ng-model='jobModel.CompanyId']"), 40);
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@ng-model='jobModel.CompanyId']")));
            var company = driver.FindElement(By.XPath("//select[@ng-model='jobModel.CompanyId']"));
            var selectElement = new SelectElement(company);
            selectElement.SelectByText("ACC - Access");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.LineSize']")).SendKeys("8");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.LineProduct']")).SendKeys("CNG");
            driver.FindElement(By.Name("runLength")).SendKeys("87456.32");
            IWebElement location = driver.FindElement(By.XPath("//select[@ng-model='jobModel.JobLocationId']"));
            var selectLocation = new SelectElement(location);
            selectLocation.SelectByText("TULSA");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.Section']")).SendKeys("Section 24 to Section 98");
            PickDate.ClickDate(driver, "04/19/2018");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.ToolType']")).SendKeys("RS-Caliper");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.Tech']")).SendKeys("Caliper");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.ToolSpeed']")).SendKeys("3.5ms");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.ReportType']")).SendKeys("Prelim - Final");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.WallThickness']")).SendKeys("3.6");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.ShipMode']")).SendKeys("USPS");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.AGM']")).SendKeys("Section 67");
            driver.FindElement(By.XPath("//input[@ng-model='jobModel.BendRadius']")).SendKeys("3.2");

            IWebElement Submit = driver.FindElement(By.XPath("//button[@ng-click='saveJob()']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(Submit).Click().Perform();
            Submit.SendKeys(Keys.Enter);

            driver.Quit();
        }
        public static void FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(40));

            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

    }
}

