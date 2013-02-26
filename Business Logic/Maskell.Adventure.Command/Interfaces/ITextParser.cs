using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ITextParser<out T>
	{
		T Parse(string input);
	}
}
