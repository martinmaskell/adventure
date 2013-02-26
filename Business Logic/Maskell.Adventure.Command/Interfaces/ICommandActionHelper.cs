using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandActionHelper
	{
		bool IsValidCommand(AdventureCommandType commandType, List<IAdventureElement> parameters);
		CommandActionDto GetCommandAction(AdventureCommandType commandType, List<IAdventureElement> parameters, Guid? gameId);
	}
}
