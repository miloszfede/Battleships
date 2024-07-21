using System;
using System.Drawing;

namespace TestAppp
{
	public class Display
	{
        

        public Display()
		{
		}

        public void PrintMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. START GAME");
            Console.WriteLine("2. SHOW SCORES");
            Console.WriteLine("3. EXIT");
        }

        public void InvalidChoice()
        {
            Console.WriteLine("Invalid choice. Please select valid choice.");
        }

        public void PrintBoard()
        {
            Console.WriteLine("BOARD!");
        }

        public void OutcomeOfGame()
        {
            Console.WriteLine("OUTCOME!");
        }
       
    }
}

