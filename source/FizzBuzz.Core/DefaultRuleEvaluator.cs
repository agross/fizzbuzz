using System.Linq;

namespace FizzBuzz.Core
{
    public class DefaultRuleEvaluator : IRuleEvaluator
	{
		readonly IRule[] _rules;

		public DefaultRuleEvaluator(IRule[] rules)
		{
			_rules = rules;
		}

		public string Evaluate(int value)
		{
			return _rules
				.Select(x => x.GetMessage(value))
				.Where(x => x != null)
				.Last();
		}
	}
}