using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.DataAccess.LocationData.Interface;
using Maskell.Adventure.DataAccess.LocationData.dbml;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.DataAccess.Common;

namespace Maskell.Adventure.DataAccess.LocationData
{
	public class LocationDataServiceRead : ILocationDataRead
	{
		public LocationDto GetLocation(Guid locationId)
		{
			using (var ctx = DataContext<LocationDataDataContext>.TrackedContext)
			{
				var result = (from l in ctx.Locations
				             where l.LocationID == locationId
				             select l).FirstOrDefault();

				return Mappers.LocationMapper.Map(result);
			}
		}

		public LocationDto GetLocationByDirection(Guid locationId, Guid directionId)
		{
			using (var ctx = DataContext<LocationDataDataContext>.TrackedContext)
			{
				var result = (from l in ctx.LocationDirections
								  where l.SourceLocationID == locationId
								  && l.DirectionID == directionId
								  select l).FirstOrDefault();

				return result == null ? null : Mappers.LocationMapper.Map(result.TargetLocation);
			}
		}

		public List<DirectionDto> GetAllDirections()
		{
			using (var ctx = DataContext<LocationDataDataContext>.TrackedContext)
			{
				return ctx.Directions.Select(direction => Mappers.DirectionMapper.Map(direction)).ToList();
			}
		}
	}
}
