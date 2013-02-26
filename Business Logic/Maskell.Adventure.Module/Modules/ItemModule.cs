using System;
using Maskell.Adventure.Module.Interfaces;

namespace Maskell.Adventure.Module.Modules
{
	public class ItemModule : IAdventureModule
	{
		public Common.Interfaces.IGameDataManager GameDataManager
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Process(ModuleRequest moduleRequest)
		{
			throw new NotImplementedException();
		}

		public event EventHandler<ModuleResponseEventArgs> RequestProcessed;
	}
}
