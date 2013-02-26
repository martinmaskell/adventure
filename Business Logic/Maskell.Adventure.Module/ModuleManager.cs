using System;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.Module.Interfaces;

namespace Maskell.Adventure.Module
{
	public class ModuleManager : IModuleManager
	{
		public event EventHandler<ModuleResponseEventArgs> ModuleProcessed;
		private IGameDataManager GameDataManager { get; set; }
		private IModuleFactory ModuleFactory { get; set; }

		public ModuleManager(IGameDataManager gameDataManager)
		{
			GameDataManager = gameDataManager;
			ModuleFactory = new ModuleFactory();
		}

		internal ModuleManager(IGameDataManager gameDataManager, IModuleFactory moduleFactory)
		{
			GameDataManager = gameDataManager;
			ModuleFactory = moduleFactory;
		}

		public void ProcessModule(ModuleRequest moduleRequest)
		{
			var module = ModuleFactory.GetModule(moduleRequest);

			if (module == null)
			{
				FinaliseRequest(new ModuleResponseEventArgs(new ModuleResponse
				                                            	{
				                                            		AdventureCommandType = moduleRequest.CommandType,
				                                            		Parameters = moduleRequest.Parameters,
				                                            		State = CommandResponseState.Fail
				                                            	}
				                	));
				return;
			}

			module.GameDataManager = GameDataManager;
			module.RequestProcessed += module_RequestProcessed;
			module.Process(moduleRequest);
		}

		void module_RequestProcessed(object sender, ModuleResponseEventArgs e)
		{
			FinaliseRequest(e);
		}

		private void FinaliseRequest(ModuleResponseEventArgs e)
		{
			if (ModuleProcessed == null)
				throw new NullReferenceException("No subscribers to ModuleProcessed event");

			ModuleProcessed(this, e);
		}
	}
}
