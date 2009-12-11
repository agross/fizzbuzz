using System;
using System.Collections.Generic;
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

				RuleEvaluator = new RuleEvaluator(new[]{One,Two,Three,Four});
			};


		Because of = () => { Result = RuleEvaluator.Evaluate(42); };

		It should_ask_all_rules = () =>
			{
				One.AssertWasCalled(x => x.GetMessage(42));
				Two.AssertWasCalled(x => x.GetMessage(42));
				Three.AssertWasCalled(x => x.GetMessage(42));
				Four.WasCalled.ShouldBeTrue();
				Four.ValueUsedForCall.ShouldEqual(42);
				Four.NumberOfCallsMade.ShouldEqual(1);
			};

		It should_return_the_last_value_unequal_to_null = 
			() => Result.ShouldEqual("foo");
	}

	internal class FakeRule : IRule
	{
		public string GetMessage(int val)
		{
			WasCalled = true;
			ValueUsedForCall = val;
			NumberOfCallsMade++;
			return "foo";
		}

		public bool WasCalled;
		public int ValueUsedForCall;
		public int NumberOfCallsMade;
	}
}