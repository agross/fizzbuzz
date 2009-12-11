namespace FizzBuzz.Core
{
	public class DefaultRule : IRule
	{
		public string GetMessage(int val)
		{
			return val.ToString();
		}
	}
}