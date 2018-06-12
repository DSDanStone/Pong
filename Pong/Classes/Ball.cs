using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Ball
	{
		public int XPosition { get; private set; }
		public int YPosition { get; private set; }
		public bool GoingUp { get; private set; }
		public bool GoingRight { get; private set; }

		private char blankSpace = ' ';
		private char ballChar = '0';

		public Ball(Board board)
		{
			ResetBall(true, board);
		}

		/// <summary>
		/// Moves the ball
		/// </summary>
		/// <param name="board">The playing board</param>
		/// <param name="player1">The left paddle</param>
		/// <param name="player2">The right paddle</param>
		/// <returns>True if the move stays in bounds</returns>
		public bool Move(Board board, Paddle player1, Paddle player2)
		{
			bool gameOver = false;

			this.EraseBall();

			if (GoingRight)
			{
				if (this.XPosition == player2.Column - 1)
				{
					if (this.YPosition == player2.Position || this.YPosition == player2.Position + 1)
					{
						GoingRight = false;
						this.XPosition -= 1;
					}
					else
					{
						this.XPosition += 1;
						gameOver = true;
					}
				}
				else
				{
					this.XPosition += 1;
				}
			}
			else
			{
				if (this.XPosition == player1.Column + 1)
				{
					if (this.YPosition == player1.Position || this.YPosition == player1.Position + 1)
					{
						GoingRight = true;
						this.XPosition++;
					}
					else
					{
						this.XPosition--;
						gameOver = true;
					}
				}
				else
				{
					this.XPosition--;
				}
			}
			if (GoingUp)
			{
				if (this.YPosition == 1)
				{
					this.GoingUp = false;
					this.YPosition++;
				}
				else
				{
					this.YPosition--;
				}
			}
			else
			{
				if (this.YPosition == board.Height)
				{
					this.GoingUp = true;
					this.YPosition--;
				}
				else
				{
					this.YPosition++;
				}
			}

			this.PrintBall();

			return !gameOver;
		}

		public void EraseBall()
		{
			Console.SetCursorPosition(this.XPosition, this.YPosition);
			Console.Write(blankSpace);
			Console.SetCursorPosition(this.XPosition, this.YPosition);
			Console.Write(blankSpace);
		}

		public void PrintBall()
		{
			Console.SetCursorPosition(this.XPosition, this.YPosition);
			Console.Write(ballChar);
			Console.SetCursorPosition(this.XPosition, this.YPosition);
			Console.Write(ballChar);
		}

		public void ResetBall(bool startAtLeft, Board board)
		{
			Random random = new Random();
			if (startAtLeft)
			{
				this.XPosition = 3;
				this.YPosition = random.Next(1, board.Height);
				this.GoingRight = true;
				this.GoingUp = true;
			}
			else
			{
				this.XPosition = board.Width - 3;
				this.YPosition = random.Next(1, board.Height);
				this.GoingRight = false;
				this.GoingUp = true;
			}
		}
	}
}
