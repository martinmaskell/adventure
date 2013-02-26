using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Common.Interfaces
{
	public interface ILocationDataManager
	{
		LocationDto GetLocationByDirection(LocationDto startingLocation, DirectionDto direction);
		List<DirectionDto> Directions { get; }
	}
}