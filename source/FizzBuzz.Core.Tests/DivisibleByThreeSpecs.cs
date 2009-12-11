using System;

using Machine.Specifications;

namespace FizzBuzz.Core.Tests
{
	[Subject(typeof(DivisibleByThree))]
	public class When_the_number_is_divisible_by_three
	{
		static string Fizz;
		static DivisibleByThree DivisibleByThree;
		
		Establish context = () => { DivisibleByThree = new DivisibleByThree(); };

		Because of = () => { Fizz = DivisibleByThree.GetMessage(3); };

		It should_return_fizz = () => Fizz.ShouldEqual("fizz");
	}
	
	[Subject(typeof(DivisibleByThree))]
	public class When_the_number_is_not_divisible_by_three
	{
		static string Fizz;

		static DivisibleByThree DivisibleByThree;
		
		Establish context = () => { DivisibleByThree = new DivisibleByThree(); };

		Because of = () => { Fizz = DivisibleByThree.GetMessage(2); };

		It should_return_null = () => Fizz.ShouldBeNull();
	}
}