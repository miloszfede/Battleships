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

        public bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }

        public bool CanPlaceShip(int  row, int col, int shipLength, Ship.PlacementDirection direction)
        {
            for (int i = 0; i < shipLength; i++)
            {
                int r = row, c = col;
                switch (direction)
                {
                    case Ship.PlacementDirection.Right:
                        c += i;
                        break;
                    case Ship.PlacementDirection.Left:
                        c -= i;
                        break;
                    case Ship.PlacementDirection.Up:
                        r -= i;
                        break;
                    case Ship.PlacementDirection.Down:
                        r += i;
                        break;
                }

                if (r < 0 || r >= Size || c < 0 || c >= Size || boardGrid[r, c].Status == Square.SquareStatus.ship)
                {
                    return false;
                }
                //else if (boardGrid[r + 1,c].Status == Square.SquareStatus.ship)
                //{
                //    return false;
                //}
                //else if (boardGrid[r, c + 1].Status == Square.SquareStatus.ship)
                //{
                //    return false;
                //}
                //else if (boardGrid[r - 1, c].Status == Square.SquareStatus.ship)
                //{
                //    return false;
                //}
                //else if (boardGrid[r, c - 1].Status == Square.SquareStatus.ship)
                //{
                //    return false;
                //}
                // wywala przy skrajnych polach 
            }
            return true;
        }

        public void PlaceShip(int row, int col, int shipLength, Ship.PlacementDirection direction)
        {
            for (int i = 0; i < shipLength; i++)
            {
                int r = row, c = col;

                switch (direction)
                {
                    case Ship.PlacementDirection.Right:
                        c += i;
                        break;
                    case Ship.PlacementDirection.Left:
                        c -= i;
                        break;
                    case Ship.PlacementDirection.Up:
                        r -= i;
                        break;
                    case Ship.PlacementDirection.Down:
                        r += i;
                        break;
                }

                boardGrid[r, c].Status = Square.SquareStatus.ship;
            }
        }

        
    }


}




