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
		private const int MinWidth = 37;
		private const int MaxWidth = 150;
		private const int MinHeight = 10;
		private const int MaxHeight = 30;

		public Board()
		{
			this.Width = 50;
			this.Height = 15;
		}

		public Board(int width, int height)
		{
			this.Width = (width < MinWidth) ? (width < MaxWidth) ? width : MaxWidth : MinWidth;
			this.Height = (height < MinHeight) ? (height < MaxHeight) ? height : MaxHeight : MinHeight;
		}

		public void PrintBoard()
		{
			List<string> boardLayout = new List<string>();
			for (int i = -1; i < this.Height + 1; i++)
			{
				string line = "  +";
				// Populates a line
				for (int j = -1; j < this.Width + 1; j++)
				{
					if (i == -1 || i == this.Height)
					{
						line += "+";
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
