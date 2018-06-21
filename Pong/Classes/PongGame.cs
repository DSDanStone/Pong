using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pong.Classes
{
	public class PongGame
	{
		/// <summary>
		/// Represents the board
		/// </summary>
		private Board Board;
		/// <summary>
		/// Represents the ball
		/// </summary>
		private Ball Ball;
		/// <summary>
		/// Represents the left paddle
		/// </summary>
		private Paddle LeftPaddle;
		/// <summary>
		/// Represents the right paddle
		/// </summary>
		private Paddle RightPaddle;
		/// <summary>
		/// represents the left paddle's score
		/// </summary>
		private int LeftScore;
		/// <summary>
		/// Represents the right paddle's score
		/// </summary>
		private int RightScore;

		/// <summary>
		/// Represents the number of human players
		/// </summary>
		private int NumberOfPlayers;
		/// <summary>
		/// Represents what score to play until
		/// </summary>
		private int GamePoints;

		/// <summary>
		/// Creates a new PongGame, with default sizes
		/// </summary>
		public PongGame()
		{
			this.Board = new Board(10, 15);
			this.Ball = new Ball(Board);
			this.LeftPaddle = new Paddle(3, ConsoleColor.Blue);
			this.RightPaddle = new Paddle(this.Board.Width + 4, ConsoleColor.Green);
			this.LeftScore = 0;
			this.RightScore = 0;
			this.GamePoints = 7;
		}

		/// <summary>
		/// Runs the game
		/// </summary>
		/// <param name="numberOfPlayers">The number of players to play with</param>
		public void Run(int numberOfPlayers)
		{
			// Define the number of players
			this.NumberOfPlayers = (numberOfPlayers < 0) ? 0 : numberOfPlayers;
			this.NumberOfPlayers = (numberOfPlayers > 2) ? 2 : this.NumberOfPlayers;

			// Set up the play screen
			CreateWindow();
			// Show the intro splash screen
			PrintGreeting();

			// Create threads to track player input
			if (this.NumberOfPlayers >= 1)
			{
				Thread player1Up = new Thread(CheckLeftUp);
				Thread player1Down = new Thread(CheckLeftDown);
				player1Up.Start();
				player1Down.Start();
			}
			if (this.NumberOfPlayers == 2)
			{
				Thread player2Up = new Thread(CheckRightUp);
				Thread player2Down = new Thread(CheckRightDown);
				player2Up.Start();
				player2Down.Start();
			}

			// Print the starting board and pieces
			this.Board.PrintBoard();
			this.LeftPaddle.PrintPaddle();
			this.RightPaddle.PrintPaddle();
			this.Ball.PrintBall();
			this.PrintScore();

			// Continue the game until someone reaches the number of points to win
			while (LeftScore < GamePoints && RightScore < GamePoints)
			{
				// Countdown before each round
				Countdown();

				// Continue moving the ball while it stays in bounds
				while (this.Ball.Move(this.Board, this.LeftPaddle, this.RightPaddle))
				{
					// Move the CPU players
					if (this.NumberOfPlayers == 0)
					{
						Think(this.LeftPaddle);
					}
					if (this.NumberOfPlayers < 2)
					{
						Think(this.RightPaddle);
					}

					// Designate the ball speed
					System.Threading.Thread.Sleep(50);
				}

				// When a point ends, check who's it was, and update the score
				if (this.Ball.XPosition <= this.Board.Width / 2)
				{
					RightScore++;
					this.Ball.ResetBall(false, this.Board);
				}
				else
				{
					LeftScore++;
					this.Ball.ResetBall(true, this.Board);
				}

				// Update the score
				PrintScore();
			}

			// Show Game Over when the game ends
			Console.WriteLine();
			Console.WriteLine("GAME OVER");
		}

		/// <summary>
		/// Sets the size of the console window and hides the cursor
		/// </summary>
		private void CreateWindow()
		{
			Console.WindowHeight = this.Board.Height + 7;
			Console.WindowWidth = this.Board.Width + 7;
			Console.BufferHeight = this.Board.Height + 7;
			Console.BufferWidth = this.Board.Width + 7;
			Console.CursorVisible = false;
		}

		/// <summary>
		/// Check for user input to move the left paddle up
		/// </summary>
		private void CheckLeftUp()
		{
			if (this.NumberOfPlayers == 2)
			{
				while (true)
				{
					if (Console.ReadKey(true).Key.Equals(ConsoleKey.W))
					{
						LeftPaddle.MoveUp(this.Board);
					}
				}
			}
			else
			{
				while (true)
				{
					if (Console.ReadKey(true).Key.Equals(ConsoleKey.UpArrow))
					{
						LeftPaddle.MoveUp(this.Board);
					}
				}
			}
		}

		/// <summary>
		/// Check for user input to move the left paddle down
		/// </summary>
		private void CheckLeftDown()
		{
			if (this.NumberOfPlayers == 2)
			{
				while (true)
				{
					if (Console.ReadKey(true).Key.Equals(ConsoleKey.S))
					{
						LeftPaddle.MoveDown(this.Board);
					}
				}
			}
			else
			{
				while (true)
				{
					if (Console.ReadKey(true).Key.Equals(ConsoleKey.DownArrow))
					{
						LeftPaddle.MoveDown(this.Board);
					}
				}
			}
		}

		/// <summary>
		/// Check for user input to move the right paddle up
		/// </summary>
		private void CheckRightUp()
		{
			while (true)
			{
				if (Console.ReadKey(true).Key.Equals(ConsoleKey.UpArrow))
				{
					RightPaddle.MoveUp(this.Board);
				}
			}
		}

		/// <summary>
		/// Check for user input to move the right paddle down
		/// </summary>
		private void CheckRightDown()
		{
			while (true)
			{
				if (Console.ReadKey(true).Key.Equals(ConsoleKey.DownArrow))
				{
					RightPaddle.MoveDown(this.Board);
				}
			}
		}

		/// <summary>
		/// Moves a CPU paddle
		/// </summary>
		/// <param name="paddle">Which paddle to move</param>
		private void Think(Paddle paddle)
		{
			// Make a random number to give the computer a chance of a wrong move
			Random random = new Random();
			int direction = random.Next(20);

			// 90% chance to move toward the ball
			if (direction < 18)
			{
				if (paddle.Position < this.Ball.YPosition)
				{
					paddle.MoveDown(this.Board);
				}
				else
				{
					paddle.MoveUp(this.Board);
				}
			}
			// 5% chance to move away from the ball
			else if (direction > 18)
			{
				if (paddle.Position < this.Ball.YPosition)
				{
					paddle.MoveUp(this.Board);
				}
				else
				{
					paddle.MoveDown(this.Board);
				}
			}
			// 5% chance of not moving
		}

		/// <summary>
		/// Prints a countdown before each round
		/// </summary>
		private void Countdown()
		{
			string message = "Round Start in 3...2...1...";

			for (int i = 0; i < message.Length; i++)
			{
				Console.SetCursorPosition((this.Board.Width / 2 - 10) + i, this.Board.Height + 4);
				Console.Write(message[i]);
				System.Threading.Thread.Sleep(i < 14 ? 10 : 80);
			}
			Console.Write("\n");
		}

		/// <summary>
		/// Prints the intro splash screen
		/// </summary>
		private void PrintGreeting()
		{
			Console.Clear();
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 - 5);
			Console.WriteLine(@" _____   _  _     _____                   ");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 - 4);
			Console.WriteLine(@"/  __ \_| || |_  /  _  \                  ");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 - 3);
			Console.WriteLine(@"| /  \/_  __  _| | (_)  |___  _ __   ___  ");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 - 2);
			Console.WriteLine(@"| |    _| || |_  |  ___// _ \| '_ `\/ _ \ ");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 - 1);
			Console.WriteLine(@"| \__/\_  __  _| | |   | (_) | | | | (_) |");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2);
			Console.WriteLine(@" \____/ |_||_|   |_|    \___/|_| |_|\__  |");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 + 1);
			Console.WriteLine(@"                                     __| /");
			Console.SetCursorPosition(Board.Width / 2 - 16, Board.Height / 2 + 2);
			Console.WriteLine(@"                                    /___/ ");
			Console.WriteLine();
		}

		/// <summary>
		/// Prints the current score
		/// </summary>
		private void PrintScore()
		{
			Console.SetCursorPosition(2, this.Board.Height + 3);
			Console.WriteLine(LeftScore.ToString().PadRight(this.Board.Width / 2 + 2) + RightScore.ToString().PadLeft(this.Board.Width / 2 + 2));
		}
	}
}
