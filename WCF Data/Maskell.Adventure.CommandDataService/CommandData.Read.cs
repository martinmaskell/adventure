using System.Collections.Generic;
using Maskell.Adventure.CommandDataService.Domain;
using Maskell.Adventure.CommandDataService.Interface;
using Maskell.Adventure.DataAccess.CommandData;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.CommandDataService
{
	public partial class CommandData : IAdventureCommandDataRead
	{
		public List<CommandDto> GetValidCommandSyntax()
		{
			var commandDataService = new CommandDataServiceRead();
			return commandDataService.GetValidCommandSyntax();
		}

		public CommandActionDto GetCommandAction(CommandActionRequest commandActionRequest)
		{
			var commandDataService = new CommandDataServiceRead();
			return commandDataService.GetCommandAction(commandActionRequest.CommandType, commandActionRequest.ParameterIdentities, commandActionRequest.GameId);
		}
	}
}
