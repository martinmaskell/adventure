using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests.CommandParameterParserTests
{
	[TestFixture]
	public class AssignParameterToParameterListTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Parameter is null or empty")]
		public void AssignParameterToParameterList_NullParameter_ThrowArgumentException()
		{
			var commandParameterParser = new CommandParameterParser();
			commandParameterParser.AssignParameterToParameterList(null, null, null, null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "InvalidParameters is null")]
		public void AssignParameterToParameterList_NullInvalidParameterList_ThrowNullReferenceException()
		{
			var adventureElements = new List<IAdventureElement> { new ItemDto { CommonName = "gold key", Description = "A small gold key", Identity = Guid.NewGuid(), Name = "A Gold Key" }};
			var commandParameterParser = new CommandParameterParser(adventureElements);
			commandParameterParser.AssignParameterToParameterList("{gold key}", null, new List<IAdventureElement>(), new Dictionary<string, List<IAdventureElement>>());
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "ValidParameters is null")]
		public void AssignParameterToParameterList_NullValidParameterList_ThrowNullReferenceException()
		{
			var adventureElements = new List<IAdventureElement> { new ItemDto { CommonName = "gold key", Description = "A small gold key", Identity = Guid.NewGuid(), Name = "A Gold Key" } };
			var commandParameterParser = new CommandParameterParser(adventureElements);
			commandParameterParser.AssignParameterToParameterList("{gold key}", new List<string>(), null, new Dictionary<string, List<IAdventureElement>>());
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "DuplicateParameters is null")]
		public void AssignParameterToParameterList_NullDuplicateParameterList_ThrowNullReferenceException()
		{
			var adventureElements = new List<IAdventureElement> { new ItemDto { CommonName = "gold key", Description = "A small gold key", Identity = Guid.NewGuid(), Name = "A Gold Key" } };
			var commandParameterParser = new CommandParameterParser(adventureElements);
			commandParameterParser.AssignParameterToParameterList("{gold key}", new List<string>(), new List<IAdventureElement>(), null);
		}

		[Test]
		public void AssignParameterToParameterList_ValidParameter_ReturnAdventureElementAddedToValidParameterList()
		{
			// Arrange
			var element = new ItemDto
			              	{
			              		CommonName = "gold key",
			              		Description = "A small gold key",
			              		Identity = Guid.NewGuid(),
			              		Name = "A Gold Key"
			              	};
			var adventureElements = new List<IAdventureElement> { element };
			var commandParameterParser = new CommandParameterParser(adventureElements);
			var validParameters = new List<IAdventureElement>();

			// Act
			commandParameterParser.AssignParameterToParameterList("{gold key}", new List<string>(), validParameters, new Dictionary<string, List<IAdventureElement>>());

			// Assert
			Assert.AreEqual(1, validParameters.Count);
		}

		[Test]
		public void AssignParameterToParameterList_InvalidParameter_ReturnAdventureElementAddedToInvalidParameterList()
		{
			// Arrange
			var element = new ItemDto
			{
				CommonName = "gold key",
				Description = "A small gold key",
				Identity = Guid.NewGuid(),
				Name = "A Gold Key"
			};
			var adventureElements = new List<IAdventureElement> { element };
			var commandParameterParser = new CommandParameterParser(adventureElements);
			var invalidParameters = new List<string>();

			// Act
			commandParameterParser.AssignParameterToParameterList("banana", invalidParameters, new List<IAdventureElement>(), new Dictionary<string, List<IAdventureElement>>());

			// Assert
			Assert.AreEqual(1, invalidParameters.Count);
		}

		[Test]
		public void AssignParameterToParameterList_DuplicateParameter_ReturnAdventureElementAddedToDuplicateParameterList()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>
			                        	{
			                        		new ItemDto
			                        			{
			                        				CommonName = "key",
			                        				Description = "A small gold key",
			                        				Identity = Guid.NewGuid(),
			                        				Name = "A Gold Key"
			                        			},

			                        		new ItemDto
			                        			{
			                        				CommonName = "key",
			                        				Description = "A rusty brass key",
			                        				Identity = Guid.NewGuid(),
			                        				Name = "A Brass Key"
			                        			}
			                        	};
			var commandParameterParser = new CommandParameterParser(adventureElements);
			var duplicateParameters = new Dictionary<string, List<IAdventureElement>>();

			// Act
			commandParameterParser.AssignParameterToParameterList("{key}", new List<string>(), new List<IAdventureElement>(), duplicateParameters);

			// Assert
			Assert.AreEqual(1, duplicateParameters.Count);
		}


	}
}
