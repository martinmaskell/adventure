using System;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities;

namespace Maskell.Adventure.Command.Parsers
{
	public class CommandTypeParser : Interfaces.ITextParser<CommandTypeParserResponse>
	{
		public CommandTypeParserResponse Parse(string commandText)
		{
			if (string.IsNullOrEmpty(commandText))
				throw new ArgumentException("CommandText is null or empty");

			AdventureCommandType adventureCommandType;
// ReSharper disable AccessToStaticMemberViaDerivedType
			if (!AdventureCommandType.TryParse(ParseFirstWord(commandText), true, out adventureCommandType))
// ReSharper restore AccessToStaticMemberViaDerivedType
				return new CommandTypeParserResponse
			       		{
			       			CommandType = AdventureCommandType.Unknown,
			       			OriginalCommandText = commandText,
								ParsedCommandText = commandText,
								State = CommandResponseState.Fail
							};

			return new CommandTypeParserResponse
			{
				CommandType = adventureCommandType,
				OriginalCommandText = commandText,
				ParsedCommandText = RemoveFirstWord(commandText),
				State = CommandResponseState.Success
			};

		}

		internal string ParseFirstWord(string input)
		{
			if (string.IsNullOrEmpty(input))
				throw new ArgumentException("Input is null or empty");

			return input.Trim().IndexOf(" ") > -1 ? input.Trim().Substring(0, input.IndexOf(" ")).ToLower() : input.Trim().ToLower();
		}

		internal string RemoveFirstWord(string input)
		{
			return input.Trim().IndexOf(" ") < 0 ? string.Empty : input.Trim().Substring(input.Trim().IndexOf(" ") +1);
		}
	}
}
