using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(DefaultRule))]
    public class When_the_default_rule_is_evaluated_with_any_number
    {
        static DefaultRule Rule;
        static string Message;

        Establish context = 
            () => { Rule = new DefaultRule(); };

        Because of =
            () => { Message = Rule.GetMessage(1); };

        It should_yield_the_number_formatted_as_a_string =
            () => Message.ShouldEqual("1");
    }
}