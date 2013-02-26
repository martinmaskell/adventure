using System;
using System.Collections.Generic;
using Maskell.Adventure.Command.Helpers;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Processors;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;

namespace Maskell.Adventure.Command.Managers
{
	public class CommandActionManager : ICommandActionManager
	{
		private readonly IGameDataManager _gameDataManager;
		private readonly ICommandActionHelper _commandActionHelper;
		private readonly IDependencyProcessor _dependencyProcessor;
		private readonly ICommandActionProcessor _commandActionProcessor;

		internal CommandActionManager(IGameDataManager gameDataManager, ICommandActionHelper commandActionHelper, IDependencyProcessor dependencyProcessor, ICommandActionProcessor commandActionProcessor)
		{
			_gameDataManager = gameDataManager;
			_commandActionHelper = commandActionHelper;
			_dependencyProcessor = dependencyProcessor;
			_commandActionProcessor = commandActionProcessor;
		}

		public CommandActionManager(IGameDataManager gameDataManager)
			: this(gameDataManager, new CommandActionHelper(), new DependencyProcessor(gameDataManager), new CommandActionProcessor(gameDataManager))
		{
		}

		public void ProcessCommand(AdventureCommandType commandType, List<IAdventureElement> parameters)
		{
			if (_gameDataManager == null)
				throw new NullReferenceException("GameDataManager is null");

			if (_commandActionHelper == null)
				throw new NullReferenceException("CommandActionHelper is null");

			if (!_commandActionHelper.IsValidCommand(commandType, parameters))
			{
				FinaliseFailedRequest(commandType, parameters);
				return;
			}

			var commandAction = _commandActionHelper.GetCommandAction(commandType, parameters, _gameDataManager.CurrentGameId);
			if (commandAction == null)
			{
				FinaliseFailedRequest(commandType, parameters);
				return;
			}

			// Process Dependancies
			var dependencyProcessorResponse = _dependencyProcessor.ProcessDependencies(commandAction.Dependencies);
			if (dependencyProcessorResponse.State == DependencyProcessorResponseState.Fail)
			{
				FinaliseFailedRequest(commandType, parameters,
				                      !string.IsNullOrEmpty(dependencyProcessorResponse.ResponseMessage)
				                      	? dependencyProcessorResponse.ResponseMessage
				                      	: commandAction.FailResponseMessage);
				return;
			}
			
			// Process Actions
         if (_commandActionProcessor.ProcessActions(commandAction, commandAction.Actions) == CommandActionProcessorResponse.Fail)
			{
				FinaliseFailedRequest(commandType, parameters, commandAction.FailResponseMessage);
				return;
			}

			FinaliseRequest(new CommandActionResponseEventArgs(new CommandActionResponse
			{
				AdventureCommandType = commandType,
				Parameters = parameters,
				State = CommandResponseState.Success,
				ResponseMessage = commandAction.SuccessResponseMessage
			}));

		}

		private void FinaliseFailedRequest(AdventureCommandType commandType, List<IAdventureElement> parameters, string responseMessage = null)
		{
			FinaliseRequest(new CommandActionResponseEventArgs(new CommandActionResponse
			                                                   	{
			                                                   		AdventureCommandType = commandType,
			                                                   		Parameters = parameters,
			                                                   		State = CommandResponseState.Fail,
																						ResponseMessage = responseMessage,
			                                                   	}));
		}

		private void FinaliseRequest(CommandActionResponseEventArgs e)
		{
			if (RequestProcessed == null)
				throw new NullReferenceException("No subscribers to RequestProcessed event");

			RequestProcessed(this, e);
		}

		public event EventHandler<CommandActionResponseEventArgs> RequestProcessed;
	}

}
