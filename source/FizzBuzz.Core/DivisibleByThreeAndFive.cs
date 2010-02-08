namespace FizzBuzz.Core
{
    public class DivisibleByThreeAndFive : IRule
    {
        public string GetMessage(int val)
        {
            if (val % 3 == 0 && val % 5 == 0)
            {
                return "fizzbuzz";
            }

            return null;
        }
    }
}