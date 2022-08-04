using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Automacao
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Setup()
        {
            string url = "https://web.whatsapp.com";
            // Instância dos objetos
            Global.capabilitiesMethods = new CapabilitiesMethods();
            

            

            // Instância do driver
            Global.driver = Global.capabilitiesMethods.BrowserConfig();
           Global.driver.Navigate().GoToUrl(url);
            Global.driver.Manage().Window.Maximize();
            
        }

       

        [TestMethod]
        public void BootWhatsApp()
        {
            List<string> contatos = new List<string>()
            {
                "Cleison"
            };


            Global.capabilitiesMethods.WaitExists(Global.driver,By.XPath("//div[contains(@title,'Caixa de texto de pesquisa')]"));

            foreach (var contato in contatos)
            {

                Global.capabilitiesMethods.SendKeys(Global.driver,By.XPath("//div[contains(@title,'Caixa de texto de pesquisa')]"),contato);
                Global.capabilitiesMethods.Click(Global.driver,By.XPath($"//span[@title='{contato}']"));
                Global.capabilitiesMethods.Click(Global.driver,By.XPath("//div[@title='Mensagem']"));
                Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath("//div[@title='Mensagem']"), "Olá Mundo!");
                Global.capabilitiesMethods.Click(Global.driver, By.XPath("//span[contains(@data-testid,'send')]"));
                
            }


        }

       


        [TestCleanup]
        public void TeardownTest()
        {
            // Finalização do browser
            try
            {
                
                Global.driver.Quit();
            }
            catch (Exception)
            {

            }
        }
    }
}