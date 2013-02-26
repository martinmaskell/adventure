using System.Collections.Generic;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface IDependencyProcessor
	{
		DependencyProcessorResponse ProcessDependencies(List<DependencyDto> dependencies);
	}
}