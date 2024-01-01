using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation_Ingematica.POM
{
    internal class MeLiHomePage
    {
        private IWebDriver _driver;

        public MeLiHomePage() { }
        public MeLiHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Cookies => _driver.FindElement(By.CssSelector("button[class='cookie-consent-banner-opt-out__action cookie-consent-banner-opt-out__action--primary cookie-consent-banner-opt-out__action--key-accept']"));
        private IWebElement InputBusqueda => _driver.FindElement(By.CssSelector("input[class='nav-search-input']"));
        private IWebElement SearchBtn => _driver.FindElement(By.CssSelector("button[class='nav-search-btn']"));

        public void Navegar(string url) => _driver.Navigate().GoToUrl(url);
        public void AceptarCookies() => Cookies.Click();
        public void IngresarBusqueda(string busqueda) => InputBusqueda.SendKeys(busqueda);
        public void RealizarBusqueda() => SearchBtn.Click();
    }
}
