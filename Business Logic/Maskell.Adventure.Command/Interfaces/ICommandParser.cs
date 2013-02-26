using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandParser<out T> : ITextParser<T>
	{
		List<IAdventureElement> AdventureElements { get; set; }
	}
}
