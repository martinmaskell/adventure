using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Module
{
	public class ModuleRequest
	{
		public AdventureCommandType CommandType { get; set; }
		public List<IAdventureElement> Parameters { get; set; }
	}
}
