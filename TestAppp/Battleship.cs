using System;
using Battleships;

namespace TestAppp
{
	public class Battleship
	{
        bool Running = true;
        private Display display;
        public Input input;
        private Board board;
        public BoardFactory boardFactory;

        public Battleship()
		{
			//int boardSize = GetBoardSize();
			board = new Board(10);
			display = new Display(board);
			input = new Input();
            boardFactory = new BoardFactory();
		}

        /*private int GetBoardSize()
        {
            int size;
            while (true)
            {
                size = input.GetInput("Enter the size of the board (e.g., 10 for a 10x10 board):");
                if (input.ValidateInput(size, 1, 100)) // Maxymalna wielkosc boarda
                {
                    return size;
                }
                else
                {
                    Console.WriteLine("Invalid board size. Please enter a positive integer.");
                }
            }
        }*/


        public void Run()
		{
			
			while (Running)
			{
				Menu();
				int Choice = input.GetInput();
                if (input.ValidateInput(Choice, 1, 3))
				{
					switch (Choice)
					{
						case 1: StartNewGame();
							break;

                        case 2:
                            HighScore();
                            break;

                        case 3:
                            Exit();
                            break;

                    }
					
				}
                else
                {
                    display.InvalidChoice();
                }

            }
		}

		public void Menu()
		{
			display.PrintMenu();
		}

		public void StartNewGame()
		{

            BoardFactory boardFactory = new BoardFactory();
            boardFactory.ManualPlacement(ShipType.Carrier);
            display.PrintBoard();
        }

		public void HighScore()
		{

		}

		public void Exit()
		{
			Running = false;
		}
	}
}

