using System;
namespace TestAppp
{
	public class Player
	{	public List<Ship> Fleet;
		public Board Board;
		public string Name;
		
		public Player(int BoardSize, string name) // konstruktor jest funkcja! 
		{
			Fleet = new List<Ship>();
			Board = new Board(BoardSize);
			Name = name;
			

		}
		
	}
}

