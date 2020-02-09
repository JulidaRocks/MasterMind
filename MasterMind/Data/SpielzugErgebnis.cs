using System.Linq;

namespace MasterMind.Data
{
    public class SpielzugErgebnis
    {
        public Ergebnisfarben[] Ergebnis { get; set; } = new Ergebnisfarben[5];

        public bool Gewonnen => Ergebnis.Where(e => e == Ergebnisfarben.Black).Count() == 5;
    }
}
