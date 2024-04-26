using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassiSolitarioFrankie
{
    public enum Valore
    {
        Asso = 1,
        Due,
        Tre,
        Quattro,
        Cinque,
        Sei,
        Sette,
        Fante,
        Cavallo,
        Re
    }
    public enum Seme
    {
        Spade = 1,
        Denara,
        Coppe,
        Bastoni      
    }
    public class Carta
    {
        private Valore _valoreCarta;
        private Seme _semeCarta;

        public Carta(int valoreCarta, Seme semeCarta)
        {
            ValoreCarta = (Valore)valoreCarta;
            SemeCarta = semeCarta;
        }

        public Valore ValoreCarta
        {
            get { return _valoreCarta; }
            set
            {
                if ((int)value <= 0 || (int)value > 10) throw new ArgumentOutOfRangeException("il valore della carta deve essere tra 1 e 10");
                _valoreCarta = value;
            }
        }
        public Seme SemeCarta
        {
            get { return _semeCarta; }
            set
            {
                if ((int)value < 1 || (int)value > 4) throw new ArgumentOutOfRangeException("seme invalido");
                _semeCarta = value;
            }
        }


        public override string ToString()
        {
            char temp = (char)(64+_semeCarta);
            string res = $"{(int)ValoreCarta}{temp}";
            return res;
        }
    }
}
