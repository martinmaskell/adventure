using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities;

namespace Maskell.Adventure.Command.Parsers
{
	public class CommandNoiseWordParser : Interfaces.ITextParser<CommandNoiseWordParserResponse>
	{
		private List<string> NoiseWords;

		private readonly Interfaces.ICommandNoiseWordHelper CommandNoiseWordHelper;
	
		public CommandNoiseWordParser()
		{
			CommandNoiseWordHelper = new Helpers.CommandNoiseWordHelper();
			GetNoiseWords();
		}

		internal CommandNoiseWordParser(Interfaces.ICommandNoiseWordHelper commandNoiseWordHelper)
		{
			CommandNoiseWordHelper = commandNoiseWordHelper;
			GetNoiseWords();
		}

		private void GetNoiseWords()
		{
			if (NoiseWords == null)
				NoiseWords = CommandNoiseWordHelper.GetNoiseWords();

			if (NoiseWords == null)
				throw new NullReferenceException("NoiseWords is null");
		}

		public CommandNoiseWordParserResponse Parse(string input)
		{
			if (string.IsNullOrEmpty(input))
				return new CommandNoiseWordParserResponse() { OriginalCommandText = input, ParsedCommandText = input, State = CommandResponseState.Success };

			if (NoiseWords.Count == 0)
				return new CommandNoiseWordParserResponse()
				       	{OriginalCommandText = input, ParsedCommandText = input, State = CommandResponseState.Fail };

			// Remove Non Alphanumeric and Whitespace characters
			var parsedInput = Regex.Replace(input, "[^A-Z0-9\\s]", "", RegexOptions.IgnoreCase);

			// Build RegEx Pattern
			var pattern = string.Join("|", NoiseWords.Select(w => "\\b" + w + "\\b").ToArray());

			// Remove Kill Words
			parsedInput = Regex.Replace(parsedInput, pattern, " ");

			// Remove Multiple Whitespace
			parsedInput = Regex.Replace(parsedInput, "\\s+", " ").Trim();

			return new CommandNoiseWordParserResponse
			       	{
			       		OriginalCommandText = input,
			       		ParsedCommandText = parsedInput,
			       		State = CommandResponseState.Success
			       	};

		}
	}
}
