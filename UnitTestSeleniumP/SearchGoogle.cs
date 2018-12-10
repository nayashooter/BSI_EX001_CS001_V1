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
            _driver = new InternetExplorerDriver(
                @"D:\S2H - POLE TEST ET CONFORMITE\Outils\IED\IEDriverServer_Win32_3.14.0\");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchGoogle()
        {
            // se rend à la page www.google.fr
            _driver.Navigate().GoToUrl("http://www.google.fr");

            /* recherche sur la page l'élément dont le nom est q et y rentre rien,
            dans notre exemple c'est la textbox de recherche google */
            _driver.FindElement(By.Name("q")).SendKeys("news");

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
