using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Module
{
	public class ModuleResponse
	{
		public AdventureCommandType AdventureCommandType { get; set; }
		public List<IAdventureElement> Parameters { get; set; }
		public CommandResponseState State { get; set; }
	}
}
