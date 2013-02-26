using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maskell.Adventure.Module.Interfaces
{
	public interface IModuleFactory
	{
		IAdventureModule GetModule(ModuleRequest moduleRequest);
	}
}
