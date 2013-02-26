using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandActionProcessor
	{
		CommandActionProcessorResponse ProcessActions(CommandActionDto commandActionDto, List<CommandAction> actions);
	}
}