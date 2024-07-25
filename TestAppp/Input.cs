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

    }
}

