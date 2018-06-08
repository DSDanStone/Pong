using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Classes;

namespace Pong
{
	class Program
	{
		static void Main(string[] args)
		{
			Ball ball = new Ball(1,1);
			Board board = new Board();
			Paddle player = new Paddle();
			Paddle computer = new Paddle();
			int leftScore = 0;
			int rightScore = 0;


			while (ball.Move(board, player, computer))
			{
				board.PrintBoard(ball, player, computer);
				Think(player, ball, board);
				Think(computer, ball, board);
				System.Threading.Thread.Sleep(42);


			}
			board.PrintBoard(ball, player, computer);
			Console.WriteLine("GAME OVER");
		}

		static void Think(Paddle paddle, Ball ball, Board board)
		{
			Random random = new Random();
			int direction = random.Next(20);

			if (direction < 18)
			{
				if (paddle.Position < ball.YPosition)
				{
					paddle.MoveDown(board);
				}
				else
				{
					paddle.MoveUp(board);
				}
			}
			else if (direction > 18)
			{
				if (paddle.Position < ball.YPosition)
				{
					paddle.MoveUp(board);
				}
				else
				{
					paddle.MoveDown(board);
				}
			}
		}
	}
}
