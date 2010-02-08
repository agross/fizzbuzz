namespace FizzBuzz.Core
{
    public class DivisibleByThree : IRule
    {
        public string GetMessage(int val)
        {
            if (val % 3 == 0)
            {
                return "fizz";
            }
            
            return null;
        }
    }
}