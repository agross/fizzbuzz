using System;

namespace FizzBuzz.Core
{
	public class Output : IOutput
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}