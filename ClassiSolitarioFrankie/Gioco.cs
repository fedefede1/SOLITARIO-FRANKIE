using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassiSolitarioFrankie
{
    public class Gioco
    {
        private Carta _cartaInCima;
        private Mazzo _mazzoIniziale;
        private List<Carta> _mazzoDeposito;

        public Gioco()
        {
            MazzoIniziale = new Mazzo();
            MazzoIniziale.MescolaMazzo();
            CartaInCima = MazzoIniziale.EstraiCarta;
            MazzoDeposito = new List<Carta> { MazzoIniziale.EstraiCarta };
        }

        public List<Carta> MazzoDeposito
        {
            get { return _mazzoDeposito; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                _mazzoDeposito = value;
            }
        }

        public Mazzo MazzoIniziale
        {
            get { return _mazzoIniziale; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                _mazzoIniziale = value;
            }
        }

        public Carta CartaInCima
        {
            get { return _cartaInCima; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                _cartaInCima = value;
            }
        }

        public void GiraCarta()
        {
            try 
            {
                _mazzoDeposito.Add(_mazzoIniziale.EstraiCarta);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        public bool GiocaCarta()
        {
            try
            {
                Carta c = _mazzoDeposito[_mazzoDeposito.Count - 1];
                if (c.SemeCarta == _cartaInCima.SemeCarta || (c.Punteggio <= _cartaInCima.Punteggio + 1 && c.Punteggio >= _cartaInCima.Punteggio - 1) || c.Punteggio == 1)
                {
                    _mazzoDeposito.RemoveAt(_mazzoDeposito.Count - 1);
                    _cartaInCima = c;
                    return true;
                }
            }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
    }
}