using System.Linq;

namespace FizzBuzz.Core
{
	public interface IRuleEvaluator
	{
		string Evaluate(int value);
	}

	public class RuleEvaluator : IRuleEvaluator
	{
		readonly IRule[] _rules;

		public RuleEvaluator(IRule[] rules)
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