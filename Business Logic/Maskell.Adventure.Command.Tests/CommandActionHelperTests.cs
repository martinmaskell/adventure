using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Maskell.Adventure.Command.Helpers;
using Maskell.Adventure.DataManager.Interface;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandActionHelperTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetParameterType_NullAdventureElement_ThrowArgumentNullException()
		{
			CommandActionHelper.GetParameterType(null);
		}

		[Test]
		public void GetParameterType_DirectionAdventureElement_ReturnCorrectEnumType()
		{
			var result = CommandActionHelper.GetParameterType(new DirectionDto());
			Assert.AreEqual(CommandParameterType.Direction, result);
		}

		[Test]
		public void GetParameterType_LocationAdventureElement_ReturnCorrectEnumType()
		{
			var result = CommandActionHelper.GetParameterType(new LocationDto());
			Assert.AreEqual(CommandParameterType.Location, result);
		}

		[Test]
		public void GetParameterType_ItemAdventureElement_ReturnCorrectEnumType()
		{
			var result = CommandActionHelper.GetParameterType(new ItemDto());
			
			Assert.AreEqual(CommandParameterType.Item, result);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetParameterTypes_NullInput_ThrowArgumentNullException()
		{
			CommandActionHelper.GetParameterTypes(null);
		}

		[Test]
		public void GetParameterTypes_LocationInput_ReturnLocationType()
		{
			var expected = new List<CommandParameterType> {CommandParameterType.Location};

			var actual = CommandActionHelper.GetParameterTypes(new List<IAdventureElement>() {new LocationDto()});

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetParameterTypes_LocationDirectionItemInput_ReturnMatchingCommandParameterTypes()
		{
			var expected = new List<CommandParameterType> { CommandParameterType.Location, CommandParameterType.Direction, CommandParameterType.Item };

			var actual = CommandActionHelper.GetParameterTypes(new List<IAdventureElement> { new LocationDto(), new DirectionDto(), new ItemDto() });

			Assert.AreEqual(expected, actual);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsValidCommand_NullParameters_ThrowArgumentNullException()
		{
			var helper = new CommandActionHelper(null);

			helper.IsValidCommand(AdventureCommandType.Go, null);

		}

		[Test]
		public void IsValidCommand_GoDirectionInput_ReturnTrue()
		{
			var mocks = new MockRepository();
			var reader = mocks.Stub<ICommandDataReader>();

			using (mocks.Record())
			{
				SetupResult.For(reader.GetValidCommandSyntax()).IgnoreArguments().Return(new List<CommandDto>
				                                                                         	{
				                                                                         		new CommandDto
				                                                                         			{
				                                                                         				CommandID = 1,
				                                                                         				CommandType = AdventureCommandType.Go,
				                                                                         				Parameters =
				                                                                         					new[]
				                                                                         						{CommandParameterType.Direction}
				                                                                         			}
				                                                                         	});
			}

			var helper = new CommandActionHelper(reader);

			using (mocks.Playback())
			{
				var actual = helper.IsValidCommand(AdventureCommandType.Go, new List<IAdventureElement> {new DirectionDto()});
				Assert.IsTrue(actual);
			}

			

		}

	}
}
