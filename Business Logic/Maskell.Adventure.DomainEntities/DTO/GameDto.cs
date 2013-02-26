using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class GameDto : IGame
	{
		public Guid GameId { get; set; }
		public int OwnerId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DateAdded { get; set; }
		public LocationDto StartLocation { get; set; }
	}
}
