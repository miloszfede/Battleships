using Battleships;
using System;
namespace TestAppp
{
	public class Battleship
	{
        bool Running = true;
        private Display display;
        public Input input;
        private Board board;
        private List<Ship> placedShips;
        

        public Battleship()
		{   input = new Input();
			int boardSize = GetBoardSize();
			board = new Board(boardSize);
			display = new Display(board);
            placedShips = new List<Ship>();
			
		}

        private int GetBoardSize()
        {
            
            while (true)
            {
                int size = input.GetInput("Enter the size of the board (e.g., 10 for a 10x10 board):");
                if (input.ValidateInput(size, 5, 50)) // Maxymalna wielkosc boarda
                {
                    return size;
                }
                else
                {
                    Console.WriteLine("Invalid board size. Please enter a positive integer.");
                }
            }
        }


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
            int numberOfShips = 5;
            int shipsPlaced = 0;
            Player p1 = new Player("PLAYER 1", 1);
            Player p2 = new Player("PLAYER 2", 2);
            while (shipsPlaced < numberOfShips)

            {
                display.PrintBoard();

                ShipType? shipType = input.GetShipType();
                if (shipType == null)
                {
                    Console.WriteLine("Invalid ship type selected.");
                    
                    continue;
                }
                Console.WriteLine($"Selected Ship Type: {shipType}");
                Ship.PlacementDirection? direction = input.GetDirection();
                if (direction == null)
                {
                    Console.WriteLine("Invalid direction selected.");
                    continue;
                }

                int shipLength = shipType.Value.GetLength();
                Console.WriteLine($"Ship Length: {shipLength}"); // checking if ship type matches ships length
                string userInput = input.GetShipsInput("Enter the position (e.g., 1A):");
                var coordinates = input.ConvertToCoordinates(userInput);

                if (coordinates != null)
                {
                    (int row, int col) = coordinates.Value;
                    Console.WriteLine($"Placing {shipType} at Coordinates: Row={row}, Column={col}");
               

                    Ship ship = new Ship(shipType.Value);
                    board.PlaceShip(row, col, shipLength, direction.Value);
                    Console.WriteLine($"Number of ships before adding: {placedShips.Count}");
                    placedShips.Add(ship);
                    Console.WriteLine($"Number of ships before adding: {placedShips.Count}");
                    Console.WriteLine($"{shipType} placed successfully.");
                    shipsPlaced++;
                    p1.Fleet.Add(ship); //tu wyskakuje błąd! "Object reference not set to an instance of an object."



                }
                else
                {
                    Console.WriteLine("Invalid position entered.");
                    
                }
            }
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

