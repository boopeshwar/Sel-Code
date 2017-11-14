using OpenQA.Selenium;
using System;
using System.Globalization;
using System.Threading;

namespace AddJob_Selenium
{
    public static class PickDate
    {

        public static void ClickDate(IWebDriver driver, string date)
        {
            // Click on the Run Date calendar button
            IWebElement RunDateCalendar = driver.FindElement(By.XPath("//button[@class='btn btn-default'][1]"));
            RunDateCalendar.Click();

            //button to move next in calendar
            //IWebElement next = driver.FindElement(By.XPath("//button[@ng-click='move(1)']"));

            // button to move previous in calendar
            //IWebElement prev = driver.FindElement(By.XPath("//button[@ng-click='move(-1)']"));

            // button to click in center of calendar header
            IWebElement header = driver.FindElement(By.XPath("//button[@role='heading']"));

            string[] date_MM_dd_yyyy = (date.Split('/'));
            int yearDiff = int.Parse(date_MM_dd_yyyy[2]) - DateTime.Now.Year;
            header.Click();

            // Year Selection
            if (yearDiff != 0)
            {
                // if you have to move next year
                if (yearDiff > 0)
                {
                    for (int i = 0; i < yearDiff; i++)
                    {
                        Console.WriteLine("Year Diff->" + i);
                        IWebElement next = driver.FindElement(By.XPath("//button[@ng-click='move(1)']"));
                        next.Click();
                    }
                }
                // if you have to move previous year
                else if (yearDiff < 0)
                {
                    try
                    {
                        for (int i = 0; i < (yearDiff * (-1)); i++)
                        {
                            Console.WriteLine("Year Diff->" + i);
                            IWebElement prev = driver.FindElement(By.XPath("//button[@ng-click='move(-1)']"));
                            prev.Click();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
                Thread.Sleep(1000);
            }
            // Getting all the months
            int iMonth = int.Parse(date_MM_dd_yyyy[0]);
            string selectMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(iMonth);

            var months = driver.FindElements(By.CssSelector(".ng-isolate-scope>table>tbody>tr>td>button>span"));
            foreach (var webElement in months)
            {
                string monthText = webElement.Text;
                if (monthText.Equals(selectMonth))
                {
                    webElement.Click();
                    break;
                }

            }


            // Getting all the dates
            int iDate = int.Parse(date_MM_dd_yyyy[1]);

            //string t = iDate.ToString("0#.#");
            var dates = driver.FindElements(By.CssSelector(".ng-isolate-scope>table>tbody>tr>td[id]"));
            foreach (var webElement in dates)
            {
                string dayText = webElement.Text;
                if (iDate == int.Parse(dayText))
                {
                    webElement.Click();
                    break;
                }
            }
        }
    }
}
