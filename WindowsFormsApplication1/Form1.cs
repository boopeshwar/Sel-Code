using AddJob_Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:localhost:64237");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("identifierId")).SendKeys("dummycal81@gmail.com");
            driver.FindElement(By.Id("identifierNext")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("envirocal");
            driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(3000);
            Actions mousehover = new Actions(driver);
            mousehover.MoveToElement(driver.FindElement(By.LinkText("Job Id Creation"))).Click().Build().Perform();
            mousehover.MoveToElement(driver.FindElement(By.XPath("//*[@id='addJobMenu']/a/span"))).Click().Build().Perform();
            Thread.Sleep(2000);
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

            driver.Quit();
        }
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
