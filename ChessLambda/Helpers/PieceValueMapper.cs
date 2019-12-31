using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLambda
{
    public class PieceValueMapper
    {
        public double GetValueForPiece(char piece)
        {
            switch (piece)
            {
                case 'p':
                case 'P':
                    return 1;
                case 'b':
                case 'B':
                    return 3;
                case 'n':
                case 'N':
                    return 3;
                case 'q':
                case 'Q':
                    return 9;
                case 'r':
                case 'R':
                    return 5;
                case 'k':
                case 'K':
                    return 10000;
                default:
                    return 0;
            }
        }
    }
}
