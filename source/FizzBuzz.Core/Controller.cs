using System.Collections.Generic;

namespace FizzBuzz.Core
{
	public class Controller : IController
	{
		readonly IEnumerable<int> _list;
		readonly IRuleEvaluator _ruleEvaluator;
		readonly IOutput _output;

		public Controller(INumberSource list, IRuleEvaluator ruleEvaluator, IOutput output)
		{
			_list = list;
			_ruleEvaluator = ruleEvaluator;
			_output = output;
		}

		public void WriteList()
		{
			foreach (var item in _list)
			{
				_output.WriteLine(_ruleEvaluator.Evaluate(item));
			}
		}
	}
}