using RegrasNegocio;
using ObjetosNegocio;
namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RegrasCarros r = new RegrasCarros();
            int a = r.TentaLerFicheiroCarros(DateTime.Now.ToString());
            Assert.AreEqual(1, a);

        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TesteAdicionaCarro()
        {
            int erro = 0;
            RegrasCarros r = new RegrasCarros();
            Carro carro = new Carro("12-GH-12", "12-12-2019", -2000, "Ford", COMBUS.Gas);
            int a = r.TentaCriarAdicionarCarro(carro.Matricula, "12-12-2019", carro.Preco, carro.Marca, carro.Combustivel, Permi.Baixa, out erro);
            Assert.AreEqual(1, a);

        }

        [TestClass]
        public class UnitTest3
        {
            [TestMethod]
            public void TesteAdicionaCarro()
            {
                int erro = 0;
                RegrasFunc f = new RegrasFunc();
                int a = f.TentaCriarAdicionarFunc(1, 1, "Antunes", Permi.Alta, out erro);
                Assert.AreEqual(-999, a);
            }
        }
        [TestClass]
        public class UnitTest4
        {
            [TestMethod]
            public void TesteAdicionaCarro()
            {
                int erro = 0;
                RegrasFunc f = new RegrasFunc();
                int a = f.TentaCriarAdicionarFunc(1, 1, "Antunes", Permi.Alta, out erro);
                int b = f.TentaRemoverFuncionario(1, Permi.Baixa);
                Assert.AreEqual(-999, b);
            }
        }
    }
}
