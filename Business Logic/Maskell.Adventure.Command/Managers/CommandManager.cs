using System;
using System.Collections.Generic;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Managers
{
	public class CommandManager : ICommandManager
	{
		internal IGameDataManager GameDataManager { get; set; }
		internal ICommandParser<CommandResponse> CommandParser { get; set; }
		internal ICommandResponseManager CommandResponseManager { get; set; }
		internal ICommandActionManager CommandActionManager { get; set; }

		public event EventHandler<CommandResponseEventArgs> RequestProcessed;

		internal CommandManager()
		{
		}

		public CommandManager(IGameDataManager gameDataManager)
		{
			GameDataManager = gameDataManager;
			CommandParser = new CommandParser();
			CommandResponseManager = new CommandResponseManager(GameDataManager);
			CommandActionManager = new CommandActionManager(GameDataManager);

			CommandActionManager.RequestProcessed += CommandActionManager_RequestProcessed;
		}

		private static List<IAdventureElement> BuildAdventureElements(IGameDataManager gameDataManager)
		{
			if (gameDataManager == null)
				return null;

			var adventureElements = new List<IAdventureElement>();

			if (gameDataManager.Inventory != null)
				adventureElements.AddRange(gameDataManager.Inventory);

			if (gameDataManager.CurrentLocation != null)
			{
				adventureElements.Add(gameDataManager.CurrentLocation);
				//adventureElements.AddRange(gameDataManager.CurrentLocation.Directions);
				adventureElements.AddRange(gameDataManager.Directions);
			}

			return adventureElements;
		}

		internal CommandResponse ParseCommand(string input)
		{
			CommandParser.AdventureElements = BuildAdventureElements(GameDataManager);
			var response = CommandParser.Parse(input);
			if (response == null)
				throw new NullReferenceException("CommandResponse is null");

			return response;
		}

		public void ProcessCommand(string commandText)
		{
			if (GameDataManager == null)
				throw new NullReferenceException("GameDataManager is null");

			if (CommandParser == null)
				throw new NullReferenceException("CommandParser is null");

			if (RequestProcessed == null)
				throw new NullReferenceException("No subscribers to RequestProcessed event");

			if (CommandResponseManager == null)
				throw new NullReferenceException("CommandResponseManager is null");

			if (string.IsNullOrEmpty(commandText))
				throw new ArgumentException("CommandText cannot be null or empty");

			var commandResponse = ParseCommand(commandText);

			if (commandResponse.State == CommandResponseState.Success)
			{
				CommandActionManager.ProcessCommand(commandResponse.AdventureCommandType, commandResponse.ValidCommandParameters);
				return;
			}

			FinaliseRequest(commandResponse);
		}

		private void CommandActionManager_RequestProcessed(object sender, CommandActionResponseEventArgs e)
		{
			if (string.IsNullOrEmpty(e.CommandActionResponse.ResponseMessage))
			{
				FinaliseRequest(new CommandResponse
										{
											AdventureCommandType =
												e.CommandActionResponse.AdventureCommandType,
											ValidCommandParameters =
												e.CommandActionResponse.Parameters,
											ResponseReason = e.CommandActionResponse.State == CommandResponseState.Fail ? CommandResponseReason.InvalidCommand : CommandResponseReason.None,
											State = e.CommandActionResponse.State
										});
			}
			else
			{
				FinaliseRequest(e.CommandActionResponse.ResponseMessage);
			}
		}

		private void FinaliseRequest(string responseMessage)
		{
			RequestProcessed(this, new CommandResponseEventArgs(responseMessage));
		}

		private void FinaliseRequest(CommandResponse commandResponse)
		{
			var responseMessage = CommandResponseManager.GetCommandResponseMessage(commandResponse);
			FinaliseRequest(responseMessage);
		}

	}
}
