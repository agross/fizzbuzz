using System;

using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
	[Subject(typeof(DivisibleByThree))]
	public class When_number_is_divisible_by_three
	{
		static string fizz;
		static DivisibleByThree DivisibleByThree;
		
		Establish context = () => { DivisibleByThree = new DivisibleByThree(); };

		Because of = () => { fizz = DivisibleByThree.GetFizz(3); };

		It should_return_fizz = () => fizz.ShouldEqual("fizz");
	}
	
	[Subject(typeof(DivisibleByThree))]
	public class When_number_is_not_divisible_by_three
	{
		static string fizz;

		static DivisibleByThree DivisibleByThree;
		
		Establish context = () => { DivisibleByThree = new DivisibleByThree(); };

		Because of = () => { fizz = DivisibleByThree.GetFizz(2); };

		It should_return_null = () => fizz.ShouldBeNull();
	}
}