using System;
namespace TestAppp
{
    public class Square
    {
        
        private int coordinate_X;
        private int coordinate_Y;
        public enum SquareStatus { _empty, ship, miss, hit }
        public SquareStatus Status { get; set; }

        public Square(int X, int Y)
        {
            coordinate_X = X;
            coordinate_Y = Y;
            Status = SquareStatus._empty; // boarda inicjalizujemy jako status empty, ktory po wybraniu statków zmieni się na ship
        }
        

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

