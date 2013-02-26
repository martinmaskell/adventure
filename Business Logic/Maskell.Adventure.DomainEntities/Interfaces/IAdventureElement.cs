using System;

namespace Maskell.Adventure.DomainEntities.Interfaces
{
	public interface IAdventureElement
	{
		Guid Identity { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string CommonName { get; set; }
	}
}