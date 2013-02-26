using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maskell.Adventure.Command
{
	public class CommandResponseEventArgs : EventArgs
	{
		public string ResponseText { get; private set; }
		public CommandResponseEventArgs(string responseText)
		{
			ResponseText = responseText;
		}
	}
}
