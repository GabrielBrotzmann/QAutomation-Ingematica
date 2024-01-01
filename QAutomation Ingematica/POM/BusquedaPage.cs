using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace QAutomation_Ingematica.POM
{
    internal class BusquedaPage
    {
        private IWebDriver _driver;
        private ISpecFlowOutputHelper _outputHelper;

        public BusquedaPage(IWebDriver driver) {
            this._driver = driver;
        }

        private IWebElement SigPagBtn() => _driver.FindElement(By.CssSelector("a[class='andes-pagination__link ui-search-link']"));
        private IWebElement TercerElemento() => _driver.FindElement(By.XPath("/html[1]/body[1]/main[1]/div[1]/div[2]/section[1]/ol[1]/li[3]/div[*]/div[1]/div[2]/div[*]/a[1]/h2[1]"));
        

        public void SigPag() => SigPagBtn().Click();
        public void ClickTercerElemento() => TercerElemento().Click();
        public bool VerificarDisponibilidad() {
            try
            {
                var disponibilidad = _driver.FindElement(By.XPath("//span[normalize-space()='Comprar ahora']"));
                if (disponibilidad != null)
                {
                    return true;
                }
                else
                {
                    _driver.FindElement(By.XPath("//span[normalize-space()='Ver opciones de compra']"));
                    disponibilidad = _driver.FindElement(By.XPath("//span[normalize-space()='Comprar ahora']"));
                    if (disponibilidad != null)
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            catch (Exception e) { 
                Console.WriteLine(e);
                return false;
            }
        }

    }
}
