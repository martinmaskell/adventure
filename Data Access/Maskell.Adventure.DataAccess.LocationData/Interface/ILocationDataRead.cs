using System;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataAccess.LocationData.Interface
{
	public interface ILocationDataRead
	{
		LocationDto GetLocation(Guid locationId);
		LocationDto GetLocationByDirection(Guid locationId, Guid directionId);
	}
}
