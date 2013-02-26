using System;
using Maskell.Adventure.Common.Interfaces;

namespace Maskell.Adventure.Module.Interfaces
{
	public interface IAdventureModule
	{
		IGameDataManager GameDataManager { get; set; }
		void Process(ModuleRequest moduleRequest);
		event EventHandler<ModuleResponseEventArgs> RequestProcessed;
	}
}
