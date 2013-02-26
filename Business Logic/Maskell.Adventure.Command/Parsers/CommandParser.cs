using System;
using System.Collections.Generic;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Parsers
{
	public class CommandParser : ICommandParser<CommandResponse>
	{
		internal ICommandParser<CommandParameterParserResponse> CommandParameterParser { get; set; }
		internal ITextParser<CommandTypeParserResponse> CommandTypeParser { get; set; }
		public List<IAdventureElement> AdventureElements { get; set; }
		internal ITextParser<CommandNoiseWordParserResponse> CommandNoiseWordParser { get; set; }

		public CommandParser()
		{
			CommandParameterParser = new CommandParameterParser();
			CommandTypeParser = new CommandTypeParser();
			CommandNoiseWordParser = new CommandNoiseWordParser();
		}

		private void ValidateDependancies()
		{
			if (CommandParameterParser == null)
				throw new NullReferenceException("CommandParameterParser is null");

			if (CommandTypeParser == null)
				throw new NullReferenceException("CommandTypeParser is null");

			if (CommandNoiseWordParser == null)
				throw new NullReferenceException("CommandNoiseWordParser is null");

			if (AdventureElements == null)
				throw new NullReferenceException("AdventureElements is null");

			if (AdventureElements.Count == 0)
				throw new Exception("AdventureElements cannot be empty");
		}

		internal CommandTypeParserResponse ParseCommandType(string input)
		{
			var commandTypeParserResponse = CommandTypeParser.Parse(input);

			if (commandTypeParserResponse == null)
				throw new NullReferenceException("CommandTypeParserResponse is null");

			return commandTypeParserResponse;
		}

		internal CommandNoiseWordParserResponse ParseNoiseWords(string input)
		{
			var commandNoiseWordParserResponse = CommandNoiseWordParser.Parse(input);

			if (commandNoiseWordParserResponse == null)
				throw new NullReferenceException("CommandNoiseWordParserResponse is null");

			return commandNoiseWordParserResponse;
		}

		internal CommandParameterParserResponse ParseParameters(string input)
		{
			CommandParameterParser.AdventureElements = AdventureElements;
			var commandParameterParserResponse = CommandParameterParser.Parse(input);
			if (commandParameterParserResponse == null)
				throw new NullReferenceException("CommandParameterParserResponse is null");

			return commandParameterParserResponse;
		}

		public CommandResponse Parse(string input)
		{
			ValidateDependancies();

			// Parse AdventureCommandType
			var commandTypeParserResponse = ParseCommandType(input);
			if (commandTypeParserResponse.State == CommandResponseState.Fail)
				return FailedResponse(commandTypeParserResponse.CommandType, CommandResponseReason.InvalidCommand);

			// Remove Noise Words
			var commandNoiseWordParserResponse = ParseNoiseWords(commandTypeParserResponse.ParsedCommandText);
			if (commandNoiseWordParserResponse.State == CommandResponseState.Fail)
				return FailedResponse(commandTypeParserResponse.CommandType, CommandResponseReason.InvalidParameters);

			// Parse Parameters
			var commandParameterParserReponse = ParseParameters(commandNoiseWordParserResponse.ParsedCommandText);
			if (commandParameterParserReponse.State == CommandParameterParserResponseState.Fail)
				return FailedResponse(commandTypeParserResponse.CommandType, CommandResponseReason.InvalidParameters,
				                      invalidParameters: commandParameterParserReponse.InvalidParameters);

			if (commandParameterParserReponse.State == CommandParameterParserResponseState.FailDuplicate)
				return FailedResponse(commandTypeParserResponse.CommandType, CommandResponseReason.DuplicateParameters,
				                      invalidParameters: commandParameterParserReponse.InvalidParameters,
				                      duplicateParameters: commandParameterParserReponse.DuplicateParameters);

			return SuccessResponse(commandTypeParserResponse, commandParameterParserReponse);
		}

		private static CommandResponse SuccessResponse(CommandTypeParserResponse commandTypeParserResponse, CommandParameterParserResponse commandParameterParserReponse)
		{
			return new CommandResponse
				{
					AdventureCommandType = commandTypeParserResponse.CommandType,
					ValidCommandParameters = commandParameterParserReponse.ValidParameters,
					ResponseReason = CommandResponseReason.None,
					State = CommandResponseState.Success
				};
		}

		private static CommandResponse FailedResponse(AdventureCommandType commandType, 
			CommandResponseReason reason,
			List<string> invalidParameters = null,
			Dictionary<string, List<IAdventureElement>> duplicateParameters = null,
			List<IAdventureElement> validParameters = null
			)
		{
			return new CommandResponse
				{
					AdventureCommandType = commandType,
					State = CommandResponseState.Fail,
					ResponseReason = reason,
					InvalidCommandParameters = invalidParameters ?? new List<string>(),
					DuplicateParameters = duplicateParameters ?? new Dictionary<string, List<IAdventureElement>>(),
					ValidCommandParameters = validParameters ?? new List<IAdventureElement>()
				};
		}
	}
}
