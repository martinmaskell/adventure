using System;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
    public class ItemDto : IItem
    {
    	public Guid Identity { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    	public string CommonName { get; set; }
    }
}
