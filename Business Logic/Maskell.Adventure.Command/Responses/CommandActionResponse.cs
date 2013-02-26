using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Responses
{
	public class CommandActionResponse
	{
		public AdventureCommandType AdventureCommandType { get; set; }
		public List<IAdventureElement> Parameters { get; set; }
		public CommandResponseState State { get; set; }
		public string ResponseMessage { get; set; }
	}
}
