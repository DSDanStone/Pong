using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Board
	{
		public int Width { get; }
		public int Height { get; }

		public Board()
		{
			this.Width = 50;
			this.Height = 15;
		}

		public Board(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public void PrintBoard(Ball ball, Paddle player1, Paddle player2)
		{
			List<string> boardLayout = new List<string>();
			for (int i = -1; i < this.Height + 1; i++)
			{
				string line = "+";
				// Populates a line
				for (int j = -1; j < this.Width + 1; j++)
				{
					if (i == -1 || i == this.Height)
					{
						line += "+";
					}
					else if (i == ball.YPosition && j == ball.XPosition)
					{
						line += "0";
					}
					else if (((i == player1.Position || i == player1.Position + 1) && j == 0) ||
							((i == player2.Position || i == player2.Position + 1) && j == this.Width))
					{
						line += "|";
					}
					else
					{
						line += " ";
					}
				}

				line += "+";
				boardLayout.Add(line);
			}
			Console.Clear();
			foreach (string line in boardLayout)
			{
				Console.WriteLine(line);
			}
		}
	}
}
