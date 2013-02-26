using System.Collections.Generic;
using System.ServiceModel;
using Maskell.Adventure.CommandDataService.Domain;
using Maskell.Adventure.Contracts;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.CommandDataService.Interface
{
	[ServiceContract(Namespace = "http://maskell.adventure.dataservice/2011/09", Name = "IAdventureCommandDataRead")]
	interface IAdventureCommandDataRead
	{
		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		List<CommandDto> GetValidCommandSyntax();

		[OperationContract]
		[FaultContract(typeof(AdventureFaultContract))]
		CommandActionDto GetCommandAction(CommandActionRequest commandActionRequest);
	}
}
