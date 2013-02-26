using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.CommandDataService.Domain;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataManager.CommandData
{
	public class DataReader : ICommandDataReader
	{
		private readonly CommandDataService.CommandData _commandData;

		public DataReader()
		{
			_commandData = new CommandDataService.CommandData();
		}

		public List<CommandDto> GetValidCommandSyntax()
		{
			//using (var client = new AdventureCommandDataReadClient())
			//{
			//    return client.GetValidCommandSyntax();
			//}
			return _commandData.GetValidCommandSyntax();
		}

		public CommandActionDto GetCommandAction(AdventureCommandType commandType, IEnumerable<Guid> parameters, Guid? gameId)
		{
			//using (var client = new AdventureCommandDataReadClient())
			//{
			//    return client.GetCommandAction(new CommandActionRequest { CommandType = commandType, ParameterIdentities = parameters.ToList(), GameId = gameId });
			//}
			return _commandData.GetCommandAction(new CommandActionRequest { CommandType = commandType, ParameterIdentities = parameters.ToList(), GameId = gameId });
		}
	}
}
