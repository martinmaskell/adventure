using System;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;

namespace Maskell.Adventure.Command.Managers
{
	public class CommandResponseManager : ICommandResponseManager
	{
		private ICommandResponseHelper CommandResponseHelper { get; set; }

		public CommandResponseManager(IGameDataManager gameDataManager)
		{
			CommandResponseHelper = new Helpers.CommandResponseHelper(gameDataManager);
		}

		internal CommandResponseManager(ICommandResponseHelper commandResponseHelper)
		{
			CommandResponseHelper = commandResponseHelper;
		}

		public string GetCommandResponseMessage(CommandResponse commandResponse)
		{
			if (CommandResponseHelper == null)
				throw new NullReferenceException("CommandResponseHelper is null");

			if (commandResponse == null)
				throw new ArgumentNullException("commandResponse", "CommandReponse is null");

			if (commandResponse.State == CommandResponseState.Fail)
			{
				return GetFailedResponse(commandResponse);
			}

			if (commandResponse.ResponseReason != CommandResponseReason.None)
			{
				throw new ArgumentOutOfRangeException("commandResponse", "ResponseReason 'None' is not valid.");
			}

			return CommandResponseHelper.GetSuccessResponse(commandResponse.AdventureCommandType,
			                                                commandResponse.ValidCommandParameters);

		}

		internal string GetFailedResponse(CommandResponse commandResponse)
		{
			if (commandResponse.State != CommandResponseState.Fail)
			{
				throw new ArgumentOutOfRangeException("commandResponse", "CommandResponseState 'Success' is not valid.");
			}

			switch (commandResponse.ResponseReason)
			{
				case CommandResponseReason.InvalidCommand:
					return CommandResponseHelper.GetFailedResponseInvalidCommand(commandResponse);
				case CommandResponseReason.InvalidParameters:
				case CommandResponseReason.DuplicateParameters:
					if (commandResponse.AdventureCommandType == AdventureCommandType.Unknown)
						throw new ArgumentOutOfRangeException("commandResponse", "AdventureCommandType 'Unknown' is not valid");

					if (commandResponse.ResponseReason == CommandResponseReason.InvalidParameters)
					{
						return CommandResponseHelper.GetFailedResponseInvalidParameters(commandResponse.AdventureCommandType,
																																 commandResponse.InvalidCommandParameters);
					}

					return CommandResponseHelper.GetFailedDuplicateResponseDuplicateParameters(commandResponse.AdventureCommandType,
					                                                                           commandResponse.DuplicateParameters);
				default:
					throw new ArgumentOutOfRangeException("commandResponse", string.Format("ResponseReason '{0}' is not valid", commandResponse.ResponseReason));
			}
		}
	}
}
