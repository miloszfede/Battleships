using System;
using TestAppp;

namespace Battleships
{
	public class Player
	{
		bool isAlive = true;
		public List<Ship> Fleet { get; set; }
		string Name { get; set; }
		int Number;

		public Player(string Name, int Number)
		{
			this.Name = Name;
			this.Number = Number;
            Fleet = Fleet;
            isAlive = isAlive;
		}
	}
}

