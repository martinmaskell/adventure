using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maskell.Adventure.Command.Helpers
{
	public class CommandNoiseWordHelper : Interfaces.ICommandNoiseWordHelper
	{
		public List<string> GetNoiseWords()
		{
			return new List<string> { "the", "with", "of", "to", "from" };
		}
	}
}
