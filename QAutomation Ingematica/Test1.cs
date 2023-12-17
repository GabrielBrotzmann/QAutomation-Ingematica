using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Debugger;
using static System.Collections.Specialized.BitVector32;
using System.Reflection.Emit;
using OpenQA.Selenium.Internal;
using System.Xml.Serialization;

namespace QAutomation_Ingematica
{
    public class Tests
    {
        Funciones F = new Funciones();
        IWebDriver driver;

        [SetUp]
        public void setup()
        {
            //Driver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Setup");
        }

        [Test]
        public void Test1()
        {
            // Busca el tercer item de la segunda pagina de Mercado Libre y chequea si esta disponible el boton de compra
            driver.Url = "https://www.mercadolibre.com.ar";

            //AceptarCookies
            F.BuscarPorXPath("//button[normalize-space()='Aceptar cookies']", driver).Click();
            
            //Buscador
            F.BuscarPorXPath("//input[@id='cb1-edit']", driver).SendKeys("Smartphone");

            //ClickeaBuscador
            F.BuscarPorXPath("//div[@aria-label='Buscar']", driver).Click();

            //ClickeaSiguientePagina
            F.BuscarPorXPath("//span[@class='andes-pagination__arrow-title']", driver).Click();
            
            //ClickTercerItem
            F.BuscarPorXPath("/html[1]/body[1]/main[1]/div[1]/div[2]/section[1]/ol[1]/li[3]/div[*]/div[1]/div[2]/div[*]/a[1]/h2[1]", driver).Click();

            /*BuscarBotonCompra (Busca el boton de compra, si esta disponible, entonces tambien el producto, si hay distintas
            opciones de compra, clickea y busca el boton nuevamente */
            try
            {
                var disponibilidad = F.BuscarPorXPath("//span[normalize-space()='Comprar ahora']", driver);
                if (disponibilidad != null)
                {
                    Console.WriteLine("El producto se encuentra disponible");
                }else if (disponibilidad is null)
                {
                    var opcionesDeCompra = F.BuscarPorXPath("//span[normalize-space()='Ver opciones de compra']", driver);
                    opcionesDeCompra.Click();
                    disponibilidad = F.BuscarPorXPath("//span[normalize-space()='Comprar ahora']", driver);
                    if (disponibilidad != null)
                    {
                        Console.WriteLine("El producto se encuentra disponible");
                    }else { Console.WriteLine("El producto no se encuentra disponible"); } 
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
            Console.WriteLine("El test ha finalizado");
        }
    }
}