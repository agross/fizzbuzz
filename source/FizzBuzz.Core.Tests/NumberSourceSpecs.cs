using System.Collections.Generic;
using System.Linq;

using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(NumberSource))]
    public class When_a_the_first_number_is_queried
    {
        static NumberSource NumberSource;
        static int FirstNumber;

        Establish context =
            () => { NumberSource = new NumberSource(); };

        Because of =
            () => { FirstNumber = NumberSource.First(); };

        It should_be_the_equal_to_one =
            () => FirstNumber.ShouldEqual(1);
    }

    [Subject(typeof(NumberSource))]
    public class When_a_number_source_is_created
    {
        static NumberSource NumberSource;

        Because of = 
            () => { NumberSource = new NumberSource(); };

        It should_be_enumerable =
            () => NumberSource.ShouldBeOfType<IEnumerable<int>>();
    }

    [Subject(typeof(NumberSource))]
    public class When_a_the_second_number_is_queried
    {
        static NumberSource NumberSource;
        static int SecondNumber;

        Establish context =
            () => { NumberSource = new NumberSource(); };

        Because of =
            () => { SecondNumber = NumberSource.Skip(1).First(); };

        It should_be_the_equal_to_two =
            () => SecondNumber.ShouldEqual(2);
    }

    [Subject(typeof(NumberSource))]
    public class When_the_last_number_was_queried
    {
        static NumberSource NumberSource;
        static int LastNumber;

        Establish context =
            () => { NumberSource = new NumberSource(); };

        Because of =
            () => { LastNumber = NumberSource.Last(); };

        It should_be_equal_to_one_hundred =
            () => LastNumber.ShouldEqual(100);
    }
}