using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLambda
{
    public struct Point
    {
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
