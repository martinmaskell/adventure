using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.Module.Interfaces;
using Maskell.Adventure.Module.Modules;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Module.Tests
{
	[TestFixture]
	public class ModuleFactoryTests
	{
		[Test]
		[ExpectedException(typeof(NullReferenceException))]
		public void GetModule_NullHelper_ThrowNullReferenceException()
		{
			// Arrange
			var moduleFactory = new ModuleFactory(null);
			
			// Act
			moduleFactory.GetModule(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetModule_NullModuleRequest_ThrowArgumentNullException()
		{
			// Arrange
			var mocks = new MockRepository();
			var moduleFactoryHelper = mocks.Stub<IModuleFactoryHelper>();
			var moduleFactory = new ModuleFactory(moduleFactoryHelper);

			// Act
			moduleFactory.GetModule(null);
		}

		[Test]
		public void GetModule_ValidLocationCommand_ReturnLocationModule()
		{
			// Arrange
			var mocks = new MockRepository();
			var moduleFactoryHelper = mocks.Stub<IModuleFactoryHelper>();
			const string typeName = "Maskell.Adventure.Module.Modules.LocationModule, Maskell.Adventure.Module";

			using (mocks.Record())
			{
				SetupResult.For(moduleFactoryHelper.GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType.Use, null)).
					IgnoreArguments().Return(typeName);
			}

			var moduleFactory = new ModuleFactory(moduleFactoryHelper);

			using (mocks.Playback())
			{
				// Act
				var locationModule = moduleFactory.GetModule(new ModuleRequest
				                        	{
				                        		CommandType = AdventureCommandType.Go,
				                        		Parameters = new List<IAdventureElement> {new LocationDto()}
				                        	});

				// Assert
				Assert.IsInstanceOf<LocationModule>(locationModule);
			}
		}

		[Test]
		public void GetModule_NullTypeName_ReturnNullModule()
		{
			// Arrange
			var mocks = new MockRepository();
			var moduleFactoryHelper = mocks.Stub<IModuleFactoryHelper>();

			using (mocks.Record())
			{
				SetupResult.For(moduleFactoryHelper.GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType.Use, null)).
					IgnoreArguments().Return(null);
			}

			var moduleFactory = new ModuleFactory(moduleFactoryHelper);

			using (mocks.Playback())
			{
				// Act
				var locationModule = moduleFactory.GetModule(new ModuleRequest
				{
					CommandType = AdventureCommandType.Go,
					Parameters = new List<IAdventureElement> { new LocationDto() }
				});

				// Assert
				Assert.IsNull(locationModule);
			}
		}

		[Test]
		public void GetModule_EmptyTypeName_ReturnNullModule()
		{
			// Arrange
			var mocks = new MockRepository();
			var moduleFactoryHelper = mocks.Stub<IModuleFactoryHelper>();
			string typeName = string.Empty;

			using (mocks.Record())
			{
				SetupResult.For(moduleFactoryHelper.GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType.Use, null)).
					IgnoreArguments().Return(typeName);
			}

			var moduleFactory = new ModuleFactory(moduleFactoryHelper);

			using (mocks.Playback())
			{
				// Act
				var locationModule = moduleFactory.GetModule(new ModuleRequest
				{
					CommandType = AdventureCommandType.Go,
					Parameters = new List<IAdventureElement> { new LocationDto() }
				});

				// Assert
				Assert.IsNull(locationModule);
			}
		}

		[Test]
		public void GetModule_UnknownTypeName_ReturnNullModule()
		{
			// Arrange
			var mocks = new MockRepository();
			var moduleFactoryHelper = mocks.Stub<IModuleFactoryHelper>();
			const string typeName = "Banana";

			using (mocks.Record())
			{
				SetupResult.For(moduleFactoryHelper.GetModuleTypeNameByCommandTypeAndParameters(AdventureCommandType.Use, null)).
					IgnoreArguments().Return(typeName);
			}

			var moduleFactory = new ModuleFactory(moduleFactoryHelper);

			using (mocks.Playback())
			{
				// Act
				var locationModule = moduleFactory.GetModule(new ModuleRequest
				{
					CommandType = AdventureCommandType.Go,
					Parameters = new List<IAdventureElement> { new LocationDto() }
				});

				// Assert
				Assert.IsNull(locationModule);
			}
		}

	}
}
