using Machine.Specifications;

using Rhino.Mocks;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(DefaultRuleEvaluator))]
    public class When_a_number_is_evaluated
    {
        static DefaultRuleEvaluator RuleEvaluator;
        static IRule One;
        static IRule Two;
        static IRule Three;
        static FakeRule Four;
        static string Result;

        Establish context = () =>
            {
                One = MockRepository.GenerateStub<IRule>();
                One
                    .Stub(x => x.GetMessage(0))
                    .IgnoreArguments()
                    .Return(null);

                Two = MockRepository.GenerateStub<IRule>();
                Two
                    .Stub(x => x.GetMessage(0))
                    .IgnoreArguments()
                    .Return("RuleTwoResult");

                Three = MockRepository.GenerateStub<IRule>();
                Three
                    .Stub(x => x.GetMessage(0))
                    .IgnoreArguments()
                    .Return(null);

                Four = new FakeRule();

                RuleEvaluator = new DefaultRuleEvaluator(new[] { One, Two, Three, Four });
            };

        Because of = 
            () => { Result = RuleEvaluator.Evaluate(42); };

        It should_evaluate_the_first_rule =
            () => One.AssertWasCalled(x => x.GetMessage(42));

        It should_evaluate_the_second_rule =
            () => Two.AssertWasCalled(x => x.GetMessage(42));

        It should_evaluate_the_third_rule =
            () => Three.AssertWasCalled(x => x.GetMessage(42));

        It should_evaluate_the_fourth_rule =
            () => Four.WasCalled.ShouldBeTrue();

        It should_evaluate_the_fourth_rule_with_the_number_to_be_evaluated =
            () => Four.ValueUsedForCall.ShouldEqual(42);

        It should_evaluate_the_fourth_rule_once =
            () => Four.NumberOfCallsMade.ShouldEqual(1);

        It should_yield_the_last_rule_evaluation_result_that_is_unequal_to_null =
            () => Result.ShouldEqual("foo");
    }

    // Just to demo a hand-rolled stub and how tedious they are to assert 
    // (see the three "It" specifications required instead of one).
    internal class FakeRule : IRule
    {
        public int NumberOfCallsMade;
        public int ValueUsedForCall;
        public bool WasCalled;

        public string GetMessage(int val)
        {
            WasCalled = true;
            ValueUsedForCall = val;
            NumberOfCallsMade++;
            return "foo";
        }
    }
}