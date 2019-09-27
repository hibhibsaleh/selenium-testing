using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement textBox;

    static void Main()
    {
        string url = "http://testing.todorvachev.com/special-elements/text-input-field/";

        driver.Navigate().GoToUrl(url);

        textBox = driver.FindElement(By.Name("username"));

        textBox.SendKeys("Test text");
        Thread.Sleep(2000);

        Console.WriteLine(textBox.GetAttribute("maxLength"));

        Thread.Sleep(2000);

        driver.Quit();
    }
}