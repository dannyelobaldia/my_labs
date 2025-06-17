using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationsTests
{
    public class Selenium
    {
        FirefoxDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            //Arrange
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";

            //Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            //Act
            //Navega a la pagina que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            IWebElement agregarPais = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar país')]"));
            agregarPais.Click();

            IWebElement nombrePais = _driver.FindElement(By.Id("name"));
            nombrePais.SendKeys("Lituania");

            IWebElement continentePais = _driver.FindElement(By.Id("continente"));
            SelectElement selectContinente = new SelectElement(continentePais);
            selectContinente.SelectByText("Europa");

            IWebElement idiomaPais = _driver.FindElement(By.Id("idioma"));
            idiomaPais.SendKeys("Lituano");

            IWebElement botonSubmit = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
            botonSubmit.Click();

            //Assert
            Assert.IsNotNull(_driver);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var rows = _driver.FindElements(By.XPath("//table//tbody//tr"));
            bool entryFound = rows.Any(row =>
                row.Text.Contains("Lituania") &&
                row.Text.Contains("Europa") &&
                row.Text.Contains("Lituano")
            );

            Assert.IsTrue(entryFound);
        }
    }
}
