using System;
using TestAppp;

namespace Battleships
{
	public class Ship
	{
		Board board = new Board(10);
		int Size;
		public int Hits { get; set; }
		public bool Sunk { get; set; }
		List<Square> Squares = new();
		public Input input;
		

		//      public Ship(Enum ShipType, Input input)
		//{
		//          input = input;
		//          ShipType = ShipType;
		//	this.Size = Size;
		//	Hits = 0;
		//	Sunk = false;
		//	Squares = Squares;
		//}






	}

}
