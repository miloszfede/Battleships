using System;
namespace TestAppp
{
	public class Input
	{

        public int test = 4;

		public int GetInput()
		{
            Console.WriteLine("Enter your choice");
            string inputStr = Console.ReadLine();
            int inputInt;

            if (int.TryParse(inputStr, out inputInt))
            {
                return inputInt;
            }
            else
            {
                return -1;
            }
        }

        public bool ValidateInput(int input, int min, int max)
        {
            return input >= min && input <= max;
        }




    }
}

