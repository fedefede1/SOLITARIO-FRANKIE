using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiSolitarioFrankie
{
    public class Mazzo
    {
        private Carta[] _carte;
        private int _index;

        public Mazzo()
        {
            _carte = new Carta[40];
            _index = 0;
            InizializzaMazzo();

        }

        private void InizializzaMazzo()
        {
            int i = 0;
            for (int seme = 1; seme <= 4; seme++)
            {
                for (int valore = 1; valore <= 10; valore++)
                {
                    _carte[i] = new Carta(valore, (Seme)seme);
                    i++;
                }
            }
        }


        public void MescolaMazzo()
        {
            if (_index != 0) throw new Exception("non puoi mescolare il mazzo se non ha tutte le carte");
            Random random = new Random();
            int pos;
            Carta cartaDaScambiare;
            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < _carte.Length; i++)
                {
                    pos = random.Next(0, _carte.Length);
                    cartaDaScambiare = _carte[pos];
                    _carte[pos] = _carte[i];
                    _carte[i] = cartaDaScambiare;
                }
            }

        }

        public Carta UltimaCarta
        {
            get
            {
                if (Empty) throw new Exception("il mazzo è vuoto");
                return _carte[_carte.Length - 1];
            }
        }

        public bool Empty
        {
            get
            {
                if (_carte[_carte.Length - 1] == null) return true;
                return false;
            }

        }

        public Carta EstraiCarta
        {
            get
            {
                if (_index >= _carte.Length) throw new Exception("mazzo completamente estratto");
                Carta carta = _carte[_index];
                _carte[_index] = null;
                _index++;
                return carta;
            }
        }
        public void Shift() //testato funziona
        {
            Carta cartaFinale = _carte[_index];
            for (int i = _index + 1; i < _carte.Length; i++)
            {
                _carte[i - 1] = _carte[i];
            }
            _carte[_carte.Length - 1] = cartaFinale;
        }
        public Carta VisualizzaCarta
        {
            get
            {
                Carta carta = _carte[_index];
                return carta;
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = _index; i < _carte.Length; i++)
            {
                res += _carte[i].ToString();
                res += "\n";
            }
            return res;
        }
    }
}
