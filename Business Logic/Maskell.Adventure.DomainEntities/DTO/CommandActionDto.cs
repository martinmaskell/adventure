using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class CommandActionDto : ICommandAction
	{
		public AdventureCommandType CommandType { get; set; }
		public List<IAdventureElement> Parameters { get; set; }
		public List<DependencyDto> Dependencies { get; set; }
		public List<CommandAction> Actions { get; set; }
		public string SuccessResponseMessage { get; set; }
		public string FailResponseMessage { get; set; }
	}
}
