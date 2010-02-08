using System;

namespace FizzBuzz.Core
{
	public class ConsoleOutput : IOutput
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}