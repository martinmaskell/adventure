using System;
using System.Collections.Generic;
using Maskell.Adventure.Command.Processors;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class DependencyProcessorTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ProcessDependency_NullDependency_ThrowArgumentNullException()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();

			var dependencyTypeProcessor = new DependencyTypeProcessor(gameDataManager);

			dependencyTypeProcessor.ProcessDependency(null);
		}

		[Test]
		public void ProcessDependency_DirectionIsAvailableDependency_ReturnTrue()
		{
			var mocks = new MockRepository();
			var gameDataManager = mocks.Stub<IGameDataManager>();
			var dependencyTypeProcessor = new DependencyTypeProcessor(gameDataManager);

			var direction = new DirectionDto
			                    {
			                		CommonName = "North",
			                		Description = "North",
			                		Identity = new Guid("027377FE-46E8-E011-B36B-005056C00008"),
			                		Name = "North"
			                	};

			var location = new LocationDto
			               	{CommonName = "Home", Description = "Your Home", Directions = new List<DirectionDto> {direction}};

			var dependency = new DependencyDto
			{
				DependencyType = DependencyType.DirectionIsAvailable,
				ElementId = direction.Identity
			};


			using (mocks.Record())
			{
				SetupResult.For(gameDataManager.CurrentLocation).Return(location);
			}

			using (mocks.Playback())
			{
				var actual = dependencyTypeProcessor.ProcessDependency(dependency);

				Assert.IsTrue(actual);
			}

		}
	}
}
