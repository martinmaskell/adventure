using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface ILocation : IAdventureElement
	{
		List<DirectionDto> Directions { get; set; }
	}
}
