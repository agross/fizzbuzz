using System;

namespace FizzBuzz.Core
{
	public class DivisibleByThree: IRule
	{
		public string GetMessage(int val)
		{
			return val % 3 == 0 ? "fizz" : null;
		}
	}
}