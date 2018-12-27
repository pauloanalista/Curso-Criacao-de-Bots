using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bot.WhatsApp.Share.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"C:\_dev\robos\Bot\Driver", false);

            try
            {
                Console.WriteLine("Abrindo o WhatsApp Web");
                webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://web.whatsapp.com");

                Console.WriteLine("Pegue seu celular e leia o QRCODE.");

                Thread.Sleep(TimeSpan.FromSeconds(10));

                string conviteUrl = @"https://chat.whatsapp.com/EuCzGT0a6HJ6UgVunH0l6S";

                Console.WriteLine("Carregando a página de convite.");

                webDriver.LoadPage(TimeSpan.FromSeconds(30), conviteUrl);

                //Clicar no botao Join
                Console.WriteLine("Clicando no botao join.");
                var btnJoin = webDriver.FindElement(By.Id("action-button"));
                btnJoin.Click();

                //Aguardo o botão Entrar no grupo aparecer
                Thread.Sleep(TimeSpan.FromSeconds(25));

                //Clicar no botão entrar no grupo
                Console.WriteLine("Clicando no botao entrar no grupo.");
                var btnEntrarNoGrupo = webDriver.FindElement(By.ClassName("PNlAR"));
                btnEntrarNoGrupo.Click();

                Thread.Sleep(TimeSpan.FromSeconds(5));

                //Digitar uma mensagem
                var txtMensagem = By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]");
                webDriver.SetText(txtMensagem, "Ola sou da equipe do WhatsApp, seu grupo foi selecionado para realização de testes de segurança! Pedimos desculpas pelo transtorno. Esse teste deve levar alguns minutos.");

                //Enviamos a mensagem
                webDriver.FindElement(txtMensagem).SendKeys(Keys.Enter);

                Thread.Sleep(TimeSpan.FromSeconds(5));

                Console.WriteLine("Abrindo o menu.");
                var menus = webDriver.FindElements(By.ClassName("rAUz7"));
                if (menus[5].Displayed)
                {
                    menus[5].Click();
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));

                Console.WriteLine("Clicando em sair do grupo.");
                var opcoesDoMenu = webDriver.FindElements(By.ClassName("_28zBA"));
                if (opcoesDoMenu[4].Displayed)
                {
                    opcoesDoMenu[4].Click();
                }

                Console.WriteLine("Aguardando 25 segundos para o botão sair aparacer.");
                Thread.Sleep(TimeSpan.FromSeconds(10));

                Console.WriteLine("Confirmando saida do grupo.");
                var btnSairGrupo = webDriver.FindElement(By.ClassName("PNlAR"));

                btnSairGrupo.Click();

                Console.WriteLine("Operação realizada com sucesso!");
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
