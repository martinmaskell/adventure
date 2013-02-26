using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.Module.Interfaces;

namespace Maskell.Adventure.Module.Modules
{
	public class LocationModule : IAdventureModule
	{
		public IGameDataManager GameDataManager { get; set; }

		public void Process(ModuleRequest moduleRequest)
		{
			ValidateModuleRequest(moduleRequest);

			switch (moduleRequest.CommandType)
			{
				case AdventureCommandType.Go:
					MoveLocation(moduleRequest.Parameters);
					break;
				case AdventureCommandType.Examine:
					break;
				case AdventureCommandType.Look:
					break;
				default:
					throw new ArgumentOutOfRangeException(string.Format("CommandType '{0}' is invalid", moduleRequest.CommandType));
			}
		}

		private void MoveLocation(List<IAdventureElement> parameters)
		{
			

			throw new NotImplementedException();
		}

		private static void ValidateModuleRequest(ModuleRequest moduleRequest)
		{
			if (moduleRequest == null)
				throw new ArgumentNullException("moduleRequest", "ModuleRequest is null");

			if (moduleRequest.Parameters == null)
				throw new ArgumentNullException("moduleRequest", "ModuleRequest Parameters is null");

			if (moduleRequest.Parameters.Any(adventureElement => adventureElement.GetType() != typeof (ILocation)))
			{
				throw new ArgumentOutOfRangeException("moduleRequest", "AdventureElement is not of type ILocation");
			}
		}

		public event EventHandler<ModuleResponseEventArgs> RequestProcessed;
	}
}
