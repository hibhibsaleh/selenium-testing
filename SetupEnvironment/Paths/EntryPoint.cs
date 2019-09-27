using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todorvachev.com/selectors/css-path/";
        string cssPath = "#post-108 > div > figure > img";
        string xPath = "//*[@id=\"post-108\"]/div/figure/img";

        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl(url);

        // better to use css selector bc better supported by browsers
        // works faster than xpath
        IWebElement cssPathElement = driver.FindElement(By.CssSelector(cssPath));

        // x path is not better for performance
        IWebElement xPathElement = driver.FindElement(By.XPath(xPath));

        if (cssPathElement.Displayed)
        {
            GreenMessage("I can see the CSS Path Element!");
        }
        else
        {
            RedMessage("I can't see the CSS Path Element.");
        }

        if (xPathElement.Displayed)
        {
            GreenMessage("I can see the XPath Element!");
        }
        else
        {
            RedMessage("I can't see the XPath Element.");
        }

        driver.Quit();
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}