using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Ball
	{
		/// <summary>
		/// Represents the posistion of the ball
		/// </summary>
		public int XPosition { get; private set; }
		public int YPosition { get; private set; }
		/// <summary>
		/// Represents the direction of the ball
		/// </summary>
		public bool GoingUp { get; private set; }
		public bool GoingRight { get; private set; }
		/// <summary>
		/// Represents the color of the ball
		/// </summary>
		public ConsoleColor Color { get; private set; }

		/// <summary>
		/// Represents the character used to display the ball
		/// </summary>
		private char ballChar = '0';
		private char blankSpace = ' ';
		
		/// <summary>
		/// Creates a new ball
		/// </summary>
		/// <param name="board">The board the ball is in</param>
		public Ball(Board board)
		{
			this.Color = ConsoleColor.Magenta;
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
			bool pointOver = false;
			
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
					else if ((this.YPosition == player2.Position - 1 && !GoingUp) || (this.YPosition == player2.Position + 2 && GoingUp))
					{
						GoingRight = false;
						this.XPosition -= 1;
						GoingUp = !GoingUp;
					}
					else
					{
						this.XPosition += 1;
						pointOver = true;
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
					else if ((this.YPosition == player1.Position - 1 && !GoingUp) || (this.YPosition == player1.Position + 2 && GoingUp))
					{
						GoingRight = true;
						this.XPosition++;
						GoingUp = !GoingUp;
					}
					else
					{
						this.XPosition--;
						pointOver = true;
					}
				}
				else
				{
					this.XPosition--;
				}
			}
			if (GoingUp)
			{
				if (this.YPosition == 0)
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
				if (this.YPosition >= board.Height - 1)
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

			return !pointOver;
		}

		/// <summary>
		/// Erases the Ball from the console
		/// </summary>
		private void EraseBall()
		{
			Console.SetCursorPosition(this.XPosition, this.YPosition + 1);
			Console.Write(blankSpace);
		}

		/// <summary>
		/// Prints the Ball from to console
		/// </summary>
		public void PrintBall()
		{
			Console.ForegroundColor = this.Color;
			Console.SetCursorPosition(this.XPosition, this.YPosition + 1);
			Console.Write(ballChar);
			Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Resets the ball after a point
		/// </summary>
		/// <param name="startAtLeft">Which side to start on</param>
		/// <param name="board">The board the ball is on</param>
		public void ResetBall(bool startAtLeft, Board board)
		{
			Random random = new Random();
			if (startAtLeft)
			{
				this.XPosition = 4;
				this.YPosition = random.Next(1, board.Height);
				this.GoingRight = true;
				this.GoingUp = true;
			}
			else
			{
				this.XPosition = board.Width;
				this.YPosition = random.Next(1, board.Height);
				this.GoingRight = false;
				this.GoingUp = true;
			}
		}
	}
}
