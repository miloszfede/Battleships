using System;
namespace TestAppp
{
    public class Square
    {
        
        private int coordinate_X;
        private int coordinate_Y;

        public Square(int X, int Y)
        {
            coordinate_X = X;
            coordinate_Y = Y;
        }
        public enum SquareStatus { _empty, ship, miss, hit }

        public int getX()
        {
            return coordinate_X;
        }
        public int getY()
        {
            return coordinate_Y;
        }
        public override string ToString()
        {
            return "[" + coordinate_X.ToString() + " " + coordinate_Y.ToString() + "]";
        }
    }
}

