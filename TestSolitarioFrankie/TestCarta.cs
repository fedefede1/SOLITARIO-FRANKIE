using ClassiSolitarioFrankie;
namespace TestSolitarioFrankie
{
    [TestClass]
    public class TestCarta
    {
        [TestMethod]
        public void Costruttore_ValoreInvalido()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Carta c = new Carta(-1, Seme.Spade); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Carta c = new Carta(12, Seme.Spade); });
        }
        [TestMethod]
        public void Costruttore_SemeInvalido()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Carta c = new Carta(1, (Seme)(-1)); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Carta c = new Carta(1, (Seme)12); });
        }
    }
}