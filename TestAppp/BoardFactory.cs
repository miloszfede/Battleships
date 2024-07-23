using System;
using TestAppp;

namespace Battleships
{
	public class BoardFactory
	{
		public Board board;
        public Input input;
		public int Size;
		public List<int> _shipCoordinates;
		public Display display;


        public BoardFactory()

		{
            this.board = new Board(10);
			board.InitializeBoard();

		}

		public void ManualPlacement()
		{
			Console.WriteLine("Choose coordinate X for your ship placement");
   //         int ChoiceX = input.GetInput();
			//if (input.ValidateInput(ChoiceX, 0, Size))
			//{
			//	_shipCoordinates.Add(ChoiceX);
			//}

			//else
			//{
			//	display.InvalidChoice();
			//}
   //         Console.WriteLine("Choose coordinate Y for your ship placement");
   //         int ChoiceY = input.GetInput();
   //         if (input.ValidateInput(ChoiceY, 0, Size))
   //         {
   //             _shipCoordinates.Add(ChoiceY);
   //         }

   //         else
   //         {
   //             display.InvalidChoice();
   //         }
			//Console.WriteLine(_shipCoordinates);
				


        }
	}

}

