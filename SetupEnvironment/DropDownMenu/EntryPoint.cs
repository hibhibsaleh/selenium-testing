using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement dropDownMenu;
    static IWebElement elementFromTheDropDownMenu;

    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
        string dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(3)";

        driver.Navigate().GoToUrl(url);

        // check value
        dropDownMenu = driver.FindElement(By.Name("DropDownTest"));

        Console.WriteLine("The selected value is: " + dropDownMenu.GetAttribute("value"));

        // check certain value
        elementFromTheDropDownMenu = driver.FindElement(By.CssSelector(dropDownMenuElements));

        Console.WriteLine("The third option from the drop down menu is: " + elementFromTheDropDownMenu.GetAttribute("value"));

        elementFromTheDropDownMenu.Click();

        Console.WriteLine("The selected value is: " +  dropDownMenu.GetAttribute("value"));
        Thread.Sleep(3000);

        // check all values
        for (int i = 1; i <= 4; i++)
        {
            dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(" + i + ")";
            elementFromTheDropDownMenu = driver.FindElement(By.CssSelector(dropDownMenuElements));

            Console.WriteLine("The " + i + " option from the drop down menu is: " + elementFromTheDropDownMenu.GetAttribute("value"));
        }

        Thread.Sleep(15000);

        driver.Quit();
    }
}