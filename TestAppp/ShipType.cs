using System;
namespace TestAppp
{
	public enum ShipType
	{
		Carrier,
		Cruiser,
		Battleship,
		Submarine,
		Destroyer
	}

    public static class ShipTypeExtensions
    {
        
        private static readonly Dictionary<ShipType, int> Lengths = new Dictionary<ShipType, int>
    {
        { ShipType.Carrier, 1 },
        { ShipType.Cruiser, 2 },
        { ShipType.Battleship, 3 },
        { ShipType.Submarine, 4 },
        { ShipType.Destroyer, 5 }
    };

        
        public static int GetLength(this ShipType shipType)
        {
            return Lengths[shipType];
        }
    }

}

