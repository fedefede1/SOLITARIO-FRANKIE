using ClassiSolitarioFrankie;
namespace TestSolitarioFrankie
{
    [TestClass]
    public class TestGioco
    {
        [TestMethod]
        public void Metodo_ControlloSeCartaAccettabile()
        {
            Gioco g = new Gioco();

            //se asso di qualsiasi seme
            Carta c = new Carta(1, (Seme)1);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(1, (Seme)2);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(1, (Seme)3);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(1, (Seme)4);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));

            //se stesso valore qulaiasi seme
            c = new Carta((int)g.CartaInCima.ValoreCarta, (Seme)1);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta((int)g.CartaInCima.ValoreCarta, (Seme)2);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta((int)g.CartaInCima.ValoreCarta, (Seme)3);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta((int)g.CartaInCima.ValoreCarta, (Seme)4);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));

            //se è un asso non controllo il valore -1
            if (g.CartaInCima.ValoreCarta != ((Valore)1)) 
            {
                c = new Carta((int)g.CartaInCima.ValoreCarta - 1, (Seme)1);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta - 1, (Seme)2);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta - 1, (Seme)3);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta - 1, (Seme)4);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            }

            //se è un re non controllo il valore +1
            if (g.CartaInCima.ValoreCarta != ((Valore)10))
            {
                c = new Carta((int)g.CartaInCima.ValoreCarta + 1, (Seme)1);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta + 1, (Seme)2);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta + 1, (Seme)3);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
                c = new Carta((int)g.CartaInCima.ValoreCarta + 1, (Seme)4);
                Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            }

            //se stesso seme qualsiasi valore
            c = new Carta(1, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(2, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(3, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(4, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(5, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(6, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(7, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(8, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(9, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
            c = new Carta(10, g.CartaInCima.SemeCarta);
            Assert.AreEqual(true, g.ControlloSeCartaAccettabile(c));
        }
    }
}