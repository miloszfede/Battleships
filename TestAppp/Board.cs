using System;
namespace TestAppp
{
	
    public class Board
    {
        List<Square> Squares = new List<Square>();
        int size;
        public Board(int size)
        {
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Square field = new Square(i, j);
                    Squares.Add(field);
                }
            }
        }
        public void DrawBoard()
        {
            foreach (Square field in Squares)
            {
                Console.Write(field);
                if (field.getY() == size - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}


