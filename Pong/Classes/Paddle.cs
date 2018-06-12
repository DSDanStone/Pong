using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Paddle
	{
		public int Position { get; private set; }
		public int Column { get; }

		private char paddleChar = '|';
		private char blankSpace = ' ';

		public Paddle(int column)
		{
			this.Position = 0;
			this.Column = column;
		}

		public Paddle(int column, int startingPosition)
		{
			this.Column = column;
			this.Position = startingPosition;
		}

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

		public void ErasePaddle()
		{
			Console.SetCursorPosition(this.Column, this.Position + 1);
			Console.Write(blankSpace);
			Console.SetCursorPosition(this.Column, this.Position + 2);
			Console.Write(blankSpace);
		}

		public void PrintPaddle()
		{
			Console.SetCursorPosition(this.Column, this.Position + 1);
			Console.Write(paddleChar);
			Console.SetCursorPosition(this.Column, this.Position + 2);
			Console.Write(paddleChar);
		}

	}
}
