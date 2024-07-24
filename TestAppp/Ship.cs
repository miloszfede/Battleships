using System;
using TestAppp;

namespace Battleships
{
	public class Ship
	{		
		public int Hits { get; set; }
		public bool Sunk { get; set; }
		public int CoordX { get;}
		public int CoodY { get;}
		public int Direction { get;}

        public Ship(int coordX, int coodY, int direction)
        {
            Hits = 0 ;
            Sunk = false;
            CoordX = coordX;
            CoodY = coodY;
            Direction = direction;
        }
    }



}
