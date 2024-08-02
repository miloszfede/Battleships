using System;
namespace TestAppp
{
    public class Input
    {
        Display display = new Display();

        public int GetInput(string prompt = "Enter your choice")
        {
            Console.WriteLine(prompt); // Display the prompt to the user
            string inputStr = Console.ReadLine();
            int inputInt;

            if (int.TryParse(inputStr, out inputInt))
            {
                return inputInt;
            }
            else
            {
                display.PrintInvalidInput();
                return -1; // Indicates invalid input
            }
        }
        public bool ValidateInput(int input, int min, int max)
        {
            return input >= min && input <= max;
        }
        public string GetShipsInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public (int, int)? ConvertToCoordinates(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr) || inputStr.Length < 2)
            {
                return null; // Invalid input, return null
            }

            // Extract row and column parts
            string rowPart = "";
            string colPart = "";
            foreach (char c in inputStr)
            {
                if (char.IsDigit(c))
                {
                    rowPart += c;
                }
                else if (char.IsLetter(c))
                {
                    colPart += c;
                }
            }

            // Convert row part to an integer
            if (!int.TryParse(rowPart, out int row) || row <= 0)
            {
                return null; // Invalid row part, return null
            }

            // Convert column part to an index
            colPart = colPart.ToUpper();
            int col = colPart[0] - 'A'; // Convert column letter to an index

            // adjusting index 
            row -= 1;

            return (row, col);
        }

        public ShipType? GetShipType()
        {
            display.ChoosingShipTypes();

            int choice = GetInput();
            if (ValidateInput(choice, 1, 5))
            {
                switch (choice)
                {
                    case 1: return ShipType.Carrier;
                    case 2: return ShipType.Cruiser;
                    case 3: return ShipType.Battleship;
                    case 4: return ShipType.Submarine;
                    case 5: return ShipType.Destroyer;
                    default: return null;
                }
            }
            return null;


        }

        public Ship.PlacementDirection? GetDirection()
        {
            display.ChoosingDirection();

            int choice = GetInput();
            if (ValidateInput(choice, 1, 4))
            {
                switch (choice)
                {
                    case 1: return Ship.PlacementDirection.Right;
                    case 2: return Ship.PlacementDirection.Left;
                    case 3: return Ship.PlacementDirection.Up;
                    case 4: return Ship.PlacementDirection.Down;
                    
                }
            }

            return null;
            


        }

        public string ChoosePlayersName()
        {
            string name;
            display.PrintSelectName();
            return name = Console.ReadLine();
        }

    }
}

