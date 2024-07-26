using System;
namespace TestAppp
{
	public class Input
	{

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
                Console.WriteLine("Invalid input. Please enter a number.");
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
            Console.WriteLine("Choose the ship you want to create:");
            Console.WriteLine("1. Carrier - 1 length");
            Console.WriteLine("2. Cruiser - 2 length");
            Console.WriteLine("3. Battleship - 3 length");
            Console.WriteLine("4. Submarine - 4 length");
            Console.WriteLine("5. Destroyer - 5 length");

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


    }

}

