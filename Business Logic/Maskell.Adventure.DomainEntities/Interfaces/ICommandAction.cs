using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface ICommandAction
	{
		AdventureCommandType CommandType { get; set; }
		List<IAdventureElement> Parameters { get; set; }
		List<DependencyDto> Dependencies { get; set; }
		List<CommandAction> Actions { get; set; } 

		string SuccessResponseMessage { get; set; }
		string FailResponseMessage { get; set; }
	}
}
