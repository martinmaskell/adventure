using Maskell.Adventure.DomainEntities;

namespace Maskell.Adventure.Command.Responses
{
	public class CommandTypeParserResponse
	{
		public AdventureCommandType CommandType { get; internal set; }
		public string OriginalCommandText { get; internal set; }
		public string ParsedCommandText { get; internal set; }
		public CommandResponseState State { get; internal set; }
	}
}
