using System;
using System.ServiceModel;
using Maskell.Adventure.Contracts;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.GameDataService.Interface
{
	[ServiceContract(Namespace = "http://maskell.adventure.dataservice/2011/09", Name = "IAdventureGameDataRead")]
	interface IAdventureGameDataRead 
	{
		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		GameDto GetGame(Guid gameId);
	}
}
