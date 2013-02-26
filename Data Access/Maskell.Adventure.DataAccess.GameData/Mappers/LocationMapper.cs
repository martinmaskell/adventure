using System.Linq;
using Maskell.Adventure.DataAccess.GameData.dbml;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataAccess.GameData.Mappers
{
	public class LocationMapper
	{
		public static LocationDto Map(Location locationDao)
		{
			if (locationDao == null)
				return null;

			return new LocationDto
			       	{
			       		CommonName = locationDao.LocationName,
			       		Description = locationDao.LocationDescription,
			       		Identity = locationDao.LocationID,
			       		Name = locationDao.LocationName,
							Directions = locationDao.LocationDirections.Select(ld => DirectionMapper.Map(ld.Direction)).ToList()
			       	};
		}
	}
}
