using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Data
{
    public class GameRound
    {
        public IList<Move> Moves { get; set; } = new List<Move>();
        public List<GameColors> DecodingBoard { get; } = new List<GameColors>();

        private Move CurrentMove => Moves.LastOrDefault();

        public bool Won => CurrentMove?.MoveResult?.Won == true;

        public GameRound(ICollection<GameColors> decodingBoard)
        {
            DecodingBoard.AddRange(decodingBoard);
        }

        public Move CreateMove()
        {
            var move = new Move();
            Moves.Add(move);
            return move;
        }

        public MoveResult EvaluateCurrentMove(GameColors[] guessedColors)
        {
            CurrentMove.GuessedColors = guessedColors;
            MoveResult moveResult = CurrentMove.MoveResult;

            for (var i = 0; i < CurrentMove.GuessedColors.Count(); i++)
            {
                GameColors guessedColor = CurrentMove.GuessedColors[i];
                if (guessedColor == DecodingBoard[i])
                {
                    moveResult.EvaluatedResultColors[i] = ResultColors.Black;
                }
                else if (DecodingBoard.Contains(guessedColor))
                {
                    moveResult.EvaluatedResultColors[i] = ResultColors.White;
                }
                else
                {
                    moveResult.EvaluatedResultColors[i] = ResultColors.Undefined;
                }
            }

            moveResult.EvaluatedResultColors = moveResult.EvaluatedResultColors.OrderBy(e => (int)e).ToArray();
            return moveResult;
        }
    }
}
