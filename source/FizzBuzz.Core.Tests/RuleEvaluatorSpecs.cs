using System;
using System.Collections.Generic;
using System.Linq;

using Machine.Specifications;

using Rhino.Mocks;

namespace FizzBuzz.Core.Tests
{
	[Subject(typeof(RuleEvaluator))]
	public class When_the_evaluation_is_called
	{
		static RuleEvaluator RuleEvaluator;
		static IRule One;
		static IRule Two;
		static IRule Three;
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

				RuleEvaluator = new RuleEvaluator(new[]{One,Two,Three});
			};


		Because of = () => { Result = RuleEvaluator.Evaluate(42); };

		It should_ask_all_rules = () =>
			{
				One.AssertWasCalled(x => x.GetMessage(42));
				Two.AssertWasCalled(x => x.GetMessage(42));
				Three.AssertWasCalled(x => x.GetMessage(42));
			};

		It should_return_the_last_value_unequal_to_null = 
			() => Result.ShouldEqual("RuleTwoResult");
	}

	public interface IRule
	{
		string GetMessage(int val);
	}

	internal class RuleEvaluator
	{
		readonly IRule[] _rules;

		public RuleEvaluator(IRule[] rules)
		{
			_rules = rules;
		}

		public string Evaluate(int value)
		{
			return _rules
				.Select(x=>x.GetMessage(value))
				.Where(x=>x!=null)
				.Last();
		}
	}
}