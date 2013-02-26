using System;
using System.Collections.Generic;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;
using Maskell.Adventure.DomainEntities.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandParserTests
	{
		[SetUp]
		public void Setup()
		{
		
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "CommandParameterParser is null")]
		public void Parse_NullCommandParameterParser_ThrowNullReferenceException()
		{
			var adventureElements = new List<IAdventureElement>();	

			var commandParser = new CommandParser {CommandParameterParser = null, AdventureElements = adventureElements};
			commandParser.Parse(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "AdventureElements is null")]
		public void Parse_NullAdventureElements_ThrowNullReferenceException()
		{
			var mocks = new MockRepository();
			var commandParameterParser = mocks.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mocks.Stub<ITextParser<CommandTypeParserResponse>>();
			var commandNoiseWordParser = mocks.Stub<ITextParser<CommandNoiseWordParserResponse>>();


			var commandParser = new CommandParser
			                    	{
			                    		CommandParameterParser = commandParameterParser,
			                    		AdventureElements = null,
			                    		CommandTypeParser = commandTypeParser,
											CommandNoiseWordParser = commandNoiseWordParser
			                    	};

			commandParser.Parse(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "CommandTypeParser is null")]
		public void Parse_NullCommandTypeParser_ThrowNullReferenceException()
		{
			var mocks = new MockRepository();
			var commandParameterParser = mocks.Stub<ICommandParser<CommandParameterParserResponse>>();
			
			var commandParser = new CommandParser
			                    	{
			                    		CommandParameterParser = commandParameterParser,
			                    		AdventureElements = new List<IAdventureElement>(),
			                    		CommandTypeParser = null
			};

			commandParser.Parse(null);
		}

		[Test]
		[ExpectedException(typeof(NullReferenceException), ExpectedMessage = "CommandNoiseWordParser is null")]
		public void Parse_NullCommandNoiseWordParser_ThrowNullReferenceException()
		{
			var mocks = new MockRepository();
			var commandParameterParser = mocks.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mocks.Stub<ITextParser<CommandTypeParserResponse>>();

			var commandParser = new CommandParser
			{
				CommandParameterParser = commandParameterParser,
				AdventureElements = new List<IAdventureElement> { new ItemDto()},
				CommandTypeParser = commandTypeParser,
				CommandNoiseWordParser = null
			};

			commandParser.Parse(null);
		}

		[Test]
		public void Parse_InvalidCommandType_ReturnFailedResponse()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandParameterParser = mocks.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mocks.Stub<ITextParser<CommandTypeParserResponse>>();
			var commandNoiseWordParser = mocks.Stub<ITextParser<CommandNoiseWordParserResponse>>();
			const string input = "aaa";

			var commandParser = new CommandParser
			{
				CommandParameterParser = commandParameterParser,
				AdventureElements = new List<IAdventureElement> { new ItemDto()},
				CommandTypeParser = commandTypeParser,
				CommandNoiseWordParser = commandNoiseWordParser
			};

			using (mocks.Record())
			{
				SetupResult.For(commandTypeParser.Parse(input)).Return(new CommandTypeParserResponse
				                                                       	{
				                                                       		CommandType = AdventureCommandType.Unknown,
																								OriginalCommandText = input,
																								ParsedCommandText = input,
				                                                       		State = CommandResponseState.Fail
				                                                       	});
			}

			using (mocks.Playback())
			{
				// Act
				var response = commandParser.Parse(input);

				// Assert
				Assert.AreEqual(response.State, CommandResponseState.Fail);
			}


		}

		[Test]
		public void Parse_InvalidCommandType_ReturnInvalidCommandResponseReason()
		{
			// Arrange
			var mocks = new MockRepository();
			var commandParameterParser = mocks.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mocks.Stub<ITextParser<CommandTypeParserResponse>>();
			var commandNoiseWordParser = mocks.Stub<ITextParser<CommandNoiseWordParserResponse>>();
			const string input = "aaa";

			var commandParser = new CommandParser
			{
				CommandParameterParser = commandParameterParser,
				AdventureElements = new List<IAdventureElement> { new ItemDto()},
				CommandTypeParser = commandTypeParser,
				CommandNoiseWordParser = commandNoiseWordParser
			};

			using (mocks.Record())
			{
				SetupResult.For(commandTypeParser.Parse(input)).Return(new CommandTypeParserResponse
				{
					CommandType = AdventureCommandType.Unknown,
					OriginalCommandText = input,
					ParsedCommandText = input,
					State = CommandResponseState.Fail
				});
			}

			using (mocks.Playback())
			{
				// Act
				var response = commandParser.Parse(input);

				// Assert
				Assert.AreEqual(response.ResponseReason, CommandResponseReason.InvalidCommand);
			}
		}

		[Test]
		public void Parse_ValidParameters_ReturnSuccessResponse()
		{
			var mocks = new MockRepository();
			CommandParser commandParser;

			var itemKey = new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key" };
			var adventureElements = new List<IAdventureElement> { itemKey };

			SetupValidCommandParserResponse(mocks, adventureElements, out commandParser);

			using (mocks.Playback())
			{
				// Act
				var commandParserResponse = commandParser.Parse("pickup the key");

				// Assert
				Assert.AreEqual(commandParserResponse.State, CommandResponseState.Success);
			}
		}
	
		[Test]
		public void Parse_ValidParameters_ReturnCorrectValidParameters()
		{
			var mocks = new MockRepository();
			CommandParser commandParser;

			var itemKey = new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key" };
			var adventureElements = new List<IAdventureElement> {itemKey};

			SetupValidCommandParserResponse(mocks, adventureElements, out commandParser);

			using (mocks.Playback())
			{
				// Act
				var commandParserResponse = commandParser.Parse("pickup the key");

				// Assert
				Assert.AreEqual(commandParserResponse.ValidCommandParameters, adventureElements);
			}

		}

		[Test]
		public void Parse_DuplicateParameters_ReturnFailedResponse()
		{
			var mocks = new MockRepository();
			CommandParser commandParser;

			var brassKey = new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key" };
			var goldKey = new ItemDto() { Description = "A Small Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "key" };
			var adventureElements = new List<IAdventureElement> { brassKey, goldKey };

			SetupDuplicateCommandParserResponse(mocks, adventureElements, out commandParser);

			using (mocks.Playback())
			{
				// Act
				var commandParserResponse = commandParser.Parse("pickup the key");

				// Assert
				Assert.AreEqual(commandParserResponse.State, CommandResponseState.Fail);
			}

		}

		[Test]
		public void Parse_DuplicateParameters_ReturnDuplicateResponseReason()
		{
			var mocks = new MockRepository();
			CommandParser commandParser;

			var brassKey = new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key" };
			var goldKey = new ItemDto() { Description = "A Small Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "key" };
			var adventureElements = new List<IAdventureElement> { brassKey, goldKey };

			SetupDuplicateCommandParserResponse(mocks, adventureElements, out commandParser);

			using (mocks.Playback())
			{
				// Act
				var commandParserResponse = commandParser.Parse("pickup the key");

				// Assert
				Assert.AreEqual(commandParserResponse.ResponseReason, CommandResponseReason.DuplicateParameters);
			}
		}

		[Test]
		public void Parse_DuplicateParameters_ReturnCorrectDuplicateParameters()
		{
			var mocks = new MockRepository();
			CommandParser commandParser;

			var brassKey = new ItemDto() { Description = "A Small Brass Key", Identity = new Guid(), Name = "Brass Key", CommonName = "key" };
			var goldKey = new ItemDto() { Description = "A Small Gold Key", Identity = new Guid(), Name = "Gold Key", CommonName = "key" };
			var adventureElements = new List<IAdventureElement> { brassKey, goldKey };

			SetupDuplicateCommandParserResponse(mocks, adventureElements, out commandParser);

			using (mocks.Playback())
			{
				// Act
				var commandParserResponse = commandParser.Parse("pickup the key");

				// Assert
				Assert.AreEqual(commandParserResponse.DuplicateParameters, new Dictionary<string, List<IAdventureElement>> {{"key", adventureElements}});
			}
		}

		#region Helper Methods

		private static void SetupValidCommandParserResponse(MockRepository mockRepository, List<IAdventureElement> adventureElements, out CommandParser commandParser)
		{
			var commandParameterParser = mockRepository.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mockRepository.Stub<ITextParser<CommandTypeParserResponse>>();
			var commandNoiseWordParser = mockRepository.Stub<ITextParser<CommandNoiseWordParserResponse>>();

			commandParser = new CommandParser
			{
				CommandParameterParser = commandParameterParser,
				AdventureElements = new List<IAdventureElement>(),
				CommandTypeParser = commandTypeParser,
				CommandNoiseWordParser = commandNoiseWordParser
			};

			commandParser.AdventureElements = adventureElements;

			using (mockRepository.Record())
			{
				SetupResult.For(commandTypeParser.Parse("pickup the key")).Return(new CommandTypeParserResponse
				{
					CommandType = AdventureCommandType.Pickup,
					OriginalCommandText = "pickup the key",
					ParsedCommandText = "the key",
					State = CommandResponseState.Success
				});

				SetupResult.For(commandNoiseWordParser.Parse("the key")).Return(new CommandNoiseWordParserResponse
				{
					OriginalCommandText = "the key",
					ParsedCommandText = "key",
					State = CommandResponseState.Success
				});

				SetupResult.For(commandParameterParser.Parse("key")).Return(new CommandParameterParserResponse
				{
					ValidParameters = adventureElements,
					State = CommandParameterParserResponseState.Success
				});

			}

		}

		private static void SetupDuplicateCommandParserResponse(MockRepository mockRepository, List<IAdventureElement> adventureElements, out CommandParser commandParser)
		{
			var commandParameterParser = mockRepository.Stub<ICommandParser<CommandParameterParserResponse>>();
			var commandTypeParser = mockRepository.Stub<ITextParser<CommandTypeParserResponse>>();
			var commandNoiseWordParser = mockRepository.Stub<ITextParser<CommandNoiseWordParserResponse>>();

			commandParser = new CommandParser
			{
				CommandParameterParser = commandParameterParser,
				AdventureElements = new List<IAdventureElement>(),
				CommandTypeParser = commandTypeParser,
				CommandNoiseWordParser = commandNoiseWordParser
			};

			commandParser.AdventureElements = adventureElements;

			using (mockRepository.Record())
			{
				SetupResult.For(commandTypeParser.Parse("pickup the key")).Return(new CommandTypeParserResponse
				{
					CommandType = AdventureCommandType.Pickup,
					OriginalCommandText = "pickup the key",
					ParsedCommandText = "the key",
					State = CommandResponseState.Success
				});

				SetupResult.For(commandNoiseWordParser.Parse("the key")).Return(new CommandNoiseWordParserResponse
				{
					OriginalCommandText = "the key",
					ParsedCommandText = "key",
					State = CommandResponseState.Success
				});

				SetupResult.For(commandParameterParser.Parse("key")).Return(new CommandParameterParserResponse
				{
					DuplicateParameters = new Dictionary<string, List<IAdventureElement>> {{"key", adventureElements}},
					State = CommandParameterParserResponseState.FailDuplicate
				});

			}

		}

		#endregion

	}
}
