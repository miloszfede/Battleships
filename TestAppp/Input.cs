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




    }
}

