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

		public Paddle()
		{
			this.Position = 0;
		}

		public Paddle(int startingPosition)
		{
			this.Position = startingPosition;
		}

		public void MoveUp(Board board)
		{
			this.Position -= 1;
			if (this.Position < 0)
			{
				this.Position = 0;
			}
			else if (this.Position >= board.Height -1)
			{
				this.Position = board.Height - 2;
			}
		}

		public void MoveDown(Board board)
		{
			this.Position += 1;
			if (this.Position < 0)
			{
				this.Position = 0;
			}
			else if (this.Position >= board.Height-1)
			{
				this.Position = board.Height - 2;
			}
		}

	}
}
