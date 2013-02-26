using System;
using System.Collections.Generic;
using Maskell.Adventure.DataAccess.LocationData;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.LocationDataService.Domain;
using Maskell.Adventure.LocationDataService.Interface;

namespace Maskell.Adventure.LocationDataService
{
	public class LocationData : IAdventureLocationDataRead
	{
		public LocationDto GetLocation(Guid locationId)
		{
			var locationDataService = new LocationDataServiceRead();
			return locationDataService.GetLocation(locationId);
		}

		public LocationDto GetLocationByDirection(LocationDirectionRequest locationDirectionRequest)
		{
			var locationDataService = new LocationDataServiceRead();
			return locationDataService.GetLocationByDirection(locationDirectionRequest.SourceLocationId, locationDirectionRequest.DirectionId);
		}

		public List<DirectionDto> GetAllDirections()
		{
			var locationDataService = new LocationDataServiceRead();
			return locationDataService.GetAllDirections();
		}
	}
}
