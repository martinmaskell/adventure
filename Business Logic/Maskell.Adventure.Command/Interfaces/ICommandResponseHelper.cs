using System.Collections.Generic;
using Maskell.Adventure.Common.Command;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Interfaces
{
	public interface ICommandResponseHelper
	{
		string GetFailedResponseInvalidCommand(CommandResponse commandResponse);
		string GetFailedResponseInvalidParameters(AdventureCommandType adventureCommandType, List<string> parameters);
		string GetFailedDuplicateResponseDuplicateParameters(AdventureCommandType adventureCommandType,
		                                             Dictionary<string, List<IAdventureElement>> duplicateParameters);
		string GetSuccessResponse(AdventureCommandType adventureCommandType, List<IAdventureElement> parameters);
	}
}
