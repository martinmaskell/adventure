using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Responses
{
	public class CommandParameterParserResponse
	{
		public List<IAdventureElement> ValidParameters { get; internal set; }
		public List<string> InvalidParameters { get; internal set; }
		public Dictionary<string, List<IAdventureElement>> DuplicateParameters { get; internal set; }
		public CommandParameterParserResponseState State { get; internal set; }
	}
}
