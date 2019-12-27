using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLambda
{
    public struct Move
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int DestX { get; set; }
        public int DestY { get; set; }
    }
}
