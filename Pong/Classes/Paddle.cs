using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Paddle
	{
		/// <summary>
		/// Represents the paddle's location on the board
		/// </summary>
		public int Position { get; private set; }
		public int Column { get; }

		/// <summary>
		/// Represents the paddle's color
		/// </summary>
		public ConsoleColor Color { get; private set; }

		/// <summary>
		/// Represents the character used to represent a paddle
		/// </summary>
		private char paddleChar = '|';
		private char blankSpace = ' ';

		/// <summary>
		/// Creates a Paddle with default settings
		/// </summary>
		/// <param name="column">Which column the paddle lives in</param>
		public Paddle(int column)
		{
			this.Position = 0;
			this.Column = column;
			this.Color = ConsoleColor.White;
		}

		/// <summary>
		/// Creates a paddle with a custom color
		/// </summary>
		/// <param name="column">Which column the paddle lives in</param>
		/// <param name="color">The desired color for the paddle</param>
		public Paddle(int column, ConsoleColor color)
		{
			this.Position = 0;
			this.Column = column;
			this.Color = color;
		}

		/// <summary>
		/// Moves the Paddle up
		/// </summary>
		/// <param name="board">The board the paddle is on</param>
		public void MoveUp(Board board)
		{
			this.ErasePaddle();

			this.Position -= 1;

			if (this.Position < 0)
			{
				this.Position = 0;
			}
			else if (this.Position >= board.Height - 1)
			{
				this.Position = board.Height - 2;
			}

			this.PrintPaddle();
		}

		/// <summary>
		/// Moves the Paddle down
		/// </summary>
		/// <param name="board">The board the paddle is on</param>
		public void MoveDown(Board board)
		{
			this.ErasePaddle();

			this.Position += 1;
			if (this.Position < 0)
			{
				this.Position = 0;
			}
			else if (this.Position >= board.Height - 1)
			{
				this.Position = board.Height - 2;
			}

			this.PrintPaddle();
		}

		/// <summary>
		/// Erases the paddle from the console
		/// </summary>
		private void ErasePaddle()
		{
			Console.SetCursorPosition(this.Column, this.Position + 1);
			Console.Write(blankSpace);
			Console.SetCursorPosition(this.Column, this.Position + 2);
			Console.Write(blankSpace);
		}

		/// <summary>
		/// Prints the paddle to the console
		/// </summary>
		public void PrintPaddle()
		{
			Console.ForegroundColor = this.Color;
			Console.SetCursorPosition(this.Column, this.Position + 1);
			Console.Write(paddleChar);
			Console.SetCursorPosition(this.Column, this.Position + 2);
			Console.Write(paddleChar);
			Console.ForegroundColor = ConsoleColor.White;
		}

	}
}
