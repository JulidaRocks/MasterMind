namespace MasterMind.Data
{
    public class Spielzug
    {
        private Farben[] _rate = new Farben[5];
        public Farben[] Rate { get { return _rate; } set { _rate = value; Ergebnis = new SpielzugErgebnis(); } }
        public SpielzugErgebnis Ergebnis { get; set; }
    }
}
