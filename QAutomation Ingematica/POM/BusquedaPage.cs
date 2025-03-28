using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        private IWebElement SigPagBtn() => _driver.FindElement(By.CssSelector("a[title='Siguiente']"));
        private IWebElement TercerItem() => _driver.FindElement(By.CssSelector("ol.ui-search-layout li:nth-child(5)"));
        //Paso el 5to li porque los primeros dos no corresponden a un producto

        public void SigPag() => SigPagBtn().Click();
        public void ClickTercerElemento() => TercerItem().Click();
        public bool VerificarDisponibilidad() {
            try
            {
                var disponibilidad = _driver.FindElement(By.CssSelector("[formaction=\"https://www.mercadolibre.com.ar/gz/checkout/buy\"]"));
                if (disponibilidad != null)
                {
                    return true;
                }
                else
                {
                    _driver.FindElement(By.XPath("//span[normalize-space()='Ver opciones de compra']")).Click();
                    disponibilidad = _driver.FindElement(By.CssSelector("[formaction=\"https://www.mercadolibre.com.ar/gz/checkout/buy\"]"));
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
