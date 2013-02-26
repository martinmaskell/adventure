using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.DataAccess.CommandData.Interface;
using Maskell.Adventure.DataAccess.CommandData.dbml;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.DataAccess.Common;
using CommandAction = Maskell.Adventure.DomainEntities.CommandAction;
using CommandParameterType = Maskell.Adventure.DomainEntities.CommandParameterType;
using LinqCommandParameterType = Maskell.Adventure.DataAccess.CommandData.dbml.CommandParameterType;

namespace Maskell.Adventure.DataAccess.CommandData
{
	public class CommandDataServiceRead : ICommandDataRead
	{
		public List<CommandDto> GetValidCommandSyntax()
		{
			using (var ctx = DataContext<CommandDataDataContext>.TrackedContext)
			{
				return (from c in ctx.Commands
				             select
				             	new CommandDto
				             		{
				             			CommandID = c.CommandID,
				             			CommandType = (AdventureCommandType) c.CommandTypeID,

											Parameters = CreateParameterArray(c.CommandParameterTypes)
				             		}).ToList();

			}
		}

		private static CommandParameterType[] CreateParameterArray(IEnumerable<LinqCommandParameterType> commandParameterTypes)
		{
			return
				commandParameterTypes.Select(commandParameterType => (CommandParameterType) commandParameterType.ParameterTypeID).
					ToArray();
		}


		public CommandActionDto GetCommandAction(AdventureCommandType adventureCommandType, IEnumerable<Guid> parameterIdentities, Guid? gameId)
		{
			if (parameterIdentities == null)
				return null;

			var parameterIdentityArray = parameterIdentities.ToArray();

			using (var ctx = DataContext<CommandDataDataContext>.TrackedContext)
			{
				var result = ctx.GetCommandAction((int) adventureCommandType,
															 parameterIdentityArray.Length > 0 ? parameterIdentityArray[0] : (Guid?)null,
															 parameterIdentityArray.Length > 1 ? parameterIdentityArray[1] : (Guid?)null,
															 parameterIdentityArray.Length > 2 ? parameterIdentityArray[2] : (Guid?)null,
															 parameterIdentityArray.Length > 3 ? parameterIdentityArray[3] : (Guid?)null,
															 gameId).FirstOrDefault();

				if (result == null)
					return null;

				return new CommandActionDto
				       	{
				       		CommandType = adventureCommandType,
				       		Actions = BuildCommandActions(result.CommandActionActions),
								Dependencies = BuildCommandDependencies(result.CommandActionDependencies),
				       		SuccessResponseMessage = result.SuccessReponseMessage,
								FailResponseMessage = result.FailResponseMessage,
				       	};
			}
		}

		internal List<DependencyDto> BuildCommandDependencies(IEnumerable<CommandActionDependency> dependencies)
		{
			return
				dependencies.OrderBy(d => d.DependencyOrder).Select(
					d =>
					new DependencyDto
						{
							DependencyType = (DependencyType) d.Dependency.DependencyTypeID,
							ElementId = d.Dependency.DependencyElementID,
							ElementKey = d.Dependency.DependencyElementKey,
							ElementValue = d.Dependency.DependencyElementValue,
							FailResponseMessage = d.FailResponseMessage
						}).ToList();
		}

		internal List<CommandAction> BuildCommandActions(IEnumerable<CommandActionAction> actions)
		{
			return actions.OrderBy(a => a.ActionOrder).Select(a => (CommandAction) a.ActionID).ToList();
		}


	}
}
