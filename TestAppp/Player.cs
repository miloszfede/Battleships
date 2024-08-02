using System;
namespace TestAppp
{
	public class Player
	{	public List<Ship> Fleet;
		public Board Board;
		public string Name;
        public int RadarUsage { get; private set; }

        public Player(int BoardSize, string name) // konstruktor jest funkcja! 
		{
			Fleet = new List<Ship>();
			Board = new Board(BoardSize);
			Name = name;
			RadarUsage = 1;
			

		}

        public bool UseRadar(int row, int col)
        {
            if (RadarUsage > 0)
            {
                RadarUsage--;
                return Board.IsAnyShipAround(row, col);
            }
            Console.WriteLine($"{Name} has no radar usages left.");
            return false;
        }

    }
}

