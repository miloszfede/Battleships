using System;
namespace TestAppp
{
	
    public class Board
    {
        public int Size { get; }
        public Square[,] boardGrid;

        public Board(int size)
        {
            Size = size;
            boardGrid = new Square[size, size];
            InitializeBoard();

        }

        public void InitializeBoard() 
        {
            for (int i = 0; i < Size; i++) 
            {
                for (int j = 0; j < Size; j++)
                {
                    boardGrid[i, j] = new Square(i, j); // Tworzy new Square objects z ich koordynatami
                }
            }
        
        }

        public Square GetSquare(int x, int y)
        {
            if (x >= 0 && x < Size && y >= 0 && y < Size)
            {
                return boardGrid[x, y];
            }
            throw new IndexOutOfRangeException("Invalid board coordinates.");
        }


    }
    
}


