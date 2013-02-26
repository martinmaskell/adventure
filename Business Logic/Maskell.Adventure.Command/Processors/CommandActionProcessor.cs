using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Processors
{
	public class CommandActionProcessor : ICommandActionProcessor
	{
		private readonly IGameDataManager _gameDataManager;

		public CommandActionProcessor(IGameDataManager gameDataManager)
		{
			_gameDataManager = gameDataManager;
		}

		public CommandActionProcessorResponse ProcessActions(CommandActionDto commandActionDto, List<CommandAction> actions)
		{
			if (actions == null)
				throw new ArgumentNullException("actions", "Actions is null");

			if (actions.Count == 0)
				return CommandActionProcessorResponse.NothingToProcess;

			foreach (
				var commandActionProcessMethod in
					commandActionDto.Actions.Select(
						commandAction => GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(
							m =>
								{
									var commandActionAttribute =
										(CommandActionAttribute) m.GetCustomAttributes(typeof (CommandActionAttribute), false).FirstOrDefault();
									return commandActionAttribute != null && (commandActionAttribute.CommandAction == commandAction);
								}).FirstOrDefault()).Where(commandActionProcessMethod => commandActionProcessMethod != null))
			{
				commandActionProcessMethod.Invoke(this, new object[] {commandActionDto});
			}

			return CommandActionProcessorResponse.Success;
		}

		[CommandActionAttribute(CommandAction.ChangeCurrentLocationByDirection)]
		internal void ProcessCommandActionChangeCurrentLocation(CommandActionDto commandActionDto)
		{
			if (commandActionDto == null)
				throw new ArgumentNullException("commandActionDto", "CommandActionDto is null");

			if (commandActionDto.Parameters == null)
				throw new ArgumentException("CommandActionDto.Parameters is null", "commandActionDto");

			if (commandActionDto.Parameters.Count == 0)
				throw new ArgumentException("Parameter Count is zero", "commandActionDto");

			if ((commandActionDto.Parameters[0] as IDirection) == null)
				throw new ArgumentException("First Parameter is not a Direction", "commandActionDto");

			var direction = commandActionDto.Parameters[0] as IDirection;
// ReSharper disable PossibleNullReferenceException
			_gameDataManager.ChangeDirection(new DirectionDto
			                                 	{
			                                 		CommonName = direction.CommonName,
			                                 		Description = direction.Description,
			                                 		Identity = direction.Identity,
			                                 		Name = direction.Name
			                                 	});
// ReSharper restore PossibleNullReferenceException

		}
	}


	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	internal sealed class CommandActionAttribute : Attribute
	{
		private readonly CommandAction _commandAction;

		public CommandActionAttribute(CommandAction commandAction)
		{
			_commandAction = commandAction;
		}

		public CommandAction CommandAction
		{
			get { return _commandAction; }
		}

	}
}