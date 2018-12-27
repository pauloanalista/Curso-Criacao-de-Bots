using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bot.Youtube.View.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\_dev\robos\Bot\Driver");

            try
            {
                Console.WriteLine("Acessando o video");
                webDriver.LoadPage(TimeSpan.FromSeconds(20), "https://www.youtube.com/watch?v=r0A4-82uujg&list=PLDcxAw7lE_46q-Tqi0ePPAVJmJ6oJvkm1");

                Thread.Sleep(TimeSpan.FromSeconds(20));

                Console.WriteLine("Verificar se tem anuncio");
                IWebElement btnPularAnuncio = null;

                try
                {

                    btnPularAnuncio = webDriver.FindElement(By.ClassName("videoAdUiFixedPaddingSkipButtonText"));

                    Console.WriteLine("Fechando o anuncio");
                    btnPularAnuncio.Click();



                    Thread.Sleep(TimeSpan.FromSeconds(30));
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine(ex.ToString());
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
