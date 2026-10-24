using NUnit.Framework;
using Prime.Services;

namespace Prime.Services.Tests
{
    [TestFixture] //Identifica la clase que contiene pruebas
    public class PrimeServiceTests
    {
        private PrimeService _service;

        [SetUp] //Ejecuta la inicilialización antes de cada prueba
        public void SetUp()
        {
            _service = new PrimeService();
        }

        //ejecuta el mismo método con distintos valores
        [TestCase(-1, false)]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(11, true)]
        public void IsPrime_DevuelveResultadoEsperado(
            int numero, bool esperado)
        {
            bool resultado = _service.IsPrime(numero);

            Assert.That(resultado, Is.EqualTo(esperado)); //comprueba si el resultado coincide con lo esperado
        }

        [Test]
        public void IsPrime_RegistraLaEvaluacion()
        {
            var logger = new FakeAuditLogger();
            var service = new PrimeService(logger);

            bool resultado = service.IsPrime(7);

            Assert.That(resultado, Is.True);
            Assert.That(logger.Registros, Does.Contain("7:True"));
        }

    }
}