using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation_Ingematica
{
    public class Funciones
    {
        public IWebElement BuscarPorXPath(string xPath, IWebDriver i)
        {
            try
            {
                var elemento = i.FindElement(By.XPath(xPath));
                Console.WriteLine("El elemento " + elemento + "fue encontrado con exito");
                return elemento;
            }
            catch (Exception e)
            {
                Console.WriteLine("No fue posible encontrar el elemento: " + xPath);
                return null;
            }

        }

    }
}
