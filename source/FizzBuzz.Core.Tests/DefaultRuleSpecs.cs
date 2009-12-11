using System;

using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
	[Subject(typeof(DefaultRule))]
	public class When_the_default_rule_is_called_with_any_number_
	{
		static DefaultRule DefaultRule;
		static string Message;
		Establish context = () =>
			{
				DefaultRule = new DefaultRule();
			};

		Because of = () =>
			{
				Message = DefaultRule.GetMessage(1);
			};

		It should_output_the_number_as_string = () => Message.ShouldEqual("1");
	}
}