using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class PongGame
	{
		public Board Board { get; private set; }
		public Ball Ball { get; private set; }
		public Paddle LeftPaddle { get; private set; }
		public Paddle RightPaddle { get; private set; }
		public int LeftScore { get; private set; }
		public int RightScore { get; private set; }
		public int NumberOfPlayers { get; private set; }
		public int GamePoints { get; private set; }

		public PongGame()
		{
			this.Board = new Board();
			this.Ball = new Ball(Board);
			this.LeftPaddle = new Paddle(3);
			this.RightPaddle = new Paddle(this.Board.Width + 4);
			this.LeftScore = 0;
			this.RightScore = 0;
			this.GamePoints = 7;
		}

		public void Run(int numberOfPlayers)
		{
			Console.WindowHeight = this.Board.Height + 5;
			Console.WindowWidth = this.Board.Width + 7;
			Console.BufferHeight = this.Board.Height + 5;
			Console.BufferWidth = this.Board.Width + 7;
			Console.CursorVisible = false;
			this.NumberOfPlayers = numberOfPlayers;
			PrintGreeting();
			while (LeftScore < GamePoints && RightScore < GamePoints)
			{
				Countdown();
				this.Board.PrintBoard();
				this.LeftPaddle.PrintPaddle();
				this.RightPaddle.PrintPaddle();
				this.Ball.PrintBall();
				this.PrintScore();

				while (this.Ball.Move(this.Board, this.LeftPaddle, this.RightPaddle))
				{
					Think(this.LeftPaddle);
					Think(this.RightPaddle);
					System.Threading.Thread.Sleep(50);
				}

				if (this.Ball.XPosition <= 2)
				{
					RightScore++;
					this.Ball.ResetBall(false, this.Board);
				}
				else
				{
					LeftScore++;
					this.Ball.ResetBall(true, this.Board);
				}
				PrintScore();

			}
			Console.WriteLine();
			Console.WriteLine("GAME OVER");
		}

		public void Think(Paddle paddle)
		{
			Random random = new Random();
			int direction = random.Next(20);

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
		}

		private void Countdown()
		{
			string message = "Round Start in 3...2...1...";
			Console.SetCursorPosition(this.Board.Width / 2 - 10, this.Board.Height + 4);

			for (int i = 0; i < message.Length; i++)
			{
				Console.Write(message[i]);
				System.Threading.Thread.Sleep(i < 14 ? 10 : 250);
			}
			Console.Write("\n");
		}

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

		private void PrintScore()
		{
			Console.SetCursorPosition(2, this.Board.Height + 3);
			Console.WriteLine(LeftScore.ToString().PadRight(this.Board.Width / 2 + 2) + RightScore.ToString().PadLeft(this.Board.Width / 2 + 2));
		}
	}
}
