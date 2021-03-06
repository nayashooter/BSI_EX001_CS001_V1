﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace UnitTestSeleniumP
{

    [TestFixture]
    public class SearchTestCase
    {
        private IWebDriver _driver;

        [SetUp]
        public void Initialize()
        {
            Proxy proxy = new Proxy {HttpProxy = "inetproxy:83", SslProxy = "inetproxy:83", Kind = ProxyKind.Manual, IsAutoDetect = false};

            InternetExplorerOptions options = new InternetExplorerOptions
            {

                //UsePerProcessProxy = true,
                Proxy = proxy
            };

            _driver = new InternetExplorerDriver( @"D:\S2H - POLE TEST ET CONFORMITE\Outils\IED\IEDriverServer_Win32_3.14.0\", options);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchGoogle()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // se rend à la page www.google.fr
            _driver.Navigate().GoToUrl("http://www.google.fr");


            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            /* recherche sur la page l'élément dont le nom est q et y rentre rien,
            dans notre exemple c'est la textbox de recherche google */
            _driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input")).SendKeys("news");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // lance la recherche
            _driver.FindElement(By.Name("q")).Submit();

            // le test réussit si on trouve un lien dont le texte est Rien - Wikipédia

            var res = true;

            try
            {
                _driver.FindElement(By.LinkText("Rien - Wikip&eacute;dia"));
            }
            catch
            {
                res = false;
            }

            Assert.IsTrue(true);
        }

        [TearDown]
        public void EndTest()
        {
            if (_driver != null)
            {
                _driver.Close();
            }
        }

    }


}
