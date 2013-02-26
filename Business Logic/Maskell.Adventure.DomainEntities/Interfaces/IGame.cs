using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface IGame
	{
		Guid GameId { get; set; }
		int OwnerId { get; set; }
		string Title { get; set; }
		string Description { get; set; }
		DateTime DateAdded { get; set; }
		LocationDto StartLocation { get; set; }
	}
}
