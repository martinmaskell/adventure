using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataManager.Interface
{
	public interface ICommandDataReader
	{
		List<CommandDto> GetValidCommandSyntax();

		CommandActionDto GetCommandAction(AdventureCommandType commandType, IEnumerable<Guid> parameters,
		                                  Guid? gameId);
	}
}
