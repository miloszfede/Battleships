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

        public void PrintBoard(Board board, bool isOponnentBoard)
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
                   
                    Square square = board.GetSquare(row, col);
                    char symbol = square.GetStatusSymbol();
                    if (isOponnentBoard && symbol == 'S')
                    {
                        symbol = '.';
                    }

                    Console.Write("| " + $"  {symbol}  " + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('-', (board.Size * 8) + 3));
            }
        }

        public void ChoosingShipTypes()
        {
            Console.WriteLine("Choose the ship you want to create:");
            Console.WriteLine("1. Carrier - 1 length");
            Console.WriteLine("2. Cruiser - 2 length");
            Console.WriteLine("3. Battleship - 3 length");
            Console.WriteLine("4. Submarine - 4 length");
            Console.WriteLine("5. Destroyer - 5 length");
        }

        public void ChoosingDirection()
        {
            Console.WriteLine("Enter your direction: ");
            Console.WriteLine("1.Right ");
            Console.WriteLine("2.Left ");
            Console.WriteLine("3.Up ");
            Console.WriteLine("4.Down ");
        }

        public void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }

        public void PrintWrongShipPlacement()
        {
            Console.WriteLine("Cannot place ship at the specified location. Try again.");
        }

        public void PrintInvalidPosition()
        {
            Console.WriteLine("Invalid position entered.");
        }

        public void OutcomeOfGame()
        {
            Console.WriteLine("OUTCOME!");
        }

        public void PrintMiss()
        {
            Console.WriteLine("Miss!");
        }

        public void PrintAlreadyShoot()
        {
            Console.WriteLine("You already shot there. Try again.");
        }

        public void PrintInvalidShipType()
        {
            Console.WriteLine("Invalid ship type selected.");
        }

        public void InvalidDirection()
        {
            Console.WriteLine("Invalid direction selected.");
        }

        public void PrintSelectName()
        {
            Console.WriteLine("Enter your name:");
        }

        public void PrintPlayer1()
        {
            Console.WriteLine("PLAYER 1");
        }

        public void PrintPlayer2()
        {
            Console.WriteLine("PLAYER 2");
        }
    }
}

