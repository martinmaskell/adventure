using System;
using Maskell.Adventure.Module.Helpers;
using Maskell.Adventure.Module.Interfaces;

namespace Maskell.Adventure.Module
{
	public class ModuleFactory : IModuleFactory
	{
		private IModuleFactoryHelper ModuleFactoryHelper { get; set; }

		public ModuleFactory()
		{
			ModuleFactoryHelper = new ModuleFactoryHelper();
		}

		internal ModuleFactory(IModuleFactoryHelper moduleFactoryHelper)
		{
			ModuleFactoryHelper = moduleFactoryHelper;
		}

		public IAdventureModule GetModule(ModuleRequest moduleRequest)
		{
			if (ModuleFactoryHelper == null)
				throw new NullReferenceException("ModuleFactoryHelper is null");

			if (moduleRequest == null)
				throw new ArgumentNullException("moduleRequest", "ModuleRequest is null");

			var typeName = ModuleFactoryHelper.GetModuleTypeNameByCommandTypeAndParameters(moduleRequest.CommandType, moduleRequest.Parameters);

			if (string.IsNullOrEmpty(typeName))
				return null;

			var type = Type.GetType(typeName);
			if (type == null)
				return null;

			return Activator.CreateInstance(type) as IAdventureModule;
		}
	}
}
