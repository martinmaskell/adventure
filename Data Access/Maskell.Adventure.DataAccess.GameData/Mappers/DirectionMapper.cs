using Maskell.Adventure.DataAccess.GameData.dbml;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DataAccess.GameData.Mappers
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
