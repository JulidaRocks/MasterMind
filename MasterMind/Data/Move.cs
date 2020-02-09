namespace MasterMind.Data
{
    public class Move
    {
        private GameColors[] _guessedColors = new GameColors[5];
        public GameColors[] GuessedColors { get { return _guessedColors; } set { _guessedColors = value; MoveResult = new MoveResult(); } }
        public MoveResult MoveResult { get; set; }
    }
}
