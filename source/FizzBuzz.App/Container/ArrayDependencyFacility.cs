using Castle.MicroKernel.Facilities;

namespace Crimson.Infrastructure.Container
{
	public class ArrayDependencyFacility : AbstractFacility
	{
		#region Overrides of AbstractFacility
		protected override void Init()
		{
			Kernel.Resolver.AddSubResolver(new ArraySubDependencyResolver(Kernel));
		}
		#endregion
	}
}