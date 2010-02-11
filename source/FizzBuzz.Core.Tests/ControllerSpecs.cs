using System.Collections.Generic;
using System.Linq;

using Machine.Specifications;

using Rhino.Mocks;

namespace FizzBuzz.Core.Tests
{
    [Subject(typeof(Controller))]
    public class When_the_list_of_evaluated_numbers_is_written
    {
        static Controller Controller;
        static INumberSource NumberSource;
        static IRuleEvaluator RuleEvaluator;
        static IOutput Output;
        static List<int> Numbers;

        Establish context = () =>
            {
                Numbers = new List<int> { 1, 2, 3 };

                NumberSource = MockRepository.GenerateStub<INumberSource>();
                NumberSource
                    .Stub(x => x.GetEnumerator())
                    .Return(Numbers.GetEnumerator());

                RuleEvaluator = MockRepository.GenerateStub<IRuleEvaluator>();
                RuleEvaluator
                    .Stub(x => x.Evaluate(0))
                    .IgnoreArguments()
                    .Return("TestMessage");

                Output = MockRepository.GenerateStub<IOutput>();
                Controller = new Controller(NumberSource, RuleEvaluator, Output);
            };

        Because of =
            () => Controller.WriteList();

        It should_process_every_number_from_the_number_source =
            () => RuleEvaluator
                      .GetArgumentsForCallsMadeOn(x => x.Evaluate(Arg<int>.Is.TypeOf))
                      .Select(x => x.First())
                      .Cast<int>()
                      .ShouldEqual(Numbers);

        It should_evaluate_every_number =
            () => RuleEvaluator.AssertWasCalled(x => x.Evaluate(0),
                                                x => x.IgnoreArguments().Repeat.Times(3));

        It should_output_the_evaluated_message_for_each_number =
            () => Output.AssertWasCalled(x => x.WriteLine(Arg<string>.Is.TypeOf),
                                         x => x.Repeat.Times(3));
    }
}