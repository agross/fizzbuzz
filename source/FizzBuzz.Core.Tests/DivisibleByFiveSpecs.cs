using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(DivisibleByFive))]
    public class When_the_number_is_divisible_by_five
    {
        static string Buzz;
        static DivisibleByFive Rule;

        Establish context = 
            () => { Rule = new DivisibleByFive(); };

        Because of =
            () => { Buzz = Rule.GetMessage(5); };

        It should_yield__buzz__ =
            () => Buzz.ShouldEqual("buzz");
    }

    [Subject(typeof(DivisibleByFive))]
    public class When_the_number_is_not_divisible_by_five
    {
        static string Buzz;
        static DivisibleByFive Rule;

        Establish context = 
            () => { Rule = new DivisibleByFive(); };

        Because of =
            () => { Buzz = Rule.GetMessage(1); };

        It should_yield_null =
            () => Buzz.ShouldBeNull();
    }
}