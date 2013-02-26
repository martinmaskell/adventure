using System;

namespace Maskell.Adventure.LocationDataService.Domain
{
	public class LocationDirectionRequest
	{
		public Guid SourceLocationId { get; set; }
		public Guid DirectionId { get; set; }
	}
}
