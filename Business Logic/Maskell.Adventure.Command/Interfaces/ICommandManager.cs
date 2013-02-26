using System;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandManager
	{
		void ProcessCommand(string commandText);

		event EventHandler<CommandResponseEventArgs> RequestProcessed;
	}
}
