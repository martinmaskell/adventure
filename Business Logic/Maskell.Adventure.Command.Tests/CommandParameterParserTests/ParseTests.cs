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
	public class ParseTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Parse_NullInput_ThrowArgumentException()
		{
			// Arrange
			var commandParameterParser = new CommandParameterParser();

			// Act
			commandParameterParser.Parse(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "AdventureElements is null")]
		public void Parse_ValidInputNullAdventureElements_ThrowNullReferenceException()
		{
			// Arrange
			var commandParameterParser = new CommandParameterParser();

			// Act
			commandParameterParser.Parse("gold key");
		}

		[Test]
		public void Parse_ValidInputEmptyAdventureElements_ReturnFailedResponseState()
		{
			// Arrange
			var commandParameterParser = new CommandParameterParser(new List<IAdventureElement>());

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("gold key");

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.Fail, commandParameterParserResponse.State);
		}

		[Test]
		public void Parse_ValidInputEmptyAdventureElements_ReturnCorrectInvalidParameters()
		{
			// Arrange
			var commandParameterParser = new CommandParameterParser(new List<IAdventureElement>());

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("gold key");

			// Assert
			Assert.AreEqual(new List<string> { "gold", "key" }, commandParameterParserResponse.InvalidParameters);
		}

		[Test]
		public void Parse_ValidInputNonEmptyAdventureElements_ReturnOneValidParameter()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>
			                        	{
			                        		new ItemDto
			                        			{
			                        				Description = "A Small Brass Key",
			                        				Identity = Guid.NewGuid(),
			                        				Name = "Brass Key",
			                        				CommonName = "brass key"
			                        			}
			                        	};
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("gold key brass key");

			// Assert
			Assert.AreEqual(adventureElements, commandParameterParserResponse.ValidParameters);
		}

		[Test]
		public void Parse_ValidInputNonEmptyAdventureElements_ReturnTwoInvalidParameters()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>() { new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "brass key" } };
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("gold key brass key");

			// Assert
			Assert.AreEqual(new List<string> { "gold", "key" }, commandParameterParserResponse.InvalidParameters);
		}

		[Test]
		public void Parse_ValidInputNonEmptyAdventureElements_ReturnCorrectInvalidParameters()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>() { new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "brass key" } };
			var commandParameterParser = new CommandParameterParser(new List<IAdventureElement>());

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("gold key");

			// Assert
			Assert.AreEqual(new List<string> { "gold", "key" }, commandParameterParserResponse.InvalidParameters);
		}

		[Test]
		public void Parse_ValidInputDuplicateAdventureElements_ReturnFailedResponseState()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>() { new ItemDto()
			                                                        	{
			                                                        		Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key"
			                                                        	}, new ItemDto()
			                                                        	{
			                                                        		Description = "A Large Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "key"
			                                                        	}
			};
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("key");

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.FailDuplicate, commandParameterParserResponse.State);
		}

		[Test]
		public void Parse_ValidInputDuplicateAdventureElements_ReturnCorrectDuplicateParameters()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>() { new ItemDto()
			                                                        	{
			                                                        		Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key"
			                                                        	}, new ItemDto()
			                                                        	{
			                                                        		Description = "A Large Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "key"
			                                                        	}
			};

			// Act
			var commandParameterParser = new CommandParameterParser(adventureElements);
			var commandParameterParserResponse = commandParameterParser.Parse("key");

			// Assert
			Assert.AreEqual(2, commandParameterParserResponse.DuplicateParameters["key"].Count);
		}

		[Test]
		public void Parse_ValidInput_ReturnSuccessResponseState()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement>
			                        	{
			                        		new ItemDto
			                        			{
			                        				Description = "A Small Brass Key",
			                        				Identity = new Guid(),
			                        				Name = "Brass Key",
			                        				CommonName = "brass key"
			                        			},
			                        		new ItemDto
			                        			{
			                        				Description = "A Large Gold Key",
			                        				Identity = new Guid(),
			                        				Name = "Gold Key",
			                        				CommonName = "gold key"
			                        			}
			                        	};
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("brass key gold key");

			// Assert
			Assert.AreEqual(CommandParameterParserResponseState.Success, commandParameterParserResponse.State);
		}

		[Test]
		public void Parse_ValidInput_ReturnValidParameters()
		{
			// Arrange
			var adventureElements = new List<IAdventureElement> { new ItemDto { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "brass key" }, new ItemDto() { Description = "A Large Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "gold key" } };
			var commandParameterParser = new CommandParameterParser(adventureElements);

			// Act
			var commandParameterParserResponse = commandParameterParser.Parse("brass key gold key");

			// Assert
			Assert.AreEqual(adventureElements, commandParameterParserResponse.ValidParameters);
		}


	}
}
