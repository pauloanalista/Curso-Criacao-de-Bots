using OpenQA.Selenium;
using prmToolkit.Configuration;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {

            var username = Configuration.GetKeyAppSettings("usuario");
            var password = Configuration.GetKeyAppSettings("senha");

            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\_dev\robos\Bot\Driver");


            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://www.instagram.com/accounts/login/");

                webDriver.SetText(By.Name("username"), username);
                webDriver.SetText(By.Name("password"), password);
                webDriver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(10));

                webDriver.LoadPage(TimeSpan.FromSeconds(10), @"https://www.instagram.com/ionicclub/");

                //webDriver.FindElement(By.XPath("//button[contains(text(), 'Seguir')]")).Click();

                IWebElement btnSeguir = null;

                try
                {
                    btnSeguir = webDriver.FindElement(By.XPath("//button[contains(text(), 'Seguir')]"));

                    btnSeguir.Click();
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("Já está seguindo o usuário");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }

            Console.ReadKey();
        }
    }
}
