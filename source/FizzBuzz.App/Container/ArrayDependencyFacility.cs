using Castle.MicroKernel.Facilities;

namespace FizzBuzz.App.Container
{
    public class ArrayDependencyFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Resolver.AddSubResolver(new ArraySubDependencyResolver(Kernel));
        }
    }
}