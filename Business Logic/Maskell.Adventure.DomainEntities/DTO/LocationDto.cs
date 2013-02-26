using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class LocationDto : ILocation
	{
		public List<DirectionDto> Directions { get; set; }
		public Guid Identity { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CommonName { get; set; }
	}
}