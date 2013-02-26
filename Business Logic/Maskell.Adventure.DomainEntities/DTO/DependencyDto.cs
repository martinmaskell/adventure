using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maskell.Adventure.DomainEntities.DTO
{
	public class DependencyDto
	{
		public DependencyType DependencyType { get; set; }
		public Guid? ElementId { get; set; }
		public string ElementKey { get; set; }
		public string ElementValue { get; set; }
		public string FailResponseMessage { get; set; }
	}
}
