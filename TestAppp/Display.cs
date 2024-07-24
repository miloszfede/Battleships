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
            Console.WriteLine("Board:");

            Console.Write("    "); //  space for column headers
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($"   {Convert.ToChar('A' + col)}    ");
            }
            Console.WriteLine();

            // row-headers
            for (int row = 0; row < board.Size; row++)
            {
                Console.Write($"{row + 1,2} "); // right-aligned, 2 odpowiada za ilosc space (2 miejsca by nie było problemu z liczbą 10)
                for (int col = 0; col < board.Size; col++)
                {
                    Console.Write("| " + board.GetSquare(row, col).ToString() + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('-', (board.Size * 8) + 3));
            }
        }

        public void ChooseTypeOfShip()
        {
            Console.WriteLine("Choose the ship you want to create");
            Console.WriteLine("Carrier (1),\nCruiser (2),\nBattleship(3),\nSubmarine(4),\nDestroyer(5)");
        }

        public void OutcomeOfGame()
        {
            Console.WriteLine("OUTCOME!");
        }
       
    }
}

