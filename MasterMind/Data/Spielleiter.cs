using System;
using System.Collections.Generic;

namespace MasterMind.Data
{
    public class Spielleiter
    {
        public Spiel Spiel { get; set; }

        public Spielzug StarteSpiel()
        {
            Spiel = new Spiel(ErstelleZuRatendeFarben());
            return Spiel.LegeSpielzugAn();
        }

        public Spielzug WerteAus(Farben[] gerateneFarben)
        {
            Spiel.WerteAktuellenSpielzugAus(gerateneFarben);
            if (!Spiel.Gewonnen)
            {
                return LegeSpielzugAn();
            }
            return null;
        }

        public IList<Spielzug> GetSpielzüge()
        {
            return Spiel?.Spielzüge ?? new List<Spielzug>();
        }

        private ICollection<Farben> ErstelleZuRatendeFarben()
        {
            var farben = new HashSet<Farben>();
            var random = new Random();

            while (farben.Count < 5)
            {
                farben.Add((Farben)random.Next(1, 8));
            }

            return farben;
        }

        private Spielzug LegeSpielzugAn()
        {
            return Spiel.LegeSpielzugAn();
        }
    }
}
