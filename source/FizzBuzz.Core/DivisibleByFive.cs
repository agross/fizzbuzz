namespace FizzBuzz.Core
{
    public class DivisibleByFive : IRule
    {
        public string GetMessage(int val)
        {
            if (val % 5 == 0)
            {
                return "buzz";
            }

            return null;
        }
    }
}