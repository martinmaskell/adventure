using System;
using System.Collections.Generic;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.CommandDataService.Interface
{
	public interface ICommandActionRequest
	{
		AdventureCommandType CommandType { get; set; }
		IEnumerable<Guid> ParameterIdentities { get; set; }
		Guid? GameId { get; set; }
	}
}