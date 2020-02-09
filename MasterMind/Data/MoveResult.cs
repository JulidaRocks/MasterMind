using System.Linq;

namespace MasterMind.Data
{
    public class MoveResult
    {
        public ResultColors[] EvaluatedResultColors { get; set; } = new ResultColors[5];

        public bool Won => EvaluatedResultColors.Where(e => e == ResultColors.Black).Count() == 5;
    }
}
