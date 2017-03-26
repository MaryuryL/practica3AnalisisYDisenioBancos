using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _AyD1_PRactica1;
using System.Globalization;

namespace AyD1PRactica1_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login()
        {
            var actual = Metodos.PLogin(6, "lea", "cpoino");
            bool esperado = true;

            Assert.AreEqual(esperado, actual);
        }

       [TestMethod]
        public void Registro()
        {
            int actual = Metodos.Registro("Pedro","pp","1235","ppe@gmail.com");
            int esperado = 3;
            
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void ConsultaSaldo()
        {
            float actual = Metodos.Consulta(2);
            float esperado = float.Parse("53,5");

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Acreditar()
        {

            bool actual = Metodos.Credito(10, 11, 1500, "Deposito por deuda");
            bool esperado = true;

            Assert.AreEqual(esperado, actual);
        }
        [TestMethod]
        public void Debitar()
        {
            bool actual = Metodos.Debito(10, 35, 150, "Debito por pago de servicio");
            bool esperado = true;

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void PagoServicios()
        {
            int cuenta = Convert.ToInt32("10");
            float monto = float.Parse("1000",CultureInfo.InvariantCulture);

            bool actual = Metodos.PagoServicio(cuenta,monto,"agua");
            bool esperado = true;

            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void Transferecias()
        {
            bool actual = Metodos.Transferencia(12, 1700, 20);
            bool esperado = true;

            Assert.AreEqual(esperado, actual);
        }

    }
}
