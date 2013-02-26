using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandActionManager
	{
		void ProcessCommand(AdventureCommandType commandType, List<IAdventureElement> parameters);

		event EventHandler<CommandActionResponseEventArgs> RequestProcessed;
	}
}
