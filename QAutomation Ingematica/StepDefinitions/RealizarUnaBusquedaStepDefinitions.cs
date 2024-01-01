using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAutomation_Ingematica.Hooks;
using QAutomation_Ingematica.POM;
using System;
using TechTalk.SpecFlow;

namespace QAutomation_Ingematica.StepDefinitions
{
    [Binding]
    public class RealizarUnaBusquedaStepDefinitions
    {
        private IWebDriver _driver;
        private MeLiHomePage _meli;
        private BusquedaPage _busqueda;

        public RealizarUnaBusquedaStepDefinitions(IWebDriver driver)
        {
            this._driver = driver;
            this._meli = new MeLiHomePage(driver);
            this._busqueda = new BusquedaPage(driver);
        }

        [Given(@"El usuario se encuentra en la pagina principal de Mercado Libre")]
        public void GivenElUsuarioSeEncuentraEnLaPaginaPrincipalDeMercadoLibre()
        {
            _meli.Navegar("https://www.mercadolibre.com.ar");
            _meli.AceptarCookies();
        }

        [When(@"Busca por “Smartphone”")]
        public void WhenBuscaPorSmartphone()
        {
            _meli.IngresarBusqueda("Smartphone");
            _meli.RealizarBusqueda();
        }

        [When(@"Navega hacia la segunda página de resultados")]
        public void WhenNavegaHaciaLaSegundaPaginaDeResultados()
        {
            _busqueda.SigPag();
        }

        [When(@"Selecciona el tercer ítem de la lista")]
        public void WhenSeleccionaElTercerItemDeLaLista()
        {
            _busqueda.ClickTercerElemento();
        }

        [Then(@"El ítem está habilitado para comprar")]
        public void ThenElItemEstaHabilitadoParaComprar()
        {
            Assert.True(_busqueda.VerificarDisponibilidad());
        }
    }
}
