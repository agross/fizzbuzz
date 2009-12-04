using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;

namespace FizzBuzz.Core.Tests
{
	[Subject(typeof(Controller))]
	public class When_list_is_displayed
	{
		static Controller Controller;
		static IEnumerable<int> NumberList;
		static IRuleEvaluator RuleEvaluator;


		Establish context = () =>
		                    	{
									NumberList = new[] { 1, 2, 3 };
									RuleEvaluator = MockRepository.GenerateStub<IRuleEvaluator>();
									Controller = new Controller(NumberList, RuleEvaluator);
		                    	};
		Because of = 
			() => { Controller.WriteList(); };

		It should_evaluate_every_given_number =
			() => RuleEvaluator
			      	.GetArgumentsForCallsMadeOn(x => x.Evaluate(Arg<int>.Is.TypeOf))
			      	.Select(x => x.First())
			      	.Cast<int>()
			      	.SequenceEqual(NumberList)
			      	.ShouldBeTrue();
	}

	public class Controller
	{
		readonly IEnumerable<int> _list;
		readonly IRuleEvaluator _ruleEvaluator;

		public Controller(IEnumerable<int> list, IRuleEvaluator ruleEvaluator)
		{
			_list = list;
			_ruleEvaluator = ruleEvaluator;
		}

		public void WriteList()
		{
			foreach (var item in _list)
				_ruleEvaluator.Evaluate(item);
		}
	}


}
