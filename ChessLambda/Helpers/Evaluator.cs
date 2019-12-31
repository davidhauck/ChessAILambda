using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLambda
{
    public class Evaluator
    {
        public static double Evaluate(List<Piece> player1, List<Piece> player2)
        {
            double score = 0;
            foreach (var piece in player2)
            {
                score += piece.Value;
            }
            foreach (var piece in player1)
            {
                score -= piece.Value;
            }
            return score;
        }
    }
}
