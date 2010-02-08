using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(DivisibleByThreeAndFive))]
    public class When_the_number_is_divisible_by_three_and_five
    {
        static string FizzBuzz;
        static DivisibleByThreeAndFive Rule;

        Establish context =
            () => { Rule = new DivisibleByThreeAndFive(); };

        Because of =
            () => { FizzBuzz = Rule.GetMessage(15); };

        It should_yield__fizzbuzz__ =
            () => FizzBuzz.ShouldEqual("fizzbuzz");
    }

    [Subject(typeof(DivisibleByThreeAndFive))]
    public class When_the_number_is_not_divisible_by_three_and_five
    {
        static string FizzBuzz;
        static DivisibleByThreeAndFive Rule;

        Establish context =
            () => { Rule = new DivisibleByThreeAndFive(); };

        Because of =
            () => { FizzBuzz = Rule.GetMessage(1); };

        It should_yield_null =
            () => FizzBuzz.ShouldBeNull();
    }
}