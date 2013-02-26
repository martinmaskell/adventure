using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Module.Interfaces
{
	public interface IModuleFactoryHelper
	{
		string GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType adventureCommandType,
		                                                   List<IAdventureElement> adventureElements);
	}
}
