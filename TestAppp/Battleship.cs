
using System;
namespace TestAppp
{
    public class Battleship
    {
        bool Running = true;
        private Display display;
        public Input input;

        private int boardSize;
        private List<Ship> placedShips; // player 1 player 2 z listami list<ship>


        public Battleship()
        {   input = new Input();
            boardSize = GetBoardSize();
            display = new Display();
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
                    display.PrintInvalidInput();
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
            display.PrintPlayer1();
            Player player1 = new Player(boardSize, input.ChoosePlayersName());
            display.PrintPlayer2();
            Player player2 = new Player(boardSize, input.ChoosePlayersName());
            ShipPlacement(player1);
            ShipPlacement(player2);
            
            

            while (true)
            {
                ShootingPhase(player1, player2);
                if (CheckWinCondition(player2))
                {
                    Console.WriteLine($"{player1.Name} wins!");
                    break;
                }

                ShootingPhase(player2, player1);
                if (CheckWinCondition(player1))
                {
                    Console.WriteLine($"{player2.Name} wins!");
                    break;
                }
            }


        }

        public void ShootingPhase(Player player1, Player player2)
        {
            Player currentPlayer = player1;
            Player opponentPlayer = player2;


            display.PrintBoardsSideBySide(currentPlayer.Board, opponentPlayer.Board);
            Console.WriteLine($"{(currentPlayer.Name)}, it's your turn to shoot!");

                string userInput = input.GetShipsInput("Enter the position to shoot (e.g., 1A):");
                var coordinates = input.ConvertToCoordinates(userInput);

                if (coordinates != null)
                {
                    (int row, int col) = coordinates.Value;
                    if (opponentPlayer.Board.IsValidCoordinate(row, col))
                    {
                        Square targetSquare = opponentPlayer.Board.GetSquare(row, col);

                        if (targetSquare.Status == Square.SquareStatus.ship)
                        {
                            targetSquare.Status = Square.SquareStatus.hit;
                            Console.WriteLine("Hit!");

                            Ship hitShip = opponentPlayer.Fleet.FirstOrDefault(ship => ship.Coordinates.Contains((col, row)));
                            if (hitShip != null)
                            {
                                hitShip.RegisterHit();

                                // Check if the ship is sunk
                                if (hitShip.Sunk)
                                {
                                    Console.WriteLine($"{hitShip.Type} has been sunk!");
                                }
                            }
                        }
                        
                   

                        else if (targetSquare.Status == Square.SquareStatus._empty)
                        {
                            targetSquare.Status = Square.SquareStatus.miss;
                            display.PrintMiss();
                        }
                        else
                        {
                            display.PrintAlreadyShoot();
                        }
                        if (CheckWinCondition(opponentPlayer))
                        {
                            Console.WriteLine($"{currentPlayer.Name} wins!");
                            
                        }



                    }
                }
           
        }

        /*public void ShootingPhase(Player currentPlayer, Player opponentPlayer)
        {
            while (true)
            {
                display.PrintBoardsSideBySide(currentPlayer.Board, opponentPlayer.Board);
                Console.WriteLine($"{currentPlayer.Name}, it's your turn to shoot or use radar!");
                Console.WriteLine("Enter 'R' to use radar or position to shoot (e.g., 1A):");

                string userInput = input.GetShipsInput("");
                if (userInput.Trim().ToUpper() == "R")
                {
                    if (currentPlayer.RadarUsage > 0)
                    {
                        Console.WriteLine("Enter the position to use radar (e.g., 1A):");
                        userInput = input.GetShipsInput("");
                        var coordinates = input.ConvertToCoordinates(userInput);
                        if (coordinates != null)
                        {
                            (int row, int col) = coordinates.Value;
                            if (currentPlayer.Board.IsValidCoordinate(row, col))
                            {
                                bool radarResult = currentPlayer.UseRadar(row, col);
                                if (radarResult)
                                {
                                    Console.WriteLine("Radar detected a ship around the specified coordinates!");
                                }
                                else
                                {
                                    Console.WriteLine("No ships detected around the specified coordinates.");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates. Try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No radar usages left. Try again.");
                    }
                }
                else
                {
                    var coordinates = input.ConvertToCoordinates(userInput);
                    if (coordinates != null)
                    {
                        (int row, int col) = coordinates.Value;
                        if (opponentPlayer.Board.IsValidCoordinate(row, col))
                        {
                            Square targetSquare = opponentPlayer.Board.GetSquare(row, col);

                            if (targetSquare.Status == Square.SquareStatus.ship)
                            {
                                targetSquare.Status = Square.SquareStatus.hit;
                                Console.WriteLine("Hit!");

                                Ship hitShip = opponentPlayer.Fleet.FirstOrDefault(ship => ship.Coordinates.Contains((row, col)));
                                if (hitShip != null)
                                {
                                    hitShip.RegisterHit();

                                    if (hitShip.Sunk)
                                    {
                                        Console.WriteLine($"{hitShip.Type} has been sunk!");
                                    }
                                }
                            }
                            else if (targetSquare.Status == Square.SquareStatus._empty)
                            {
                                targetSquare.Status = Square.SquareStatus.miss;
                                Console.WriteLine("Miss!");
                            }
                            else
                            {
                                Console.WriteLine("You already shot there. Try again.");
                            }

                            if (CheckWinCondition(opponentPlayer))
                            {
                                Console.WriteLine($"{currentPlayer.Name} wins!");
                                
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
            }
        }*/


        public void ShipPlacement(Player player) 
            {
            int numberOfShips = 2;
            int shipsPlaced = 0;
            
            while (shipsPlaced < numberOfShips)

            {
                display.PrintBoard(player.Board, false);

                ShipType? shipType = input.GetShipType();
                if (shipType == null)
                {
                    display.PrintInvalidShipType();

                    continue;
                }
                Console.WriteLine($"Selected Ship Type: {shipType}");
                Ship.PlacementDirection? direction = input.GetDirection();
                if (direction == null)
                {
                    display.InvalidDirection();
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

                    if (player.Board.CanPlaceShip(row,col,shipLength, direction.Value)) 
                        {
                        Ship ship = new Ship(shipType.Value);
                        ship.AddCoordinate(col, row);
                        player.Board.PlaceShip(row, col, shipLength, direction.Value);
                        Console.WriteLine($"Number of ships before adding: {placedShips.Count}");
                        player.Fleet.Add(ship);
                        Console.WriteLine($"Number of ships before adding: {placedShips.Count}");
                        Console.WriteLine($"{shipType} placed successfully.");
                        shipsPlaced++;

                        }

                    else
                    {
                        display.PrintWrongShipPlacement();
                    }


                }
                else
                {
                    display.PrintInvalidPosition();

                }
            }
            display.PrintBoard(player.Board, false);


        }

        public bool CheckWinCondition(Player player)
        {
            return player.Fleet.All(ship => ship.Sunk);
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

