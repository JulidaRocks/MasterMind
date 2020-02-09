using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Data
{
    public class Spiel
    {
        public IList<Spielzug> Spielzüge { get; set; } = new List<Spielzug>();
        public List<Farben> ZuRatendeFarben { get; } = new List<Farben>();

        private Spielzug AktuellerSpielzug => Spielzüge.LastOrDefault();

        public bool Gewonnen => AktuellerSpielzug?.Ergebnis?.Gewonnen == true;

        public Spiel(ICollection<Farben> zuRatendeFarben)
        {
            ZuRatendeFarben.AddRange(zuRatendeFarben);
        }

        public Spielzug LegeSpielzugAn()
        {
            var spielzug = new Spielzug();
            Spielzüge.Add(spielzug);
            return spielzug;
        }

        public SpielzugErgebnis WerteAktuellenSpielzugAus(Farben[] gerateneFarben)
        {
            AktuellerSpielzug.Rate = gerateneFarben;
            SpielzugErgebnis ergebnis = AktuellerSpielzug.Ergebnis;

            for (var i = 0; i < AktuellerSpielzug.Rate.Count(); i++)
            {
                Farben gerateneFarbe = AktuellerSpielzug.Rate[i];
                if (gerateneFarbe == ZuRatendeFarben[i])
                {
                    ergebnis.Ergebnis[i] = Ergebnisfarben.Black;
                }
                else if (ZuRatendeFarben.Contains(gerateneFarbe))
                {
                    ergebnis.Ergebnis[i] = Ergebnisfarben.White;
                }
                else
                {
                    ergebnis.Ergebnis[i] = Ergebnisfarben.Undefined;
                }
            }

            ergebnis.Ergebnis = ergebnis.Ergebnis.OrderByDescending(e => (int)e).ToArray();
            return ergebnis;
        }
    }
}
