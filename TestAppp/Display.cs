using System;
using System.Drawing;

namespace TestAppp
{
	public class Display
	{
        private Board board;
        

        public Display(Board board)
		{
            this.board = board; 
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
            Console.WriteLine("Board:");

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.Write("| " + board.GetSquare(i, j).ToString() + " ");
                }
                Console.WriteLine("|");

                // Fikuśny separator
                Console.WriteLine(new string('-', (board.Size * 6) + 1));
            }
        }

        public void OutcomeOfGame()
        {
            Console.WriteLine("OUTCOME!");
        }
       
    }
}

