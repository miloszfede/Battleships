using System;
namespace TestAppp
{
	public class Battleship
	{
        bool Running = true;
        public Display display;
		public Input input;

		public Battleship()
		{
			display = new Display();
			input = new Input();
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

