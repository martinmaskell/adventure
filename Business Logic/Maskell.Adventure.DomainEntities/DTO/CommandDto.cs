using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class CommandDto : ICommand
	{
		public int CommandID { get; set; }
		public AdventureCommandType CommandType { get; set; }
		public CommandParameterType[] Parameters { get; set; }


	}
}
