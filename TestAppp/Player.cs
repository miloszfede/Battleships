using System;
namespace TestAppp
{
	public class Player
	{	public List<Ship> Fleet;
		public Board Board;
		
		public Player(int BoardSize) // konstruktor jest funkcja! 
		{
			Fleet = new List<Ship>();
			Board = new Board(BoardSize);
			

		}
		
	}
}

