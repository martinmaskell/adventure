using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class EnvironmentItemDto : IEnvironmentItem
	{
		public Guid Identity { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CommonName { get; set; }
	}
}
