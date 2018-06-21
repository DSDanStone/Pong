using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Pong.Classes;

namespace Pong
{
	class Program
	{
		static void Main(string[] args)
		{
			PongGame pong = new PongGame();
			pong.Run(2);
		}
	}
}
