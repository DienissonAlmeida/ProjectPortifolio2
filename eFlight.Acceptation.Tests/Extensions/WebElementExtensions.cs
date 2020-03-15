using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Extensions
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Aguarda até que o elemento esteja sendo exibido na interface.
        /// </summary>
        /// <param name="element"> Elemento da interface.</param>
        /// <param name="ngDriver"> ngWebDriver utilizado.</param>
        /// <param name="timeout"> Tempo limite até que o elemento seja exibido, padrão é 20 segundos.</param>
        public static void WaitUntilVisibleOn(this IWebElement element, NgWebDriver ngDriver, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(ngDriver, timeout ?? TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        /// Aguarda até que o elemento esteja sendo exibido na interface e executa o Click.
        /// </summary>
        /// <param name="element"> Elemento da interface.</param>
        /// <param name="ngDriver"> ngWebDriver utilizado.</param>
        /// <param name="timeout"> Tempo limite até que o elemento seja exibido, padrão é 20 segundos.</param>
        public static void WaitUntilBeVisibleAndClickOnIt(this IWebElement element, NgWebDriver ngDriver, TimeSpan? timeout = null)
        {
            element.WaitUntilVisibleOn(ngDriver, timeout);

            element.Click();
        }

        /// <summary>
        /// Valida se o elemento está sendo exibido na interface.
        /// </summary>
        /// <param name="element"> Elemento da interface.</param>
        /// <param name="ngDriver"> ngWebDriver utilizado.</param>
        public static bool IsDisplayed(this IWebElement element, NgWebDriver ngDriver)
        {
            try
            {
                element.WaitUntilVisibleOn(ngDriver);
                return element.Displayed;
            }
            catch
            {
                //Elemento não foi encontrado ou não está visível
            }

            return false;
        }

        /// <summary>
        /// Muda o foco para o elemento antes de clicá-lo.
        /// </summary>
        /// <param name="element"> Elemento da interface.</param>
        public static void HeadlessClick(this IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.Command);
            }
            catch
            {
                //Alguns browser não suportam interação em determinados elementos através do teclado
            }

            element.Click();
        }

        #region Prevent Stale Element

        /// <summary>
        /// Evita a utilização de elementos obsoletos (que pertece a uma página que não está mais disponível)
        /// </summary>
        /// <param name="NgDriver">Driver utilizado</param>
        /// <param name="path">Critério para localizar os elementos</param>
        /// <returns></returns>
        public static IList<NgWebElement> AvoidStaleElements(this NgWebDriver NgDriver, By path)
        {
            while (true)
            {
                try
                {
                    return NgDriver.FindElements(path);
                }
                catch (StaleElementReferenceException) { }
            }
        }

        /// <summary>
        /// Evita a utilização de elementos obsoletos (que pertece a uma página que não está mais disponível)
        /// </summary>
        /// <param name="NgDriver">Driver utilizado</param>
        /// <param name="path">Critério para localizar os elementos</param>
        /// <returns></returns>
        public static NgWebElement AvoidStaleElement(this NgWebDriver NgDriver, By path)
        {
            while (true)
            {
                try
                {
                    return NgDriver.FindElement(path);
                }
                catch (StaleElementReferenceException) { }
            }
        }

        /// <summary>
        /// Evita a utilização de elementos obsoletos (que pertece a uma página que não está mais disponível)
        /// </summary>
        /// <param name="NgDriver">Driver utilizado</param>
        /// <param name="path">Critério para localizar os elementos</param>
        /// <returns></returns>
        public static IList<IWebElement> AvoidStaleElements(this IWebElement element, By path)
        {
            while (true)
            {
                try
                {
                    return element.FindElements(path);
                }
                catch (StaleElementReferenceException) { }
            }
        }

        /// <summary>
        /// Evita a utilização de elementos obsoletos (que pertece a uma página que não está mais disponível)
        /// </summary>
        /// <param name="NgDriver">Driver utilizado</param>
        /// <param name="path">Critério para localizar os elementos</param>
        /// <returns></returns>
        public static IWebElement AvoidStaleElement(this IWebElement element, By path)
        {
            while (true)
            {
                try
                {
                    return element.FindElement(path);
                }
                catch (StaleElementReferenceException) { }
            }
        }

        #endregion Prevent Stale Element ReferenceException

    }
}
