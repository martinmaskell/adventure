using System;
using System.Collections.Generic;
using Maskell.Adventure.CommandDataService.Interface;
using Maskell.Adventure.DomainEntities;

namespace Maskell.Adventure.CommandDataService.Domain
{
	public class CommandActionRequest : ICommandActionRequest
	{
		public AdventureCommandType CommandType { get; set; }
		public IEnumerable<Guid> ParameterIdentities { get; set; }
		public Guid? GameId { get; set; }
	}
}
