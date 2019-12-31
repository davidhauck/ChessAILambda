using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLambda
{

    public class Piece
    {
        public Piece(int x, int y, double value, char label, Boolean team, Boolean hasMoved = false)
        {
            _x = x;
            _y = y;
            _value = value;
            _label = label;
            _isPlayer1 = team;
            _hasMoved = hasMoved;

        }

        private int _x;
        public int X { get { return _x; } set { _x = value; } }

        private int _y;
        public int Y { get { return _y; } set { _y = value; } }

        private double _value;
        public double Value { get { return _value; } set { _value = value; } }

        private char _label;
        public char Label { get { return _label; } set { _label = value; } }

        private bool _isPlayer1;
        public Boolean IsPlayer1 { get { return _isPlayer1; } set { _isPlayer1 = value; } }

        private bool _hasMoved;
        public Boolean HasMoved { get { return _hasMoved; } set { _hasMoved = value; } }
    }
}
