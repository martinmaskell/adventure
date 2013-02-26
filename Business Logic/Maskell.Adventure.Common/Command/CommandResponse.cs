using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Common.Command
{
	public class CommandResponse
	{
		public AdventureCommandType AdventureCommandType { get; set; }
		public List<IAdventureElement> ValidCommandParameters { get; set; }
		public List<string> InvalidCommandParameters { get; set; }
		public Dictionary<string, List<IAdventureElement>> DuplicateParameters { get; set; }
		public CommandResponseState State { get; set; }
		public CommandResponseReason ResponseReason { get; set; }
	}
}
