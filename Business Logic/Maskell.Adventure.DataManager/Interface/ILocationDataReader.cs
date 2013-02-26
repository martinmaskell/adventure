using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataManager.Interface
{
	public interface ILocationDataReader
	{
		LocationDto GetLocation(Guid locationId);
		LocationDto GetLocationByDirection(LocationDto sourceLocation, DirectionDto direction);
		List<DirectionDto> GetAllDirections();
	}
}