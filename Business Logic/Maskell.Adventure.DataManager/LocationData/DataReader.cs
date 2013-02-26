using System;
using System.Collections.Generic;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.LocationDataService.Domain;

namespace Maskell.Adventure.DataManager.LocationData
{
	public class DataReader : ILocationDataReader
	{
		private readonly LocationDataService.LocationData _locationData;

		public DataReader()
		{
			 _locationData = new LocationDataService.LocationData();
		}

		public LocationDto GetLocation(Guid locationId)
		{
			//using (var client = new AdventureLocationDataReadClient())
			//{
			//    return client.GetLocation(locationId);
			//}
			return _locationData.GetLocation(locationId);
		}

		public LocationDto GetLocationByDirection(LocationDto sourceLocation, DirectionDto direction)
		{
			//using (var client = new AdventureLocationDataReadClient())
			//{
			//    return client.GetLocationByDirection(new LocationDirectionRequest { SourceLocationId = sourceLocation.Identity, DirectionId = direction.Identity});
			//}
			return _locationData.GetLocationByDirection(new LocationDirectionRequest { SourceLocationId = sourceLocation.Identity, DirectionId = direction.Identity });
		}

		public List<DirectionDto> GetAllDirections()
		{
			//using (var client = new AdventureLocationDataReadClient())
			//{
			//    return client.GetAllDirections();
			//}
			return _locationData.GetAllDirections();
		}
	}
}
