using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Command.Parsers;
using Maskell.Adventure.Command.Responses;
using Maskell.Adventure.DomainEntities;
using NUnit.Framework;

namespace Maskell.Adventure.Command.Tests
{
	[TestFixture]
	public class CommandTypeParserTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "CommandText is null or empty")]
		public void Parse_NullString_ThrowArgumentException()
		{
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			parser.Parse(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "CommandText is null or empty")]
		public void Parse_EmptyString_ThrowArgumentException()
		{
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			parser.Parse(string.Empty);
		}

		[Test]
		public void Parse_InvalidString_ReturnFailedResponse()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			// Act
			var response = parser.Parse("aaa");
			// Assert
			Assert.AreEqual(response.State, CommandResponseState.Fail);
		}

		[Test]
		public void Parse_InvalidString_ReturnUnknownCommandType()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			// Act
			var response = parser.Parse("aaa");
			// Assert
			Assert.AreEqual(response.CommandType, AdventureCommandType.Unknown);
		}

		[Test]
		public void Parse_SingleValidCommandString_ReturnSuccessResponse()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			// Act
			var response = parser.Parse("go");
			// Assert
			Assert.AreEqual(response.State, CommandResponseState.Success);
		}

		[Test]
		public void Parse_SingleValidCommandString_ReturnCorrectCommandType()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			// Act
			var response = parser.Parse("go");
			// Assert
			Assert.AreEqual(response.CommandType, AdventureCommandType.Go);
		}

		[Test]
		public void Parse_SingleValidCommandString_OriginalCommandTextSameAsInput()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			const string input = "go";
			// Act
			var response = parser.Parse(input);
			// Assert
			Assert.AreEqual(response.OriginalCommandText, input);
		}

		[Test]
		public void Parse_SingleValidCommandString_ParsedCommandTextDoesnotContainCommandTypeText()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			const string input = "go";
			// Act
			var response = parser.Parse(input);
			// Assert
			Assert.AreEqual(response.ParsedCommandText, string.Empty);
		}

		[Test]
		public void Parse_SingleValidCommandString_ValidParsedCommandText()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();
			const string input = "go";
			// Act
			var response = parser.Parse(input);
			// Assert
			Assert.AreEqual(response.ParsedCommandText, string.Empty);
		}

		[Test]
		public void Parse_ValidCommandStringWithWords_ParsedCommandTextUpdated()
		{
			// Arrange
			ITextParser<CommandTypeParserResponse> parser = new CommandTypeParser();

			// Act
			var response = parser.Parse("go north");
			// Assert
			Assert.AreEqual(response.ParsedCommandText, "north");
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Input is null or empty")]
		public void ParseFirstWord_NullString_ThrowArgumentException()
		{
			// Arrange
			var parser = new CommandTypeParser();

			// Act
			parser.ParseFirstWord(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Input is null or empty")]
		public void ParseFirstWord_EmptyString_ThrowArgumentException()
		{
			// Arrange
			var parser = new CommandTypeParser();

			// Act
			parser.ParseFirstWord(string.Empty);
		}

		[Test]
		public void ParseFirstWord_ValidStringSingleWord_ReturnValidResult()
		{
			// Arrange
			var parser = new CommandTypeParser();
			const string input = "fish";

			// Act
			var result = parser.ParseFirstWord(input);

			// Assert
			Assert.AreEqual(result, input);
		}

		[Test]
		public void ParseFirstWord_ValidStringMultipleWord_ReturnValidResult()
		{
			// Arrange
			var parser = new CommandTypeParser();

			// Act
			var result = parser.ParseFirstWord("fish cakes");

			// Assert
			Assert.AreEqual(result, "fish");
		}

	}
}
