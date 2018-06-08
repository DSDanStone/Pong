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

		public Ball()
		{
			XPosition = 3;
			YPosition = 3;
			GoingUp = true;
			GoingRight = true;
		}

		public Ball(int startingX, int startingY)
		{
			XPosition = startingX;
			YPosition = startingY;
			GoingUp = true;
			GoingRight = true;
		}

		public Ball(int startingX, int startingY, bool goingUp, bool goingRight)
		{
			XPosition = startingX;
			YPosition = startingY;
			GoingUp = goingUp;
			GoingRight = goingRight;
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
			if (GoingRight)
			{

				if (this.XPosition == board.Width - 2)
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
				if (this.XPosition == 1)
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
				if (this.YPosition == board.Height-1)
				{
					this.GoingUp = true;
					this.YPosition--;
				}
				else
				{
					this.YPosition++;
				}
			}


			return !gameOver;
		}
	}
}
