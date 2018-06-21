using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Classes
{
	public class Board
	{
		/// <summary>
		/// Represent the dimensions of the board
		/// </summary>
		public int Width { get; }
		public int Height { get; }

		/// <summary>
		/// Size constraints before the board starts getting wonky. 
		/// ****(May need to be adjusted for different screens)****
		/// </summary>
		private const int MinWidth = 37;
		private const int MaxWidth = 150;
		private const int MinHeight = 10;
		private const int MaxHeight = 30;

		/// <summary>
		/// Construct the board with default size
		/// </summary>
		public Board()
		{
			this.Width = 50;
			this.Height = 15;
		}

		/// <summary>
		/// Construct the board with specified size
		/// </summary>
		/// <param name="width">The desired width of the board</param>
		/// <param name="height">The desired height of the board</param>
		public Board(int width, int height)
		{
			this.Width = (width < MinWidth) ? MinWidth : width;
			this.Width = (width > MaxWidth) ? MaxWidth : this.Width;
			this.Height = (height < MinHeight) ? MinHeight : height;
			this.Height = (height > MaxHeight) ? MaxHeight : this.Height;
		}

		/// <summary>
		/// Prints the board to the console
		/// </summary>
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
