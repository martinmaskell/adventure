using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface IDependencyTypeProcessor
	{
		bool ProcessDependency(DependencyDto dependency);
	}
}