using System;

namespace Maskell.Adventure.Command.Responses
{
	public class CommandActionResponseEventArgs : EventArgs
	{
		public CommandActionResponse CommandActionResponse { get; private set; }

		public CommandActionResponseEventArgs(CommandActionResponse commandActionResponse)
		{
			CommandActionResponse = commandActionResponse;
		}
	}
	
}
