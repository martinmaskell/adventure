using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.DataManager.CommandData;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Helpers
{
	public class CommandActionHelper : ICommandActionHelper
	{
		private readonly ICommandDataReader CommandDataReader;
		
		private List<CommandDto> _validCommandSyntax;
		private IEnumerable<CommandDto> ValidCommandSyntax
		{
			get { return _validCommandSyntax ?? (_validCommandSyntax = CommandDataReader.GetValidCommandSyntax()); }
		}

		internal CommandActionHelper(ICommandDataReader commandDataReader)
		{
			CommandDataReader = commandDataReader;
		}

		public CommandActionHelper()
		{
			CommandDataReader = new DataReader();
		}

		public bool IsValidCommand(AdventureCommandType commandType, List<IAdventureElement> parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException("parameters", "Parameters is null");

			var parameterArray = GetParameterTypes(parameters);

			return ValidCommandSyntax.Where(c => c.CommandType == commandType && c.Parameters.SequenceEqual(parameterArray)).Count() > 0;
		}

		internal static CommandParameterType[] GetParameterTypes(IEnumerable<IAdventureElement> adventureElements)
		{
			if (adventureElements == null)
				throw new ArgumentNullException("adventureElements", "AdventureElements is null");

			return adventureElements.Select(GetParameterType).ToArray();
		}

		internal static CommandParameterType GetParameterType(IAdventureElement adventureElement)
		{
			if (adventureElement == null)
				throw new ArgumentNullException("adventureElement", "AdventureElement is null");

			if (adventureElement is IItem)
				return CommandParameterType.Item;

			if (adventureElement is ILocation)
				return CommandParameterType.Location;

			if (adventureElement is IDirection)
				return CommandParameterType.Direction;

			throw new NotImplementedException();
		}

		public CommandActionDto GetCommandAction(AdventureCommandType commandType, List<IAdventureElement> parameters, Guid? gameId)
		{
			var commandAction = CommandDataReader.GetCommandAction(commandType, parameters.Select(p => p.Identity), gameId);
			if (commandAction != null)
				commandAction.Parameters = parameters;

			return commandAction;
		}
	}
}

