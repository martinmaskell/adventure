using System;
using System.Collections.Generic;
using System.ServiceModel;
using Maskell.Adventure.Contracts;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.LocationDataService.Domain;

namespace Maskell.Adventure.LocationDataService.Interface
{
	[ServiceContract(Namespace = "http://maskell.adventure.dataservice/2011/09", Name = "IAdventureLocationDataRead")]
	interface IAdventureLocationDataRead
	{
		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		LocationDto GetLocation(Guid locationId);

		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		LocationDto GetLocationByDirection(LocationDirectionRequest locationDirectionRequest);

		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		List<DirectionDto> GetAllDirections();
	}
}
