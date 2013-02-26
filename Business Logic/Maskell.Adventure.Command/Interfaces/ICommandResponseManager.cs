
using Maskell.Adventure.Common.Command;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandResponseManager
	{
		string GetCommandResponseMessage(CommandResponse commandResponse);
	}
}
