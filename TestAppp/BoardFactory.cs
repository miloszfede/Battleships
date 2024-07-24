using System;
using TestAppp;

namespace Battleships
{
	public class BoardFactory
	{
		public Board board;
        public Input input;
		public int Size;
		public Display display;

        public BoardFactory()

		{
            this.board = new Board(10);
			board.InitializeBoard();
			this.input = new Input();
			this.display = new Display();
		}

		public Ship ManualPlacement(ShipType shipType)
		{
			int ChoiceX;
			int ChoiceY;
			int direction;
            Boolean isValidated;
            do
			{
				Console.WriteLine("Choose coordinate X for your ship placement");
				ChoiceX = input.GetInput();
				int Size = 10;
				isValidated = input.ValidateInput(ChoiceX, 0, Size);
                if (!isValidated)
				{
					display.InvalidChoice();
				}
			} while (!isValidated);
            do
            {
                Console.WriteLine("Choose coordinate Y for your ship placement");
                ChoiceY = input.GetInput();
                int Size = 10;
                isValidated = input.ValidateInput(ChoiceY, 0, Size);
                if (!isValidated)
                {
                    display.InvalidChoice();
                }
            } while (!isValidated);
			do
			{
				Console.WriteLine("Choose direction for your ship.");
				Console.WriteLine("1. for left");
				Console.WriteLine("2. for up");
				Console.WriteLine("3. for right");
				Console.WriteLine("4. for down");
				direction = input.GetInput();
				isValidated = input.ValidateInput(direction, 1, 4);
                if (!isValidated)
				{
					display.InvalidChoice();
				}
			} while (!isValidated);
			Ship ship = new Ship(ChoiceX, ChoiceY, direction);
			return ship;
        }
	}

}

