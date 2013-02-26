using Maskell.Adventure.DataAccess.LocationData.dbml;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataAccess.LocationData.Mappers
{
	public class DirectionMapper
	{
		public static DirectionDto Map(Direction direction)
		{
			if (direction == null)
				return null;

			return new DirectionDto
			       	{
							Name = direction.DirectionName,
							CommonName = direction.ShortName,
							Description = direction.DirectionName,
							Identity = direction.DirectionID
			       	};
		}
	}
}
