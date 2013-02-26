using System;
using System.Collections.Generic;
using System.Linq;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Command.Processors
{
	public class DependencyProcessor : IDependencyProcessor
	{
		// ReSharper disable NotAccessedField.Local
		private IGameDataManager _gameDataManager;
		private readonly IDependencyTypeProcessor _dependencyTypeProcessor;
		// ReSharper restore NotAccessedField.Local

		internal DependencyProcessor(IGameDataManager gameDataManager, IDependencyTypeProcessor dependencyTypeProcessor)
		{
			_gameDataManager = gameDataManager;
			_dependencyTypeProcessor = dependencyTypeProcessor;
		}

		public DependencyProcessor(IGameDataManager gameDataManager) : this(gameDataManager, new DependencyTypeProcessor(gameDataManager))
		{
		}

		public DependencyProcessorResponse ProcessDependencies(List<DependencyDto> dependencies)
		{
			if (dependencies == null)
				throw new ArgumentNullException("dependencies", "Dependencies is null");

			if (dependencies.Count == 0)
				return new DependencyProcessorResponse {State = DependencyProcessorResponseState.NothingToProcess};


			foreach (var dependencyDto in dependencies.Where(dependencyDto => !_dependencyTypeProcessor.ProcessDependency(dependencyDto)))
			{
				return new DependencyProcessorResponse
				       	{ResponseMessage = dependencyDto.FailResponseMessage, State = DependencyProcessorResponseState.Fail};
			}

			return new DependencyProcessorResponse {State = DependencyProcessorResponseState.Success};
		}

	}


}