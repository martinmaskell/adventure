using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.Module.Interfaces;

namespace Maskell.Adventure.Module.Helpers
{
	public class ModuleFactoryHelper : IModuleFactoryHelper
	{
		public string GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType adventureCommandType, List<IAdventureElement> adventureElements)
		{
			throw new NotImplementedException();
		}
	}
}
