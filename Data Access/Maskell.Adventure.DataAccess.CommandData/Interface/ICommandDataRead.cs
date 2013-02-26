using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DataAccess.CommandData.Interface
{
	public interface ICommandDataRead
	{
		List<CommandDto> GetValidCommandSyntax();
		CommandActionDto GetCommandAction(AdventureCommandType adventureCommandType, IEnumerable<Guid> parameterIdentities, Guid? gameId);
	}
}
