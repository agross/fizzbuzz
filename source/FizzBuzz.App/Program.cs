using Castle.MicroKernel.Registration;
using Castle.Windsor;

using Crimson.Infrastructure.Container;

using FizzBuzz.Core;

namespace FizzBuzz.App
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (IWindsorContainer container = new WindsorContainer())
			{
				container.AddFacility<ArrayDependencyFacility>();

				container.Register(
					Component
					.For<IRule>()
					.ImplementedBy<DefaultRule>()
					.Named("default"),
					Component
					.For<IRule>()
					.ImplementedBy<DivisibleByThree>()
					.Named("div-by-three"),
					Component
					.For<IRuleEvaluator>()
					.ImplementedBy<RuleEvaluator>()
					.ServiceOverrides(ServiceOverride.ForKey("rules").Eq("default", "div-by-three")),
					Component
					.For<IOutput>()
					.ImplementedBy<Output>(),
					Component
					.For<IController>()
					.ImplementedBy<Controller>(),
					Component
					.For<INumberSource>()
					.ImplementedBy<NumberSource>()
					);

				IController controller = container.Resolve<IController>();
				controller.WriteList();
			}
		}
	}
}