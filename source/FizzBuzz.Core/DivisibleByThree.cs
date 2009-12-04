namespace FizzBuzz.Core
{
	public class DivisibleByThree
	{
		public string GetFizz(int i)
		{
			return i % 3 == 0 ? "fizz" : null;
		}
	}
}