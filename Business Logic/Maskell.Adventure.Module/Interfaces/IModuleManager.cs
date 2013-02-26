using System;

namespace Maskell.Adventure.Module.Interfaces
{
	public interface IModuleManager
	{
		void ProcessModule(ModuleRequest moduleRequest);

		event EventHandler<ModuleResponseEventArgs> ModuleProcessed;
	}
}
