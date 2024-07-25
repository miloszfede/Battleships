﻿using System;
using TestAppp;

namespace Battleships
{
	public class Ship
	{
        public ShipType Type { get; }
        public List<(int x, int y)> Coordinates { get;  set; }
        public int Hits { get; set; }
        public bool Sunk { get; set; }

        public Ship(ShipType type)
        {
            Type = type;
            Coordinates = new List<(int x, int y)>();
            Hits = 0;
            Sunk = false;
        }

        
        public void AddCoordinate(int x, int y)
        {
            Coordinates.Add((x, y));
        }
    }



}
