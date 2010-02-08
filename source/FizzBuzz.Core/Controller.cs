using System.Collections.Generic;

namespace FizzBuzz.Core
{
	public class Controller : IController
	{
		readonly IEnumerable<int> _numbers;
		readonly IRuleEvaluator _ruleEvaluator;
		readonly IOutput _output;

		public Controller(INumberSource numbers, IRuleEvaluator ruleEvaluator, IOutput output)
		{
			_numbers = numbers;
			_ruleEvaluator = ruleEvaluator;
			_output = output;
		}

		public void WriteList()
		{
			foreach (var item in _numbers)
			{
			    var message = _ruleEvaluator.Evaluate(item);
			    _output.WriteLine(message);
			}
		}
	}
}