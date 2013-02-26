using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Common.Game
{
	public class LocationDirectionRelationship
	{
		public LocationDto Source { get; set; }
		public DirectionDto Direction { get; set; }
		public LocationDto Target { get; set; }

		public LocationDirectionRelationship(LocationDto source, DirectionDto direction, LocationDto target)
		{
			Source = source;
			Direction = direction;
			Target = target;
		}
	}

	

}
