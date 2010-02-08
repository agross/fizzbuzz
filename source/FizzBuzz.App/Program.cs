using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;

using FizzBuzz.App.Container;
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

                container.Register(Component.For<IRule>()
                                       .ImplementedBy<DefaultRule>()
                                       .Named("default"),
                                   Component.For<IRule>()
                                       .ImplementedBy<DivisibleByThree>()
                                       .Named("div-by-three"),
                                   Component.For<IRule>()
                                       .ImplementedBy<DivisibleByFive>()
                                       .Named("div-by-five"),
                                   Component.For<IRule>()
                                       .ImplementedBy<DivisibleByThreeAndFive>()
                                       .Named("div-by-three-and-five"),
                                   Component.For<IRuleEvaluator>()
                                       .ImplementedBy<DefaultRuleEvaluator>()
                                       .ServiceOverrides(ServiceOverride.ForKey("rules").Eq("default",
                                                                                            "div-by-three",
                                                                                            "div-by-five",
                                                                                            "div-by-three-and-five")),
                                   Component.For<IOutput>()
                                       .ImplementedBy<ConsoleOutput>(),
                                   Component.For<IController>()
                                       .ImplementedBy<Controller>(),
                                   Component.For<INumberSource>()
                                       .ImplementedBy<NumberSource>()
                    );

                IController controller = container.Resolve<IController>();
                controller.WriteList();

                Console.ReadLine();
            }
        }
    }
}