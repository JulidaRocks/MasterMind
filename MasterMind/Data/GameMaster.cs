using System;
using System.Collections.Generic;

namespace MasterMind.Data
{
    public class GameMaster
    {
        public GameRound GameRound { get; set; }

        public Move StartGame()
        {
            GameRound = new GameRound(CreateDecodingBoard());
            return GameRound.CreateMove();
        }

        public Move Evaluate(GameColors[] guessedColors)
        {
            GameRound.EvaluateCurrentMove(guessedColors);
            if (!GameRound.Won)
            {
                return CreateMove();
            }
            return null;
        }

        public IList<Move> GetMoves()
        {
            return GameRound?.Moves ?? new List<Move>();
        }

        private ICollection<GameColors> CreateDecodingBoard()
        {
            var colors = new HashSet<GameColors>();
            var random = new Random();

            while (colors.Count < 5)
            {
                colors.Add((GameColors)random.Next(1, 8));
            }

            return colors;
        }

        private Move CreateMove()
        {
            return GameRound.CreateMove();
        }
    }
}
