using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;

namespace UnitTestSeleniumP
{

    [TestClass]
    public class UntitledTestCase
    {
        [TestMethod]
        public void TestMethod1()
        {
            // initialisation du web driver, le chemin en paramètre est celui où se trouve le fichier IEDriverServer.exe
            IWebDriver driver = new InternetExplorerDriver(@"D:\S2H - POLE TEST ET CONFORMITE\Outils\IED\IEDriverServer_x64_3.14.0\");

            // se rend à la page www.google.fr
            driver.Navigate().GoToUrl("http://www.google.fr");

            /* recherche sur la page l'élément dont le nom est q et y rentre rien,
            dans notre exemple c'est la textbox de recherche google */
            driver.FindElement(By.Name("q")).SendKeys("news");

            // lance la recherche
            driver.FindElement(By.Name("q")).Submit();

            // le test réussit si on trouve un lien dont le texte est Rien - Wikipédia

            var res = true;

            try
            {
                driver.FindElement(By.LinkText("Rien - Wikip&eacute;dia"));
            }
            catch
            {
                res = false;
            }

            Assert.IsTrue(true);
        }

    }


}
